using System.Data.SqlClient;
using System.Collections.Generic;

namespace TheGiftList.DATA.Repositories
{
    public interface IConnection
    {
        int ExecuteNonQuery(string sql, List<SqlParameter> sqlParams = null);
        SqlDataReader ExecuteReader(string sql, List<SqlParameter> sqlParams = null);
        object ExecuteScalar(string sql, List<SqlParameter> sqlParams = null);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
