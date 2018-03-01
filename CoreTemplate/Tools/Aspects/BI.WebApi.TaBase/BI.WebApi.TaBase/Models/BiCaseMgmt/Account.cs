using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("Account")]
	internal class Account
	{
		#region Primary key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AccountId { get; set; }

		#endregion

		#region Columns

		[ForeignKey("Role")]
		public int RoleId { get; set; }

		#endregion

		#region Relationships
		public Role Role { get; set; }
		#endregion
	}
}