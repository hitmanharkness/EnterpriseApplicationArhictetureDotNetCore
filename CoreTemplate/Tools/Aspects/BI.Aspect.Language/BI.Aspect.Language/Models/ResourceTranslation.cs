using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.Aspect.Language.Models
{
	[Table("ResourceTranslation")]
	internal class ResourceTranslation
	{
		#region Primary Key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ResourceTranslationId { get; set; }

		#endregion

		#region Columns
		public short LanguageId { get; set; }
		public int ResourceId { get; set; }
		public byte[] ResourceImage { get; set; }
		public string ResourceString { get; set; }
		#endregion
	}
}