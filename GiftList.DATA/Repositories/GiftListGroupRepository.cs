using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class GiftListGroupRepository : IGiftListGroupRepository
    {
        public IList<GiftListGroupEntity> GetAllGiftListGroups()
        {
            using (Connection conn = new Connection())
            {
                return GetAllGiftListGroups(conn);
            }
        }

        public IList<GiftListGroupEntity> GetAllGiftListGroups(IConnection conn)
        {
            List<GiftListGroupEntity> giftListGrouplist = new List<GiftListGroupEntity>();
            string sql = "SELECT giftListGroupId, giftListFK, groupFK, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST;";

            var rdr = conn.ExecuteReader(sql);
            while (rdr.Read())
            {
                var giftListGroup = new GiftListGroupEntity()
                {
                    giftListGroupId = rdr.IsDBNull(rdr.GetOrdinal("giftListGroupId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListGroupId")),
                    giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                    groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                giftListGrouplist.Add(giftListGroup);
            }

            return giftListGrouplist;
        }

        public IList<GiftListGroupEntity> GetAllGiftListGroups(int group)
        {
            using (Connection conn = new Connection())
            {
                return GetAllGiftListGroups(group,conn);
            }
        }

        public IList<GiftListGroupEntity> GetAllGiftListGroups(int group, IConnection conn)
        {
            List<GiftListGroupEntity> giftListGrouplist = new List<GiftListGroupEntity>();

            string sql = "SELECT giftListGroupId, giftListFK, groupFK, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE groupFK = @groupFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramQuery = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = group
            };
            prms.Add(paramQuery);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var giftListGroup = new GiftListGroupEntity()
                {
                    giftListGroupId = rdr.IsDBNull(rdr.GetOrdinal("giftListGroupId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListGroupId")),
                    giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                    groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                giftListGrouplist.Add(giftListGroup);
            }

            return giftListGrouplist;
        }

        public GiftListGroupEntity GetGiftListGroup(int giftList, int group)
        {
            using (Connection conn = new Connection())
            {
                return GetGiftListGroup(giftList, group, conn);
            }
        }

        public GiftListGroupEntity GetGiftListGroup(int giftList, int group, IConnection conn)
        {
            List<GiftListGroupEntity> giftListGrouplist = new List<GiftListGroupEntity>();
 
            string sql = "SELECT giftListGroupId, giftListFK, groupFK, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE groupFK = @groupFK and giftListFK = @giftListFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramGiftList = new SqlParameter
            {
                ParameterName = "@giftListFK",
                Value = giftList
            };
            prms.Add(paramGiftList);

            var paramGroup = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = group
            };
            prms.Add(paramGroup);

            var rdr = conn.ExecuteReader(sql, prms);
            while (rdr.Read())
            {
                var giftListGroup = new GiftListGroupEntity()
                {
                    giftListGroupId = rdr.IsDBNull(rdr.GetOrdinal("giftListGroupId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListGroupId")),
                    giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                    groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                giftListGrouplist.Add(giftListGroup);
            }

            return giftListGrouplist.FirstOrDefault();
        }

        public GiftListGroupEntity GetGiftListGroupById(int id)
        {
            using (Connection conn = new Connection())
            {
                return GetGiftListGroupById(id, conn);
            }
        }

        public GiftListGroupEntity GetGiftListGroupById(int id, IConnection conn)
        {
            List<GiftListGroupEntity> giftListGrouplist = new List<GiftListGroupEntity>();

            string sql = "SELECT giftListGroupId, giftListFK, groupFK, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE giftListGroupId = @id;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramId = new SqlParameter
            {
                ParameterName = "@id",
                Value = id
            };
            prms.Add(paramId);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var giftListGroup = new GiftListGroupEntity()
                {
                    giftListGroupId = rdr.IsDBNull(rdr.GetOrdinal("giftListGroupId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListGroupId")),
                    giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                    groupFK = rdr.IsDBNull(rdr.GetOrdinal("groupFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("groupFK")),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                giftListGrouplist.Add(giftListGroup);
            }

            return giftListGrouplist.FirstOrDefault();
        }
        
        public long GetNumberOfGiftListGroups(int group)
        {
            using (Connection conn = new Connection())
            {
                return GetNumberOfGiftListGroups(group, conn);
            }
        }

        public long GetNumberOfGiftListGroups(int group, IConnection conn)
        {
            string sql = "SELECT COUNT(giftListGroupId) FROM DBO.GIFTLISTGROUP WHERE groupFK = @groupFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramQuery = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = group
            };
            prms.Add(paramQuery);

            return Int32.Parse(conn.ExecuteScalar(sql,prms).ToString());
            
        }

        public bool GiftListGroupExists(int giftList, int group)
        {
            using (Connection conn = new Connection())
            {
                return GiftListGroupExists(giftList, group, conn);
            }
        }

        public bool GiftListGroupExists(int giftList, int group, IConnection conn)
        {
            const string sql = "SELECT COUNT([giftListGroupId]) FROM dbo.giftListGroup WHERE giftListFK = @giftListFK AND groupFK = @groupFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@giftListFK",
                Value = giftList
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = group
            };
            prms.Add(param2);

            return ((int)conn.ExecuteScalar(sql,prms) >= 1);
        }

        public long Insert(GiftListGroupEntity giftListGroup)
        {
            using (Connection conn = new Connection())
            {
                return Insert(giftListGroup, conn);
            }
        }

        public long Insert(GiftListGroupEntity giftListGroup, IConnection conn)
        {
            CheckGiftListGroupForRequiredValues(giftListGroup, RepositoryUtils.RepositoryAction.Insert);
            using (Connection _conn = new Connection())
            {
                var giftListGroupExists = GetGiftListGroup(giftListGroup.giftListFK, giftListGroup.groupFK);
                if (giftListGroupExists != null)
                {
                    throw new Exception($"Gift List Group {giftListGroup.giftListFK} {giftListGroup.groupFK} already exists in database!");
                }


                string sql =
                    @"INSERT INTO[dbo].[giftListGroup] (giftListFK, groupFK, updateTimestamp, updatePersonFK) 
                    VALUES(@giftListFK, @groupFK, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";
                List<SqlParameter> prms = new List<SqlParameter>();

                var param1 = new SqlParameter
                {
                    ParameterName = "@giftListFK",
                    Value = giftListGroup.giftListFK
                };
                prms.Add(param1);

                var param2 = new SqlParameter
                {
                    ParameterName = "@groupFK",
                    Value = giftListGroup.groupFK
                };
                prms.Add(param2);

                var param3 = new SqlParameter
                {
                    ParameterName = "@updatePersonFK",
                    Value = giftListGroup.updatePersonFK
                };
                prms.Add(param3);
                
                try
                {
                    return int.Parse(_conn.ExecuteScalar(sql,prms).ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"Entity {giftListGroup.giftListFK} {giftListGroup.groupFK} not inserted in database!");
                }

            }
        }

        public void Insert(List<GiftListGroupEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                conn.BeginTransaction();
                try {
                    batch.ForEach(x => Insert(x, conn));
                } catch(Exception e)
                {
                    conn.RollbackTransaction();
                    throw e;
                }
                conn.CommitTransaction();
            }
        }

        public void Insert(List<GiftListGroupEntity> batch, IConnection conn)
        {
            batch.ForEach(x => Insert(x,conn));
        }

        public void Update(int id, GiftListGroupEntity giftListGroup)
        {
            using (Connection conn = new Connection())
            {
                Update(id, giftListGroup, conn);
            }
        }

        public void Update(int id, GiftListGroupEntity giftListGroup, IConnection conn)
        {
            CheckGiftListGroupForRequiredValues(giftListGroup, RepositoryUtils.RepositoryAction.Update);

            var giftListGroupToUpdate = GetGiftListGroupById(giftListGroup.giftListGroupId);
            if (giftListGroupToUpdate == null)
            {
                throw new Exception("Gift List does not exist in database");
            }
            
            string sql = @"UPDATE person SET [giftListFK]=@giftListFK, 
                                                    [groupFK]=@groupFK, 
                                                    [updateTimestamp]=getdate(),
                                                    [updatePersonFK]=@updatePersonFK
                                                    WHERE giftListGroupId=@giftListGroupId";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@giftListFK",
                Value = giftListGroup.giftListFK
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@groupFK",
                Value = giftListGroup.groupFK
            };
            prms.Add(param2);

            var param3 = new SqlParameter
            {
                ParameterName = "@updatePersonFK",
                Value = giftListGroup.updatePersonFK
            };
            prms.Add(param3);

            var param4 = new SqlParameter
            {
                ParameterName = "@giftListGroupId",
                Value = giftListGroup.giftListGroupId
            };
            prms.Add(param4);
            
            var number = conn.ExecuteNonQuery(sql,prms);

            if (number != 1)
            {
                throw new Exception($"No Gift Lsits were updated with Id: {id}");
            }
        }

        public void Update(List<GiftListGroupEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                conn.BeginTransaction();
                try
                {

                }
                catch (Exception e)
                {
                    conn.RollbackTransaction();
                    throw e;
                }
                conn.CommitTransaction();
            }
        }

        public void Update(List<GiftListGroupEntity> batch, IConnection conn)
        {
            batch.ForEach(x => Update(x.giftListGroupId, x, conn));
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
            string sql = @"DELETE FROM giftlistGroup WHERE [giftListGroupId] = @Id;";
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

        public void Delete(List<int> batch)
        {
            using (Connection conn = new Connection())
            {
                conn.BeginTransaction();
                try {
                    Delete(batch, conn);
                }
                catch(Exception e)
                {
                    conn.RollbackTransaction();
                    throw e;
                }
                conn.CommitTransaction();
            }
        }

        public void Delete(List<int> batch, IConnection conn)
        {
            batch.ForEach(x => Delete(x, conn));
        }

        private void CheckGiftListGroupForRequiredValues(GiftListGroupEntity glg, RepositoryUtils.RepositoryAction action)
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
