namespace BI.Aspect.RabbitMq.Contract
{
	/// <summary>
	/// Represents the base response for a consumer request.
	/// </summary>
	public class QueueMessageResponseBase
	{
		/// <summary>
		/// When the Success flag is false this indicates the error code.
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// When the Success flag is false, this property will contain the reason of the failure.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// The object returned by the consumer processor, if any.
		/// </summary>
		public object Response { get; set; }

		/// <summary>
		/// true if the consumer completed the process successfully; Otherwise false.
		/// </summary>
		public bool Success { get; set; }
	}
}