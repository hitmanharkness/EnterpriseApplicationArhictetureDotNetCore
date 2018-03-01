namespace BI.Repository.Resource.Models
{
	public class LanguageCode
	{
		public int? bi_code { get; set; }
		public string culture { get; set; }
		public string culture_id { get; set; }
		public string culture_language_name { get; set; }
		public int? DisplayOrder { get; set; }
		public bool? DisplayUI { get; set; }
		public bool is_used { get; set; }
		public string Iso_639_3Id { get; set; }
		public string IsoName { get; set; }
		public int language_id { get; set; }
		public short? ResourceLanguageId { get; set; }

		#region Relationships

		public virtual Language Language { get; set; }

		#endregion
	}
}