using System.Data.Entity;

namespace BI.Repository.Resource.Models
{
	using Mapping;

	public class ResourceContext : DbContext
	{
		public ResourceContext()
			: base("Name=BICaseMgmtContext")
		{ }

		public DbSet<Client> Clients { get; set; }

		public DbSet<Language> Languages { get; set; }

		public DbSet<LanguageCode> LanguageCodes { get; set; }

		public DbSet<ResourceDescription> ResourceDescriptions { get; set; }

		public DbSet<ResourceTranslation> ResourceTranslations { get; set; }

		public DbSet<ResourceType> ResourceTypes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ClientMap());
			modelBuilder.Configurations.Add(new LanguageMap());
			modelBuilder.Configurations.Add(new LanguageCodeMap());
			modelBuilder.Configurations.Add(new ResourceDescriptionMap());
			modelBuilder.Configurations.Add(new ResourceTranslationMap());
			modelBuilder.Configurations.Add(new ResourceTypeMap());
		}
	}
}