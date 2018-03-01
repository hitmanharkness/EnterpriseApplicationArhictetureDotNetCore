using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("AppService")]
	internal class AppService
	{
		#region Primary Key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int AppServiceId { get; set; }

		#endregion

		#region Columns

		[ForeignKey("Application")]
		public long AppId { get; set; }

		public string Description { get; set; }
		public string Name { get; set; }
		public bool RequiresWrite { get; set; }
		#endregion

		#region Relationships
		public Application Application { get; set; }
		public virtual ICollection<AppServiceFunction> AppServiceFunctions { get; set; } = new HashSet<AppServiceFunction>();
		#endregion
	}
}