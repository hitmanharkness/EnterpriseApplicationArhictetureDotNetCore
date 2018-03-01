using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("UserAgency")]
	internal class UserAgency
	{
		#region Primary Key

		[Key,
		Column("access_group_id", Order = 2)]
		public int AccessGroupId { get; set; }

		[Key,
		Column(Order = 1),
		ForeignKey("Account")]
		public int AccountId { get; set; }

		[Key,
		Column("agency_id", Order = 3)]
		public int AgencyId { get; set; }

		#endregion

		#region Foreign Key

		public Account Account { get; set; }

		public User User { get; set; }

		[Column("user_id"),
		ForeignKey("User")]
		public int UserId { get; set; }

		#endregion

		#region Column

		[Column("agency_name")]
		public string AgencyName { get; set; }

		[Column("customer_id")]
		public int? CustomerId { get; set; }

		[Column("customer_number")]
		public string CustomerNumber { get; set; }

		[Column("entity_type_id")]
		public int EntityTypeId { get; set; }

		public bool ExcludeFromReports { get; set; }

		[Column("first_name")]
		public string FirstName { get; set; }

		public bool? IsActiveAccount { get; set; }

		[Column("is_default")]
		public bool IsDefault { get; set; }

		[Column("last_name")]
		public string LastName { get; set; }

		[Column("middle_initial")]
		public string MiddleInitial { get; set; }

		[Column("officer_number")]
		public string OfficerNumber { get; set; }

		[Column("officer_pin")]
		public int? OfficerPin { get; set; }

		#endregion
	}
}