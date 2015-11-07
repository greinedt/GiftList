using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public IList<ItemEntity> GetAllItems()
        {
            List<ItemEntity> itemList = new List<ItemEntity>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemId, itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK FROM dbo.item;";
                var cmd = new SqlCommand(sql, _conn);
                
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var item = new ItemEntity()
                    {
                        itemId = rdr.IsDBNull(rdr.GetOrdinal("itemId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemId")),
                        itemStatusFK = rdr.IsDBNull(rdr.GetOrdinal("itemStatusFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemStatusFK")),
                        giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                        itemName = rdr.IsDBNull(rdr.GetOrdinal("itemName")) ? null : rdr.GetString(rdr.GetOrdinal("itemName")),
                        description = rdr.IsDBNull(rdr.GetOrdinal("description")) ? null : rdr.GetString(rdr.GetOrdinal("description")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemList.Add(item);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemList;
        }

        public IList<ItemEntity> GetAllItems(int giftList)
        {
            List<ItemEntity> itemList = new List<ItemEntity>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemId, itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK FROM dbo.item WHERE giftList = @giftListFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@giftListFK",
                    Value = giftList
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var item = new ItemEntity()
                    {
                        itemId = rdr.IsDBNull(rdr.GetOrdinal("itemId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemId")),
                        itemStatusFK = rdr.IsDBNull(rdr.GetOrdinal("itemStatusFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemStatusFK")),
                        giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                        itemName = rdr.IsDBNull(rdr.GetOrdinal("itemName")) ? null : rdr.GetString(rdr.GetOrdinal("itemName")),
                        description = rdr.IsDBNull(rdr.GetOrdinal("description")) ? null : rdr.GetString(rdr.GetOrdinal("description")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemList.Add(item);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemList;
        }

        public ItemEntity GetItem(int list, string itemName)
        {
            List<ItemEntity> itemList = new List<ItemEntity>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemId, itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK FROM dbo.item FROM dbo.item WHERE listFK = @listFK and itemName = @itemName;";
                var cmd = new SqlCommand(sql, _conn);

                var paramList = new SqlParameter
                {
                    ParameterName = "@listFK",
                    Value = list
                };
                cmd.Parameters.Add(paramList);

                var paramName = new SqlParameter
                {
                    ParameterName = "@itemName",
                    Value = itemName
                };
                cmd.Parameters.Add(paramName);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var item = new ItemEntity()
                    {
                        itemId = rdr.IsDBNull(rdr.GetOrdinal("itemId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemId")),
                        itemStatusFK = rdr.IsDBNull(rdr.GetOrdinal("itemStatusFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemStatusFK")),
                        giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                        itemName = rdr.IsDBNull(rdr.GetOrdinal("itemName")) ? null : rdr.GetString(rdr.GetOrdinal("itemName")),
                        description = rdr.IsDBNull(rdr.GetOrdinal("description")) ? null : rdr.GetString(rdr.GetOrdinal("description")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemList.Add(item);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemList.FirstOrDefault();
        }

        public ItemEntity GetItemById(int id)
        {
            List<ItemEntity> itemList = new List<ItemEntity>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT itemId, itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK FROM dbo.item FROM dbo.item WHERE itemId = @id;";
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
                    var item = new ItemEntity()
                    {
                        itemId = rdr.IsDBNull(rdr.GetOrdinal("itemId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemId")),
                        itemStatusFK = rdr.IsDBNull(rdr.GetOrdinal("itemStatusFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemStatusFK")),
                        giftListFK = rdr.IsDBNull(rdr.GetOrdinal("giftListFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("giftListFK")),
                        itemName = rdr.IsDBNull(rdr.GetOrdinal("itemName")) ? null : rdr.GetString(rdr.GetOrdinal("itemName")),
                        description = rdr.IsDBNull(rdr.GetOrdinal("description")) ? null : rdr.GetString(rdr.GetOrdinal("description")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    itemList.Add(item);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return itemList.FirstOrDefault();
        }

        public bool ItemExists(int giftList, string itemName)
        {
            try
            {
                const string sql = "SELECT COUNT([itemId]) FROM dbo.item WHERE listFK = @giftListFK and itemName like @itemName;";

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                var cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.Add("@giftListFK", SqlDbType.Int);
                cmd.Parameters["@giftListFK"].Value = giftList;
                
                cmd.Parameters.Add("@itemName", SqlDbType.VarChar);
                cmd.Parameters["@itemName"].Value = itemName;

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public long GetNumberOfItems(int giftList)
        {
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(itemId) FROM dbo.item WHERE giftListFK = @giftListFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@giftListFK",
                    Value = giftList
                };
                cmd.Parameters.Add(paramQuery);

                return Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                _conn?.Close();
            }
        }

        public long Insert(ItemEntity item)
        {
            CheckItemForRequiredValues(item, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                var itemExists = ItemExists(item.giftListFK, item.itemName);
                if (!itemExists)
                {
                    throw new Exception($"Entity {item.giftListFK} {item.itemName} already exists in database!");
                }
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO[dbo].[person] (itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK) 
                    VALUES(@itemStatusFK, @giftListFK, @itemName, @description, getdate(), @updatePersonFK);SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@itemStatusFK", SqlDbType.Int);
                cmd.Parameters["@itemStatusFK"].Value = item.itemStatusFK;

                cmd.Parameters.Add("@giftListFK", SqlDbType.Int);
                cmd.Parameters["@giftListFK"].Value = item.giftListFK;

                cmd.Parameters.Add("@itemName", SqlDbType.VarChar);
                cmd.Parameters["@itemName"].Value = item.itemName;

                cmd.Parameters.Add("@description", SqlDbType.VarChar);
                cmd.Parameters["@description"].Value = item.description;

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = item.updatePersonFK;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"Entity {item.giftListFK} {item.itemName} not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Update(int id, ItemEntity item)
        {
            CheckItemForRequiredValues(item, RepositoryUtils.RepositoryAction.Update);

            var contactToUpdate = GetItemById(id);
            if (contactToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE person SET [itemStatusFK]=@itemStatusFK, 
                                                      [giftListFK]=@giftListFK, 
                                                      [itemName]=@itemName, 
                                                      [description]=@description,  
                                                      [updateTimestamp]=getdate(),
                                                      [updatePersonFK]=@updatePersonFK,
                                                      WHERE personId=@Id";

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = id;

                cmd.Parameters.Add("@itemStatusFK", SqlDbType.Int);
                cmd.Parameters["@itemStatusFK"].Value = item.itemStatusFK;

                cmd.Parameters.Add("@giftListFK", SqlDbType.Int);
                cmd.Parameters["@giftListFK"].Value = item.giftListFK;

                cmd.Parameters.Add("@itemName", SqlDbType.VarChar);
                cmd.Parameters["@itemName"].Value = item.itemName;

                cmd.Parameters.Add("@description", SqlDbType.VarChar);
                cmd.Parameters["@description"].Value = item.description;

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = item.updatePersonFK;

                _conn.Open();

                var number = cmd.ExecuteNonQuery();

                if (number != 1)
                {
                    throw new Exception($"No Contacts were updated with Id: {id}");
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
            sqlComm.CommandText = @"DELETE FROM item WHERE [itemId] = @Id;";
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

        private void CheckItemForRequiredValues(ItemEntity i, RepositoryUtils.RepositoryAction action)
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

        public void Insert(List<ItemEntity> batch)
        {
            batch.ForEach(x => Insert(x));
        }

        public void Update(List<ItemEntity> batch)
        {
            batch.ForEach(x => Update(x.itemId, x));
        }

        public void Delete(List<int> batch)
        {
            batch.ForEach(x => Delete(x));
        }
    }
}
