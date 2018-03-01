namespace BI.Enterprise.Common.Exceptions.Interfaces
{
	public interface ICodeMessageException
	{
		int Code { get; }

		string Message { get; }
	}
}