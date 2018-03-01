using BI.Repository.Template.Contract;
using BI.Repository.Template.Models;
using BI.ServiceBus.Core.Template;
using BI.ServiceBus.Core.Template.Contract;
using BI.ServiceBus.Manager.Template;
using BI.ServiceBus.Manager.Template.Contract;
using BI.ServiceBus.Repository.Template;
using BI.ServiceBus.Repository.Template.Contract;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;

namespace BI.WebApi.Template
{
	/// <summary>
	/// Registers dependencies via SimpleInjector for WebAPI app composition root.
	/// </summary>
	public static class DependencyRegistrar
	{
		/// <summary>
		/// Register dependencies via SimpleInjector for WebAPI composition root.
		/// </summary>
		/// <param name="config">The <see cref="HttpConfiguration"/> for the WebAPI app.</param>
		public static void RegisterDependencies(HttpConfiguration config)
		{
			config = config ?? throw new ArgumentNullException(nameof(config));
			// Create dependency injection container.
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

			// Set up and verify dependency bindings.
			container.RegisterWebApiControllers(config);

			RegisterDependenciesClient(container);

			container.Verify();

			// Set the global dependency resolver.
			config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
		}

		#region Private Methods

		private static void RegisterDependenciesClient(Container container)
		{
			container.Register<ITemplateManager, TemplateManager>(Lifestyle.Scoped);
			container.Register<ITemplateCore, TemplateCore>(Lifestyle.Scoped);
			container.Register<ITemplateRepositoryManager, TemplateRepositoryManager>(Lifestyle.Scoped);
			container.Register<ITemplateContext, TemplateContext>(Lifestyle.Scoped);
		}

		#endregion Methods
	}
}