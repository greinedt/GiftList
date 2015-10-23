using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories.Interfaces
{
    public class GroupRepository : IGroupRepository
    {

        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public IList<Group> GetAllGroups(int creator)
        {
            List<Group> groupList = new List<Group>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT groupId, creatorFK, groupName, description, isPrivate, updateTimestamp, updatePersonFK FROM dbo.[group] WHERE creatorFK = @creatorFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@creatorFK",
                    Value = creator
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var group = new Group()
                    {
                        groupId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                        creatorFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        groupName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                        desription = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                        isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : (rdr.GetString(rdr.GetOrdinal("isImage")) == "Y"),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonKey")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonKey"))
                    };
                    groupList.Add(group);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return groupList;
        }

        public Group GetGroup(int creator, string groupName)
        {
            List<Group> grouplist = new List<Group>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT groupId, creatorFK, groupName, description, isPrivate, updateTimestamp, updatePersonFK FROM dbo.[group] WHERE creatorFK = @creatorFK and groupName = @groupName;";
                var cmd = new SqlCommand(sql, _conn);

                var paramItem = new SqlParameter
                {
                    ParameterName = "@creatorFK",
                    Value = creator
                };
                cmd.Parameters.Add(paramItem);

                var paramName = new SqlParameter
                {
                    ParameterName = "@groupName",
                    Value = groupName
                };
                cmd.Parameters.Add(paramName);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var group = new Group()
                    {
                        groupId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                        creatorFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        groupName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                        desription = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                        isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : (rdr.GetString(rdr.GetOrdinal("isImage")) == "Y"),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonKey")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonKey"))
                    };
                    grouplist.Add(group);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return grouplist.FirstOrDefault();
        }

        public Group GetGroupById(int id)
        {
            List<Group> grouplist = new List<Group>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT groupId, creatorFK, groupName, description, isPrivate, updateTimestamp, updatePersonFK FROM dbo.[group] WHERE groupId = @id;";
                var cmd = new SqlCommand(sql, _conn);
                
                var paramName = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                cmd.Parameters.Add(paramName);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var group = new Group()
                    {
                        groupId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                        creatorFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        groupName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                        desription = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                        isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : (rdr.GetString(rdr.GetOrdinal("isImage")) == "Y"),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonKey")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonKey"))
                    };
                    grouplist.Add(group);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return grouplist.FirstOrDefault();
        }

        public long GetNumberOfGroups(int creator)
        {
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(groupId) FROM dbo.[group] WHERE creatorFK = @creatorFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@creatorFK",
                    Value = creator
                };
                cmd.Parameters.Add(paramQuery);

                return Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                _conn?.Close();
            }
        }

        public bool GroupExists(int creator, string groupName)
        {
            try
            {
                const string sql = "SELECT COUNT([groupId]) FROM dbo.[group] WHERE creatorFK = @creatorFK AND groupName = @groupName;";

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                var cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.Add("@creatorFK", SqlDbType.Int);
                cmd.Parameters["@creatorFK"].Value = creator;

                cmd.Parameters.Add("@groupName", SqlDbType.VarChar);
                cmd.Parameters["@groupName"].Value = groupName;

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public long Insert(Group group)
        {
            CheckGroupForRequiredValues(group, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                var groupExists = GetGroup(group.creatorFK, group.groupName);
                if (groupExists != null)
                {
                    throw new Exception($"Entity {group.creatorFK} {group.groupName} already exists in database!");
                }
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO[dbo].[link] (creatorFK, groupName, description, isPrivate, updateTimestamp, updatePersonFK) 
                    VALUES(@creatorFK, @groupName, @description, @isPrivate, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@creatorFK", SqlDbType.Int);
                cmd.Parameters["@creatorFK"].Value = group.creatorFK;

                cmd.Parameters.Add("@groupName", SqlDbType.VarChar);
                cmd.Parameters["@groupName"].Value = group.groupName;

                cmd.Parameters.Add("@description", SqlDbType.VarChar);
                cmd.Parameters["@description"].Value = group.description;

                cmd.Parameters.Add("@isPrivate", SqlDbType.Char);
                cmd.Parameters["@isPrivate"].Value = group.isPrivate ? 'Y' : 'N';

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = group.updatePersonFK;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());s
                }
                catch (Exception)
                {
                    throw new Exception($"Entity {group.creatorFK} {group.groupName} not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Update(int id, Group group)
        {
            CheckGroupForRequiredValues(group, RepositoryUtils.RepositoryAction.Update);

            var linkToUpdate = GetGroupById(group.linkId);
            if (linkToUpdate == null)
            {
                throw new Exception("Group does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE person SET [creatorFK]=@creatorFK, 
                                                      [groupName]=@groupName, 
                                                      [description]=@description, 
                                                      [isPrivate]=@isPrivate, 
                                                      [updateTimeStamp]=getdate(),
                                                      [updatePersonFK]=@updatePersonFK
                                                      WHERE groupId=@groupId";

                cmd.Parameters.Add("@creatorFK", SqlDbType.Int);
                cmd.Parameters["@creatorFK"].Value = group.creatorFK;

                cmd.Parameters.Add("@groupName", SqlDbType.Int);
                cmd.Parameters["@groupName"].Value = group.groupName;

                cmd.Parameters.Add("@description", SqlDbType.VarChar);
                cmd.Parameters["@description"].Value = group.description;

                cmd.Parameters.Add("@groupId", SqlDbType.Int);
                cmd.Parameters["@groupId"].Value = group.groupId;

                cmd.Parameters.Add("@isPrivate", SqlDbType.Char);
                cmd.Parameters["@isPrivate"].Value = group.isPrivate ? 'Y' : 'N';

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = group.updatePersonFK;

                _conn.Open();

                var number = cmd.ExecuteNonQuery();

                if (number != 1)
                {
                    throw new Exception($"No Groups were updated with Id: {id}");
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
            sqlComm.CommandText = @"DELETE FROM [group] WHERE [groupId] = @Id;";
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

        private void CheckGroupForRequiredValues(Group g, RepositoryUtils.RepositoryAction action)
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
