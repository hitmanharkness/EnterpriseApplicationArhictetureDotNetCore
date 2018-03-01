using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BI.Repository.Resource.Models.Mapping
{
	public class LanguageCodeMap : EntityTypeConfiguration<LanguageCode>
	{
		public LanguageCodeMap()
		{
			// Primary Key
			this.HasKey(t => t.language_id);

			// Properties
			this.Property(t => t.language_id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			this.Property(t => t.culture_language_name)
				.IsRequired()
				.HasMaxLength(20);

			this.Property(t => t.culture_id)
				.HasMaxLength(20);

			this.Property(t => t.culture)
				.IsRequired()
				.HasMaxLength(100);

			this.Property(t => t.Iso_639_3Id)
				.HasMaxLength(5);

			this.Property(t => t.IsoName)
				.HasMaxLength(50);

			// Table & Column Mappings
			this.ToTable("LanguageCode");
			this.Property(t => t.language_id).HasColumnName("language_id");
			this.Property(t => t.culture_language_name).HasColumnName("culture_language_name");
			this.Property(t => t.culture_id).HasColumnName("culture_id");
			this.Property(t => t.culture).HasColumnName("culture");
			this.Property(t => t.is_used).HasColumnName("is_used");
			this.Property(t => t.bi_code).HasColumnName("bi_code");
			this.Property(t => t.DisplayUI).HasColumnName("DisplayUI");
			this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
			this.Property(t => t.Iso_639_3Id).HasColumnName("Iso_639_3Id");
			this.Property(t => t.IsoName).HasColumnName("IsoName");
			this.Property(t => t.ResourceLanguageId).HasColumnName("ResourceLanguageId");

			// Relationships
			this.HasOptional(t => t.Language)
				.WithMany(t => t.LanguageCodes)
				.HasForeignKey(d => d.ResourceLanguageId);
		}
	}
}