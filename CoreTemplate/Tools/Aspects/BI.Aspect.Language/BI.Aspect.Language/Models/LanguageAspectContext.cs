using System.Data.Entity;

namespace BI.Aspect.Language.Models
{
	internal class LanguageAspectContext : DbContext
	{
		#region Constructor

		public LanguageAspectContext()
			: base("Name=BICaseMgmtContext")
		{ }

		#endregion

		#region Table Representations
		public DbSet<Language> Languages { get; set; }
		public DbSet<ResourceTranslation> ResourceTranslations { get; set; }
		#endregion
	}
}