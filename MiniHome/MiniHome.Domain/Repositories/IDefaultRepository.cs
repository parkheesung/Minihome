using System.Collections.Generic;
using OctopusV3.Core;

namespace MiniHome.Domain
{
	public interface IDefaultRepository : IBaseRepository
	{
		ReturnValue ExecuteReturnValue(string query);
		
		ReturnValue Erase<T>(string whereStr) where T : IEntity, new();
		
		List<T> ExecuteModel<T>(string query) where T : IEntity, new();
		
		T Single<T>(string whereStr, string OrderStr = "") where T : IEntity, new();
		
		T Single<T>(string entity, string whereStr, string OrderStr = "") where T : IEntity, new();
		
		List<T> Select<T>(string whereStr, string OrderStr = "") where T : IEntity, new();
		
		List<T> Select<T>(string entity, string whereStr, string OrderStr = "") where T : IEntity, new();
		
		List<T> Select<T>(string entity, int TopCount, string whereStr, string OrderStr = "") where T : IEntity, new();
		
		List<T> Select<T>(int TopCount, string whereStr, string OrderStr = "") where T : IEntity, new();
		
		List<T> Select<T>() where T : IEntity, new();
		
		List<T> List<T>(IDynamicQuery paramData) where T : IEntity, new();
		
		List<T> List<T>(string entity, IDynamicQuery paramData) where T : IEntity, new();
		
		List<T> List<T>(ISubDynamicQuery paramData) where T : IEntity, new();
		
		List<T> List<T>(string entity, ISubDynamicQuery paramData) where T : IEntity, new();
		
		int Count<T>(IDynamicQueryBase paramData) where T : IEntity, new();
		
		int Count<T>(string whereStr) where T : IEntity, new();
		
		int Count(string entity, IDynamicQueryBase paramData);
		
		ReturnValue Update<T>(string where, Dictionary<string, object> data) where T : IEntity, new();
		
		ReturnValue Update<T>(string where, string Key, object Value) where T : IEntity, new();
		
		ReturnValue Update(string entity, string where, string Key, object Value);
		
		ReturnValue Update<T>(string entity, string where, Dictionary<string, object> data) where T : IEntity, new();
		
		List<T> GroupBy<T>(string ValueColumn, string whereStr = "") where T : IEntity, new();
	}
}

