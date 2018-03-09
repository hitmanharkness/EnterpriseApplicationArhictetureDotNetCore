using System;

namespace BI.WebApi.Base.SwashbuckleExtensions
{
	public class SwaggerPayloadSampleAttribute : Attribute
	{
		public SwaggerPayloadSampleAttribute(Type responseType, Type sampleType)
		{
			ResponseType = responseType;
			SampleType = sampleType;
		}

		public Type ResponseType { get; private set; }
		public Type SampleType { get; private set; }
	}
}