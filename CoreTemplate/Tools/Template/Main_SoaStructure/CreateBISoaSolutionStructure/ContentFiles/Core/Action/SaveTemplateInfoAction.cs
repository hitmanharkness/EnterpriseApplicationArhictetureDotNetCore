using BI.Enterprise.Dto.Template;
using BI.ServiceBus.Core.Template.Action.Rule;
using BI.ServiceBus.Repository.Template.Contract;
using BWSRulesEngine;
using System;
using System.Collections.Generic;

namespace BI.ServiceBus.Core.Template.Action
{
	internal class SaveTemplateInfoAction : WorkAction
	{
		#region Private Variables
		private readonly DtoTemplateInfo _info;
		private readonly ITemplateRepositoryManager _repo;
		#endregion

		#region Constructor

		public SaveTemplateInfoAction(ITemplateRepositoryManager repo, DtoTemplateInfo info)
		{
			this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
			this._info = info;
		}

		#endregion

		#region Public Properties

		//This "Response" property can be change to any type that this action needs to return
		// if the action doesn't return a value, this property is not required.
		public int Response { get; set; }

		#endregion

		#region Overridden Methods

		protected override void AddRules(IList<IWorkRule> rules)
		{
			// IMPORTANT: Try to create rules as specific as possible.
			// If a rule should return a 404 (not found) HTTP code, just use a -404 as the errorCode for the rule.
			rules.Add(new ValueShouldNotBeEmptyOrNullRule(-1, "The name is missing.", this._info.Name));
		}

		protected override void ProcessAction()
		{
			// This is where the magic happens. Add the required changes to accomplish an individual action. You can create
			// private methods to support the action in this class. If you are doing more than one individual business action in this
			// class, that is not correct, you should create an action class per business action.
			this.Response = this._repo.SaveTemplateInfo(_info);
		}

		#endregion
	}
}