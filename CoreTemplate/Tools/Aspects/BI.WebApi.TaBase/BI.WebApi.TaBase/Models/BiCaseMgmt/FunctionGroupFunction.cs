using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("FunctionGroupXRef")]
	internal class FunctionGroupFunction
	{
		#region Primary key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None),
		Column(Order = 1),
		ForeignKey("FunctionGroup")]
		public int FunctionGroupId { get; set; }

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None),
		Column(Order = 2),
		ForeignKey("Function")]
		public int FunctionId { get; set; }

		#endregion

		#region Relationships
		public Function Function { get; set; }
		public FunctionGroup FunctionGroup { get; set; }
		#endregion
	}
}