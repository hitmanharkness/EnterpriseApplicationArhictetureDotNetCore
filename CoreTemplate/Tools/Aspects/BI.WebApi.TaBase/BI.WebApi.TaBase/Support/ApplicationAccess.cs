using BI.WebApi.TaBase.Attributes;
using BI.WebApi.TaBase.Models;
using System.Collections.Generic;
using System.Linq;

namespace BI.WebApi.TaBase.Support
{
	/// <summary>
	/// This class contains methods that check the access information of an officer over an application.
	/// </summary>
	public static class ApplicationAccess
	{
		/// <summary>
		/// Gets a collection of service ids and a flag that indicates if the officer can use that specific service.
		/// </summary>
		/// <param name="officerId">The id of the officer.</param>
		/// <param name="appId">The id of the application.</param>
		/// <returns>A collection of Tuples that contains the service id and a flag that indicates
		/// if the officer has access to that service or not</returns>
		public static IEnumerable<ServiceAccess> GetAppServiceAccess(int officerId, long appId)
		{
			using (var taContext = new TaContext())
			{
				if (!taContext.Applications.Any(x => x.ApplicationId == appId))
					return null;

				var serviceIds = taContext.AppServices.Where(x => x.AppId == appId).Select(x => x.AppServiceId);
				var resp = new List<ServiceAccess>();
				foreach (var id in serviceIds)
					resp.Add(new ServiceAccess { ServiceId = id, HasAccess = TaAuthorizeAttribute.CheckService(id, officerId) });
				return resp;
			}
		}
	}

	#region Support Classes

	/// <summary>
	/// Represents the officer access of a specific service
	/// </summary>
	public class ServiceAccess
	{
		/// <summary>
		/// true if the officer has access to the service; Otherwise false.
		/// </summary>
		public bool HasAccess { get; set; }

		/// <summary>
		/// The id of the service that is been validated.
		/// </summary>
		public int ServiceId { get; set; }
	}

	#endregion
}