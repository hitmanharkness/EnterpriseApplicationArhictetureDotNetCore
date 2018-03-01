using BI.Enterprise.ViewModels.Template;
using BI.WebApi.Base.SwashbuckleExtensions.Interfaces;
using System.Collections.Generic;

namespace BI.WebApi.Template.Models
{
	/// <summary>
	///
	/// </summary>
	public class GetTemplateSampleProvider : ISampleDataProvider
	{
		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public object ProvideSample()
		{
			return new TemplateInfo { Id = 1 };
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public IList<object> ProvideSamples()
		{
			throw new System.NotImplementedException();
		}
	}
}