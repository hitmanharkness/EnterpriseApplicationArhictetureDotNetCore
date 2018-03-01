using BI.Enterprise.Common.Exceptions;
using BI.Enterprise.Dto.Template;
using BI.ServiceBus.Repository.Template.Contract.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BI.ServiceBus.Core.Template.Test
{
	[TestClass]
	public class TemplateTest
	{
		// IMPORTANT: We should unit test the Core only. This is because the Core is the only layer that contains business logic.
		// Testing the manager should be consider as an integration test given that a manager method could call multiple actions.

		#region GetTemplateInfo Tests

		[TestMethod]
		public void GetTemplateInfoFailIdIsRequired()
		{
			var core = new TemplateCore(new StubITemplateRepositoryManager());
			try
			{
				core.GetTemplateInfo(0);
			}
			catch (ValidationException ex)
			{
				Assert.AreEqual(ex.Code, -1);
			}
		}

		[TestMethod]
		public void GetTemplateInfoFailNotFound()
		{
			var core = new TemplateCore(new StubITemplateRepositoryManager());
			try
			{
				core.GetTemplateInfo(4);
			}
			catch (ValidationException ex)
			{
				Assert.AreEqual(ex.Code, -404);
			}
		}

		[TestMethod]
		public void GetTemplateInfoSuccess()
		{
			var repo = new StubITemplateRepositoryManager
			{
				GetTemplateInfoInt32 = (id) => new DtoTemplateInfo
				{
					Id = id,
					Name = "TemplateName",
					ChangeDate = DateTime.UtcNow,
					CreateDate = DateTime.UtcNow
				}
			};
			var core = new TemplateCore(repo);
			var dto = core.GetTemplateInfo(1);
			Assert.AreEqual(dto.Id, 1);
		}

		#endregion

		#region SaveTemplateInfo Tests

		[TestMethod]
		public void SaveTemplateInfoFailNameIsMissing()
		{
			var core = new TemplateCore(new StubITemplateRepositoryManager());
			try
			{
				var dto = new DtoTemplateInfo();
				core.SaveTemplateInfo(dto);
			}
			catch (ValidationException ex)
			{
				Assert.AreEqual(ex.Code, -1);
			}
		}

		[TestMethod]
		public void SaveTemplateInfoSuccess()
		{
			var repo = new StubITemplateRepositoryManager
			{
				SaveTemplateInfoDtoTemplateInfo = (info) => 3
			};
			var core = new TemplateCore(repo);
			var dto = new DtoTemplateInfo
			{
				Name = "Template Name"
			};
			var resp = core.SaveTemplateInfo(dto);
			Assert.AreEqual(resp, 3);
		}

		#endregion
	}
}