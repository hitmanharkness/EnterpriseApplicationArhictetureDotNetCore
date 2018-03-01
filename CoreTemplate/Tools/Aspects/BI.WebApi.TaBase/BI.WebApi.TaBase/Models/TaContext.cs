using BI.WebApi.TaBase.Models.BiCaseMgmt;
using System.Data.Entity;

namespace BI.WebApi.TaBase.Models
{
	internal class TaContext : DbContext
	{
		#region Constructor

		public TaContext()
			: base("BICaseMgmtContext")
		{ }

		#endregion

		#region Table Representations
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Application> Applications { get; set; }
		public DbSet<AppServiceFunction> AppServiceFunctions { get; set; }
		public DbSet<AppService> AppServices { get; set; }
		public DbSet<FunctionGroupFunction> FunctionGroupFunctions { get; set; }
		public DbSet<FunctionGroup> FunctionGroups { get; set; }
		public DbSet<Function> Functions { get; set; }
		public DbSet<RoleFunctionGroup> RoleFunctionGroups { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserAgency> UserAgencies { get; set; }
		public DbSet<User> Users { get; set; }
		#endregion
	}
}