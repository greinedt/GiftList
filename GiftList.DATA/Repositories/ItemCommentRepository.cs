using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class ItemCommentRepository : IItemCommentRepository
    {
        public IList<ItemCommentEntity> GetAllItemComments()
        {
            using (Connection conn = new Connection())
            {
                return GetAllItemComments(conn);
            }
        }

        public IList<ItemCommentEntity> GetAllItemComments(IConnection conn)
        {
            List<ItemCommentEntity> itemCommentList = new List<ItemCommentEntity>();
            
            string sql = "SELECT itemCommentId, itemFK, commentorFK, commentText, isHiddenFromOwner, updateTimestamp, updatePersonFK FROM dbo.itemComment;";
                
            var rdr = conn.ExecuteReader(sql);
            while (rdr.Read())
            {
                var itemComment = new ItemCommentEntity()
                {
                    itemCommentId = rdr.IsDBNull(rdr.GetOrdinal("itemCommentId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemCommentId")),
                    itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                    commentorFK = rdr.IsDBNull(rdr.GetOrdinal("commentorFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("commentorFK")),
                    commentText = rdr.IsDBNull(rdr.GetOrdinal("commentText")) ? null : rdr.GetString(rdr.GetOrdinal("commentText")),
                    isHiddenFromOwner = rdr.IsDBNull(rdr.GetOrdinal("isHiddenFromOwner")) ? true : (rdr.GetString(rdr.GetOrdinal("isHiddenFromOwner")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                itemCommentList.Add(itemComment);
            }
            return itemCommentList;
        }

        public IList<ItemCommentEntity> GetAllItemComments(int item)
        {
            using (Connection conn = new Connection())
            {
                return GetAllItemComments(item, conn);
            }
        }

        public IList<ItemCommentEntity> GetAllItemComments(int item, IConnection conn)
        {
            List<ItemCommentEntity> itemCommentList = new List<ItemCommentEntity>();
            
            string sql = "SELECT itemCommentId, itemFK, commentorFK, commentText, isHiddenFromOwner, updateTimestamp, updatePersonFK FROM dbo.itemComment WHERE itemFK = @itemFK;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramQuery = new SqlParameter
            {
                ParameterName = "@itemFK",
                Value = item
            };
            prms.Add(paramQuery);

            var rdr = conn.ExecuteReader(sql, prms);
            while (rdr.Read())
            {
                var itemComment = new ItemCommentEntity()
                {
                    itemCommentId = rdr.IsDBNull(rdr.GetOrdinal("itemCommentId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemCommentId")),
                    itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                    commentorFK = rdr.IsDBNull(rdr.GetOrdinal("commentorFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("commentorFK")),
                    commentText = rdr.IsDBNull(rdr.GetOrdinal("commentText")) ? null : rdr.GetString(rdr.GetOrdinal("commentText")),
                    isHiddenFromOwner = rdr.IsDBNull(rdr.GetOrdinal("isHiddenFromOwner")) ? true : (rdr.GetString(rdr.GetOrdinal("isHiddenFromOwner")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                itemCommentList.Add(itemComment);
            }
            return itemCommentList;
        }

        public ItemCommentEntity GetItemCommentById(int id)
        {
            using (Connection conn = new Connection())
            {
                return GetItemCommentById(id, conn);
            }
        }

        public ItemCommentEntity GetItemCommentById(int id, IConnection conn)
        {
            List<ItemCommentEntity> itemCommentList = new List<ItemCommentEntity>();
            
            string sql = "SELECT itemCommentId, itemFK, commentorFK, commentText, isHiddenFromOwner, updateTimestamp, updatePersonFK FROM dbo.itemComment WHERE itemCommentId = @id;";
            List<SqlParameter> prms = new List<SqlParameter>();    

            var paramQuery = new SqlParameter
            {
                ParameterName = "@id",
                Value = id
            };
            prms.Add(paramQuery);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var itemComment = new ItemCommentEntity()
                {
                    itemCommentId = rdr.IsDBNull(rdr.GetOrdinal("itemCommentId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemCommentId")),
                    itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                    commentorFK = rdr.IsDBNull(rdr.GetOrdinal("commentorFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("commentorFK")),
                    commentText = rdr.IsDBNull(rdr.GetOrdinal("commentText")) ? null : rdr.GetString(rdr.GetOrdinal("commentText")),
                    isHiddenFromOwner = rdr.IsDBNull(rdr.GetOrdinal("isHiddenFromOwner")) ? true : (rdr.GetString(rdr.GetOrdinal("isHiddenFromOwner")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                itemCommentList.Add(itemComment);
            }
            return itemCommentList.FirstOrDefault();
        }

        public ItemCommentEntity GetItemCommentByItem(int itemId)
        {
            using (Connection conn = new Connection())
            {
                return GetItemCommentById(itemId, conn);
            }
        }

        public ItemCommentEntity GetItemCommentByItem(int itemId, IConnection conn)
        {
            List<ItemCommentEntity> itemCommentList = new List<ItemCommentEntity>();
            
            string sql = "SELECT itemCommentId, itemFK, commentorFK, commentText, isHiddenFromOwner, updateTimestamp, updatePersonFK FROM dbo.itemComment WHERE itemId = @itemId;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramQuery = new SqlParameter
            {
                ParameterName = "@itemId",
                Value = itemId
            };
            prms.Add(paramQuery);

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var itemComment = new ItemCommentEntity()
                {
                    itemCommentId = rdr.IsDBNull(rdr.GetOrdinal("itemCommentId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemCommentId")),
                    itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                    commentorFK = rdr.IsDBNull(rdr.GetOrdinal("commentorFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("commentorFK")),
                    commentText = rdr.IsDBNull(rdr.GetOrdinal("commentText")) ? null : rdr.GetString(rdr.GetOrdinal("commentText")),
                    isHiddenFromOwner = rdr.IsDBNull(rdr.GetOrdinal("isHiddenFromOwner")) ? true : (rdr.GetString(rdr.GetOrdinal("isHiddenFromOwner")) == "Y"),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                    updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                };
                itemCommentList.Add(itemComment);
            }
            return itemCommentList.FirstOrDefault();
        }

        public long GetNumberOfItemComments(int item)
        {
            using (Connection conn = new Connection())
            {
                return GetNumberOfItemComments(item, conn);
            }
        }

        public long GetNumberOfItemComments(int item, IConnection conn)
        {
            string sql = "SELECT COUNT(itemCommentId) FROM DBO.PERSON WHERE itemFK LIKE @item;";
            List<SqlParameter> prms = new List<SqlParameter>();

            var paramQuery = new SqlParameter
            {
                ParameterName = "@item",
                Value = item
            };
            prms.Add(paramQuery);

            return Int32.Parse(conn.ExecuteScalar(sql,prms).ToString());
        }

        public long Insert(ItemCommentEntity itemComment)
        {
            using (Connection conn = new Connection())
            {
                return Insert(itemComment, conn);
            }
        }

        public long Insert(ItemCommentEntity itemComment, IConnection conn)
        {
            CheckItemCommentForRequiredValues(itemComment, RepositoryUtils.RepositoryAction.Insert);
            
            string sql =
                @"INSERT INTO [dbo].[itemComment] (itemFK, commentorFK, commentText, isHiddenFromOwner, updateTimestamp, updatePersonFK) 
                VALUES(@itemFK, @commentorFK, @commentText, @isHiddenFromOwner, getdate(), @updatePersonFK);SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> prms = new List<SqlParameter>();

            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = itemComment.itemFK });
            prms.Add(new SqlParameter { ParameterName = "@commentorFK", Value = itemComment.commentorFK });
            prms.Add(new SqlParameter { ParameterName = "@commentText", Value = itemComment.commentText });
            prms.Add(new SqlParameter { ParameterName = "@isHiddenFromOwner", Value = itemComment.isHiddenFromOwner ? "Y" : "N" });
            prms.Add(new SqlParameter { ParameterName = "@updatePersonFK", Value = itemComment.updatePersonFK });

            try
            {
                return int.Parse(conn.ExecuteScalar(sql,prms).ToString());
            }
            catch (Exception)
            {
                throw new Exception($"ItemComment not inserted in database!");
            }
        }

        public void Update(int id, ItemCommentEntity itemComment)
        {
            using (Connection conn = new Connection())
            {
                Update(id, itemComment, conn);
            }
        }

        public void Update(int id, ItemCommentEntity itemComment, IConnection conn)
        {
            CheckItemCommentForRequiredValues(itemComment, RepositoryUtils.RepositoryAction.Update);

            var contactToUpdate = GetItemCommentById(id);
            if (contactToUpdate == null)
            {
                throw new Exception("ItemComment does not exist in database");
            }
            
            string sql = @"UPDATE itemComment SET [itemFK]=@itemFK, 
                                                    [commentorFK]=@commentorFK, 
                                                    [commentText]=@commentText, 
                                                    [isHiddenFromOwner]=@getdate(), 
                                                    [updatePersonFK]=@updatePersonFK
                                                    WHERE itemCommentId=@Id";
            List<SqlParameter> prms = new List<SqlParameter>();

            prms.Add(new SqlParameter { ParameterName = "@Id", Value = id });
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = itemComment.itemFK });
            prms.Add(new SqlParameter { ParameterName = "@commentorFK", Value = itemComment.commentorFK });
            prms.Add(new SqlParameter { ParameterName = "@commentText", Value = itemComment.commentText });
            prms.Add(new SqlParameter { ParameterName = "@isHiddenFromOwner", Value = itemComment.isHiddenFromOwner ? "Y" : "N" });
            prms.Add(new SqlParameter { ParameterName = "@updatePersonFK", Value = itemComment.updatePersonFK });

            var number = conn.ExecuteNonQuery(sql,prms);

            if (number != 1)
            {
                throw new Exception($"No ItemComments were updated with Id: {id}");
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
            string sql = @"DELETE FROM itemComment WHERE [itemCommentId] = @Id;";
            List<SqlParameter> prms = new List<SqlParameter>();

            prms.Add(new SqlParameter { ParameterName = "@Id", Value = id });
            
            var rowsAffected = conn.ExecuteNonQuery(sql,prms);
            
            if (rowsAffected < 1)
            {
                throw new Exception("Entity has not been deleted!");
            }
        }

        public void Insert(List<ItemCommentEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Insert(batch, conn);
            }
        }

        public void Insert(List<ItemCommentEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try
            {
                batch.ForEach(x => Insert(x, conn));
            }
            catch(Exception e)
            {
                conn.RollbackTransaction();
            }
            conn.CommitTransaction();
        }

        public void Update(List<ItemCommentEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Update(batch, conn);
            }
        }

        public void Update(List<ItemCommentEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try
            { 
                batch.ForEach(x => Update(x.itemCommentId, x, conn));
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
                Delete(batch,conn);
            }
        }

        public void Delete(List<int> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try
            {
                batch.ForEach(x => Delete(x,conn));
            }
            catch(Exception e)
            {
                conn.RollbackTransaction();
                throw e;
            }
            conn.CommitTransaction();
        }

        private void CheckItemCommentForRequiredValues(ItemCommentEntity ic, RepositoryUtils.RepositoryAction action)
        {
            List<string> missingFields = new List<string>();

            //if (String.IsNullOrWhiteSpace(p.userName)) missingFields.Add("User Name");
            //if (String.IsNullOrWhiteSpace(p.emailAddress)) missingFields.Add("Email Address");
            //if (String.IsNullOrWhiteSpace(p.firstName)) missingFields.Add("First Name");
            //if (String.IsNullOrWhiteSpace(p.lastName)) missingFields.Add("Last Name");
            //if (String.IsNullOrWhiteSpace(p.passwordHash)) missingFields.Add("Password");

            if (missingFields.Count > 0)
            {
                throw new Exception(String.Format("Cannot {0} Person: Missing Fields {1}", action.ToString(), String.Join(", ", missingFields.ToArray())));
            }
        }
    }
}
