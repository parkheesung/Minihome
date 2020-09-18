using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using OctopusV3.Core;
using OctopusV3.Data;

namespace MiniHome.Domain
{
	public class DefaultRepository : BaseRepository, IDefaultRepository
	{
		public DefaultRepository() : base()
		{
		}
		public ReturnValue ExecuteReturnValue(string query)
		{
			ReturnValue result = new ReturnValue();
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = CommandType.Text;
				result = cmd.ExecuteReturnValue();
			}
		
			return result;
		}
		
		public ReturnValue Erase<T>(string whereStr) where T : IEntity, new()
		{
			var result = new ReturnValue();
			T obj = new T();
			string query = $"delete from {obj.TableName} where {whereStr}".TryReturnValue();
		
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteReturnValue();
			}
			return result;
		}
		
		public List<T> ExecuteModel<T>(string query) where T : IEntity, new()
		{
			List<T> result = new List<T>();
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public T Single<T>(string whereStr, string OrderStr = "") where T : IEntity, new()
		{
			T result = new T();
			string query = result.Select(whereStr, OrderStr);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>().FirstOrDefault();
			}
			return result;
		}
		
		public T Single<T>(string entity, string whereStr, string OrderStr = "") where T : IEntity, new()
		{
			T result = new T();
			string query = DynamicQuery.Select(entity, 1, whereStr, OrderStr);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>().FirstOrDefault();
			}
			return result;
		}
		
		public List<T> Select<T>(string whereStr, string OrderStr = "") where T : IEntity, new()
		{
			List<T> result = new List<T>();
			string query = result.Select(whereStr, OrderStr);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public List<T> Select<T>(string entity, string whereStr, string OrderStr = "") where T : IEntity, new()
		{
			List<T> result = new List<T>();
			string query = DynamicQuery.Select(entity, whereStr, OrderStr);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public List<T> Select<T>(string entity, int TopCount, string whereStr, string OrderStr = "") where T : IEntity, new()
		{
			List<T> result = new List<T>();
			string query = DynamicQuery.Select(entity, TopCount, whereStr, OrderStr);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public List<T> Select<T>(int TopCount, string whereStr, string OrderStr = "") where T : IEntity, new()
		{
			List<T> result = new List<T>();
			string query = DynamicQuery.Select<T>(TopCount, whereStr, OrderStr);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public List<T> Select<T>() where T : IEntity, new()
		{
			List<T> result = new List<T>();
			string query = result.Select();
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public List<T> List<T>(IDynamicQuery paramData) where T : IEntity, new()
		{
			List<T> result = new List<T>();
			string query = paramData.List<T>();
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public List<T> List<T>(string entity, IDynamicQuery paramData) where T : IEntity, new()
		{
			if (string.IsNullOrWhiteSpace(paramData.OrderBy)) throw new ArgumentException("Entity 이름으로 쿼리를 생성할 떈, PagingParamBase 클래스의 OrderBy 인자가 필수값입니다.");
		
			List<T> result = new List<T>();
			string query = DynamicQuery.List(entity, paramData);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public List<T> List<T>(ISubDynamicQuery paramData) where T : IEntity, new()
		{
			List<T> result = new List<T>();
			string query = paramData.List<T>();
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public List<T> List<T>(string entity, ISubDynamicQuery paramData) where T : IEntity, new()
		{
			if (string.IsNullOrWhiteSpace(paramData.OrderBy)) throw new ArgumentException("Entity 이름으로 쿼리를 생성할 떈, PagingParamBase 클래스의 OrderBy 인자가 필수값입니다.");
		
			List<T> result = new List<T>();
			string query = DynamicQuery.List(entity, paramData);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
		
		public int Count<T>(IDynamicQueryBase paramData) where T : IEntity, new()
		{
			int result = 0;
			string query = paramData.Count<T>();
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = Convert.ToInt32(cmd.ExecuteScalar());
			}
			return result;
		}
		
		public int Count<T>(string whereStr) where T : IEntity, new()
		{
			int result = 0;
			string query = DynamicQuery.Count<T>(whereStr);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = Convert.ToInt32(cmd.ExecuteScalar());
			}
			return result;
		}
		
		public int Count(string entity, IDynamicQueryBase paramData)
		{
			int result = 0;
			string query = DynamicQuery.Count(entity, paramData);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = Convert.ToInt32(cmd.ExecuteScalar());
			}
			return result;
		}
		
		public ReturnValue Update<T>(string where, Dictionary<string, object> data) where T : IEntity, new()
		{
			var result = new ReturnValue();
			T obj = new T();
			StringBuilder query = new StringBuilder();
			query.AppendLine($"begin try");
			query.AppendLine($"UPDATE [{obj.TableName}] SET");
			int num = 0;
			foreach (var item in data)
			{
				if (num > 0) query.Append(",");
				query.AppendLine($"[{item.Key}] = @{item.Key}");
				num++;
			}
			query.AppendLine($"where {where}");
			query.AppendLine($"SET @Code = @@ROWCOUNT");
			query.AppendLine($"SET @Value = ''");
			query.AppendLine($"SET @Msg = ''");
			query.AppendLine($"end try");
			query.AppendLine($"begin catch");
			query.AppendLine($"SET @Code = -1");
			query.AppendLine($"SET @Msg = ERROR_MESSAGE()");
			query.AppendLine($"SET @Value = ''");
			query.AppendLine($"end catch");
			if (this.Logger != null) this.Logger.Info(query.ToString());
			using (var cmd = new SqlCommand(query.ToString(), this.SqlConn))
			{
				cmd.CommandType = CommandType.Text;
				foreach (var item in data)
				{
					cmd.AddParameterInput($"@{item.Key}", obj.GetType(item.Key), item.Value, obj.GetSize(item.Key));
				}
				result = cmd.ExecuteReturnValue();
			}
			return result;
		}
		
		public ReturnValue Update<T>(string where, string Key, object Value) where T : IEntity, new()
		{
			var result = new ReturnValue();
			T obj = new T();
			StringBuilder query = new StringBuilder();
			query.AppendLine($"begin try");
			query.AppendLine($"UPDATE [{obj.TableName}] SET");
			query.AppendLine($"[{Key}] = @{Key}");
			query.AppendLine($"where {where}");
			query.AppendLine($"SET @Code = @@ROWCOUNT");
			query.AppendLine($"SET @Value = ''");
			query.AppendLine($"SET @Msg = ''");
			query.AppendLine($"end try");
			query.AppendLine($"begin catch");
			query.AppendLine($"SET @Code = -1");
			query.AppendLine($"SET @Msg = ERROR_MESSAGE()");
			query.AppendLine($"SET @Value = ''");
			query.AppendLine($"end catch");
			if (this.Logger != null) this.Logger.Info(query.ToString());
			using (var cmd = new SqlCommand(query.ToString(), this.SqlConn))
			{
				cmd.CommandType = CommandType.Text;
				cmd.AddParameterInput($"@{Key}", obj.GetType(Key), Value, obj.GetSize(Key));
				result = cmd.ExecuteReturnValue();
			}
			return result;
		}
		
		public ReturnValue Update(string entity, string where, string Key, object Value)
		{
			var result = new ReturnValue();
			StringBuilder query = new StringBuilder();
			query.AppendLine($"begin try");
			query.AppendLine($"UPDATE [{entity}] SET");
			query.AppendLine($"[{Key}] = '{Value}'");
			query.AppendLine($"where {where}");
			query.AppendLine($"SET @Code = @@ROWCOUNT");
			query.AppendLine($"SET @Value = ''");
			query.AppendLine($"SET @Msg = ''");
			query.AppendLine($"end try");
			query.AppendLine($"begin catch");
			query.AppendLine($"SET @Code = -1");
			query.AppendLine($"SET @Msg = ERROR_MESSAGE()");
			query.AppendLine($"SET @Value = ''");
			query.AppendLine($"end catch");
			if (this.Logger != null) this.Logger.Info(query.ToString());
			using (var cmd = new SqlCommand(query.ToString(), this.SqlConn))
			{
				cmd.CommandType = CommandType.Text;
				result = cmd.ExecuteReturnValue();
			}
			return result;
		}
		
		public ReturnValue Update<T>(string entity, string where, Dictionary<string, object> data) where T : IEntity, new()
		{
			var result = new ReturnValue();
			T obj = new T();
			StringBuilder query = new StringBuilder();
			query.AppendLine($"begin try");
			query.AppendLine($"UPDATE [{entity}] SET");
			int num = 0;
			foreach (var item in data)
			{
				if (num > 0) query.Append(",");
				query.AppendLine($"[{item.Key}] = @{item.Key}");
				num++;
			}
			query.AppendLine($"where {where}");
			query.AppendLine($"SET @Code = @@ROWCOUNT");
			query.AppendLine($"SET @Value = ''");
			query.AppendLine($"SET @Msg = ''");
			query.AppendLine($"end try");
			query.AppendLine($"begin catch");
			query.AppendLine($"SET @Code = -1");
			query.AppendLine($"SET @Msg = ERROR_MESSAGE()");
			query.AppendLine($"SET @Value = ''");
			query.AppendLine($"end catch");
			if (this.Logger != null) this.Logger.Info(query.ToString());
			using (var cmd = new SqlCommand(query.ToString(), this.SqlConn))
			{
				cmd.CommandType = CommandType.Text;
				foreach (var item in data)
				{
					cmd.AddParameterInput($"@{item.Key}", obj.GetType(item.Key), item.Value, obj.GetSize(item.Key));
				}
				result = cmd.ExecuteReturnValue();
			}
			return result;
		}
		
		public List<T> GroupBy<T>(string ValueColumn, string whereStr = "") where T : IEntity, new()
		{
			List<T> result = new List<T>();
			string query = DynamicQuery.GroupBy<T>(ValueColumn, whereStr);
			if (this.Logger != null) this.Logger.Info(query);
			using (var cmd = new SqlCommand(query, this.SqlConn))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				result = cmd.ExecuteList<T>();
			}
			return result;
		}
	}
}

