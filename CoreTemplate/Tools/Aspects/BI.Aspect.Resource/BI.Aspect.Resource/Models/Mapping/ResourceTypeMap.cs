using System.Data.Entity.ModelConfiguration;

namespace BI.Repository.Resource.Models.Mapping
{
	public class ResourceTypeMap : EntityTypeConfiguration<ResourceType>
	{
		public ResourceTypeMap()
		{
			// Primary Key
			this.HasKey(t => t.ResourceTypeId);

			// Properties
			this.Property(t => t.Description)
				.IsRequired()
				.HasMaxLength(256);

			// Table & Column Mappings
			this.ToTable("ResourceType");
			this.Property(t => t.ResourceTypeId).HasColumnName("ResourceTypeId");
			this.Property(t => t.Description).HasColumnName("Description");
		}
	}
}