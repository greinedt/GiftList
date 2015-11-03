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
        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public IList<GiftList> GetAllGiftLists()
        {
            List<GiftList> giftListlist = new List<GiftList>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT giftListId, personFK, listName, isPrivate, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST;";
                var cmd = new SqlCommand(sql, _conn);
                
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var giftList = new GiftList()
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
            }
            finally
            {
                _conn?.Close();
            }
            return giftListlist;
        }

        public IList<GiftList> GetAllGiftLists(int person)
        {
            List<GiftList> giftListlist = new List<GiftList>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT giftListId, personFK, listName, isPrivate, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE personFK = @personFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@personFK",
                    Value = person
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var giftList = new GiftList()
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
            }
            finally
            {
                _conn?.Close();
            }
            return giftListlist;
        }

        public long GetNumberOGiftfLists(int person)
        {
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(giftListId) FROM DBO.GIFTLIST WHERE personFK = @personFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@personFK",
                    Value = person
                };
                cmd.Parameters.Add(paramQuery);

                return Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                _conn?.Close();
            }
        }

        public bool GiftListExists(int person, string listName)
        {
            try
            {
                const string sql = "SELECT COUNT([giftListId]) AS LinkId FROM dbo.giftList WHERE listName = @listName AND personFK = @personFK;";

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                var cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.Add("@personFK", SqlDbType.Int);
                cmd.Parameters["@personFK"].Value = person;

                cmd.Parameters.Add("@listName", SqlDbType.VarChar);
                cmd.Parameters["@listName"].Value = listName;

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public GiftList GetListById(int id)
        {
            List<GiftList> giftListlist = new List<GiftList>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT giftListId, personFK, listName, isPrivate, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE giftListId = @id;";
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
                    var giftList = new GiftList()
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
            }
            finally
            {
                _conn?.Close();
            }
            return giftListlist.FirstOrDefault();
        }

        public GiftList GetList(int person, string listName)
        {
            List<GiftList> giftListlist = new List<GiftList>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT giftListId, personFK, listName, isPrivate, updateTimestamp, updatePersonFK FROM DBO.GIFTLIST WHERE personFK = @personFK and listName = @listName;";
                var cmd = new SqlCommand(sql, _conn);

                var paramPerson = new SqlParameter
                {
                    ParameterName = "@personFK",
                    Value = person
                };
                cmd.Parameters.Add(paramPerson);

                var paramName = new SqlParameter
                {
                    ParameterName = "@listName",
                    Value = listName
                };
                cmd.Parameters.Add(paramName);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var giftList = new GiftList()
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
            }
            finally
            {
                _conn?.Close();
            }
            return giftListlist.FirstOrDefault();
        }

        public long Insert(GiftList giftList)
        {
            CheckGiftListForRequiredValues(giftList, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                var linkExists = GetList(giftList.personFK, giftList.listName);
                if (linkExists != null)
                {
                    throw new Exception($"Gift List {giftList.personFK} {giftList.listName} already exists in database!");
                }
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO[dbo].[giftList] (personFK, listName, isPrivate, updateTimestamp, updatePersonFK) 
                    VALUES(@personFK, @listName, @isPrivate, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@personFK", SqlDbType.Int);
                cmd.Parameters["@personFK"].Value = giftList.personFK;

                cmd.Parameters.Add("@listName", SqlDbType.VarChar);
                cmd.Parameters["@listName"].Value = giftList.listName;

                cmd.Parameters.Add("@isPrivate", SqlDbType.Char);
                cmd.Parameters["@isPrivate"].Value = giftList.isPrivate ? 'Y' : 'N';

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = giftList.updatePersonFK;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"Entity {giftList.personFK} {giftList.listName} not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Insert(List<GiftList> batch)
        {
            batch.ForEach(x => Insert(x));
        }

        public void Update(int id, GiftList giftList)
        {
            CheckGiftListForRequiredValues(giftList, RepositoryUtils.RepositoryAction.Update);

            var linkToUpdate = GetListById(giftList.giftListId);
            if (linkToUpdate == null)
            {
                throw new Exception("Gift List does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE person SET [personFK]=@personFK, 
                                                      [listName]=@listName, 
                                                      [isPrivate]=@isPrivate, 
                                                      [updateTimestamp]=getdate(),
                                                      [updatePersonFK]=@updatePersonFK
                                                      WHERE giftListId=@giftListId";

                cmd.Parameters.Add("@personFK", SqlDbType.Int);
                cmd.Parameters["@personFK"].Value = giftList.personFK;

                cmd.Parameters.Add("@listName", SqlDbType.VarChar);
                cmd.Parameters["@listName"].Value = giftList.listName;
                
                cmd.Parameters.Add("@isPrivate", SqlDbType.Char);
                cmd.Parameters["@isPrivate"].Value = giftList.isPrivate ? 'Y' : 'N';

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = giftList.updatePersonFK;

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

        public void Update(List<GiftList> batch)
        {
            batch.ForEach(x => Update(x.giftListId, x));
        }

        public void Delete(int id)
        {
            _conn = new SqlConnection(ConnString);

            var sqlComm = _conn.CreateCommand();
            sqlComm.CommandText = @"DELETE FROM giftlist WHERE [giftListId] = @Id;";
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

        public void Delete(List<int> batch)
        {
            batch.ForEach(x => Delete(x));
        }

        private void CheckGiftListForRequiredValues(GiftList gl, RepositoryUtils.RepositoryAction action)
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
