using BI.Enterprise.ViewModels.Template.Contract;

namespace BI.ServiceBus.Manager.Template.Contract
{
	public interface ITemplateManager
	{
		T GetTemplateInfo<T>(int id)
			where T : class, ITemplateInfo, new();

		int SaveTemplateInfo(ITemplateInfo Template);
	}
}