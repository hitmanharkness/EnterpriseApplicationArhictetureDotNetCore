using BI.Enterprise.Dto.Template;

namespace BI.ServiceBus.Repository.Template.Contract
{
	public interface ITemplateRepositoryManager
	{
		DtoTemplateInfo GetTemplateInfo(int id);

		int SaveTemplateInfo(DtoTemplateInfo dto);
	}
}