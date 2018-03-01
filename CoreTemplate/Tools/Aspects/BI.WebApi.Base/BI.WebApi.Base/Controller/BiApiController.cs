using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace BI.WebApi.Base.Controller
{
	public abstract class BiApiController : ApiController
	{
		#region Private Variables
		private ClaimsIdentity _identity;
		#endregion

		#region Public Properties

		protected ClaimsPrincipal CurrentPrincipal => User as ClaimsPrincipal;

		protected ClaimsIdentity Identity => this.GetClaimsIdentity();

		protected int RequestVersion
		{
			get
			{
				var mediaType = this.Request.Headers.Accept.FirstOrDefault(x => x.MediaType.Contains("api.v"))?.MediaType;
				if (string.IsNullOrWhiteSpace(mediaType))
					return 1;
				var idx1 = mediaType.IndexOf(".v", StringComparison.InvariantCultureIgnoreCase) + 2;
				var idx2 = mediaType.IndexOf("+", StringComparison.InvariantCultureIgnoreCase);
				if (idx1 < 0 || idx2 < 0)
					return 1;
				int.TryParse(mediaType.Substring(idx1, idx2 - idx1), out var version);
				return version;
			}
		}

		protected int TotalAccessEntityId
		{
			get
			{
				var taEntityIdClaim = this.CurrentPrincipal.Claims.FirstOrDefault(x => x.Type.Equals("TaEntityId"));
				return int.Parse(taEntityIdClaim?.Value ?? "0");
			}
		}

		protected int TotalAccessEntityTypeId
		{
			get
			{
				var taEntityTypeIdClaim = this.CurrentPrincipal.Claims.FirstOrDefault(x => x.Type.Equals("TaEntityTypeId"));
				return int.Parse(taEntityTypeIdClaim?.Value ?? "0");
			}
		}

		#endregion

		#region Private Methods

		private ClaimsIdentity GetClaimsIdentity()
		{
			if (this._identity != null)
				return this._identity;

			var principal = base.RequestContext.Principal as ClaimsPrincipal;
			this._identity = principal?.Identity as ClaimsIdentity;
			return this._identity;
		}

		#endregion

		#region Public Methods

		protected void AddNotFoundCode(params int[] codes)
		{
			Attributes.ServiceExceptionHandlerAttribute.NotFoundCodes.AddRange(codes);
		}

		#endregion
	}
}