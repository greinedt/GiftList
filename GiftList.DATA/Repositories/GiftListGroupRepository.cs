using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class ListGroupRepository : IGiftListGroupRepository
    {
        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public IList<GiftListGroup> GetAllGiftListGroups(int group)
        {
            List<GiftListGroup> giftListGrouplist = new List<GiftListGroup>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT giftListGroupId, giftListFK, groupFK, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE groupFK = @groupFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@groupFK",
                    Value = group
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var giftListGroup = new GiftListGroup()
                    {
                        giftListGroupId = rdr.IsDBNull(rdr.GetOrdinal("giftListGroupId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListGroupId")),
                        giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                        groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    giftListGrouplist.Add(giftListGroup);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return giftListGrouplist;
        }

        public GiftListGroup GetGiftListGroup(int giftList, int group)
        {
            List<GiftListGroup> giftListGrouplist = new List<GiftListGroup>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT giftListGroupId, giftListFK, groupFK, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE groupFK = @groupFK and giftListFK = @giftListFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramGiftList = new SqlParameter
                {
                    ParameterName = "@giftListFK",
                    Value = giftList
                };
                cmd.Parameters.Add(paramGiftList);

                var paramGroup = new SqlParameter
                {
                    ParameterName = "@groupFK",
                    Value = group
                };
                cmd.Parameters.Add(paramGroup);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var giftListGroup = new GiftListGroup()
                    {
                        giftListGroupId = rdr.IsDBNull(rdr.GetOrdinal("giftListGroupId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListGroupId")),
                        giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                        groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    giftListGrouplist.Add(giftListGroup);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return giftListGrouplist.FirstOrDefault();
        }

        public GiftListGroup GetGiftListGroupById(int id)
        {
            List<GiftListGroup> giftListGrouplist = new List<GiftListGroup>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT giftListGroupId, giftListFK, groupFK, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE giftListGroupId = @id;";
                var cmd = new SqlCommand(sql, _conn);

                var paramId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                cmd.Parameters.Add(paramId);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var giftListGroup = new GiftListGroup()
                    {
                        giftListGroupId = rdr.IsDBNull(rdr.GetOrdinal("giftListGroupId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListGroupId")),
                        giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                        groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    giftListGrouplist.Add(giftListGroup);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return giftListGrouplist.FirstOrDefault();
        }

        public long GetNumberOfGiftListGroups(int group)
        {
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(giftListGroupId) FROM DBO.GIFTLISTGROUP WHERE groupFK = @groupFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@groupFK",
                    Value = group
                };
                cmd.Parameters.Add(paramQuery);

                return Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                _conn?.Close();
            }
        }

        public bool GiftListGroupExists(int giftList, int group)
        {
            try
            {
                const string sql = "SELECT COUNT([giftListGroupId]) FROM dbo.giftListGroup WHERE giftListFK = @giftListFK AND groupFK = @groupFK;";

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                var cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.Add("@giftListFK", SqlDbType.Int);
                cmd.Parameters["@giftListFK"].Value = giftList;

                cmd.Parameters.Add("@groupFK", SqlDbType.Int);
                cmd.Parameters["@groupFK"].Value = group;

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public long Insert(GiftListGroup giftListGroup)
        {
            CheckGiftListGroupForRequiredValues(giftListGroup, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                var giftListGroupExists = GetGiftListGroup(giftListGroup.giftListFK, giftListGroup.groupFK);
                if (giftListGroupExists != null)
                {
                    throw new Exception($"Gift List Group {giftListGroup.giftListFK} {giftListGroup.groupFK} already exists in database!");
                }
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO[dbo].[giftListGroup] (giftListFK, groupFK, updateTimestamp, updatePersonFK) 
                    VALUES(@giftListFK, @groupFK, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@giftListFK", SqlDbType.Int);
                cmd.Parameters["@giftListFK"].Value = giftListGroup.giftListFK;

                cmd.Parameters.Add("@groupFK", SqlDbType.Int);
                cmd.Parameters["@groupFK"].Value = giftListGroup.groupFK;

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = giftListGroup.updatePersonFK;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"Entity {giftListGroup.giftListFK} {giftListGroup.groupFK} not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Update(int id, GiftListGroup giftListGroup)
        {
            CheckGiftListGroupForRequiredValues(giftListGroup, RepositoryUtils.RepositoryAction.Update);

            var giftListGroupToUpdate = GetGiftListGroupById(giftListGroup.giftListGroupId);
            if (giftListGroupToUpdate == null)
            {
                throw new Exception("Gift List does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE person SET [giftListFK]=@giftListFK, 
                                                      [groupFK]=@groupFK, 
                                                      [updateTimeStamp]=getdate(),
                                                      [updatePersonFK]=@updatePersonFK
                                                      WHERE giftListGroupId=@giftListGroupId";

                cmd.Parameters.Add("@giftListFK", SqlDbType.Int);
                cmd.Parameters["@giftListFK"].Value = giftListGroup.giftListFK;

                cmd.Parameters.Add("@groupFK", SqlDbType.Int);
                cmd.Parameters["@groupFK"].Value = giftListGroup.groupFK;

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = giftListGroup.updatePersonFK;
                
                cmd.Parameters.Add("@giftListGroupId", SqlDbType.Int);
                cmd.Parameters["@giftListGroupId"].Value = giftListGroup.giftListGroupId;

                _conn.Open();

                var number = cmd.ExecuteNonQuery();

                if (number != 1)
                {
                    throw new Exception($"No Gift Lsits were updated with Id: {id}");
                }
            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Delete(int id)
        {
            _conn = new SqlConnection(ConnString);

            var sqlComm = _conn.CreateCommand();
            sqlComm.CommandText = @"DELETE FROM giftlistGroup WHERE [giftListGroupId] = @Id;";
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

        private void CheckGiftListGroupForRequiredValues(GiftListGroup glg, RepositoryUtils.RepositoryAction action)
        {
            List<string> missingFields = new List<string>();

            //if (String.IsNullOrWhiteSpace(p.userName)) missingFields.Add("User Name");
            //if (String.IsNullOrWhiteSpace(p.emailAddress)) missingFields.Add("Email Address");
            //if (String.IsNullOrWhiteSpace(p.firstName)) missingFields.Add("First Name");
            //if (String.IsNullOrWhiteSpace(p.lastName)) missingFields.Add("Last Name");
            //if (String.IsNullOrWhiteSpace(p.passwordHash)) missingFields.Add("Password");

            if (missingFields.Count > 0)
            {
                throw new Exception(String.Format("Cannot {0} Link: Missing Fields {1}", action.ToString(), String.Join(", ", missingFields.ToArray())));
            }
        }
    }
}
