using System;

namespace BI.Enterprise.ViewModels.Template.Contract
{
	public interface ITemplateInfo
	{
		DateTime ChangeDate { get; set; }
		DateTime CreateDate { get; set; }
		int Id { get; set; }
		string Name { get; set; }
	}
}