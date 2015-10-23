using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class ItemStatusRepository : IItemStatusRepository
    {
        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public void Delete(int id)
        {
            _conn = new SqlConnection(ConnString);

            var sqlComm = _conn.CreateCommand();
            sqlComm.CommandText = @"DELETE FROM itemStatus WHERE [itemStatusId] = @Id;";
            sqlComm.Parameters.Add("@Id", SqlDbType.Int);
            sqlComm.Parameters["@Id"].Value = id;

            _conn.Open();

            var rowsAffected = sqlComm.ExecuteNonQuery();

            _conn.Close();

            if (rowsAffected < 1)
            {
                throw new Exception("Entity has not been deleted!");
            }
        }

        public IList<ItemStatus> GetAllItemStatuss()
        {
            List<ItemStatus> itemStatusList = new List<ItemStatus>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemStatusUd, status, updateTimeStamp, updatePersonFK FROM DBO.itemStatus;";
                var cmd = new SqlCommand(sql, _conn);
                
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var itemStatus = new ItemStatus()
                    {
                        itemStatusId = rdr.IsDBNull(rdr.GetOrdinal("itemStatusId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemStatusId")),
                        status = rdr.IsDBNull(rdr.GetOrdinal("status")) ? null : rdr.GetString(rdr.GetOrdinal("status")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemStatusList.Add(itemStatus);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemStatusList;
        }

        public ItemStatus GetItemStatusByStatusName(string status)
        {
            List<ItemStatus> itemStatusList = new List<ItemStatus>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemStatusUd, status, updateTimeStamp, updatePersonFK FROM DBO.itemStatus WHERE status = @status;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = "%" + status + "%"
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var itemStatus = new ItemStatus()
                    {
                        itemStatusId = rdr.IsDBNull(rdr.GetOrdinal("itemStatusId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemStatusId")),
                        status = rdr.IsDBNull(rdr.GetOrdinal("status")) ? null : rdr.GetString(rdr.GetOrdinal("status")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemStatusList.Add(itemStatus);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemStatusList.FirstOrDefault();
        }

        public ItemStatus GetItemStatusById(int id)
        {
            List<ItemStatus> itemStatusList = new List<ItemStatus>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemStatusUd, status, updateTimeStamp, updatePersonFK FROM DBO.itemStatus WHERE itemStatusId = @id;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = "%" + id + "%"
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var itemStatus = new ItemStatus()
                    {
                        itemStatusId = rdr.IsDBNull(rdr.GetOrdinal("itemStatusId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemStatusId")),
                        status = rdr.IsDBNull(rdr.GetOrdinal("status")) ? null : rdr.GetString(rdr.GetOrdinal("status")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemStatusList.Add(itemStatus);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemStatusList.FirstOrDefault();
        }

        public long GetNumberOfItemStatus()
        {
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(itemStatusId) FROM dbo.itemStatus;";
                var cmd = new SqlCommand(sql, _conn);

                return Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                _conn?.Close();
            }
        }

        public long Insert(ItemStatus itemStatus)
        {
            CheckItemStatusForRequiredValues(itemStatus, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                var contactExists = GetItemStatusByStatusName(itemStatus.status);
                if (contactExists != null)
                {
                    throw new Exception($"Entity {itemStatus.status} already exists in database!");
                }
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO[dbo].[itemStatus] (status, updateTimestamp, updatePersonFK) 
                    VALUES(@status, getdate(), @updatePersonFK);SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@status", SqlDbType.VarChar);
                cmd.Parameters["@status"].Value = itemStatus.status;

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = itemStatus.updatePersonFK;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"ItemStatus {itemStatus.status} not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }

        public bool ItemStatusExists(string status)
        {
            try
            {
                const string sql = "SELECT COUNT([itemStatusId]) FROM dbo.itemStatus WHERE status = @status;";

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                var cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.Add("@status", SqlDbType.VarChar);
                cmd.Parameters["@status"].Value = status;

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Update(int id, ItemStatus itemStatus)
        {
            CheckItemStatusForRequiredValues(itemStatus, RepositoryUtils.RepositoryAction.Update);

            var contactToUpdate = GetItemStatusById(id);
            if (contactToUpdate == null)
            {
                throw new Exception("ItemStatus does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE person SET [status]=@status, 
                                                      [updateTimeStamp]=getdate(),
                                                      [updatePersonFK]=@updatePersonFK
                                                      WHERE personId=@Id";

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = id;

                cmd.Parameters.Add("@status", SqlDbType.VarChar);
                cmd.Parameters["@status"].Value = itemStatus.status;

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = itemStatus.updatePersonFK;
                
                _conn.Open();

                var number = cmd.ExecuteNonQuery();

                if (number != 1)
                {
                    throw new Exception($"No Contacts were updated with Id: {id}");
                }
            }
            finally
            {
                _conn?.Close();
            }
        }

        private void CheckItemStatusForRequiredValues(ItemStatus status, RepositoryUtils.RepositoryAction action)
        {
            List<string> missingFields = new List<string>();

            //if (String.IsNullOrWhiteSpace(p.userName)) missingFields.Add("User Name");
            //if (String.IsNullOrWhiteSpace(p.emailAddress)) missingFields.Add("Email Address");
            //if (String.IsNullOrWhiteSpace(p.firstName)) missingFields.Add("First Name");
            //if (String.IsNullOrWhiteSpace(p.lastName)) missingFields.Add("Last Name");
            //if (String.IsNullOrWhiteSpace(p.passwordHash)) missingFields.Add("Password");

            if (missingFields.Count > 0)
            {
                throw new Exception(String.Format("Cannot {0} ItemStatus: Missing Fields {1}", action.ToString(), String.Join(", ", missingFields.ToArray())));
            }
        }
    }
}
