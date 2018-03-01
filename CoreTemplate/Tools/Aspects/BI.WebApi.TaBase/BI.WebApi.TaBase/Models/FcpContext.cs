using BI.WebApi.TaBase.Models.Fcp;
using System.Data.Entity;

namespace BI.WebApi.TaBase.Models
{
	internal class FcpContext : DbContext
	{
		#region Constructor

		public FcpContext()
			: base("FCPContext")
		{
			Database.SetInitializer<FcpContext>(null);
		}

		#endregion

		#region Table Representations
		public DbSet<CustomerFeatureObject> CustomerFeatureObjects { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<FeatureObject> FeatureObjects { get; set; }
		#endregion
	}
}