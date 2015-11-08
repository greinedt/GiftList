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
        public IList<LinkEntity> GetAllLinks()
        {
            using (Connection conn = new Connection())
            {
                return GetAllLinks(conn);
            }
        }
        public IList<LinkEntity> GetAllLinks(IConnection conn)
        {
            List<LinkEntity> linklist = new List<LinkEntity>();

            string sql = "SELECT linkId, itemFK, linkName, url, isImage, updateTimestamp, updatePersonFK FROM DBO.LINK;";
                
            var rdr = conn.ExecuteReader(sql);
            while (rdr.Read())
            {
                var link = new LinkEntity()
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
            return linklist;
        }

        public IList<LinkEntity> GetAllLinks(int item)
        {
            using (Connection conn = new Connection())
            {
                return GetAllLinks(item, conn);
            }
        }

        public IList<LinkEntity> GetAllLinks(int item, IConnection conn)
        {
            List<LinkEntity> linklist = new List<LinkEntity>();
            
            string sql = "SELECT linkId, itemFK, linkName, url, isImage, updateTimestamp, updatePersonFK FROM DBO.LINK WHERE itemFK = @itemFK;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = item });

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var link = new LinkEntity()
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

            return linklist;
        }

        public LinkEntity GetLink(int item, string linkName)
        {
            using (Connection conn = new Connection())
            {
                return GetLink(item, linkName, conn);
            }
        }

        public LinkEntity GetLink(int item, string linkName, IConnection conn)
        {
            List<LinkEntity> linklist = new List<LinkEntity>();
            
            string sql = "SELECT linkId, itemFK, url, linkName, isImage, updateTimestamp, updatePersonFK FROM DBO.LINK WHERE itemFK = @itemFK and linkName = @linkName;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = item });
            prms.Add(new SqlParameter { ParameterName = "@linkName", Value = linkName });
            

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var link = new LinkEntity()
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
            return linklist.FirstOrDefault();
        }

        public LinkEntity GetLinkById(int id)
        {
            using (Connection conn = new Connection())
            {
                return GetLinkById(id, conn);
            }
        }

        public LinkEntity GetLinkById(int id, IConnection conn)
        {
            List<LinkEntity> linklist = new List<LinkEntity>();
            
            string sql = "SELECT linkId, itemFK, url, linkName, isImage, updateTimestamp, updatePersonFK FROM DBO.LINK WHERE linkId = @id";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@id", Value = id });
            
            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var link = new LinkEntity()
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
            return linklist.FirstOrDefault();
        }

        public long GetNumberOfLinks(int item)
        {
            using (Connection conn = new Connection())
            {
                return GetNumberOfLinks(item, conn);
            }
        }

        public long GetNumberOfLinks(int item, IConnection conn)
        {
            string sql = "SELECT COUNT(linkId) FROM DBO.LINK WHERE itemFK = @itemFK;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = item });
            
            return Int32.Parse(conn.ExecuteScalar(sql,prms).ToString());
        }

        public long Insert(LinkEntity link)
        {
            using (Connection conn = new Connection())
            {
                return Insert(link, conn);
            }
        }

        public long Insert(LinkEntity link, IConnection conn)
        {
            CheckLinkForRequiredValues(link, RepositoryUtils.RepositoryAction.Insert);
            
            var linkExists = GetLinkById(link.linkId);
            if (linkExists != null)
            {
                throw new Exception($"Entity {link.linkName} {link.itemFK} already exists in database!");
            }

            string sql =
                @"INSERT INTO[dbo].[link] (linkId, itemFK, url, linkName, isImage, updateTimestamp, updatePersonFK) 
                VALUES(@itemFK, @url, @linkName, @isImage, getdate(), @updatePersonFK );SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = link.itemFK });
            prms.Add(new SqlParameter { ParameterName = "@url", Value = link.url });
            prms.Add(new SqlParameter { ParameterName = "@linkName", Value = link.linkName });
            prms.Add(new SqlParameter { ParameterName = "@isImage", Value = link.isImage ? 'Y' : 'N' });
            prms.Add(new SqlParameter { ParameterName = "@updatePersonFK", Value = link.updatePersonFK });
                
            try
            {
                return int.Parse(conn.ExecuteScalar(sql,prms).ToString());
            }
            catch (Exception)
            {
                throw new Exception($"Entity {link.linkName} {link.itemFK} not inserted in database!");
            }
        }

        public bool LinkExists(int item, string linkName)
        {
            using (Connection conn = new Connection())
            {
                return LinkExists(item, linkName, conn);
            }
        }

        public bool LinkExists(int item, string linkName, IConnection conn)
        {
            const string sql = "SELECT COUNT([linkId]) AS LinkId FROM dbo.link WHERE itemFK = @itemFK AND linkName = @linkName;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = item });
            prms.Add(new SqlParameter { ParameterName = "@linkName", Value = linkName });
                
            return ((int)conn.ExecuteScalar(sql,prms) >= 1);
        }

        public void Update(int id, LinkEntity link)
        {
            using (Connection conn = new Connection())
            {
                Update(id, link, conn);
            }
        }

        public void Update(int id, LinkEntity link, IConnection conn)
        {
            CheckLinkForRequiredValues(link, RepositoryUtils.RepositoryAction.Update);

            var linkToUpdate = GetLinkById(link.linkId);
            if (linkToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }
            string sql = @"UPDATE person SET [itemFK]=@itemFK, 
                                                    [linkName]=@linkName, 
                                                    [url]=@url, 
                                                    [isImage]=@isImage, 
                                                    [updateTimestamp]=getdate(),
                                                    [updatePersonFK]=@updatePersonFK
                                                    WHERE linkId=@linkId";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@linkId", Value = link.linkId });
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = link.itemFK });
            prms.Add(new SqlParameter { ParameterName = "@linkName", Value = link.linkName });
            prms.Add(new SqlParameter { ParameterName = "@url", Value = link.url });
            prms.Add(new SqlParameter { ParameterName = "@isImage", Value = link.isImage ? 'Y' : 'N' });
            prms.Add(new SqlParameter { ParameterName = "@updatePersonFK", Value = link.updatePersonFK });

            var number = conn.ExecuteNonQuery(sql,prms);

            if (number != 1)
            {
                throw new Exception($"No Links were updated with Id: {id}");
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
            string sql = @"DELETE FROM link WHERE [linkId] = @Id;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@Id", Value = id });
            var rowsAffected = conn.ExecuteNonQuery(sql,prms);
            
            if (rowsAffected < 1)
            {
                throw new Exception("Entity has not been deleted!");
            }
        }

        private void CheckLinkForRequiredValues(LinkEntity l, RepositoryUtils.RepositoryAction action)
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

        public void Insert(List<LinkEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Insert(batch, conn);
            }
        }

        public void Insert(List<LinkEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try {
                batch.ForEach(x => Insert(x, conn));
            }
            catch(Exception e)
            {
                conn.RollbackTransaction();
                throw e;
            }
            conn.CommitTransaction();
        }


        public void Update(List<LinkEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Update(batch, conn);
            }
        }

        public void Update(List<LinkEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try
            { 
                batch.ForEach(x => Update(x.linkId, x, conn));
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
                batch.ForEach(x => Delete(x, conn));
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
