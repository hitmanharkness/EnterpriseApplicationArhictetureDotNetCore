using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable VirtualMemberCallInConstructor

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("App")]
	internal class Application
	{
		#region Constructor

		public Application() =>
			this.AppServices = new HashSet<AppService>();

		#endregion

		#region Primary Key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None),
		Column("Id")]
		public long ApplicationId { get; set; }

		#endregion

		#region Columns

		public string AppName { get; set; }

		#endregion

		#region Relationships

		public virtual ICollection<AppService> AppServices { get; set; }

		#endregion
	}
}