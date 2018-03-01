using System.Data.Entity.ModelConfiguration;

namespace BI.Repository.Resource.Models.Mapping
{
	public class ResourceTranslationMap : EntityTypeConfiguration<ResourceTranslation>
	{
		public ResourceTranslationMap()
		{
			// Primary Key
			this.HasKey(t => t.ResourceTranslationId);

			// Properties
			// Table & Column Mappings
			this.ToTable("ResourceTranslation");
			this.Property(t => t.ResourceTranslationId).HasColumnName("ResourceTranslationId");
			this.Property(t => t.ResourceId).HasColumnName("ResourceId");
			this.Property(t => t.LanguageId).HasColumnName("LanguageId");
			this.Property(t => t.ResourceString).HasColumnName("ResourceString");
			this.Property(t => t.ResourceImage).HasColumnName("ResourceImage");

			// Relationships
			this.HasRequired(t => t.Language)
				.WithMany(t => t.ResourceTranslations)
				.HasForeignKey(d => d.LanguageId);
			this.HasRequired(t => t.ResourceDescription)
				.WithMany(t => t.ResourceTranslations)
				.HasForeignKey(d => d.ResourceId);
		}
	}
}