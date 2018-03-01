using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("FunctionGroup")]
	internal class FunctionGroup
	{
		#region Constructor

		public FunctionGroup()
		{
			this.RoleFunctionGroups = new HashSet<RoleFunctionGroup>();
			this.FunctionGroupFunctions = new HashSet<FunctionGroupFunction>();
		}

		#endregion

		#region Primary Key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int FunctionGroupId { get; set; }

		#endregion

		#region Columns

		[Column("IsFCPControl")]
		public bool IsFcpControlled { get; set; }

		[Column("FunctionGroupName")]
		public string Name { get; set; }

		#endregion

		#region Relationships
		public virtual ICollection<FunctionGroupFunction> FunctionGroupFunctions { get; set; }
		public virtual ICollection<RoleFunctionGroup> RoleFunctionGroups { get; set; }
		#endregion
	}
}