using System.Collections.Generic;

namespace BI.Repository.Resource.Models
{
	public class ResourceDescription
	{
		public ResourceDescription()
		{
			this.ResourceTranslations = new List<ResourceTranslation>();
		}

		public string Description { get; set; }
		public string Key { get; set; }
		public int ResourceId { get; set; }
		public byte ResourceTypeId { get; set; }

		#region Relationships

		public virtual ICollection<ResourceTranslation> ResourceTranslations { get; set; }
		public virtual ResourceType ResourceType { get; set; }

		#endregion
	}
}