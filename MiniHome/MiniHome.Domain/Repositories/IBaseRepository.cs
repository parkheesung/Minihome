using System.Data;
using System.Data.SqlClient;
using OctopusV3.Core;

namespace MiniHome.Domain
{
	public interface IBaseRepository
	{
		SqlConnection SqlConn { get; set; }

		ILogHelper Logger { get; set; }

		SqlConnection Connection { get; set; }

		void Open(string connStr);

		void Close();

		void Dispose();

		DataTable ExecuteTable(string query);

		int ExecuteCount(string query);
	}
}

