using BI.Enterprise.Dto.Template;
using BI.Repository.Template.Contract;
using BI.ServiceBus.Repository.Template.Contract;
using System;

namespace BI.ServiceBus.Repository.Template
{
	public class TemplateRepositoryManager : ITemplateRepositoryManager
	{
		#region Private Variables
		private readonly ITemplateContext _context;
		#endregion

		#region Constructor

		public TemplateRepositoryManager(ITemplateContext context)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
		}

		#endregion

		#region ITemplateRepositoryManager Implementation

		public DtoTemplateInfo GetTemplateInfo(int id)
		{
			// TODO: Implement query using _context.
			return new DtoTemplateInfo
			{
				ChangeDate = DateTime.UtcNow,
				CreateDate = DateTime.UtcNow,
				Id = id,
				Name = "Test Name"
			};
		}

		public int SaveTemplateInfo(DtoTemplateInfo dto)
		{
			// TODO: Implement logic to save data into database.
			this._context.SaveChangesInDb();
			return 1;
		}

		#endregion
	}
}