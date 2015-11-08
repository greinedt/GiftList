using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public IList<PurchaseEntity> GetAllPurchases()
        {
            using (Connection conn = new Connection())
            {
                return GetAllPurchases(conn);
            }
        }

        public IList<PurchaseEntity> GetAllPurchases(IConnection conn)
        {
            List<PurchaseEntity> purchaseList = new List<PurchaseEntity>();
            string sql = "SELECT purchaseId, itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonKey FROM DBO.PURCHASE;";

            var rdr = conn.ExecuteReader(sql);
            while (rdr.Read())
            {
                var purchase = new PurchaseEntity()
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
            return purchaseList;
        }

        public IList<PurchaseEntity> GetAllPurchases(int purchaser)
        {
            using (Connection conn = new Connection())
            {
                return GetAllPurchases(purchaser, conn);
            }
        }

        public IList<PurchaseEntity> GetAllPurchases(int purchaser, IConnection conn)
        {
            List<PurchaseEntity> purchaseList = new List<PurchaseEntity>();
            string sql = "SELECT purchaseId, itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonKey FROM DBO.PURCHASE WHERE purchaserFK = @purchaserFK";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add( new SqlParameter { ParameterName = "@purchaserFK", Value = purchaser });

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var purchase = new PurchaseEntity()
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
            return purchaseList;
        }

        public long GetNumberOfPurchases(int purchaser)
        {
            using (Connection conn = new Connection())
            {
                return GetNumberOfPurchases(purchaser, conn);
            }
        }
        public long GetNumberOfPurchases(int purchaser, IConnection conn)
        {
                string sql = "SELECT COUNT(purchaseId) FROM DBO.PURCHASE WHERE purchaserFK = @purchaser;";
                List<SqlParameter> prms = new List<SqlParameter>();
                prms.Add(new SqlParameter { ParameterName = "@purchaser", Value = purchaser });
                return Int32.Parse(conn.ExecuteScalar(sql,prms).ToString());
        }

        public PurchaseEntity GetPurchase(int item, int purchaser)
        {
            using (Connection conn = new Connection())
            {
                return GetPurchase(item, purchaser, conn);
            }
        }
        public PurchaseEntity GetPurchase(int item, int purchaser, IConnection conn)
        {
            List<PurchaseEntity> purchaseList = new List<PurchaseEntity>();
            string sql = "SELECT purchaseId, itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonFK FROM DBO.PURCHASE WHERE itemFK = @itemFK AND purchaserFK = @purchaserFK;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = item });
            prms.Add(new SqlParameter { ParameterName = "@purchaserFK", Value = purchaser });

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var purchase = new PurchaseEntity()
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
            return purchaseList.FirstOrDefault();
        }

        public PurchaseEntity GetPurchaseById(int id)
        {
            using (Connection conn = new Connection())
            {
                return GetPurchaseById(id, conn);
            }
        }
        public PurchaseEntity GetPurchaseById(int id, IConnection conn)
        {
            List<PurchaseEntity> purchaseList = new List<PurchaseEntity>();
            string sql = "SELECT purchaseId, itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonFK FROM DBO.PURCHASE WHERE purchaseId = @purchaseId;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@purchaseId", Value = id });

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var purchase = new PurchaseEntity()
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
            return purchaseList.FirstOrDefault();
        }

        public bool PurchaseExists(int item, int purchaser)
        {
            using (Connection conn = new Connection())
            {
                return PurchaseExists(item, purchaser, conn);
            }
        }

        public bool PurchaseExists(int item, int purchaser, IConnection conn)
        {
            const string sql = "SELECT COUNT([purchaseId]) AS PurchaseId FROM dbo.purchase WHERE itemFK = @itemFK and purchaserFK = @purchaserFK;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = item });
            prms.Add(new SqlParameter { ParameterName = "@purchaserFK", Value = purchaser });

            return ((int)conn.ExecuteScalar(sql,prms) >= 1);
        }

        public long Insert(PurchaseEntity purchase)
        {
            using (Connection conn = new Connection())
            {
                return Insert(purchase, conn);
            }
        }

        public long Insert(PurchaseEntity purchase, IConnection conn)
        {
            CheckPurchaseForRequiredValues(purchase, RepositoryUtils.RepositoryAction.Insert);
            var purchaseExists = GetPurchase(purchase.itemFK, purchase.purchaserFK);
            if (purchaseExists != null)
            {
                throw new Exception($"Entity {purchase.itemFK}, {purchase.purchaserFK} already exists in database!");
            }
            string sql =
                @"INSERT INTO[dbo].[purchase] (itemFK, purchaserFK, purchaseDate, updateTimestamp, updatePersonFK) 
                VALUES(@itemFk, @purchaserFK, @purchaseDate, getdate(), @updatePersonKey);SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = purchase.itemFK });
            prms.Add(new SqlParameter { ParameterName = "@purchaserFK", Value = purchase.purchaserFK });
            prms.Add(new SqlParameter { ParameterName = "@purchaseDate", Value = purchase.purchaseDate });
            prms.Add(new SqlParameter { ParameterName = "@updatePersonFK", Value = purchase.updatePersonFK });
            
            try
            {
                return int.Parse(conn.ExecuteScalar(sql,prms).ToString());
            }
            catch (Exception)
            {
                throw new Exception($"Entity {purchase.itemFK} {purchase.purchaserFK} not inserted in database!");
            }
        }

        public void Update(int id, PurchaseEntity purchase)
        {
            using (Connection conn = new Connection())
            {
                Update(id, purchase, conn);
            }
        }

        public void Update(int id, PurchaseEntity purchase, IConnection conn)
        {
            CheckPurchaseForRequiredValues(purchase, RepositoryUtils.RepositoryAction.Update);

            var purchaseToUpdate = GetPurchase(purchase.itemFK, purchase.purchaserFK);
            if (purchaseToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }
            string sql = @"UPDATE person SET [itemFK]=@itemFK,
                                                    [purchaserFK]=@purchaserFK, 
                                                    [purchaseDate]=@purchaseDate, 
                                                    [updateTimestamp]=@getdate(), 
                                                    [updatePersonFK]=@updatePersonFK
                                                    WHERE purchaseId=@Id";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@Id", Value = id });
            prms.Add(new SqlParameter { ParameterName = "@itemFK", Value = purchase.itemFK });
            prms.Add(new SqlParameter { ParameterName = "@purchaserFK", Value = purchase.purchaserFK });
            prms.Add(new SqlParameter { ParameterName = "@purchaseDate", Value = purchase.purchaseDate });
            prms.Add(new SqlParameter { ParameterName = "@updatePersonFK", Value = purchase.updatePersonFK });
                
            var number = conn.ExecuteNonQuery(sql,prms);

            if (number != 1)
            {
                throw new Exception($"No Purchases were updated with Id: {id}");
            }
        }

        public void Delete(int id)
        {
            using(Connection conn = new Connection())
            {
                Delete(id, conn);
            }
        }

        public void Delete(int id, IConnection conn)
        {
            string sql = @"DELETE FROM purchase WHERE [purchaseId] = @Id;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@Id", Value = id });
            var rowsAffected = conn.ExecuteNonQuery(sql,prms);
            if (rowsAffected < 1)
            {
                throw new Exception("Entity has not been deleted!");
            }
        }

        private void CheckPurchaseForRequiredValues(PurchaseEntity p, RepositoryUtils.RepositoryAction action)
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

        public void Insert(List<PurchaseEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Insert(batch,conn);
            }
        }
        public void Insert(List<PurchaseEntity> batch, IConnection conn)
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
        }

        public void Update(List<PurchaseEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Update(batch, conn);
            }
        }

        public void Update(List<PurchaseEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try
            {
                batch.ForEach(x => Update(x.purchaseId, x, conn));
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
