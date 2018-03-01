namespace BI.Repository.Resource.Models
{
	public partial class ResourceTranslation
	{
		public int ResourceTranslationId { get; set; }
		public int ResourceId { get; set; }
		public short LanguageId { get; set; }
		public string ResourceString { get; set; }
		public byte[] ResourceImage { get; set; }
		public virtual Language Language { get; set; }
		public virtual ResourceDescription ResourceDescription { get; set; }
	}
}