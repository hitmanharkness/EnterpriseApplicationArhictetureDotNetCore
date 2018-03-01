using BI.Enterprise.Dto.Template;

namespace BI.ServiceBus.Core.Template.Contract
{
	public interface ITemplateCore
	{
		DtoTemplateInfo GetTemplateInfo(int id);

		int SaveTemplateInfo(DtoTemplateInfo dto);
	}
}