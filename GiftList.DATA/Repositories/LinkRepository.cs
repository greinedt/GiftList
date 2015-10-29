using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public IList<Link> GetAllLinks()
        {
            List<Link> linklist = new List<Link>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT linkId, itemFK, linkName, url, isImage, updateTimestamp, updatePersonFK FROM DBO.LINK;";
                var cmd = new SqlCommand(sql, _conn);
                
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var link = new Link()
                    {
                        linkId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        linkName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                        url = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                        isImage = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : (rdr.GetString(rdr.GetOrdinal("isImage")) == "Y"),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    linklist.Add(link);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return linklist;
        }

        public IList<Link> GetAllLinks(int item)
        {
            List<Link> linklist = new List<Link>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT linkId, itemFK, linkName, url, isImage, updateTimestamp, updatePersonFK FROM DBO.LINK WHERE itemFK = @itemFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@itemFK",
                    Value = item
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var link = new Link()
                    {
                        linkId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        linkName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                        url = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                        isImage = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : (rdr.GetString(rdr.GetOrdinal("isImage")) == "Y"),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    linklist.Add(link);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return linklist;
        }

        public Link GetLink(int item, string linkName)
        {
            List<Link> linklist = new List<Link>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT linkId, itemFK, url, linkName, isImage, updateTimestamp, updatePersonFK FROM DBO.LINK WHERE itemFK = @itemFK and linkName = @linkName;";
                var cmd = new SqlCommand(sql, _conn);

                var paramItem = new SqlParameter
                {
                    ParameterName = "@itemFK",
                    Value = item
                };
                cmd.Parameters.Add(paramItem);

                var paramName = new SqlParameter
                {
                    ParameterName = "@linkName",
                    Value = linkName
                };
                cmd.Parameters.Add(paramName);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var link = new Link()
                    {
                        linkId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        linkName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                        url = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                        isImage = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : rdr.GetBoolean(rdr.GetOrdinal("isImage")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    linklist.Add(link);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return linklist.FirstOrDefault();
        }

        public Link GetLinkById(int id)
        {
            List<Link> linklist = new List<Link>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT linkId, itemFK, url, linkName, isImage, updateTimestamp, updatePersonFK FROM DBO.LINK WHERE linkId = @id";
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
                    var link = new Link()
                    {
                        linkId = rdr.IsDBNull(rdr.GetOrdinal("linkId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("linkId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        linkName = rdr.IsDBNull(rdr.GetOrdinal("linkName")) ? null : rdr.GetString(rdr.GetOrdinal("linkName")),
                        url = rdr.IsDBNull(rdr.GetOrdinal("url")) ? null : rdr.GetString(rdr.GetOrdinal("url")),
                        isImage = rdr.IsDBNull(rdr.GetOrdinal("isImage")) ? false : rdr.GetBoolean(rdr.GetOrdinal("isImage")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    linklist.Add(link);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return linklist.FirstOrDefault();
        }

        public long GetNumberOfLinks(int item)
        {
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(linkId) FROM DBO.LINK WHERE itemFK = @itemFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@itemFK",
                    Value = item
                };
                cmd.Parameters.Add(paramQuery);

                return Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                _conn?.Close();
            }
        }

        public long Insert(Link link)
        {
            CheckLinkForRequiredValues(link, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                var linkExists = GetLinkById(link.linkId);
                if (linkExists != null)
                {
                    throw new Exception($"Entity {link.linkName} {link.itemFK} already exists in database!");
                }
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO[dbo].[link] (linkId, itemFK, url, linkName, isImage, updateTimestamp, updatePersonFK) 
                    VALUES(@itemFK, @url, @linkName, @isImage, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@itemFK", SqlDbType.Int);
                cmd.Parameters["@itemFK"].Value = link.itemFK;

                cmd.Parameters.Add("@url", SqlDbType.VarChar);
                cmd.Parameters["@url"].Value = link.url;

                cmd.Parameters.Add("@linkName", SqlDbType.VarChar);
                cmd.Parameters["@linkName"].Value = link.linkName;

                cmd.Parameters.Add("@isImage", SqlDbType.Char);
                cmd.Parameters["@isImage"].Value = link.isImage ? 'Y' : 'N';

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = link.updatePersonFK;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"Entity {link.linkName} {link.itemFK} not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }

        public bool LinkExists(int item, string linkName)
        {
            try
            {
                const string sql = "SELECT COUNT([linkId]) AS LinkId FROM dbo.link WHERE itemFK = @itemFK AND linkName = @linkName;";

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                var cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.Add("@itemFK", SqlDbType.Int);
                cmd.Parameters["@itemFK"].Value = item;

                cmd.Parameters.Add("@linkName", SqlDbType.VarChar);
                cmd.Parameters["@linkName"].Value = linkName;

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Update(int id, Link link)
        {
            CheckLinkForRequiredValues(link, RepositoryUtils.RepositoryAction.Update);

            var linkToUpdate = GetLinkById(link.linkId);
            if (linkToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE person SET [itemFK]=@itemFK, 
                                                      [linkName]=@linkName, 
                                                      [url]=@url, 
                                                      [isImage]=@isImage, 
                                                      [updateTimeStamp]=getdate(),
                                                      [updatePersonFK]=@updatePersonFK
                                                      WHERE linkId=@linkId";

                cmd.Parameters.Add("@linkId", SqlDbType.Int);
                cmd.Parameters["@linkId"].Value = link.linkId;

                cmd.Parameters.Add("@itemFK", SqlDbType.Int);
                cmd.Parameters["@itemFK"].Value = link.itemFK;

                cmd.Parameters.Add("@linkName", SqlDbType.VarChar);
                cmd.Parameters["@linkName"].Value = link.linkName;

                cmd.Parameters.Add("@url", SqlDbType.VarChar);
                cmd.Parameters["@url"].Value = link.url;

                cmd.Parameters.Add("@isImage", SqlDbType.Char);
                cmd.Parameters["@isImage"].Value = link.isImage ? 'Y' : 'N';

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = link.updatePersonFK;

                _conn.Open();

                var number = cmd.ExecuteNonQuery();

                if (number != 1)
                {
                    throw new Exception($"No Links were updated with Id: {id}");
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
            sqlComm.CommandText = @"DELETE FROM link WHERE [linkId] = @Id;";
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

        private void CheckLinkForRequiredValues(Link l, RepositoryUtils.RepositoryAction action)
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

        public void Insert(List<Link> batch)
        {
            batch.ForEach(x => Insert(x));
        }

        public void Update(List<Link> batch)
        {
            batch.ForEach(x => Update(x.linkId, x));
        }

        public void Delete(List<int> batch)
        {
            batch.ForEach(x => Delete(x));
        }
    }
}
