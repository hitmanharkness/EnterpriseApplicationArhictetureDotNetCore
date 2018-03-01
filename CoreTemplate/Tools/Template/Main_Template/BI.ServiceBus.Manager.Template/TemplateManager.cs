using BI.Enterprise.Common.Exceptions;
using BI.Enterprise.Dto.Template;
using BI.Enterprise.ViewModels.Template.Contract;
using BI.ServiceBus.Core.Template.Contract;
using BI.ServiceBus.Manager.Template.Contract;
using Serilog;
using System.Runtime.CompilerServices;

namespace BI.ServiceBus.Manager.Template
{
	public class TemplateManager : ITemplateManager
	{
		#region Private Variables
		private readonly ITemplateCore _core;
		#endregion

		#region Constructor

		public TemplateManager(ITemplateCore core) =>
			this._core = core;

		#endregion

		#region ITemplateManager Implementation

		public T GetTemplateInfo<T>(int id)
			where T : class, ITemplateInfo, new()
		{
			var mName = GetCallerMethodName();
			Log.Verbose("{MethodName} - Manager - Id {Id} - Starting", mName, id);
			try
			{
				// The Manager should coordinates any necessary calls to the core.
				var dto = this._core.GetTemplateInfo(id);
				// TODO: Set the values of the resp variable using the content of the dto variable.
				var resp = new T
				{
					ChangeDate = dto.ChangeDate,
					CreateDate = dto.CreateDate,
					Id = dto.Id,
					Name = dto.Name
				};
				return resp;
			}
			catch (ValidationException)
			{
				Log.Warning("{MethodName} - Manager - Validation exception detected.", mName);
				throw;
			}
			catch
			{
				Log.Error("{MethodName} - Manager - Exception detected.", mName);
				throw;
			}
			finally
			{
				Log.Verbose("{MethodName} - Manager - Id {Id} - Completed", mName, id);
			}
		}

		public int SaveTemplateInfo(ITemplateInfo Template)
		{
			var mName = GetCallerMethodName();
			Log.Verbose("{MethodName} - Manager - Starting", mName);
			try
			{
				// The Manager should coordinates any necessary calls to the core.
				var dto = new DtoTemplateInfo { Name = Template.Name };
				// The validation of the DTO should be part of the Core.
				// This must be done in the validation rules of the action.
				var newId = this._core.SaveTemplateInfo(dto);
				return newId;
			}
			catch (ValidationException)
			{
				Log.Warning("{MethodName} - Manager - Validation exception detected.", mName);
				throw;
			}
			catch
			{
				Log.Error("{MethodName} - Manager - Exception detected.", mName);
				throw;
			}
			finally
			{
				Log.Verbose("{MethodName} - Manager - Completed", mName);
			}
		}

		#endregion

		#region Private Methods

		private static string GetCallerMethodName([CallerMemberName]string callerName = "") => callerName;

		#endregion
	}
}