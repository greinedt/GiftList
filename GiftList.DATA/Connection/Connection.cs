using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace TheGiftList.DATA.Repositories
{
    public class Connection : IConnection, IDisposable
    {
        private SqlConnection _conn;
        private SqlTransaction _tran;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public Connection()
        {
            _conn = new SqlConnection(ConnString);
            _tran = null;
        }
        
        public int ExecuteNonQuery(string sql, List<SqlParameter> sqlParams = null)
        {
            if(sqlParams == null)
            {
                sqlParams = new List<SqlParameter>();
            }
            SqlCommand cmd = new SqlCommand(sql, _conn);
            if(_tran != null)
            {
                cmd.Transaction = _tran;
            }
            foreach(SqlParameter param in sqlParams)
            {
                cmd.Parameters.Add(param);
            }
            return cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string sql, List<SqlParameter> sqlParams = null)
        {
            if (sqlParams == null)
            {
                sqlParams = new List<SqlParameter>();
            }
            SqlCommand cmd = new SqlCommand(sql, _conn);
            if (_tran != null)
            {
                cmd.Transaction = _tran;
            }
            foreach (SqlParameter param in sqlParams)
            {
                cmd.Parameters.Add(param);
            }
            return cmd.ExecuteReader();
        }

        public object ExecuteScalar(string sql, List<SqlParameter> sqlParams = null)
        {
            if (sqlParams == null)
            {
                sqlParams = new List<SqlParameter>();
            }
            SqlCommand cmd = new SqlCommand(sql, _conn);
            if (_tran != null)
            {
                cmd.Transaction = _tran;
            }
            foreach (SqlParameter param in sqlParams)
            {
                cmd.Parameters.Add(param);
            }
            return cmd.ExecuteScalar();
        }

        public void BeginTransaction()
        {
            if (_tran == null)
            {
                _tran = _conn.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            if(_tran != null)
            {
                _tran.Commit();
                _tran = null;
            }
        }

        public void RollbackTransaction()
        {
            if(_tran != null)
            {
                _tran.Rollback();
                _tran = null;
            }
        }

        public void Dispose()
        {
            RollbackTransaction();
            _conn.Close();
        }
    }
}
