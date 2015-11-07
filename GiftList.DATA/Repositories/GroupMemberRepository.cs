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
        public IList<GroupMemberEntity> GetAllGroupMembers()
        {
            using (Connection conn = new Connection())
            {
                return GetAllGroupMembers(conn);
            }
        }

        public IList<GroupMemberEntity> GetAllGroupMembers(IConnection conn)
        {
            List<GroupMemberEntity> groupMemberList = new List<GroupMemberEntity>();
            
            string sql = "SELECT groupMemberId, groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK FROM DBO.GROUPMEMBER;";
                
            var rdr = conn.ExecuteReader(sql);
            while (rdr.Read())
            {
                var groupMember = new GroupMemberEntity()
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
            
            return groupMemberList;
        }

        public IList<GroupMemberEntity> GetAllGroupMembers(int group)
        {
            using (Connection conn = new Connection())
            {
                return GetAllGroupMembers(group, conn);
            }
        }

        public IList<GroupMemberEntity> GetAllGroupMembers(int group, IConnection conn)
        {
            List<GroupMemberEntity> groupMemberList = new List<GroupMemberEntity>();

            string sql = "SELECT groupMemberId, groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK FROM DBO.GROUPMEMBER WHERE groupFK = @groupFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = group
            };
            prms.Add(param1);

            var rdr = conn.ExecuteReader(sql,prms);

            while (rdr.Read())
            {
                var groupMember = new GroupMemberEntity()
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
            return groupMemberList;
        }

        public GroupMemberEntity GetGroupMember(int group, int member)
        {
            using (Connection conn = new Connection())
            {
                return GetGroupMember(group, member, conn);
            }
        }

        public GroupMemberEntity GetGroupMember(int group, int member, IConnection conn)
        {
            List<GroupMemberEntity> groupMemberList = new List<GroupMemberEntity>();

            string sql = "SELECT groupMemberId, groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK FROM DBO.GROUPMEMBER WHERE groupFK = @groupFK and itemFK = @itemFK;";
            List<SqlParameter> prms = new List<SqlParameter>();    

            var param1 = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = group
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@memberFK",
                Value = member
            };
            prms.Add(param2);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var groupMember = new GroupMemberEntity()
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
            
            return groupMemberList.FirstOrDefault();
        }

        public GroupMemberEntity GetGroupMemberById(int id)
        {
            using (Connection conn = new Connection())
            {
                return GetGroupMemberById(id, conn);
            }
        }

        public GroupMemberEntity GetGroupMemberById(int id, IConnection conn)
        {
            List<GroupMemberEntity> groupMemberList = new List<GroupMemberEntity>();

            string sql = "SELECT groupMemberId, groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK FROM DBO.GROUPMEMBER WHERE groupMemberId = @id;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@id",
                Value = id
            };
            prms.Add(param1);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var groupMember = new GroupMemberEntity()
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

            return groupMemberList.FirstOrDefault();
        }
        
        public long GetNumberOfGroupMembers(int group)
        {
            using (Connection conn = new Connection())
            {
                return GetNumberOfGroupMembers(group, conn);
            }
        }

        public long GetNumberOfGroupMembers(int group, IConnection conn)
        {
            string sql = "SELECT COUNT(groupMemberId) FROM DBO.GROUPMEMBER WHERE groupFK = @groupFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = group
            };
            prms.Add(param1);

            return Int32.Parse(conn.ExecuteScalar(sql,prms).ToString());
        }


        public bool GroupMemberExists(int group, int member)
        {
            using (Connection conn = new Connection())
            {
                return GroupMemberExists(group, member, conn);
            }
        }

        public bool GroupMemberExists(int group, int member, IConnection conn)
        {
            string sql = "SELECT groupMemberId, groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK FROM DBO.GROUPMEMBER WHERE groupFK = @groupFK and itemFK = @itemFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = group
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@memberFK",
                Value = member
            };
            prms.Add(param2);
                
            return ((int)conn.ExecuteScalar(sql,prms) >= 1);
        }

        public long Insert(GroupMemberEntity groupMember)
        {
            using (Connection conn = new Connection())
            {
                return Insert(groupMember, conn);
            }
        }

        public long Insert(GroupMemberEntity groupMember, IConnection conn)
        {
            CheckGroupMemberForRequiredValues(groupMember, RepositoryUtils.RepositoryAction.Insert);

            var groupMemberExists = GetGroupMember(groupMember.groupFK, groupMember.memberFK);
            if (groupMemberExists != null)
            {
                throw new Exception($"Entity {groupMember.groupFK} {groupMember.memberFK} already exists in database!");
            }

            string sql =
                @"INSERT INTO[dbo].[link] (groupFK, memberFK, isAdmin, updateTimestamp, updatePersonFK) 
                VALUES(@groupFK, @memberFK, @isAdmin, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = groupMember.groupFK
             };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@memberFK",
                Value = groupMember.memberFK
            };
            prms.Add(param2);

            var param3 = new SqlParameter
            {
                ParameterName = "@isAdmin",
                Value = groupMember.isAdmin ? 'Y' : 'N'
            };
            prms.Add(param3);

            var param4 = new SqlParameter
            {
                ParameterName = "@updatePersonFK",
                Value = groupMember.updatePersonFK
            };
            prms.Add(param4);
            
            try
            {
                return int.Parse(conn.ExecuteScalar(sql,prms).ToString());
            }
            catch (Exception)
            {
                throw new Exception($"Entity {groupMember.groupFK} {groupMember.memberFK} not inserted in database!");
            }
        }

        public void Update(int id, GroupMemberEntity groupMember)
        {
            using (Connection conn = new Connection())
            {
                Update(id, groupMember, conn);
            }
        }

        public void Update(int id, GroupMemberEntity groupMember, IConnection conn)
        {
            CheckGroupMemberForRequiredValues(groupMember, RepositoryUtils.RepositoryAction.Update);

            var linkToUpdate = GetGroupMemberById(groupMember.groupMemberId);
            if (linkToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }
            
            string sql = @"UPDATE person SET [groupFK]=@groupFK, 
                                                    [memberFK]=@memberFK, 
                                                    [isAdmin]=@isAdmin, 
                                                    [updateTimestamp]=getdate(),
                                                    [updatePersonFK]=@updatePersonFK
                                                    WHERE groupMemberId=@groupMemberId";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@groupMemberId",
                Value = groupMember.groupMemberId
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = groupMember.groupFK
            };
            prms.Add(param2);

            var param3 = new SqlParameter
            {
                ParameterName = "@memberFK",
                Value = groupMember.memberFK
            };
            prms.Add(param3);

            var param4 = new SqlParameter
            {
                ParameterName = "@isAdmin",
                Value = groupMember.isAdmin ? 'Y' : 'N'
            };
            prms.Add(param4);

            var param5 = new SqlParameter
            {
                ParameterName = "@updatePersonFK",
                Value = groupMember.updatePersonFK
            };
            prms.Add(param5);
                
            var number = conn.ExecuteNonQuery(sql,prms);

            if (number != 1)
            {
                throw new Exception($"No GroupMembers were updated with Id: {id}");
            }
        }

        public void Delete(int id)
        {
            using (Connection conn = new Connection())
            {
                Delete(id, conn);
            }
        }

        public void Delete(int id, IConnection conn)
        {
            string sql = @"DELETE FROM groupMember WHERE [groupMemberId] = @Id;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@Id",
                Value = id
            };
            prms.Add(param1);
            
            var rowsAffected = conn.ExecuteNonQuery(sql,prms);
            
            if (rowsAffected < 1)
            {
                throw new Exception("GroupMember has not been deleted!");
            }
        }


        private void CheckGroupMemberForRequiredValues(GroupMemberEntity gm, RepositoryUtils.RepositoryAction action)
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

        public void Insert(List<GroupMemberEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Insert(batch, conn);
            }
        }

        public void Insert(List<GroupMemberEntity> batch, IConnection conn)
        {
            batch.ForEach(x => Insert(x, conn));
        }

        public void Update(List<GroupMemberEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Update(batch, conn);
            }
        }

        public void Update(List<GroupMemberEntity> batch, IConnection conn)
        {
            batch.ForEach(x => Update(x.groupMemberId, x, conn));
        }

        public void Delete(List<int> batch)
        {
            using (Connection conn = new Connection())
            {
                Delete(batch, conn);
            }
        }

        public void Delete(List<int> batch, IConnection conn)
        {
            batch.ForEach(x => Delete(x, conn));
        }
    }
}
