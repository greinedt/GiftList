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
        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public IList<ItemComment> GetAllItemComments(int item)
        {
            List<ItemComment> itemCommentList = new List<ItemComment>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemCommentId, itemFK, commentorFK, commentText, isHiddenFromOwner, updateTimestamp, updatePersonFK FROM dbo.itemComment WHERE itemFK = @itemFK;";
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
                    var itemComment = new ItemComment()
                    {
                        itemCommentId = rdr.IsDBNull(rdr.GetOrdinal("itemCommentId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemCommentId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        commentorFK = rdr.IsDBNull(rdr.GetOrdinal("commentorFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("commentorFK")),
                        commentText = rdr.IsDBNull(rdr.GetOrdinal("commentText")) ? null : rdr.GetString(rdr.GetOrdinal("commentText")),
                        isHiddenFromOwner = rdr.IsDBNull(rdr.GetOrdinal("isHiddenFromOwner")) ? true : (rdr.GetString(rdr.GetOrdinal("isHiddenFromOwner")) == "Y"),
                        updateTimeStamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemCommentList.Add(itemComment);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemCommentList;
        }

        public ItemComment GetItemCommentById(int id)
        {
            List<ItemComment> itemCommentList = new List<ItemComment>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemCommentId, itemFK, commentorFK, commentText, isHiddenFromOwner, updateTimestamp, updatePersonFK FROM dbo.itemComment WHERE itemCommentId = @id;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var itemComment = new ItemComment()
                    {
                        itemCommentId = rdr.IsDBNull(rdr.GetOrdinal("itemCommentId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemCommentId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        commentorFK = rdr.IsDBNull(rdr.GetOrdinal("commentorFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("commentorFK")),
                        commentText = rdr.IsDBNull(rdr.GetOrdinal("commentText")) ? null : rdr.GetString(rdr.GetOrdinal("commentText")),
                        isHiddenFromOwner = rdr.IsDBNull(rdr.GetOrdinal("isHiddenFromOwner")) ? true : (rdr.GetString(rdr.GetOrdinal("isHiddenFromOwner")) == "Y"),
                        updateTimeStamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemCommentList.Add(itemComment);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemCommentList.FirstOrDefault();
        }

        public ItemComment GetItemCommentByItem(int itemId)
        {
            List<ItemComment> itemCommentList = new List<ItemComment>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemCommentId, itemFK, commentorFK, commentText, isHiddenFromOwner, updateTimestamp, updatePersonFK FROM dbo.itemComment WHERE itemId = @itemId;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@itemId",
                    Value = itemId
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var itemComment = new ItemComment()
                    {
                        itemCommentId = rdr.IsDBNull(rdr.GetOrdinal("itemCommentId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemCommentId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        commentorFK = rdr.IsDBNull(rdr.GetOrdinal("commentorFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("commentorFK")),
                        commentText = rdr.IsDBNull(rdr.GetOrdinal("commentText")) ? null : rdr.GetString(rdr.GetOrdinal("commentText")),
                        isHiddenFromOwner = rdr.IsDBNull(rdr.GetOrdinal("isHiddenFromOwner")) ? true : (rdr.GetString(rdr.GetOrdinal("isHiddenFromOwner")) == "Y"),
                        updateTimeStamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemCommentList.Add(itemComment);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemCommentList.FirstOrDefault();
        }

        public long GetNumberOfItemComments(int item)
        {
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(itemCommentId) FROM DBO.PERSON WHERE itemFK LIKE @item;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@item",
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

        public long Insert(ItemComment itemComment)
        {
            CheckItemCommentForRequiredValues(itemComment, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO [dbo].[itemComment] (itemFK, commentorFK, commentText, isHiddenFromOwner, updateTimestamp, updatePersonFK) 
                    VALUES(@itemFK, @commentorFK, @commentText, @isHiddenFromOwner, getdate(), @updatePersonFK);SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@itemFK", SqlDbType.VarChar);
                cmd.Parameters["@itemFK"].Value = itemComment.itemFK;

                cmd.Parameters.Add("@commentorFK", SqlDbType.VarChar);
                cmd.Parameters["@commentorFK"].Value = itemComment.commentorFK;

                cmd.Parameters.Add("@commentText", SqlDbType.VarChar);
                cmd.Parameters["@commentText"].Value = itemComment.commentText;

                cmd.Parameters.Add("@isHiddenFromOwner", SqlDbType.VarChar);
                cmd.Parameters["@isHiddenFromOwner"].Value = itemComment.isHiddenFromOwner;

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.VarChar);
                cmd.Parameters["@updatePersonFK"].Value = itemComment.updatePersonFK;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"ItemComment not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }
        
        public void Update(int id, ItemComment itemComment)
        {
            CheckItemCommentForRequiredValues(itemComment, RepositoryUtils.RepositoryAction.Update);

            var contactToUpdate = GetItemCommentById(id);
            if (contactToUpdate == null)
            {
                throw new Exception("ItemComment does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE itemComment SET [itemFK]=@itemFK, 
                                                      [commentorFK]=@commentorFK, 
                                                      [commentText]=@commentText, 
                                                      [isHiddenFromOwner]=@getdate(), 
                                                      [updatePersonFK]=@updatePersonFK
                                                      WHERE itemCommentId=@Id";

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = id;

                cmd.Parameters.Add("@itemFK", SqlDbType.Int);
                cmd.Parameters["@itemFK"].Value = itemComment.itemFK;

                cmd.Parameters.Add("@commentorFK", SqlDbType.Int);
                cmd.Parameters["@commentorFK"].Value = itemComment.commentorFK;

                cmd.Parameters.Add("@commentText", SqlDbType.VarChar);
                cmd.Parameters["@commentText"].Value = itemComment.commentText;

                cmd.Parameters.Add("@isHiddenFromOwner", SqlDbType.VarChar);
                cmd.Parameters["@isHiddenFromOwner"].Value = itemComment.isHiddenFromOwner ? "Y" : "N";

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = itemComment.updatePersonFK;

                _conn.Open();

                var number = cmd.ExecuteNonQuery();

                if (number != 1)
                {
                    throw new Exception($"No ItemComments were updated with Id: {id}");
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
            sqlComm.CommandText = @"DELETE FROM itemComment WHERE [itemCommentId] = @Id;";
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

        private void CheckItemCommentForRequiredValues(ItemComment ic, RepositoryUtils.RepositoryAction action)
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
