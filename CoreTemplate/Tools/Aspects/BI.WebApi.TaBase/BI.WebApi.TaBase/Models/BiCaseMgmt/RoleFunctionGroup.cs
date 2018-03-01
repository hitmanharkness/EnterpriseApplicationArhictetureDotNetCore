using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("RoleFunctionGroup")]
	internal class RoleFunctionGroup
	{
		#region Primary key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None),
		Column(Order = 2),
		ForeignKey("FunctionGroup")]
		public int FunctionGroupId { get; set; }

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None),
		Column(Order = 1),
		ForeignKey("Role")]
		public int RoleId { get; set; }

		#endregion

		#region Columns

		[Column("ReadOnly")]
		public bool IsReadOnly { get; set; }

		#endregion

		#region Relationships
		public FunctionGroup FunctionGroup { get; set; }
		public Role Role { get; set; }
		#endregion
	}
}