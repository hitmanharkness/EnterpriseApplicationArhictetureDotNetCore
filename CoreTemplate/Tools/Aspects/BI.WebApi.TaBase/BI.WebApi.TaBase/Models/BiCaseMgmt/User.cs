using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("appUser")]
	internal class User
	{
		#region Primary Key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.Identity),
		Column("user_id")]
		public int UserId { get; set; }

		#endregion

		#region Columns

		[ForeignKey("Account")]
		public int AccountId { get; set; }

		#endregion

		#region Relationships
		public Account Account { get; set; }
		#endregion
	}
}