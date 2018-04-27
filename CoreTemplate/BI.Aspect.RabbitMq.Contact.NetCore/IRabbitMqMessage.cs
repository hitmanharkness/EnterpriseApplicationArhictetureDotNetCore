namespace BI.Aspect.RabbitMq.Contract
{
	/// <summary>
	/// Represents the contract that should used to interact with RabbitMQ consumers.
	/// </summary>
	public interface IRabbitMqMessage
	{
		/// <summary>
		/// Enqueues a message an waits for a response from the consumer.
		/// </summary>
		/// <typeparam name="T">The type of the response that the consumer should return. This is based on contracts.</typeparam>
		/// <param name="payload">The payload that will be delivered to the consumer. This is based on contracts.</param>
		/// <param name="appName">The application name that should be used to load the RabbitMQ configurations.</param>
		/// <param name="replyTo">A unique name that should be used as a temporary response queue. If left null a GUID will be assigned.</param>
		/// <returns>A QueueMessageResponse object that contains the information returned by the consumer.</returns>
		QueueMessageResponse<T> EnqueueAndWaitResponse<T>(QueueMessageRequest payload, string appName, string replyTo = null);

		/// <summary>
		/// Enqueues a message for a consumer to be processed.
		/// </summary>
		/// <param name="payload">The payload that will be delivered to the consumer. This is based on contracts.</param>
		/// <param name="appName">The application name that will be used to load the RabbitNQ configurations.</param>
		void EnqueueMessage(QueueMessageRequest payload, string appName);
	}
}