using System.Collections.Generic;

namespace BI.Repository.Resource.Models
{
	public class Language
	{
		public Language()
		{
			this.ResourceTranslations = new List<ResourceTranslation>();
			this.LanguageCodes = new List<LanguageCode>();
		}

		public virtual ICollection<LanguageCode> LanguageCodes { get; set; }
		public short LanguageId { get; set; }
		public string LanguageTag { get; set; }
        public int LanguageNameResource { get; set; }
		public virtual ICollection<ResourceTranslation> ResourceTranslations { get; set; }
	}
}