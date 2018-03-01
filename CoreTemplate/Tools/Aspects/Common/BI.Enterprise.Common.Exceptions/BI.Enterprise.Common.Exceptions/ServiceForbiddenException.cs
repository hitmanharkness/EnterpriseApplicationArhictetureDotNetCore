using BI.Enterprise.Common.Exceptions.Interfaces;
using System;

namespace BI.Enterprise.Common.Exceptions
{
	public class ServiceForbiddenException : Exception, ICodeMessageException
	{
		public ServiceForbiddenException()
			: this(998, "You don't have permission to execute this service.")
		{ }

		public ServiceForbiddenException(string message)
			: this(0, message)
		{ }

		public ServiceForbiddenException(int code, string message)
			: base(message) =>
			this.Code = code;

		public int Code { get; }
	}
}