using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BI.Enterprise.Repository
{
	public class EFStoredProcHelpers
	{
		DbContext contextToRunOn;

		public EFStoredProcHelpers(DbContext contextToRunOn)
		{
			this.contextToRunOn = contextToRunOn;

			Parameters = new List<SqlParameter>();
		}

		public List<SqlParameter> Parameters { get; protected set; }

		public void ClearParameters()
		{
			Parameters = new List<SqlParameter>();
		}

		public void AddParameter<T>(T value, SqlDbType parameterDbType, int? parameterSize, string name, ParameterDirection direction = ParameterDirection.Input)
		{
			// TODO: We could attempt to dynamically determine the SqlDbType from the typeof(T) but there are some pitfalls there like for a string we don't
			// know if the DB column they want the parameter to be used against is a varchar or an nvarchar, for decimal, float and double we don't know if
			// the column is going to be a Decimal, Float, Money, SmallMoney or Real and we wouldn't be able to determine precision, etc.  So this is most likely
			// about the closest we can get to a truly generic method for this purpose without having issues, especially with the DB in the current state of
			// consistency.  --Jason Melvin
			SqlParameter parm = new SqlParameter();
			parm.ParameterName = name;
			parm.SqlDbType = parameterDbType;
			parm.Direction = direction;

			// Handle null parameter values.
			if (value == null)
			{
				parm.Value = DBNull.Value;
			}
			else
			{
				parm.Value = value;
			}

			// Set the size if we have one.
			if (parameterSize != null)
			{
				parm.Size = parameterSize.Value;
			}

			Parameters.Add(parm);
		}

		/// <summary>
		/// Executes a stored procedure that doesn't return any data.
		/// </summary>
		/// <param name="spName">The name of the stored procedure to execute on the store.</param>
		public void SpExecute(string spName)
		{
			var ctx = ((IObjectContextAdapter)contextToRunOn).ObjectContext;
			ctx.CommandTimeout = 0;

			object[] parameters = Parameters.ToArray();

			// Get the Parameters ready if we have any. Using parameters ensures we protect against Sql Injection Attacks...
			if (Parameters.Any())
			{
				spName = Parameters.Aggregate(spName, (current, p) => $"{current.Trim()} {p.ParameterName}, ");
				spName = spName.Substring(0, spName.Length - 2);
			}

			ctx.ExecuteStoreCommand(spName.Trim(), parameters);
		}

		/// <summary>
		/// Executes a stored procedure that doesn't return any data asynchronously.
		/// </summary>
		/// <param name="spName"></param>
		public async Task SpExecuteAsync(string spName)
		{
			var ctx = ((IObjectContextAdapter)contextToRunOn).ObjectContext;
			ctx.CommandTimeout = 0;

			object[] parameters = Parameters.ToArray();

			// Get the Parameters ready if we have any. Using parameters ensures we protect against Sql Injection Attacks...
			if (Parameters.Any())
			{
				spName = Parameters.Aggregate(spName, (current, p) => $"{current.Trim()} {p.ParameterName}, ");
				spName = spName.Substring(0, spName.Length - 2);
			}

			await ctx.ExecuteStoreCommandAsync(spName.Trim(), parameters);
		}

		public ObjectResult<T> SpGetAs<T>(string spName)
		{
			var ctx = ((IObjectContextAdapter)contextToRunOn).ObjectContext;
			ctx.CommandTimeout = 0;
			object[] parameters = Parameters.ToArray();

			if (!Parameters.Any()) return ctx.ExecuteStoreQuery<T>(spName.Trim(), parameters);

			spName = Parameters.Aggregate(spName, (current, p) => $"{current.Trim()} {p.ParameterName}, ");
			spName = spName.Substring(0, spName.Length - 2);
			return ctx.ExecuteStoreQuery<T>(spName.Trim(), parameters);
		}

		public async Task<ObjectResult<T>> SpGetAsAsync<T>(string spName)
		{
			var ctx = ((IObjectContextAdapter)contextToRunOn).ObjectContext;
			ctx.CommandTimeout = 0;
			object[] parameters = Parameters.ToArray();

			if (!Parameters.Any()) return await ctx.ExecuteStoreQueryAsync<T>(spName.Trim(), parameters);

			spName = Parameters.Aggregate(spName, (current, p) => $"{current.Trim()} {p.ParameterName}, ");
			spName = spName.Substring(0, spName.Length - 2);
			return await ctx.ExecuteStoreQueryAsync<T>(spName.Trim(), parameters);
		}
	}
}
