using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("Role")]
	internal class Role
	{
		#region Constructor

		public Role() =>
			this.RoleFunctionGroups = new HashSet<RoleFunctionGroup>();

		#endregion

		#region Primary Key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.Identity),
		Column("role_id")]
		public int RoleId { get; set; }

		#endregion

		#region Relationships
		public virtual ICollection<RoleFunctionGroup> RoleFunctionGroups { get; set; }
		#endregion
	}
}