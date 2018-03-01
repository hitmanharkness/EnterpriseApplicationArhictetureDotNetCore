using BI.Enterprise.Common.Exceptions;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BI.WebApi.Base.Attributes
{
	public class ExtendedAuthorizeAttribute : AuthorizeAttribute
	{
		#region Properties
		public string ClaimsToCheck { get; set; }

		private ClaimsPrincipal Principal { get; set; }
		#endregion

		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
		{
			if (actionContext.RequestContext.Principal.Identity.IsAuthenticated)
				throw new ServiceForbiddenException();
			base.HandleUnauthorizedRequest(actionContext);
		}

		protected override bool IsAuthorized(HttpActionContext actionContext)
		{
			if (!base.IsAuthorized(actionContext))
				return false;

			if (string.IsNullOrWhiteSpace(this.ClaimsToCheck))
				return true;

			this.Principal = actionContext.RequestContext.Principal as ClaimsPrincipal;
			if (this.Principal == null)
				return false;

			var claimsToCheck = this.ClaimsToCheck;

			if (this.ClaimsToCheck.Contains("["))
				claimsToCheck = this.ClaimsToCheck.Remove(this.ClaimsToCheck.Length - 1).Substring(1);

			var checkPackages = claimsToCheck.Split("][".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			return checkPackages.Any(this.CheckClaimsPackage);
		}

		#region Private Methods

		private bool CheckClaimsPackage(string package)
		{
			var subPackages = package.Split("&&".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			return subPackages.All(this.CheckOrClaims);
		}

		private bool CheckOrClaims(string claimsToCheck) =>
		(
			from claimSet in claimsToCheck.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
			select claimSet.Split(':')
			into claimSetValues
			let claimType = claimSetValues[0]
			let claims = claimSetValues[1].Split(',')
			where claims.Any(claim => this.Principal.HasClaim(claimType, claim))
			select claimType
		).Any();

		#endregion
	}
}