namespace BI.Aspect.RabbitMq.Contract
{
	/// <inheritdoc />
	/// <summary>
	/// Represents a response of a consumer after processing a request.
	/// </summary>
	/// <typeparam name="T">The type of the response that the consumer should return. This is based on contracts.</typeparam>
	public class QueueMessageResponse<T> : QueueMessageResponseBase
	{
		/// <summary>
		/// The object returned by the consumer processor, if any.
		/// </summary>
		public new T Response { get; set; }
	}
}