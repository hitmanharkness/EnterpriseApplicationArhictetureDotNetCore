using System.Collections.Generic;

namespace BI.Repository.Resource.Models
{
	public class ResourceType
	{
		public ResourceType()
		{
			this.ResourceDescriptions = new List<ResourceDescription>();
		}

		public string Description { get; set; }
		public byte ResourceTypeId { get; set; }

		#region Relationships

		public virtual ICollection<ResourceDescription> ResourceDescriptions { get; set; }

		#endregion
	}
}