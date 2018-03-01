using BI.Enterprise.ViewModels.Template.Contract;
using System;

namespace BI.Enterprise.ViewModels.Template
{
	public class TemplateInfo : ITemplateInfo
	{
		// TODO: Create and Change date values should be set by the system when the data is being saved in the database.

		#region ITemplateInfo Explicit Implementation
		DateTime ITemplateInfo.ChangeDate { get; set; }
		DateTime ITemplateInfo.CreateDate { get; set; }
		#endregion

		public int Id { get; set; }
		public string Name { get; set; }
	}
}