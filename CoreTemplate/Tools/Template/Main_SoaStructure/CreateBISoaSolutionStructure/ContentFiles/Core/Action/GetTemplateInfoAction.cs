using BI.Enterprise.Dto.Template;
using BI.ServiceBus.Core.Template.Action.Rule;
using BI.ServiceBus.Repository.Template.Contract;
using BWSRulesEngine;
using System;
using System.Collections.Generic;

namespace BI.ServiceBus.Core.Template.Action
{
	internal class GetTemplateInfoAction : WorkAction
	{
		#region Private Variables
		private readonly int _id;
		private readonly ITemplateRepositoryManager _repo;
		#endregion

		#region Constructor

		public GetTemplateInfoAction(ITemplateRepositoryManager repo, int id)
		{
			this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
			this._id = id;
		}

		#endregion

		#region Public Properties

		//This "Response" property can be change to any type that this action needs to return
		// if the action doesn't return a value, this property is not required.
		public DtoTemplateInfo Response { get; set; }

		#endregion

		#region Overridden Methods

		protected override void AddRules(IList<IWorkRule> rules)
		{
			// IMPORTANT: Try to create rules as specific as possible.
			// If a rule should return a 404 (not found) HTTP code, just use a -404 as the errorCode for the rule.
			rules.Add(new ValueShouldBeGreaterThanZeroRule(-1, "The TemplateId should be greater that zero.", this._id));
			rules.Add(new IdEqualTo4Returns404Rule(-404, "The template id doesn't exists", this._id));
		}

		protected override void ProcessAction()
		{
			// This is where the magic happens. Add the required changes to accomplish an individual action. You can create
			// private methods to support the action in this class. If you are doing more than one individual business action in this
			// class, that is not correct, you should create an action class per business action.
			this.Response = this._repo.GetTemplateInfo(this._id);
		}

		#endregion
	}
}