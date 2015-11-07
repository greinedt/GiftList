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
        public IList<ItemEntity> GetAllItems()
        {
            using (Connection conn = new Connection())
            {
                return GetAllItems(conn);
            }
        }

        public IList<ItemEntity> GetAllItems(IConnection conn)
        {
            List<ItemEntity> itemList = new List<ItemEntity>();
            
            string sql = "SELECT itemId, itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK FROM dbo.item;";
                
            var rdr = conn.ExecuteReader(sql);
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

            return itemList;
        }

        public IList<ItemEntity> GetAllItems(int giftList)
        {
            using (Connection conn = new Connection())
            {
                return GetAllItems(giftList, conn);
            }
        }

        public IList<ItemEntity> GetAllItems(int giftList, IConnection conn)
        {
            List<ItemEntity> itemList = new List<ItemEntity>();
            
            string sql = "SELECT itemId, itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK FROM dbo.item WHERE giftList = @giftListFK;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add( new SqlParameter { ParameterName = "@giftListFK", Value = giftList });

            var rdr = conn.ExecuteReader(sql,prms);
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
            return itemList;
        }

        public ItemEntity GetItem(int list, string itemName)
        {
            using (Connection conn = new Connection())
            {
                return GetItem(list, itemName, conn);
            }
        }

        public ItemEntity GetItem(int list, string itemName, IConnection conn)
        {
            List<ItemEntity> itemList = new List<ItemEntity>();
           
            string sql = "SELECT itemId, itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK FROM dbo.item FROM dbo.item WHERE listFK = @listFK and itemName = @itemName;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@listFK", Value = list });
            prms.Add(new SqlParameter { ParameterName = "@itemName", Value = itemName });
            
            var rdr = conn.ExecuteReader(sql,prms);
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
            return itemList.FirstOrDefault();
        }

        public ItemEntity GetItemById(int id)
        {
            using (Connection conn = new Connection())
            {
                return GetItemById(id, conn);
            }
        }

        public ItemEntity GetItemById(int id, IConnection conn)
        {
            List<ItemEntity> itemList = new List<ItemEntity>();
            
            string sql = "SELECT itemId, itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK FROM dbo.item FROM dbo.item WHERE itemId = @id;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@id", Value = id });

            var rdr = conn.ExecuteReader(sql,prms);
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
            return itemList.FirstOrDefault();
        }

        public bool ItemExists(int giftList, string itemName)
        {
            using (Connection conn = new Connection())
            {
                return ItemExists(giftList, itemName, conn);
            }
        }

        public bool ItemExists(int giftList, string itemName, IConnection conn)
        {
            const string sql = "SELECT COUNT([itemId]) FROM dbo.item WHERE listFK = @giftListFK and itemName like @itemName;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@giftListFK", Value = giftList });
            prms.Add(new SqlParameter { ParameterName = "@itemName", Value = itemName });

            return ((int)conn.ExecuteScalar(sql,prms) >= 1);
        }

        public long GetNumberOfItems(int giftList)
        {
            using (Connection conn = new Connection())
            {
                return GetNumberOfItems(giftList, conn);
            }
        }

        public long GetNumberOfItems(int giftList, IConnection conn)
        {
            string sql = "SELECT COUNT(itemId) FROM dbo.item WHERE giftListFK = @giftListFK;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@giftListFK", Value = giftList });
            
            return Int32.Parse(conn.ExecuteScalar(sql,prms).ToString());
        }

        public long Insert(ItemEntity item)
        {
            using (Connection conn = new Connection())
            {
                return Insert(item, conn);
            }
        }

        public long Insert(ItemEntity item, IConnection conn)
        {
            CheckItemForRequiredValues(item, RepositoryUtils.RepositoryAction.Insert);
            
            var itemExists = ItemExists(item.giftListFK, item.itemName);
            if (!itemExists)
            {
                throw new Exception($"Entity {item.giftListFK} {item.itemName} already exists in database!");
            }

            string sql =
                @"INSERT INTO[dbo].[person] (itemStatusFK, giftListFK, itemName, description, updateTimestamp, updatePersonFK) 
                VALUES(@itemStatusFK, @giftListFK, @itemName, @description, getdate(), @updatePersonFK);SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@itemStatusFK", Value = item.itemStatusFK });
            prms.Add(new SqlParameter { ParameterName = "@giftListFK", Value = item.giftListFK });
            prms.Add(new SqlParameter { ParameterName = "@itemName", Value = item.itemName });
            prms.Add(new SqlParameter { ParameterName = "@description", Value = item.description });
            prms.Add(new SqlParameter { ParameterName = "@updatePersonFK", Value = item.updatePersonFK });

            try
            {
                return int.Parse(conn.ExecuteScalar(sql, prms).ToString());
            }
            catch (Exception)
            {
                throw new Exception($"Entity {item.giftListFK} {item.itemName} not inserted in database!");
            }
        }

        public void Update(int id, ItemEntity item)
        {
            using (Connection conn = new Connection())
            {
                Update(id, item, conn);
            }
        }

        public void Update(int id, ItemEntity item, IConnection conn)
        {
            CheckItemForRequiredValues(item, RepositoryUtils.RepositoryAction.Update);

            var contactToUpdate = GetItemById(id);
            if (contactToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }
            
            string sql = @"UPDATE person SET [itemStatusFK]=@itemStatusFK, 
                                                    [giftListFK]=@giftListFK, 
                                                    [itemName]=@itemName, 
                                                    [description]=@description,  
                                                    [updateTimestamp]=getdate(),
                                                    [updatePersonFK]=@updatePersonFK,
                                                    WHERE personId=@Id";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@Id", Value = id });
            prms.Add(new SqlParameter { ParameterName = "@itemStatusFK", Value = item.itemStatusFK });
            prms.Add(new SqlParameter { ParameterName = "@giftListFK", Value = item.giftListFK });
            prms.Add(new SqlParameter { ParameterName = "@itemName", Value = item.itemName });
            prms.Add(new SqlParameter { ParameterName = "@description", Value = item.description });
            prms.Add(new SqlParameter { ParameterName = "@updatePersonFK", Value = item.updatePersonFK });
                
            var number = conn.ExecuteNonQuery(sql,prms);

            if (number != 1)
            {
                throw new Exception($"No Contacts were updated with Id: {id}");
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
            string sql = @"DELETE FROM item WHERE [itemId] = @Id;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@Id", Value = id });
            
            var rowsAffected = conn.ExecuteNonQuery(sql,prms);
            
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
            using (Connection conn = new Connection())
            {
                Insert(batch, conn);
            }
        }

        public void Insert(List<ItemEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try
            {
                batch.ForEach(x => Insert(x, conn));
            }
            catch(Exception e)
            {
                conn.RollbackTransaction();
                throw e;
            }
            conn.CommitTransaction();
        }

        public void Update(List<ItemEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Update(batch, conn);
            }
        }

        public void Update(List<ItemEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try {
                batch.ForEach(x => Update(x.itemId, x, conn));
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
