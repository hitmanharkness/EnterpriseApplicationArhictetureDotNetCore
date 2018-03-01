using BI.WebApi.Base.MessageHandler;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace BI.WebApi.Template
{
	/// <summary>
	///
	/// </summary>
	public static class WebApiConfig
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="config"></param>
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Register dependencies. This is the Composition Root for DI.
			DependencyRegistrar.RegisterDependencies(config);

			// Web API routes
			config.MapHttpAttributeRoutes();

			// Register pipeline-level language support.
			config.MessageHandlers.Insert(0, new LanguageAwareMessageHandler());
			config.EnableCors();
			config.Routes.MapHttpRoute(
				"DefaultApi",
				"api/{controller}/{id}",
				new { id = RouteParameter.Optional }
			);

			// Get some camels, lots of em.
			config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			config.Formatters.JsonFormatter.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
			config.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
			config.Formatters.XmlFormatter.UseXmlSerializer = true;

			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				NullValueHandling = NullValueHandling.Ignore,
				MissingMemberHandling = MissingMemberHandling.Ignore,
				DefaultValueHandling = DefaultValueHandling.Ignore
			};
		}
	}
}