using BI.Enterprise.Common.Exceptions;
using BI.Enterprise.Dto.Template;
using BI.ServiceBus.Core.Template.Action;
using BI.ServiceBus.Core.Template.Contract;
using BI.ServiceBus.Repository.Template.Contract;
using Serilog;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BI.ServiceBus.Core.Template
{
	public class TemplateCore : ITemplateCore
	{
		#region Private Variables
		private readonly ITemplateRepositoryManager _repository;
		#endregion

		#region Constructor

		public TemplateCore(ITemplateRepositoryManager repository) =>
			this._repository = repository;

		#endregion

		#region ITemplateCore Implementation

		public DtoTemplateInfo GetTemplateInfo(int id)
		{
			var mName = GetCallerMethodName();
			Log.Verbose("{MethodName} - Core - Id {Id} - Starting", mName, id);
			try
			{
				// TODO: Instantiate all the required actions and execute each one individually. Check the response of each action to
				// decide if the next action should be executed. If the process needs to be terminated due to an invalid action, your should
				// throw a validation exception with the information related to the error. Is easier for unit testing if you return the first
				// error instead of collecting all the errors and return all of them at once. Also is easier for the exception handlers of the API
				// to manage one error at a time specially if a translation is required for the response.
				var action = new GetTemplateInfoAction(this._repository, id);
				action.Execute();
				if (action.WorkValidationContext.IsValid)
					return action.Response;
				var error = action.WorkValidationContext.FailedResults.First();
				throw new ValidationException(error.ErrorCode, error.Message);
			}
			catch (ValidationException)
			{
				Log.Warning("{MethodName} - Core - Validation exception detected.", mName);
				throw;
			}
			catch
			{
				Log.Error("{MethodName} - Core - Exception detected.", mName);
				throw;
			}
			finally
			{
				Log.Verbose("{MethodName} - Core - Id {Id} - Completed", mName, id);
			}
		}

		public int SaveTemplateInfo(DtoTemplateInfo dto)
		{
			var mName = GetCallerMethodName();
			Log.Verbose("{MethodName} - Core - Starting", mName);
			try
			{
				// TODO: Instantiate all the required actions and execute each one individually. Check the response of each action to
				// decide if the next action should be executed. If the process needs to be terminated due to an invalid action, your should
				// throw a ValidationException with the information related to the error. Is easier for unit testing if you return the first
				// error instead of collecting all the errors and return all of them at once. Also is easier for the exception handlers of the API
				// to manage one error at a time specially if a translation is required for the response.
				var action = new SaveTemplateInfoAction(this._repository, dto);
				action.Execute();
				if (action.WorkValidationContext.IsValid)
					return action.Response;
				var error = action.WorkValidationContext.FailedResults.First();
				throw new ValidationException(error.ErrorCode, error.Message);
			}
			catch (ValidationException)
			{
				Log.Warning("{MethodName} - Core - Validation exception detected.", mName);
				throw;
			}
			catch
			{
				Log.Error("{MethodName} - Core - Exception detected.", mName);
				throw;
			}
			finally
			{
				Log.Verbose("{MethodName} - Core - Completed", mName);
			}
		}

		#endregion

		#region Private Methods

		private static string GetCallerMethodName([CallerMemberName]string callerName = "") => callerName;

		#endregion
	}
}