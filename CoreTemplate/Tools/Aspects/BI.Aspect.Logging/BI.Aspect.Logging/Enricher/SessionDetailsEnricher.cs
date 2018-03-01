using Serilog.Core;
using Serilog.Events;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace BI.Aspect.Logging.Enricher
{
	/// <inheritdoc />
	/// <summary>
	/// Adds session information variables that will be available for logging purposes.
	/// </summary>
	public class SessionDetailsEnricher : ILogEventEnricher
	{
		private const string TaEntityKey = "TaEntityId",
			EntityType = "EntityType",
			TaClientKey = "client_id",
			EntityIdPropertyKey = "EntityId";

		/// <summary>
		///
		/// </summary>
		/// <param name="logEvent"></param>
		/// <param name="propertyFactory"></param>
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			var principal = Thread.CurrentPrincipal as ClaimsPrincipal;

			var i = principal?.Identities.First();
			var entityId = "N/A";
			var entityType = "N/A";
			string entityValues;
			if (string.IsNullOrWhiteSpace(i?.Label))
			{
				if (principal?.HasClaim(x => x.Type == TaEntityKey) ?? false)
					entityId = principal.FindFirst(x => x.Type == TaEntityKey).Value;
				else if (principal?.HasClaim(x => x.Type == TaClientKey) ?? false)
					entityId = principal.FindFirst(x => x.Type == TaClientKey).Value;
				if (principal?.HasClaim(x => x.Type == EntityType) ?? false)
					entityType = principal.FindFirst(x => x.Type == EntityType).Value;
				entityValues = $"{entityId}:{entityType}";
				if (i != null)
					i.Label = entityValues;
			}
			else
				entityValues = i.Label;

			var values = entityValues.Split(':');
			entityId = values[0];
			entityType = values[1];

			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(EntityIdPropertyKey, entityId));
			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(EntityType, entityType));
		}
	}
}