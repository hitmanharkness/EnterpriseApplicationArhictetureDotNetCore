using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("Function")]
	internal class Function
	{
		#region Constructor

		public Function() =>
			this.FunctionGroupFunctions = new HashSet<FunctionGroupFunction>();

		#endregion

		#region Primary key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int FunctionId { get; set; }

		#endregion

		#region Columns

		[Column("FunctionName")]
		public string Name { get; set; }

		#endregion

		#region Relationships
		public ICollection<FunctionGroupFunction> FunctionGroupFunctions { get; set; }
		#endregion
	}
}