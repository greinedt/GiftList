using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IList<PersonEntity> GetAllPersons()
        {
            using (Connection conn = new Connection())
            {
                return GetAllPersons(conn);
            }
        }

        public IList<PersonEntity> GetAllPersons(IConnection conn)
        {
            List<PersonEntity> personList = new List<PersonEntity>();
            
            string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash FROM DBO.PERSON;";
            
            var rdr = conn.ExecuteReader(sql);
            while (rdr.Read())
            {
                var person = new PersonEntity()
                {
                    personId = rdr.IsDBNull(rdr.GetOrdinal("personId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("personId")),
                    userName = rdr.IsDBNull(rdr.GetOrdinal("userName")) ? null : rdr.GetString(rdr.GetOrdinal("userName")),
                    emailAddress = rdr.IsDBNull(rdr.GetOrdinal("emailAddress")) ? null : rdr.GetString(rdr.GetOrdinal("emailAddress")),
                    firstName = rdr.IsDBNull(rdr.GetOrdinal("firstName")) ? null : rdr.GetString(rdr.GetOrdinal("firstName")),
                    lastName = rdr.IsDBNull(rdr.GetOrdinal("lastName")) ? null : rdr.GetString(rdr.GetOrdinal("lastName")),
                    passwordHash = rdr.IsDBNull(rdr.GetOrdinal("passwordHash")) ? null : rdr.GetString(rdr.GetOrdinal("passwordHash"))
                };
                personList.Add(person);
            }
            return personList;
        }

        public IList<PersonEntity> GetAllPersonsLike(string partialUserName)
        {
            using (Connection conn = new Connection())
            {
                return GetAllPersonsLike(partialUserName, conn);
            }
        }

        public IList<PersonEntity> GetAllPersonsLike(string partialUserName, IConnection conn)
        {
            List<PersonEntity> personList = new List<PersonEntity>();
            
            string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash FROM DBO.PERSON WHERE userName like @partialUserName;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@partialUserName", Value = "%" + partialUserName + "%" });

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var person = new PersonEntity()
                {
                    personId = rdr.IsDBNull(rdr.GetOrdinal("personId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("personId")),
                    userName = rdr.IsDBNull(rdr.GetOrdinal("userName")) ? null : rdr.GetString(rdr.GetOrdinal("userName")),
                    emailAddress = rdr.IsDBNull(rdr.GetOrdinal("emailAddress")) ? null : rdr.GetString(rdr.GetOrdinal("emailAddress")),
                    firstName = rdr.IsDBNull(rdr.GetOrdinal("firstName")) ? null : rdr.GetString(rdr.GetOrdinal("firstName")),
                    lastName = rdr.IsDBNull(rdr.GetOrdinal("lastName")) ? null : rdr.GetString(rdr.GetOrdinal("lastName")),
                    passwordHash = rdr.IsDBNull(rdr.GetOrdinal("passwordHash")) ? null : rdr.GetString(rdr.GetOrdinal("passwordHash"))
                };
                personList.Add(person);
            }
            return personList;
        }

        public int GetNumberOfPersons(string partialUserName)
        {
            using (Connection conn = new Connection())
            {
                return GetNumberOfPersons(partialUserName, conn);
            }
        }

        public int GetNumberOfPersons(string partialUserName, IConnection conn)
        {
            string sql = "SELECT COUNT(personId) FROM DBO.PERSON WHERE userName LIKE @partialUserName;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@partialUserName", Value = "%" + partialUserName + "%" });
                
            return Int32.Parse(conn.ExecuteScalar(sql,prms).ToString()) ;
        }

        public PersonEntity GetPersonByEmail(string emailAddress)
        {
            using (Connection conn = new Connection())
            {
                return GetPersonByEmail(emailAddress, conn);
            }
        }

        public PersonEntity GetPersonByEmail(string emailAddress, IConnection conn)
        {
            List<PersonEntity> personList = new List<PersonEntity>();
            
            string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash, updateTimestamp FROM DBO.PERSON WHERE emailAddress = @emailAddress;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@emailAddress", Value = emailAddress });

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var person = new PersonEntity()
                {
                    personId = rdr.IsDBNull(rdr.GetOrdinal("personId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("personId")),
                    userName = rdr.IsDBNull(rdr.GetOrdinal("userName")) ? null : rdr.GetString(rdr.GetOrdinal("userName")),
                    emailAddress = rdr.IsDBNull(rdr.GetOrdinal("emailAddress")) ? null : rdr.GetString(rdr.GetOrdinal("emailAddress")),
                    firstName = rdr.IsDBNull(rdr.GetOrdinal("firstName")) ? null : rdr.GetString(rdr.GetOrdinal("firstName")),
                    lastName = rdr.IsDBNull(rdr.GetOrdinal("lastName")) ? null : rdr.GetString(rdr.GetOrdinal("lastName")),
                    passwordHash = rdr.IsDBNull(rdr.GetOrdinal("passwordHash")) ? null : rdr.GetString(rdr.GetOrdinal("passwordHash")),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp"))
                };
                personList.Add(person);
            }
            return personList.FirstOrDefault();
        }

        public PersonEntity GetPersonById(int id)
        {
            using (Connection conn = new Connection())
            {
                return GetPersonById(id, conn);
            }
        }

        public PersonEntity GetPersonById(int id, IConnection conn)
        {
            List<PersonEntity> personList = new List<PersonEntity>();

            string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash, updateTimestamp FROM DBO.PERSON WHERE personId = @id;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@id", Value = id });

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var person = new PersonEntity()
                {
                    personId = rdr.IsDBNull(rdr.GetOrdinal("personId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("personId")),
                    userName = rdr.IsDBNull(rdr.GetOrdinal("userName")) ? null : rdr.GetString(rdr.GetOrdinal("userName")),
                    emailAddress = rdr.IsDBNull(rdr.GetOrdinal("emailAddress")) ? null : rdr.GetString(rdr.GetOrdinal("emailAddress")),
                    firstName = rdr.IsDBNull(rdr.GetOrdinal("firstName")) ? null : rdr.GetString(rdr.GetOrdinal("firstName")),
                    lastName = rdr.IsDBNull(rdr.GetOrdinal("lastName")) ? null : rdr.GetString(rdr.GetOrdinal("lastName")),
                    passwordHash = rdr.IsDBNull(rdr.GetOrdinal("passwordHash")) ? null : rdr.GetString(rdr.GetOrdinal("passwordHash")),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp"))
                };
                personList.Add(person);
            }
            return personList.FirstOrDefault();
        }

        public PersonEntity GetPersonByUserName(string userName)
        {
            using (Connection conn = new Connection())
            {
                return GetPersonByUserName(userName, conn);
            }
        }

        public PersonEntity GetPersonByUserName(string userName, IConnection conn)
        {
            List<PersonEntity> personList = new List<PersonEntity>();

            string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash, updateTimestamp FROM DBO.PERSON WHERE userName = @userName;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@userName", Value = userName });

            var rdr = conn.ExecuteReader(sql,prms);
            while (rdr.Read())
            {
                var person = new PersonEntity()
                {
                    personId = rdr.IsDBNull(rdr.GetOrdinal("personId")) ? -1 : rdr.GetInt32(rdr.GetOrdinal("personId")),
                    userName = rdr.IsDBNull(rdr.GetOrdinal("userName")) ? null : rdr.GetString(rdr.GetOrdinal("userName")),
                    emailAddress = rdr.IsDBNull(rdr.GetOrdinal("emailAddress")) ? null : rdr.GetString(rdr.GetOrdinal("emailAddress")),
                    firstName = rdr.IsDBNull(rdr.GetOrdinal("firstName")) ? null : rdr.GetString(rdr.GetOrdinal("firstName")),
                    lastName = rdr.IsDBNull(rdr.GetOrdinal("lastName")) ? null : rdr.GetString(rdr.GetOrdinal("lastName")),
                    passwordHash = rdr.IsDBNull(rdr.GetOrdinal("passwordHash")) ? null : rdr.GetString(rdr.GetOrdinal("passwordHash")),
                    updateTimestamp = rdr.IsDBNull(rdr.GetOrdinal("updateTimestamp")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("updateTimestamp"))
                };
                personList.Add(person);
            }
            return personList.FirstOrDefault();
        }

        public int Insert(PersonEntity person)
        {
            using (Connection conn = new Connection())
            {
                return Insert(person, conn);
            }
        }

        public int Insert(PersonEntity person, IConnection conn)
        {
            CheckPersonForRequiredValues(person, RepositoryUtils.RepositoryAction.Insert);
            
            var contactExists = GetPersonByEmail(person.emailAddress);
            if (contactExists != null)
            {
                throw new Exception($"Entity {person.emailAddress} already exists in database!");
            }

            string sql =
                @"INSERT INTO[dbo].[person] (userName, emailAddress, firstName, lastName, passwordHash, updateTimestamp) 
                VALUES(@userName, @emailAddress, @firstName, @lastName, @passwordHash, getdate());SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@userName", Value = person.userName });
            prms.Add(new SqlParameter { ParameterName = "@emailAddress", Value = person.emailAddress });
            prms.Add(new SqlParameter { ParameterName = "@firstName", Value = person.firstName });
            prms.Add(new SqlParameter { ParameterName = "@lastName", Value = person.lastName });
            prms.Add(new SqlParameter { ParameterName = "@passwordHash", Value = person.passwordHash });
            
            try
            {
                return int.Parse(conn.ExecuteScalar(sql,prms).ToString());
            }
            catch (Exception)
            {
                throw new Exception($"Entity {person.firstName} {person.lastName} not inserted in database!");
            }
        }

        public bool PersonExistsByEmail(string email)
        {
            using (Connection conn = new Connection())
            {
                return PersonExistsByEmail(email, conn);
            }
        }

        public bool PersonExistsByEmail(string email, IConnection conn)
        {
            const string sql = "SELECT COUNT([personId]) AS ContactsId FROM dbo.person WHERE emailAddress = @emailAddress;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@emailAddress", Value = email });
            
            return ((int)conn.ExecuteScalar(sql,prms) >= 1);
        }

        public bool PersonExistsByUserName(string userName)
        {
            using (Connection conn = new Connection())
            {
                return PersonExistsByUserName(userName, conn);
            }
        }

        public bool PersonExistsByUserName(string userName, IConnection conn)
        {
            const string sql = "SELECT COUNT([personId]) AS ContactsId FROM dbo.person WHERE userName = @userName;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@userName", Value = userName });

            return ((int)conn.ExecuteScalar(sql,prms) >= 1);
        }
        
        public void Update(int id, PersonEntity person)
        {
            using (Connection conn = new Connection())
            {
                Update(id, person, conn);
            }
        }

        public void Update(int id, PersonEntity person, IConnection conn)
        {
            CheckPersonForRequiredValues(person, RepositoryUtils.RepositoryAction.Update);

            var contactToUpdate = GetPersonById(id);
            if (contactToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }
            string sql =        @"UPDATE person SET [userName]=@userName, 
                                                    [emailAddress]=@emailAddress, 
                                                    [firstName]=@firstName, 
                                                    [lastName]=@lastName, 
                                                    [passwordHash]=@passwordHash, 
                                                    [updateTimestamp]=getdate()
                                                    WHERE personId=@Id";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@Id", Value = id });
            prms.Add(new SqlParameter { ParameterName = "@userName", Value = person.userName });
            prms.Add(new SqlParameter { ParameterName = "@emailAddress", Value = person.emailAddress });
            prms.Add(new SqlParameter { ParameterName = "@firstName", Value = person.firstName });
            prms.Add(new SqlParameter { ParameterName = "@lastName", Value = person.lastName });
            prms.Add(new SqlParameter { ParameterName = "@passwordHash", Value = person.passwordHash });

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
            string sql = @"DELETE FROM person WHERE [personId] = @Id;";
            List<SqlParameter> prms = new List<SqlParameter>();
            prms.Add(new SqlParameter { ParameterName = "@Id", Value = id });
            var rowsAffected = conn.ExecuteNonQuery(sql,prms);
            if (rowsAffected < 1)
            {
                throw new Exception("Entity has not been deleted!");
            }
        }

        private void CheckPersonForRequiredValues(PersonEntity p, RepositoryUtils.RepositoryAction action)
        {
            List<string> missingFields = new List<string>();

            if (String.IsNullOrWhiteSpace(p.userName)) missingFields.Add("User Name");
            if (String.IsNullOrWhiteSpace(p.emailAddress)) missingFields.Add("Email Address");
            if (String.IsNullOrWhiteSpace(p.firstName)) missingFields.Add("First Name");
            if (String.IsNullOrWhiteSpace(p.lastName)) missingFields.Add("Last Name");
            if (String.IsNullOrWhiteSpace(p.passwordHash)) missingFields.Add("Password");

            if (missingFields.Count > 0)
            {
                throw new Exception(String.Format("Cannot {0} Person: Missing Fields {1}", action.ToString(), String.Join(", ", missingFields.ToArray())));
            }
        }

        public void Insert(List<PersonEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Insert(batch, conn);
            }
        }

        public void Insert(List<PersonEntity> batch, IConnection conn)
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

        public void Update(List<PersonEntity> batch)
        {
            using (Connection conn = new Connection())
            {
                Update(batch, conn);
            }
        }

        public void Update(List<PersonEntity> batch, IConnection conn)
        {
            conn.BeginTransaction();
            try
            {
                batch.ForEach(x => Update(x.personId, x, conn));
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
