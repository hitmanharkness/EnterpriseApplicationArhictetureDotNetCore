using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BI.Repository.Resource.Models.Mapping
{
	public class ResourceDescriptionMap : EntityTypeConfiguration<ResourceDescription>
	{
		public ResourceDescriptionMap()
		{
			// Primary Key
			this.HasKey(t => t.ResourceId);

			// Properties
			this.Property(t => t.ResourceId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			this.Property(t => t.Key)
				.IsRequired()
				.HasMaxLength(64);

			this.Property(t => t.Description)
				.IsRequired()
				.HasMaxLength(256);

			// Table & Column Mappings
			this.ToTable("ResourceDescription");
			this.Property(t => t.ResourceId).HasColumnName("ResourceId");
			this.Property(t => t.ResourceTypeId).HasColumnName("ResourceTypeId");
			this.Property(t => t.Key).HasColumnName("Key");
			this.Property(t => t.Description).HasColumnName("Description");

			// Relationships
			this.HasRequired(t => t.ResourceType)
				.WithMany(t => t.ResourceDescriptions)
				.HasForeignKey(d => d.ResourceTypeId);
		}
	}
}