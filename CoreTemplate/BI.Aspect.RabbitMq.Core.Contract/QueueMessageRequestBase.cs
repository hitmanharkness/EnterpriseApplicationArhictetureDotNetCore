namespace BI.Aspect.RabbitMq.Contract
{
	/// <summary>
	/// Represents the minimum information that a Rabbit MQ message should contain.
	/// </summary>
	public class QueueMessageRequestBase
	{
		/// <summary>
		/// The id of the action to execute
		/// </summary>
		public int ActionId { get; set; }

		/// <summary>
		/// Gets or sets an string that represents the caller session information.
		/// </summary>
		public string SessionInfo { get; set; }
	}
}