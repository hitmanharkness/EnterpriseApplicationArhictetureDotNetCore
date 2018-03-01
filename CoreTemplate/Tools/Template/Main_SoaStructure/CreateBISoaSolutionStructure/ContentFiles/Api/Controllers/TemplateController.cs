using BI.Enterprise.Common.Exceptions;
using BI.Enterprise.ViewModels.Template;
using BI.ServiceBus.Manager.Template.Contract;
using BI.WebApi.Base.Attributes;
using BI.WebApi.Base.Controller;
using BI.WebApi.Base.SwashbuckleExtensions;
using BI.WebApi.Template.Models;
using Serilog;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace BI.WebApi.Template.Controllers
{
	/// <summary>
	/// Contains all the API services of the TemplateController.
	/// </summary>
	[Log,
	RoutePrefix("v1"),
	ServiceExceptionHandler]
	public class TemplateController : BiApiController
	{
		#region Private Variables
		private readonly ITemplateManager _manager;
		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the TemplateController.
		/// </summary>
		/// <param name="manager">The manager implementation to be used by the controller.</param>
		public TemplateController(ITemplateManager manager)
		{
			this._manager = manager ?? throw new ArgumentNullException(nameof(manager));
			base.AddNotFoundCode(-404, -405, -406, -407, -408, -409, -410, -411, -412, -413, -414, -415, -416, -417, -418, -419,
				-420, -421, -422, -423, -424, -425, -426, -427, -428, -429, -430);
		}

		#endregion

		#region Services

		/// <summary>
		/// Gets the Template info.
		/// </summary>
		/// <param name="id">The Template id.</param>
		/// <returns>A TemplateInfo object.</returns>
		[// TODO: User attribute ExtendedAuthorize to include security validation.
		HttpGet,
		Route("Template"),
		SwaggerResponse(HttpStatusCode.OK, type: typeof(GetTemplateResponseInfo)),
		SwaggerResponse(HttpStatusCode.Forbidden, type: typeof(ErrorMessage)),
		SwaggerResponse(HttpStatusCode.BadRequest, type: typeof(ErrorMessage)),
		SwaggerResponse(HttpStatusCode.InternalServerError, type: typeof(ErrorMessage)),
		SwaggerPayloadSample(typeof(TemplateInfo), typeof(GetTemplateSampleProvider))]
		public HttpResponseMessage GetTemplate(int id)
		{
			var methodName = GetCallerMethodName();
			Log.Information($"{methodName} - Started");
			try
			{
				if (id <= 0)
					throw new ServiceBadRequestException(0, "Missing id");
				var resp = this._manager.GetTemplateInfo<GetTemplateResponseInfo>(id);
				return base.Request.CreateResponse(HttpStatusCode.OK, resp);
			}
			finally
			{
				Log.Information($"{methodName} - Completed");
			}
		}

		/// <summary>
		/// Creates a new Template.
		/// </summary>
		/// <param name="Template">The Template information to be stored in the database.</param>
		/// <returns>An PostTemplateReponse object with the information of the new Template id.</returns>
		[// TODO: User attribute ExtendedAuthorize to include security validation.
		HttpPost,
		Route("Template"),
		SwaggerResponse(HttpStatusCode.OK, type: typeof(SaveTemplateResponseInfo)),
		SwaggerResponse(HttpStatusCode.Forbidden, type: typeof(ErrorMessage)),
		SwaggerResponse(HttpStatusCode.BadRequest, type: typeof(ErrorMessage)),
		SwaggerResponse(HttpStatusCode.InternalServerError, type: typeof(ErrorMessage))]
		public HttpResponseMessage PostTemplate(TemplateInfo Template)
		{
			var methodName = GetCallerMethodName();
			Log.Information($"{methodName} - Started");
			try
			{
				if (Template == null)
					throw new ServiceBadRequestException();
				var resp = this._manager.SaveTemplateInfo(Template);
				return base.Request.CreateResponse(HttpStatusCode.OK, new SaveTemplateResponseInfo { Id = resp });
			}
			finally
			{
				Log.Information($"{methodName} - Completed");
			}
		}

		#endregion

		#region Private Methods

		private static string GetCallerMethodName([CallerMemberName]string callerName = "") => callerName;

		#endregion
	}
}