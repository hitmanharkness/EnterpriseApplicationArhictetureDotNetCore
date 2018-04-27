namespace BI.Aspect.RabbitMq.Contract
{
	/// <inheritdoc />
	/// <summary>
	/// Represents a request to be process by a particular consumer.
	/// </summary>
	public class QueueMessageRequest : QueueMessageRequestBase
	{
		/// <summary>
		/// The payload attached this request.
		/// </summary>
		public object Payload { get; set; }
	}

	/// <inheritdoc />
	/// <summary>
	/// Represents a request to be process by a particular consumer.
	/// </summary>
	public class QueueMessageRequest<T> : QueueMessageRequestBase
	{
		/// <summary>
		/// The payload attached this request.
		/// </summary>
		public T Payload { get; set; }
	}
}