using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.Aspect.Language.Models
{
	[Table("Language")]
	internal class Language
	{
		#region Primary Key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None)]
		public short LanguageId { get; set; }

		#endregion

		public int LanguageNameResource { get; set; }
		public string LanguageTag { get; set; }
	}
}