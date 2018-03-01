using BI.Enterprise.Common.Exceptions;
using BI.WebApi.TaBase.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BI.WebApi.TaBase.Attributes
{
	/// <inheritdoc />
	/// <summary>
	/// Specifies the authorization filter that verifies the request's System.Security.Principal.IPrincipal against TA roles.
	/// </summary>
	public class TaAuthorizeAttribute : AuthorizeAttribute
	{
		#region Public Properties

		/// <summary>
		/// The function(s) that should have at least read access.
		/// </summary>
		/// <remarks>Format should be "1||2||3" or "1&amp;&amp;2&amp;&amp;3".</remarks>
		public string ReadFunctions { get; set; }

		/// <summary>
		/// The id linked to the service that the officer should access to.
		/// </summary>
		public int ServiceId { get; set; }

		/// <summary>
		/// The function(s) that should have write access.
		/// </summary>
		/// <remarks>Format should be "1||2||3" or "1&amp;&amp;2&amp;&amp;3".</remarks>
		public string WriteFunctions { get; set; }

		#endregion

		#region Private Variables
		private static readonly int[] AdminRoles = { 9, 25, 29, 56, 57 };
		private ClaimsPrincipal _principal;
		#endregion

		#region Overridden Methods

		/// <inheritdoc />
		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
		{
			if (actionContext.RequestContext.Principal.Identity.IsAuthenticated)
				throw new ServiceForbiddenException();
			base.HandleUnauthorizedRequest(actionContext);
		}

		/// <inheritdoc />
		protected override bool IsAuthorized(HttpActionContext actionContext)
		{
			if (!base.IsAuthorized(actionContext))
				return false;

			if (string.IsNullOrWhiteSpace(this.ReadFunctions) &&
				string.IsNullOrWhiteSpace(this.WriteFunctions) &&
				this.ServiceId <= 0)
				return true;

			this._principal = actionContext.RequestContext.Principal as ClaimsPrincipal;
			if (this._principal == null)
				return false;

			var taEntityType = this._principal.Claims.FirstOrDefault(x => x.Type == "EntityType");
			if (taEntityType?.Value != "TaUser")
				return false;

			var taEntityIdClaim = this._principal.Claims.FirstOrDefault(x => x.Type.Equals("TaEntityId"));
			if (!int.TryParse(taEntityIdClaim?.Value, out var userId) || userId <= 0)
				return false;

			var readFunctionsPassed = true;
			if (!string.IsNullOrWhiteSpace(this.ReadFunctions))
			{
				var readFunctionsToCheck = this.ReadFunctions.Trim();

				if (readFunctionsToCheck.Contains("["))
					readFunctionsToCheck = readFunctionsToCheck.Remove(readFunctionsToCheck.Length - 1).Substring(1);

				var checkReadPackages = readFunctionsToCheck.Split("][".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				readFunctionsPassed = checkReadPackages.Any(package => CheckFunctionsPackage(package, false, userId));
			}

			var writeFunctionsPassed = true;
			if (!string.IsNullOrWhiteSpace(this.WriteFunctions))
			{
				var writeFunctionsToCheck = this.WriteFunctions.Trim();

				if (writeFunctionsToCheck.Contains("["))
					writeFunctionsToCheck = writeFunctionsToCheck.Remove(writeFunctionsToCheck.Length - 1).Substring(1);

				var checkWritePackages = writeFunctionsToCheck.Split("][".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				writeFunctionsPassed = checkWritePackages.Any(package => CheckFunctionsPackage(package, true, userId));
			}

			if (this.ServiceId <= 0)
				return readFunctionsPassed && writeFunctionsPassed;

			var serviceCheckPassed = CheckService(this.ServiceId, userId);
			return readFunctionsPassed && writeFunctionsPassed && serviceCheckPassed;
		}

		#endregion

		#region Private Methods

		internal static bool CheckService(int serviceId, int userId)
		{
			using (var taContext = new TaContext())
			{
				var appService = taContext.AppServices.FirstOrDefault(x => x.AppServiceId == serviceId);
				if (appService == null)
					return false;

				var roleFunctionGroups = taContext.Users
					.Where(x => x.UserId == userId)
					.SelectMany(x => x.Account.Role.RoleFunctionGroups);
				var functionGroupFunctions = taContext.AppServices
					.Where(x => x.AppServiceId == serviceId)
					.SelectMany(x => x.AppServiceFunctions)
					.SelectMany(x => x.Function.FunctionGroupFunctions);

				var q =
					from rfg in roleFunctionGroups
					join fgf in functionGroupFunctions
						on rfg.FunctionGroupId equals fgf.FunctionGroupId
					select new RoleInfo
					{
						RoleId = rfg.RoleId,
						FunctionGroupId = rfg.FunctionGroupId,
						IsReadOnly = rfg.IsReadOnly,
						IsFcpControlled = rfg.FunctionGroup.IsFcpControlled
					};

				var roleInfos = q.ToArray();

				if (roleInfos.Length < 1)
					return false;

				var roleInfo = roleInfos
					.OrderByDescending(x => x.IsFcpControlled)
					.ThenByDescending(x => x.IsReadOnly)
					.FirstOrDefault();

				return IsRoleInfoValid(userId, roleInfo, appService.RequiresWrite, taContext);
			}
		}

		private static bool CheckFunctionsPackage(string package, bool shouldHaveWriteAccess, int userId)
		{
			var subPackages = package.Split("&&".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			return subPackages.All(x => CheckOrFunctions(x, shouldHaveWriteAccess, userId));
		}

		private static bool CheckOrFunctions(string functionsToCheck, bool shouldHaveWriteAccess, int userId)
		{
			using (var taContext = new TaContext())
			{
				var functionSet = functionsToCheck.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				foreach (var fId in functionSet)
				{
					if (!int.TryParse(fId, out var functionId))
						continue;
					var roleFunctionGroups = taContext.Users
						.Where(x => x.UserId == userId)
						.SelectMany(x => x.Account.Role.RoleFunctionGroups);
					var functionGroupFunctions = taContext.Functions
						.Where(x => x.FunctionId == functionId)
						.SelectMany(x => x.FunctionGroupFunctions);
					var roleInfos = (
						from rfg in roleFunctionGroups
						join fgf in functionGroupFunctions
						on rfg.FunctionGroupId equals fgf.FunctionGroupId
						select new RoleInfo
						{
							RoleId = rfg.RoleId,
							FunctionGroupId = rfg.FunctionGroupId,
							IsReadOnly = rfg.IsReadOnly,
							IsFcpControlled = rfg.FunctionGroup.IsFcpControlled
						}
						).ToArray();
					if (roleInfos.Length != 1)
						continue;
					var roleInfo = roleInfos.First();
					if (IsRoleInfoValid(userId, roleInfo, shouldHaveWriteAccess, taContext))
						return true;
				}
				return false;
			}
		}
		private static bool IsFunctionGroupFcpEnabled(string customerNumber, int functionGroupId)
		{
			if (string.IsNullOrWhiteSpace(customerNumber))
				return false;

			using (var fcpCtx = new FcpContext())
			{
				var now = DateTime.Now;
				return fcpCtx.CustomerFeatureObjects
					.Any(x =>
						x.Customer.CustomerNumber == customerNumber
						&& x.FeatureObject.ReferenceId == functionGroupId
						&& x.FeatureObject.IsEnabled
						&& x.StartDate <= now
						&& (!x.EndDate.HasValue || x.EndDate.Value >= now));
			}
		}

		private static bool IsRoleInfoValid(int userId, RoleInfo roleInfo, bool shouldHaveWriteAccess, TaContext taContext)
		{
			if (shouldHaveWriteAccess && roleInfo.IsReadOnly)
				return false;
			if (!roleInfo.IsFcpControlled)
				return true;
			if (AdminRoles.Contains(roleInfo.RoleId))
				return true;

			var customerNumber = taContext.UserAgencies.FirstOrDefault(x => x.UserId == userId && x.CustomerId.HasValue)?.CustomerNumber;
			return IsFunctionGroupFcpEnabled(customerNumber, roleInfo.FunctionGroupId);
		}

		#endregion
	}

	#region Support Classes

	internal class RoleInfo
	{
		public int FunctionGroupId { get; set; }
		public bool IsFcpControlled { get; set; }
		public bool IsReadOnly { get; set; }
		public int RoleId { get; set; }
	}

	#endregion
}