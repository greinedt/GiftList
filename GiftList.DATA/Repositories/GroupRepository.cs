using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        public IList<GroupEntity> GetAllGroups()
        {
            using (Connection conn = new Connection())
            {
                return GetAllGroups(conn);
            }
        }

        public IList<GroupEntity> GetAllGroups(IConnection conn)
        {
            List<GroupEntity> groupList = new List<GroupEntity>();
            string sql = "SELECT groupId, creatorFK, groupName, description, isPrivate, updateTimestamp, updatePersonFK FROM dbo.[group];";

            var rdr = conn.ExecuteReader(sql);
            while (rdr.Read())
            {
                var group = new GroupEntity()
                {
                    groupId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                    creatorFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                    groupName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                    description = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                    isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : (rdr.GetString(rdr.GetOrdinal("isImage")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonKey")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonKey"))
                };
                groupList.Add(group);
            }

            return groupList;
        }

        public IList<GroupEntity> GetAllGroups(int creator)
        {
            using (Connection conn = new Connection())
            {
                return GetAllGroups(creator, conn);
            }
        }

        public IList<GroupEntity> GetAllGroups(int creator, IConnection conn)
        {
            List<GroupEntity> groupList = new List<GroupEntity>();

            string sql = "SELECT groupId, creatorFK, groupName, description, isPrivate, updateTimestamp, updatePersonFK FROM dbo.[group] WHERE creatorFK = @creatorFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramQuery = new SqlParameter
            {
                ParameterName = "@creatorFK",
                Value = creator
            };
            prms.Add(paramQuery);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var group = new GroupEntity()
                {
                    groupId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                    creatorFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                    groupName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                    description = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                    isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : (rdr.GetString(rdr.GetOrdinal("isImage")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonKey")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonKey"))
                };
                groupList.Add(group);
            }

            return groupList;
        }


        public GroupEntity GetGroup(int creator, string groupName)
        {
            using (Connection conn = new Connection())
            {
                return GetGroup(creator, groupName, conn);
            }
        }

        public GroupEntity GetGroup(int creator, string groupName, IConnection conn)
        {
            List<GroupEntity> grouplist = new List<GroupEntity>();

            string sql = "SELECT groupId, creatorFK, groupName, description, isPrivate, updateTimestamp, updatePersonFK FROM dbo.[group] WHERE creatorFK = @creatorFK and groupName = @groupName;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramItem = new SqlParameter
            {
                ParameterName = "@creatorFK",
                Value = creator
            };
            prms.Add(paramItem);

            var paramName = new SqlParameter
            {
                ParameterName = "@groupName",
                Value = groupName
            };
            prms.Add(paramName);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var group = new GroupEntity()
                {
                    groupId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                    creatorFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                    groupName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                    description = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                    isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : (rdr.GetString(rdr.GetOrdinal("isImage")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonKey")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonKey"))
                };
                grouplist.Add(group);
            }

            return grouplist.FirstOrDefault();
        }

        public GroupEntity GetGroupById(int id)
        {
            using (Connection conn = new Connection())
            {
                return GetGroupById(id, conn);
            }
        }

        public GroupEntity GetGroupById(int id, IConnection conn)
        {
            List<GroupEntity> grouplist = new List<GroupEntity>();
      
            string sql = "SELECT groupId, creatorFK, groupName, description, isPrivate, updateTimestamp, updatePersonFK FROM dbo.[group] WHERE groupId = @id;";
            List<SqlParameter> prms = new List<SqlParameter>();
                
            var paramName = new SqlParameter
            {
                ParameterName = "@id",
                Value = id
            };
            prms.Add(paramName);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var group = new GroupEntity()
                {
                    groupId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                    creatorFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                    groupName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                    description = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                    isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : (rdr.GetString(rdr.GetOrdinal("isImage")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonKey")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonKey"))
                };
                grouplist.Add(group);
            }

            return grouplist.FirstOrDefault();
        }

        public long GetNumberOfGroups(int creator)
        {
            using (Connection conn = new Connection())
            {
                return GetNumberOfGroups(creator, conn);
            }
        }

        public long GetNumberOfGroups(int creator, IConnection conn)
        {
            string sql = "SELECT COUNT(groupId) FROM dbo.[group] WHERE creatorFK = @creatorFK;";
            List<SqlParameter> prms = new List<SqlParameter>();
            var paramQuery = new SqlParameter
            {
                ParameterName = "@creatorFK",
                Value = creator
            };
            prms.Add(paramQuery);

            return Int32.Parse(conn.ExecuteScalar(sql,prms).ToString());
        }

        public bool GroupExists(int creator, string groupName)
        {
            using (Connection conn = new Connection())
            {
                return GroupExists(creator, groupName, conn);
            }
        }

        public bool GroupExists(int creator, string groupName, IConnection conn)
        {
            const string sql = "SELECT COUNT([groupId]) FROM dbo.[group] WHERE creatorFK = @creatorFK AND groupName = @groupName;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@creatorFK",
                Value = creator
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@groupName",
                Value = groupName
            };
            prms.Add(param2);

            return ((int)conn.ExecuteScalar(sql,prms) >= 1);
        }
        
        public long Insert(GroupEntity group)
        {
            using (Connection conn = new Connection())
            {
                return Insert(group, conn);
            }
        }

        public long Insert(GroupEntity group, IConnection conn)
        {
            var groupExists = GetGroup(group.creatorFK, group.groupName);
            if (groupExists != null)
            {
                throw new Exception($"Entity {group.creatorFK} {group.groupName} already exists in database!");
            }
            string sql =
                @"INSERT INTO[dbo].[link] (creatorFK, groupName, description, isPrivate, updateTimestamp, updatePersonFK) 
                VALUES(@creatorFK, @groupName, @description, @isPrivate, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@creatorFK",
                Value = group.creatorFK
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@groupName",
                Value = group.groupName
            };
            prms.Add(param2);

            var param3 = new SqlParameter
            {
                ParameterName = "@description",
                Value = group.description
            };
            prms.Add(param3);

            var param4 = new SqlParameter
            {
                ParameterName = "@isPrivate",
                Value = group.isPrivate ? 'Y' : 'N'
            };
            prms.Add(param4);

            var param5 = new SqlParameter
            {
                ParameterName = "@updatePersonFK",
                Value = group.updatePersonFK
            };
            prms.Add(param5);
                
            try
            {
                return int.Parse(conn.ExecuteScalar(sql,prms).ToString()); ;
            }
            catch (Exception)
            {
                throw new Exception($"Entity {group.creatorFK} {group.groupName} not inserted in database!");
            }
        }

        public void Update(int id, GroupEntity group)
        {
            using (Connection conn = new Connection())
            {
                Update(id, group, conn);
            }
        }
        public void Update(int id, GroupEntity group, IConnection conn)
        {
            CheckGroupForRequiredValues(group, RepositoryUtils.RepositoryAction.Update);

            var linkToUpdate = GetGroupById(group.groupId);
            if (linkToUpdate == null)
            {
                throw new Exception("Group does not exist in database");
            }
            
            string sql = @"UPDATE person SET [creatorFK]=@creatorFK, 
                                                    [groupName]=@groupName, 
                                                    [description]=@description, 
                                                    [isPrivate]=@isPrivate, 
                                                    [updateTimestamp]=getdate(),
                                                    [updatePersonFK]=@updatePersonFK
                                                    WHERE groupId=@groupId";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@creatorFK",
                Value = group.creatorFK
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@groupName",
                Value = group.groupName
            };
            prms.Add(param2);

            var param3 = new SqlParameter
            {
                ParameterName = "@description",
                Value = group.description
            };
            prms.Add(param3);

            var param4 = new SqlParameter
            {
                ParameterName = "@groupId",
                Value = group.groupId
            };
            prms.Add(param4);

            var param5 = new SqlParameter
            {
                ParameterName = "@isPrivate",
                Value = group.isPrivate ? 'Y' : 'N'
            };
            prms.Add(param5);

            var param6 = new SqlParameter
            {
                ParameterName = "@updatePersonFK",
                Value = group.updatePersonFK
            };
            prms.Add(param6);
                
            var number = conn.ExecuteNonQuery(sql,prms);

            if (number != 1)
            {
                throw new Exception($"No Groups were updated with Id: {id}");
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
            string sql = @"DELETE FROM [group] WHERE [groupId] = @Id;";
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
                throw new Exception("Entity has not been deleted!");
            }
        }

        private void CheckGroupForRequiredValues(GroupEntity g, RepositoryUtils.RepositoryAction action)
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

        public void Insert(List<GroupEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Insert(batch, conn);
            }
        }

        public void Insert(List<GroupEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try {
                batch.ForEach(x => Insert(x));
            }
            catch(Exception e)
            {
                conn.RollbackTransaction();
                throw e;
            }
            conn.CommitTransaction();
        }

        public void Update(List<GroupEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Update(batch, conn);
            }
        }

        public void Update(List<GroupEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try
            {
                batch.ForEach(x => Update(x.groupId, x));
            }
            catch(Exception e)
            {
                conn.RollbackTransaction();
                throw e;
            }
            conn.CommitTransaction();
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
            conn.BeginTransaction();
            try
            {
                batch.ForEach(x => Delete(x));
            }
            catch(Exception e)
            {
                conn.RollbackTransaction();
                throw e;
            }
            conn.CommitTransaction();
        }
    }
}
