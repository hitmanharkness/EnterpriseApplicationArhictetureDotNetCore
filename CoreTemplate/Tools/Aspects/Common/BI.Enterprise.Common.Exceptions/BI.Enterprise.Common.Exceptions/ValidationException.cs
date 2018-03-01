using BI.Enterprise.Common.Exceptions.Interfaces;
using System;

namespace BI.Enterprise.Common.Exceptions
{
	public class ValidationException : Exception, ICodeMessageException
	{
		public ValidationException(string message)
		: this(0, message)
		{ }

		public ValidationException(int code, string message)
			: base(message) =>
			this.Code = code;

		public int Code { get; }
	}
}