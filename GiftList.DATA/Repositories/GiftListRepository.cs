using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class GiftListRepository : IGiftListRepository
    {

        public IList<GiftListEntity> GetAllGiftLists()
        {
            using (Connection conn = new Connection())
            {
                return GetAllGiftLists(conn);
            }
        }

        public IList<GiftListEntity> GetAllGiftLists(IConnection conn)
        {
            List<GiftListEntity> giftListlist = new List<GiftListEntity>();
            
            string sql = "SELECT giftListId, personFK, listName, isPrivate, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST;";
            List<SqlParameter> prms = new List<SqlParameter>();
                
            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var giftList = new GiftListEntity()
                {
                    giftListId = rdr.IsDBNull(rdr.GetOrdinal("giftListId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListId")),
                    personFK = rdr.IsDBNull(rdr.GetOrdinal("personFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("personFK")),
                    listName = rdr.IsDBNull(rdr.GetOrdinal("listName")) ? null : rdr.GetString(rdr.GetOrdinal("listName")),
                    isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isPrivate")) ? false : (rdr.GetString(rdr.GetOrdinal("isPrivate")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                giftListlist.Add(giftList);
            }

            return giftListlist;
        }

        public IList<GiftListEntity> GetAllGiftLists(int person)
        {
            using (Connection conn = new Connection())
            {
                return GetAllGiftLists(person, conn);
            }
        }

        public IList<GiftListEntity> GetAllGiftLists(int person, IConnection conn)
        {
            List<GiftListEntity> giftListlist = new List<GiftListEntity>();
            
            string sql = "SELECT giftListId, personFK, listName, isPrivate, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE personFK = @personFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramQuery = new SqlParameter
            {
                ParameterName = "@personFK",
                Value = person
            };
            prms.Add(paramQuery);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var giftList = new GiftListEntity()
                {
                    giftListId = rdr.IsDBNull(rdr.GetOrdinal("giftListId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListId")),
                    personFK = rdr.IsDBNull(rdr.GetOrdinal("personFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("personFK")),
                    listName = rdr.IsDBNull(rdr.GetOrdinal("listName")) ? null : rdr.GetString(rdr.GetOrdinal("listName")),
                    isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isPrivate")) ? false : (rdr.GetString(rdr.GetOrdinal("isPrivate")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                giftListlist.Add(giftList);
            }

            return giftListlist;
        }

        public long GetNumberOGiftfLists(int person)
        {
            using (Connection conn = new Connection())
            {
                return GetNumberOGiftfLists(person, conn);
            }
        }

        public long GetNumberOGiftfLists(int person, IConnection conn)
        {
            string sql = "SELECT COUNT(giftListId) FROM DBO.GIFTLIST WHERE personFK = @personFK;";
            List<SqlParameter> prms = new List<SqlParameter>();
            
            var paramQuery = new SqlParameter
            {
                ParameterName = "@personFK",
                Value = person
            };
            prms.Add(paramQuery);

            return Int32.Parse(conn.ExecuteScalar(sql,prms).ToString());
        }

        public bool GiftListExists(int person, string listName)
        {
            using (Connection conn = new Connection())
            {
                return GiftListExists(person, listName, conn);
            }
        }


        public bool GiftListExists(int person, string listName, IConnection conn)
        {
            const string sql = "SELECT COUNT([giftListId]) AS LinkId FROM dbo.giftList WHERE listName = @listName AND personFK = @personFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@personFK",
                Value = person
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@listName",
                Value = listName
            };
            prms.Add(param2);
            
            return ((int)conn.ExecuteScalar(sql,prms) >= 1);
        }

        public GiftListEntity GetListById(int id)
        {
            using (Connection conn = new Connection())
            {
                return GetListById(id, conn);
            }
        }

        public GiftListEntity GetListById(int id, IConnection conn)
        {
            List<GiftListEntity> giftListlist = new List<GiftListEntity>();
            
            string sql = "SELECT giftListId, personFK, listName, isPrivate, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE giftListId = @id;";
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
                var giftList = new GiftListEntity()
                {
                    giftListId = rdr.IsDBNull(rdr.GetOrdinal("giftListId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListId")),
                    personFK = rdr.IsDBNull(rdr.GetOrdinal("personFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("personFK")),
                    listName = rdr.IsDBNull(rdr.GetOrdinal("listName")) ? null : rdr.GetString(rdr.GetOrdinal("listName")),
                    isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isPrivate")) ? false : (rdr.GetString(rdr.GetOrdinal("isPrivate")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                giftListlist.Add(giftList);
            }
            return giftListlist.FirstOrDefault();
        }
        
        public GiftListEntity GetList(int person, string listName)
        {
            using (Connection conn = new Connection())
            {
                return GetList(person, listName, conn);
            }
        }

        public GiftListEntity GetList(int person, string listName, IConnection conn)
        {
            List<GiftListEntity> giftListlist = new List<GiftListEntity>();

            string sql = "SELECT giftListId, personFK, listName, isPrivate, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE personFK = @personFK and listName = @listName;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@personFK",
                Value = person
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@listName",
                Value = listName
            };
            prms.Add(param2);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var giftList = new GiftListEntity()
                {
                    giftListId = rdr.IsDBNull(rdr.GetOrdinal("giftListId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListId")),
                    personFK = rdr.IsDBNull(rdr.GetOrdinal("personFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("personFK")),
                    listName = rdr.IsDBNull(rdr.GetOrdinal("listName")) ? null : rdr.GetString(rdr.GetOrdinal("listName")),
                    isPrivate = rdr.IsDBNull(rdr.GetOrdinal("isPrivate")) ? false : (rdr.GetString(rdr.GetOrdinal("isPrivate")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                giftListlist.Add(giftList);
            }
           
            return giftListlist.FirstOrDefault();
        }
        
        public long Insert(GiftListEntity giftList)
        {
            using (Connection conn = new Connection())
            {
                return Insert(giftList, conn);
            }
        }

        public long Insert(GiftListEntity giftList, IConnection conn)
        {
            CheckGiftListForRequiredValues(giftList, RepositoryUtils.RepositoryAction.Insert);

            var linkExists = GetList(giftList.personFK, giftList.listName);
            if (linkExists != null)
            {
                throw new Exception($"Gift List {giftList.personFK} {giftList.listName} already exists in database!");
            }

            string sql =
                @"INSERT INTO[dbo].[giftList] (personFK, listName, isPrivate, updateTimestamp, updatePersonFK) 
                VALUES(@personFK, @listName, @isPrivate, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@personFK",
                Value = giftList.personFK
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@listName",
                Value = giftList.listName
            };
            prms.Add(param2);

            var param3 = new SqlParameter
            {
                ParameterName = "@isPrivate",
                Value = giftList.isPrivate ? 'Y' : 'N'
            };
            prms.Add(param3);

            var param4 = new SqlParameter
            {
                ParameterName = "@updatePersonFK",
                Value = giftList.updatePersonFK
            };
            prms.Add(param4);
            
            try
            {
                return int.Parse(conn.ExecuteScalar(sql,prms).ToString());
            }
            catch (Exception)
            {
                throw new Exception($"Entity {giftList.personFK} {giftList.listName} not inserted in database!");
            }
        }

        public void Insert(List<GiftListEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Insert(batch, conn);
            }
        }

        public void Insert(List<GiftListEntity> batch, IConnection conn)
        {
            batch.ForEach(x => Insert(x));
        }
        
        public void Update(int id, GiftListEntity giftList)
        {
            using (Connection conn = new Connection())
            {
                Update(id, giftList, conn);
            }
        }

        public void Update(int id, GiftListEntity giftList, IConnection conn)
        {
            CheckGiftListForRequiredValues(giftList, RepositoryUtils.RepositoryAction.Update);

            var linkToUpdate = GetListById(giftList.giftListId);
            if (linkToUpdate == null)
            {
                throw new Exception("Gift List does not exist in database");
            }
            
            string sql = @"UPDATE person SET [personFK]=@personFK, 
                                                    [listName]=@listName, 
                                                    [isPrivate]=@isPrivate, 
                                                    [updateTimestamp]=getdate(),
                                                    [updatePersonFK]=@updatePersonFK
                                                    WHERE giftListId=@giftListId";
            List<SqlParameter> prms = new List<SqlParameter>();

            var param1 = new SqlParameter
            {
                ParameterName = "@personFK",
                Value = giftList.personFK
            };
            prms.Add(param1);

            var param2 = new SqlParameter
            {
                ParameterName = "@listName",
                Value = giftList.listName
            };
            prms.Add(param2);

            var param3 = new SqlParameter
            {
                ParameterName = "@isPrivate",
                Value = giftList.isPrivate ? 'Y' : 'N'
            };
            prms.Add(param3);

            var param4 = new SqlParameter
            {
                ParameterName = "@updatePersonFK",
                Value = giftList.updatePersonFK
            };
            prms.Add(param4);
            
            var number = conn.ExecuteNonQuery(sql,prms);

            if (number != 1)
            {
                throw new Exception($"No Gift Lsits were updated with Id: {id}");
            }
        }

        public void Update(List<GiftListEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Update(batch, conn);
            }
        }

        public void Update(List<GiftListEntity> batch, IConnection conn)
        {
            batch.ForEach(x => Update(x.giftListId, x));
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
            string sql = @"DELETE FROM giftlist WHERE [giftListId] = @Id;";
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
                Delete(batch, conn);
            }
        }

        public void Delete(List<int> batch, IConnection conn)
        {
            batch.ForEach(x => Delete(x,conn));
        }

        private void CheckGiftListForRequiredValues(GiftListEntity gl, RepositoryUtils.RepositoryAction action)
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
