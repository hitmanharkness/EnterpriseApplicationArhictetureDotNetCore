using BI.Enterprise.Common.Exceptions.Interfaces;
using System;

namespace BI.Enterprise.Common.Exceptions
{
	public class ServiceBadRequestException : Exception, ICodeMessageException
	{
		public ServiceBadRequestException()
			: this(997, "No request body specified.")
		{ }

		public ServiceBadRequestException(int code, string message)
			: base(message) =>
			this.Code = code;

		public int Code { get; }
	}
}