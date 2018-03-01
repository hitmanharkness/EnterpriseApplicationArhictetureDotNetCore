using BI.Aspect.Config;
using BI.WebApi.Base.SwashbuckleExtensions;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using Serilog;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(BI.WebApi.Template.Startup))]

namespace BI.WebApi.Template
{
	/// <summary>
	///
	/// </summary>
	public class Startup
	{
		#region Public Methods

		/// <summary>
		///
		/// </summary>
		/// <param name="app"></param>
		public void Configuration(IAppBuilder app)
		{
			var appAssembly = typeof(Startup).Assembly;
			Aspect.Logging.LoggingHandler.Initialize(appAssembly);
			Log.Information($"Starting {AssemblyName}...");

			// Order is important here. The security wiring must happen first.
			ConfigureAuthentication(app);

			// Create web configuration and register with WebAPI.
			HttpConfiguration config = new HttpConfiguration();
			WebApiConfig.Register(config);

			// Configure documentation.
			ConfigureDocumentation(config);

			// Start the API.
			app.UseWebApi(config);
			Log.Information($"{AssemblyName} started.");
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Configure authentication.
		/// </summary>
		/// <param name="app">The app being started under OWIN hosting.</param>
		private void ConfigureAuthentication(IAppBuilder app)
		{
			JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
			app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
			{
				Authority = ConfigSettingsStsInfo.Instance.Authority,
				RequiredScopes = ConfigSettingsStsInfo.Instance.RequiredScopesArray
			});
		}

		/// <summary>
		///  Configure Swagger/Swashbuckle documentation and exploration capabilities.
		/// </summary>
		/// <param name="config">The <see cref="HttpConfiguration"/> instance for the app.</param>
		private void ConfigureDocumentation(HttpConfiguration config)
		{
			config
				.EnableSwagger(c =>
				{
					// Configure.
					c
						.SingleApiVersion("1_0", "BI Inc - Template REST API")
						.Description("REST API for Template domain.")
						.TermsOfService("Private use only.")
						.Contact(cc => cc
							.Name("BI Labs.")
							.Url("https://bi.com/")
							.Email("art.newsome@bi.com")
						);

					c.UseFullTypeNameInSchemaIds();

					// Include developer comments from controller classes.
					if (File.Exists(this.XmlDocumentationPathForControllers))
						c.IncludeXmlComments(this.XmlDocumentationPathForControllers);
					else
						Log.Information($"{AssemblyName} cannot find XML documentation file for Swashbuckle inclusion.");

					// Hookup the custom sample payload generation capability.
					c.OperationFilter<PayloadSamplesOperationFilter>();

					// Handle IIS-hosted OWIN path determination.
					c.RootUrl(req =>
						req.RequestUri.GetLeftPart(UriPartial.Authority) +
						req.GetRequestContext().VirtualPathRoot.TrimEnd('/'));
				})
				.EnableSwaggerUi(c =>
				{
					// Inject JavaScript that builds the BI bearer token header from the value pasted into the api-key input.
					var assembly = typeof(Startup).Assembly;
					c.InjectJavaScript(assembly, $"{AssemblyName}.SwaggerExtensions.auth-header.js");

					// Disable the call to the swagger.io external meta-data validator. The meta-data can be validated at build
					// time, and especially since this is not a widely publicized API, the need to prove validity on-line is low.
					c.DisableValidator();
				});
		}

		#endregion

		#region Private Properties

		private string AssemblyName => typeof(Startup).Assembly.GetName().Name;

		/// <summary>
		/// Returns the path where the XML documentation for controllers should be found.
		/// </summary>
		/// <remarks>Note, this depends on the XML documentation actually being created as part of the build process, i.e.
		/// configured to be built in the csproj file.</remarks>
		private string XmlDocumentationPathForControllers
		{
			get
			{
				// Construct the path where the XML documentation should be found. Note, this depends on the XML documentation
				// actually being created as part of the build process, i.e. configured to be built in the csproj file.
				var baseDirectory = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
				var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
				return Path.Combine(baseDirectory, commentsFileName);
			}
		}

		#endregion
	}
}