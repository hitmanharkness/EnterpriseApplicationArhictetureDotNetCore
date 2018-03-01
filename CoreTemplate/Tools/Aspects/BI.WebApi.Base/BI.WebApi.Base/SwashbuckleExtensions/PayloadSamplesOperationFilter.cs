using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;

namespace BI.WebApi.Base.SwashbuckleExtensions
{
	using Interfaces;

	public class PayloadSamplesOperationFilter : IOperationFilter
	{
		public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
		{
			var responseAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerPayloadSampleAttribute>();
			foreach (var attr in responseAttributes)
			{
				var responseType = attr.ResponseType;
				var sampleType = attr.SampleType;
				var schema = schemaRegistry.GetOrRegister(responseType);
				var response = operation.responses
					.FirstOrDefault(x => x.Value?.schema?.type == schema?.type && x.Value?.schema?.@ref == schema?.@ref)
					.Value;
				if (response == null) continue;

				// Determine whether to provide single or multiple samples, based on whether response type implements IList<>.
				if (!sampleType.IsAssignableFrom(typeof(ISampleDataProvider)) &&
					!typeof(ISampleDataProvider).IsAssignableFrom(sampleType)) continue;
				var provider = (ISampleDataProvider)Activator.CreateInstance(sampleType);
				response.examples = FormatAsJson(provider, IsGenericList(responseType));
			}
		}

		private static object ConvertToCamelCase(Dictionary<string, object> examples)
		{
			var jsonString = JsonConvert.SerializeObject(examples,
				new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
			return JsonConvert.DeserializeObject(jsonString);
		}

		private static object FormatAsJson(ISampleDataProvider provider, bool isList)
		{
			var samples = new Dictionary<string, object>
			{
				{
					"application/json", isList ? provider.ProvideSamples() : provider.ProvideSample()
				}
			};

			return ConvertToCamelCase(samples);
		}
		private static bool IsGenericList(Type type)
		{
			if (type == null)
				throw new ArgumentNullException("type");

			// Determine whether to provide single or multiple samples, based on whether response type implements IList<>.
			var interfaceTest = new Predicate<Type>(i =>
			i.IsGenericType &&
			(i.GetGenericTypeDefinition() == typeof(IList<>) ||
			i.GetGenericTypeDefinition() == typeof(IEnumerable<>)));

			return (interfaceTest(type) || type.GetInterfaces().Any(i => interfaceTest(i)));
		}
	}
}