using BI.Repository.Template.Contract;
using System.Data.Entity;

namespace BI.Repository.Template.Models
{
	public class TemplateContext : DbContext, ITemplateContext
	{
		#region Constructor

		public TemplateContext()
			: base("Name=BICaseMgmtContext")
		{ }

		#endregion

		#region Table Representations
		// TODO: Implement the required database models. Check Officer Mobile for examples.
		#endregion

		#region ITemplateContext Implementation
		// TODO: Implement ITemplateContext interface. Check Officer Mobile for examples.

		public int SaveChangesInDb()
		{
			return base.SaveChanges();
		}

		#endregion
	}

	#region Support class to import the assembly EntityFramework.SqlServer into the bin folder

	internal class ImportSqlClient
	{
		public System.Data.Entity.SqlServer.SqlProviderServices Test = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
	}

	#endregion
}