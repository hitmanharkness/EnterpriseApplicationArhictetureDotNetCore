using BI.Enterprise.ViewModels.Template.Contract;
using System;

namespace BI.Enterprise.ViewModels.Template
{
	public class GetTemplateResponseInfo : ITemplateInfo
	{
		public DateTime ChangeDate { get; set; }
		public DateTime CreateDate { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
	}
}