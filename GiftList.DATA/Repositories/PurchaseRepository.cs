using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using GiftList.DATA.Entities;

namespace GiftList.DATA.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public IList<Purchase> GetAllPurchases()
        {
            List<Purchase> purchaseList = new List<Purchase>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT purchaseId, itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonKey FROM DBO.PURCHASE;";
                var cmd = new SqlCommand(sql, _conn);
                
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var purchase = new Purchase()
                    {
                        purchaseId = rdr.IsDBNull(rdr.GetOrdinal("purchaseId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("purchaseId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        purchaserFK = rdr.IsDBNull(rdr.GetOrdinal("purchaserFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("purchaserFK")),
                        purchaseDate = rdr.IsDBNull(rdr.GetOrdinal("purchaseDate")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("purchaseDate")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    purchaseList.Add(purchase);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return purchaseList;
        }

        public IList<Purchase> GetAllPurchases(int purchaser)
        {
            List<Purchase> purchaseList = new List<Purchase>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT purchaseId, itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonKey FROM DBO.PURCHASE WHERE purchaserFK = @purchaserFK";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@purchaserFK",
                    Value = purchaser
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var purchase = new Purchase()
                    {
                        purchaseId = rdr.IsDBNull(rdr.GetOrdinal("purchaseId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("purchaseId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        purchaserFK = rdr.IsDBNull(rdr.GetOrdinal("purchaserFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("purchaserFK")),
                        purchaseDate = rdr.IsDBNull(rdr.GetOrdinal("purchaseDate")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("purchaseDate")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    purchaseList.Add(purchase);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return purchaseList;
        }

        public long GetNumberOfPurchases(int purchaser)
        {
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(purchaseId) FROM DBO.PURCHASE WHERE purchaserFK = @purchaser;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@purchaser",
                    Value = purchaser
                };
                cmd.Parameters.Add(paramQuery);

                return Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                _conn?.Close();
            }
        }

        public Purchase GetPurchase(int item, int purchaser)
        {
            List<Purchase> purchaseList = new List<Purchase>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT purchaseId, itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonFK FROM DBO.PURCHASE WHERE itemFK = @itemFK AND purchaserFK = @purchaserFK;";
                var cmd = new SqlCommand(sql, _conn);

                var paramItem = new SqlParameter
                {
                    ParameterName = "@itemFK",
                    Value = item
                };
                cmd.Parameters.Add(paramItem);

                var paramPurchaser = new SqlParameter
                {
                    ParameterName = "@purchaserFK",
                    Value = purchaser
                };
                cmd.Parameters.Add(paramPurchaser);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var purchase = new Purchase()
                    {
                        purchaseId = rdr.IsDBNull(rdr.GetOrdinal("purchaseId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("purchaseId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        purchaserFK = rdr.IsDBNull(rdr.GetOrdinal("purchaserFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("purchaserFK")),
                        purchaseDate = rdr.IsDBNull(rdr.GetOrdinal("purchaseDate")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("purchaseDate")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    purchaseList.Add(purchase);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return purchaseList.FirstOrDefault();
        }

        public Purchase GetPurchaseById(int id)
        {
            List<Purchase> purchaseList = new List<Purchase>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT purchaseId, itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonFK FROM DBO.PURCHASE WHERE purchaseId = @purchaseId;";
                var cmd = new SqlCommand(sql, _conn);

                var paramId = new SqlParameter
                {
                    ParameterName = "@purchaseId",
                    Value = id
                };
                cmd.Parameters.Add(paramId);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var purchase = new Purchase()
                    {
                        purchaseId = rdr.IsDBNull(rdr.GetOrdinal("purchaseId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("purchaseId")),
                        itemFK = rdr.IsDBNull(rdr.GetOrdinal("itemFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("itemFK")),
                        purchaserFK = rdr.IsDBNull(rdr.GetOrdinal("purchaserFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("purchaserFK")),
                        purchaseDate = rdr.IsDBNull(rdr.GetOrdinal("purchaseDate")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("purchaseDate")),
                        updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp")),
                        updatePersonFK = rdr.IsDBNull(rdr.GetOrdinal("updatePersonFK")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("updatePersonFK"))
                    };
                    purchaseList.Add(purchase);
                }
            }
            finally
            {
                _conn?.Close();
            }
            return purchaseList.FirstOrDefault();
        }
        
        public bool PurchaseExists(int item, int purchaser)
        {
            try
            {
                const string sql = "SELECT COUNT([purchaseId]) AS PurchaseId FROM dbo.purchase WHERE itemFK = @itemFK and purchaserFK = @purchaserFK;";

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                var cmd = new SqlCommand(sql, _conn);

                var paramItem = new SqlParameter
                {
                    ParameterName = "@itemFK",
                    Value = item
                };
                cmd.Parameters.Add(paramItem);

                var paramPurchaser = new SqlParameter
                {
                    ParameterName = "@purchaserFK",
                    Value = purchaser
                };
                cmd.Parameters.Add(paramPurchaser);

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public long Insert(Purchase purchase)
        {
            CheckPurchaseForRequiredValues(purchase, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                var purchaseExists = GetPurchase(purchase.itemFK, purchase.purchaserFK);
                if (purchaseExists != null)
                {
                    throw new Exception($"Entity {purchase.itemFK}, {purchase.purchaserFK} already exists in database!");
                }
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO[dbo].[purchase] (itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonFK) 
                    VALUES(@itemFk, @purchaserFK, @purchaseDate, getdate(), @updatePersonKey);SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@itemFk", SqlDbType.Int);
                cmd.Parameters["@itemFk"].Value = purchase.itemFK;

                cmd.Parameters.Add("@purchaserFK", SqlDbType.Int);
                cmd.Parameters["@purchaserFK"].Value = purchase.purchaserFK;

                cmd.Parameters.Add("@purchaseDate", SqlDbType.DateTime);
                cmd.Parameters["@purchaseDate"].Value = purchase.purchaseDate;

                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = purchase.updatePersonFK;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"Entity {purchase.itemFK} {purchase.purchaserFK} not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Update(int id, Purchase purchase)
        {
            CheckPurchaseForRequiredValues(purchase, RepositoryUtils.RepositoryAction.Update);

            var purchaseToUpdate = GetPurchase(purchase.itemFK, purchase.purchaserFK);
            if (purchaseToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE person SET [itemFK]=@itemFK,
                                                      [purchaserFK]=@purchaserFK, 
                                                      [purchaseDate]=@purchaseDate, 
                                                      [updateTimestamp]=@getdate(), 
                                                      [updatePersonFK]=@updatePersonFK
                                                      WHERE purchaseId=@Id";

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = id;

                cmd.Parameters.Add("@itemFK", SqlDbType.Int);
                cmd.Parameters["@itemFK"].Value = purchase.itemFK;

                cmd.Parameters.Add("@purchaserFK", SqlDbType.Int);
                cmd.Parameters["@purchaserFK"].Value = purchase.purchaserFK;

                cmd.Parameters.Add("@purchaseDate", SqlDbType.DateTime);
                cmd.Parameters["@purchaseDate"].Value = purchase.purchaseDate;
                
                cmd.Parameters.Add("@updatePersonFK", SqlDbType.Int);
                cmd.Parameters["@updatePersonFK"].Value = purchase.updatePersonFK;

                _conn.Open();

                var number = cmd.ExecuteNonQuery();

                if (number != 1)
                {
                    throw new Exception($"No Purchases were updated with Id: {id}");
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
            sqlComm.CommandText = @"DELETE FROM purchase WHERE [purchaseId] = @Id;";
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

        private void CheckPurchaseForRequiredValues(Purchase p, RepositoryUtils.RepositoryAction action)
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
