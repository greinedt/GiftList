using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";
        
        public IList<GroupMember> GetAllGroupMembers(int group)
        {
            List<GroupMember> groupMemberList = new List<GroupMember>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT groupMemberId, groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK FROM DBO.GROUPMEMBER WHERE groupFK = @groupFK;";
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
                    var groupMember = new GroupMember()
                    {
                        groupMemberId = rdr.IsDBNull(rdr.GetOrdinal("groupMemberId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupMemberId")),
                        groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                        memberFK = rdr.IsDBNull(rdr.GetOrdinal("memberFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("memberFK")),
                        isAdmin = rdr.IsDBNull(rdr.GetOrdinal("isAdmin")) ? false : (rdr.GetString(rdr.GetOrdinal("isAdmin")) == "Y"),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    groupMemberList.Add(groupMember);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return groupMemberList;
        }

        public GroupMember GetGroupMember(int group, int member)
        {
            List<GroupMember> groupMemberList = new List<GroupMember>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT groupMemberId, groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK FROM DBO.GROUPMEMBER WHERE groupFK = @groupFK and itemFK = @itemFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramItem = new SqlParameter
                {
                    ParameterName = "@groupFK",
                    Value = group
                };
                cmd.Parameters.Add(paramItem);

                var paramName = new SqlParameter
                {
                    ParameterName = "@memberFK",
                    Value = member
                };
                cmd.Parameters.Add(paramName);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var groupMember = new GroupMember()
                    {
                        groupMemberId = rdr.IsDBNull(rdr.GetOrdinal("groupMemberId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupMemberId")),
                        groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                        memberFK = rdr.IsDBNull(rdr.GetOrdinal("memberFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("memberFK")),
                        isAdmin = rdr.IsDBNull(rdr.GetOrdinal("isAdmin")) ? false : (rdr.GetString(rdr.GetOrdinal("isAdmin")) == "Y"),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    groupMemberList.Add(groupMember);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return groupMemberList.FirstOrDefault();
        }

        public GroupMember GetGroupMemberById(int id)
        {
            List<GroupMember> groupMemberList = new List<GroupMember>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT groupMemberId, groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK FROM DBO.GROUPMEMBER WHERE groupMemberId = @id;";
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
                    var groupMember = new GroupMember()
                    {
                        groupMemberId = rdr.IsDBNull(rdr.GetOrdinal("groupMemberId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupMemberId")),
                        groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                        memberFK = rdr.IsDBNull(rdr.GetOrdinal("memberFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("memberFK")),
                        isAdmin = rdr.IsDBNull(rdr.GetOrdinal("isAdmin")) ? false : (rdr.GetString(rdr.GetOrdinal("isAdmin")) == "Y"),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    groupMemberList.Add(groupMember);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return groupMemberList.FirstOrDefault();
        }

        public long GetNumberOfGroupMembers(int group)
        {
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(groupMemberId) FROM DBO.GROUPMEMBER WHERE groupFK = @groupFK;";
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

        public bool GroupMemberExists(int group, int member)
        {
            try
            {
                string sql = "SELECT groupMemberId, groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK FROM DBO.GROUPMEMBER WHERE groupFK = @groupFK and itemFK = @itemFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramItem = new SqlParameter
                {
                    ParameterName = "@groupFK",
                    Value = group
                };
                cmd.Parameters.Add(paramItem);

                var paramName = new SqlParameter
                {
                    ParameterName = "@memberFK",
                    Value = member
                };
                cmd.Parameters.Add(paramName);

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public long Insert(GroupMember groupMember)
        {
            CheckGroupMemberForRequiredValues(groupMember, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                var groupMemberExists = GetGroupMember(groupMember.groupFK, groupMember.memberFK);
                if (groupMemberExists != null)
                {
                    throw new Exception($"Entity {groupMember.groupFK} {groupMember.memberFK} already exists in database!");
                }
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO[dbo].[link] (groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK) 
                    VALUES(@groupFK, @memberFK, @isAdmin, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@groupFK", SqlDbType.Int);
                cmd.Parameters["@groupFK"].Value = groupMember.groupFK;

                cmd.Parameters.Add("@memberFK", SqlDbType.Int);
                cmd.Parameters["@memberFK"].Value = groupMember.memberFK;

                cmd.Parameters.Add("@isAdmin", SqlDbType.Char);
                cmd.Parameters["@isAdmin"].Value = groupMember.isAdmin ? 'Y' : 'N';

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = groupMember.updatePersonFK;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"Entity {groupMember.groupFK} {groupMember.memberFK} not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Update(int id, GroupMember groupMember)
        {
            CheckGroupMemberForRequiredValues(groupMember, RepositoryUtils.RepositoryAction.Update);

            var linkToUpdate = GetGroupMemberById(groupMember.groupMemberId);
            if (linkToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE person SET [groupFK]=@groupFK, 
                                                      [memberFK]=@memberFK, 
                                                      [isAdmin]=@isAdmin, 
                                                      [updateTimeStamp]=getdate(),
                                                      [updatePersonFK]=@updatePersonFK
                                                      WHERE groupMemberId=@groupMemberId";

                cmd.Parameters.Add("@groupMemberId", SqlDbType.Int);
                cmd.Parameters["@groupMemberId"].Value = groupMember.groupMemberId;

                cmd.Parameters.Add("@groupFK", SqlDbType.Int);
                cmd.Parameters["@groupFK"].Value = groupMember.groupFK;

                cmd.Parameters.Add("@memberFK", SqlDbType.VarChar);
                cmd.Parameters["@memberFK"].Value = groupMember.memberFK;
                
                cmd.Parameters.Add("@isAdmin", SqlDbType.Char);
                cmd.Parameters["@isAdmin"].Value = groupMember.isAdmin ? 'Y' : 'N';

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = groupMember.updatePersonFK;

                _conn.Open();

                var number = cmd.ExecuteNonQuery();

                if (number != 1)
                {
                    throw new Exception($"No GroupMembers were updated with Id: {id}");
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
            sqlComm.CommandText = @"DELETE FROM groupMember WHERE [groupMemberId] = @Id;";
            sqlComm.Parameters.Add("@Id", SqlDbType.Int);
            sqlComm.Parameters["@Id"].Value = id;

            _conn.Open();

            var rowsAffected = sqlComm.ExecuteNonQuery();

            _conn.Close();

            if (rowsAffected < 1)
            {
                throw new Exception("GroupMember has not been deleted!");
            }
        }


        private void CheckGroupMemberForRequiredValues(GroupMember gm, RepositoryUtils.RepositoryAction action)
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
