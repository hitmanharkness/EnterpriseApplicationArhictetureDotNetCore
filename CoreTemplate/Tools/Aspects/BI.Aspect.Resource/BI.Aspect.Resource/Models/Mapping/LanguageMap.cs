using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BI.Repository.Resource.Models.Mapping
{
	public class LanguageMap : EntityTypeConfiguration<Language>
	{
		public LanguageMap()
		{
			// Primary Key
			this.HasKey(t => t.LanguageId);

			// Properties
			this.Property(t => t.LanguageId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			this.Property(t => t.LanguageTag)
				.HasMaxLength(24);

			// Table & Column Mappings
			this.ToTable("Language");
			this.Property(t => t.LanguageId).HasColumnName("LanguageId");
			this.Property(t => t.LanguageTag).HasColumnName("LanguageTag");
		}
	}
}