using System.Collections.Generic;

namespace BI.WebApi.Base.SwashbuckleExtensions.Interfaces
{
	/// <summary>
	/// Provides sample payloads for a non-specific DTO type. Non-generic implemenation to satisfy the wizardry
	/// requirements within Swashbuckle operation filter.
	/// </summary>
	public interface ISampleDataProvider
	{
		#region Methods

		/// <summary>
		/// Provides a single sample payload for a non-specific DTO type.
		/// </summary>
		object ProvideSample();

		/// <summary>
		/// Provides an IList of sample payloads for a non-specific DTO type.
		/// </summary>
		IList<object> ProvideSamples();

		#endregion Methods
	}
}