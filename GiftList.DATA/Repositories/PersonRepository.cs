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
        private SqlConnection _conn;
        private const string ConnString = "Data Source=.;Initial Catalog=GiftList;Integrated Security=True";

        public IList<Person> GetAllPersons()
        {
            List<Person> personList = new List<Person>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash FROM DBO.PERSON;";
                var cmd = new SqlCommand(sql, _conn);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var person = new Person()
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
            }
            finally
            {
                _conn?.Close();
            }
            return personList;
        }

        public IList<Person> GetAllPersonsLike(string partialUserName)
        {
            List<Person> personList = new List<Person>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();
                
                string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash FROM DBO.PERSON WHERE userName like @partialUserName;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@partialUserName",
                    Value = "%" + partialUserName + "%"
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var person = new Person()
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
            }
            finally
            {
                _conn?.Close();
            }
            return personList;
        }

        public int GetNumberOfPersons(string partialUserName)
        {
            try { 
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT COUNT(personId) FROM DBO.PERSON WHERE userName LIKE @partialUserName;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@partialUserName",
                    Value = "%" + partialUserName + "%"
                };
                cmd.Parameters.Add(paramQuery);

                return Int32.Parse(cmd.ExecuteScalar().ToString()) ;
            }
            finally
            {
                _conn?.Close();
            }
        }

        public Person GetPersonByEmail(string emailAddress)
        {
            List<Person> personList = new List<Person>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash, updateTimestamp FROM DBO.PERSON WHERE emailAddress = @emailAddress;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@emailAddress",
                    Value = emailAddress
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var person = new Person()
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
            }
            finally
            {
                _conn?.Close();
            }
            return personList.FirstOrDefault();
        }

        public Person GetPersonById(int id)
        {
            List<Person> personList = new List<Person>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash, updateTimestamp FROM DBO.PERSON WHERE personId = @id;";
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
                    var person = new Person()
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
            }
            finally
            {
                _conn?.Close();
            }
            return personList.FirstOrDefault();
        }

        public Person GetPersonByUserName(string userName)
        {
            List<Person> personList = new List<Person>();
            try
            {
                _conn = new SqlConnection(ConnString);
                _conn.Open();

                string sql = "SELECT personId, userName, emailAddress, firstName, lastName, passwordHash, updateTimestamp FROM DBO.PERSON WHERE userName = @userName;";
                var cmd = new SqlCommand(sql, _conn);

                var paramQuery = new SqlParameter
                {
                    ParameterName = "@userName",
                    Value = userName
                };
                cmd.Parameters.Add(paramQuery);

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var person = new Person()
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
            }
            finally
            {
                _conn?.Close();
            }
            return personList.FirstOrDefault();
        }

        public int Insert(Person person)
        {
            CheckPersonForRequiredValues(person, RepositoryUtils.RepositoryAction.Insert);
            try
            {
                var contactExists = GetPersonByEmail(person.emailAddress);
                if (contactExists != null)
                {
                    throw new Exception($"Entity {person.emailAddress} already exists in database!");
                }
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO[dbo].[person] (userName, emailAddress, firstName, lastName, passwordHash, updateTimestamp) 
                    VALUES(@userName, @emailAddress, @firstName, @lastName, @passwordHash, getdate());SELECT CAST(scope_identity() AS int)";


                cmd.Parameters.Add("@userName", SqlDbType.VarChar);
                cmd.Parameters["@userName"].Value = person.userName;

                cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar);
                cmd.Parameters["@emailAddress"].Value = person.emailAddress;

                cmd.Parameters.Add("@firstName", SqlDbType.VarChar);
                cmd.Parameters["@firstName"].Value = person.firstName;

                cmd.Parameters.Add("@lastName", SqlDbType.VarChar);
                cmd.Parameters["@lastName"].Value = person.lastName;

                cmd.Parameters.Add("@passwordHash", SqlDbType.VarChar);
                cmd.Parameters["@passwordHash"].Value = person.passwordHash;

                _conn.Open();

                try
                {
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw new Exception($"Entity {person.firstName} {person.lastName} not inserted in database!");
                }

            }
            finally
            {
                _conn?.Close();
            }
        }

        public bool PersonExistsByEmail(string email)
        {
            try
            {
                const string sql = "SELECT COUNT([personId]) AS ContactsId FROM dbo.person WHERE emailAddress = @emailAddress;";

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                var cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar);
                cmd.Parameters["@emailAddress"].Value = email;

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public bool PersonExistsByUserName(string userName)
        {
            try
            {
                const string sql = "SELECT COUNT([personId]) AS ContactsId FROM dbo.person WHERE userName = @userName;";

                _conn = new SqlConnection(ConnString);
                _conn.Open();

                var cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.Add("@userName", SqlDbType.VarChar);
                cmd.Parameters["@userName"].Value = userName;

                return ((int)cmd.ExecuteScalar() >= 1);
            }
            finally
            {
                _conn?.Close();
            }
        }

        public void Update(int id, Person person)
        {
            CheckPersonForRequiredValues(person, RepositoryUtils.RepositoryAction.Update);

            var contactToUpdate = GetPersonById(id);
            if (contactToUpdate == null)
            {
                throw new Exception("Contact does not exist in database");
            }

            try
            {
                _conn = new SqlConnection(ConnString);

                var cmd = _conn.CreateCommand();
                cmd.CommandText = @"UPDATE person SET [userName]=@userName, 
                                                      [emailAddress]=@emailAddress, 
                                                      [firstName]=@firstName, 
                                                      [lastName]=@lastName, 
                                                      [passwordHash]=@passwordHash, 
                                                      [updateTimeStamp]=getdate()
                                                      WHERE personId=@Id";

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = id;

                cmd.Parameters.Add("@userName", SqlDbType.VarChar);
                cmd.Parameters["@userName"].Value = person.userName;

                cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar);
                cmd.Parameters["@emailAddress"].Value = person.emailAddress;

                cmd.Parameters.Add("@firstName", SqlDbType.VarChar);
                cmd.Parameters["@firstName"].Value = person.firstName;

                cmd.Parameters.Add("@lastName", SqlDbType.VarChar);
                cmd.Parameters["@lastName"].Value = person.lastName;

                cmd.Parameters.Add("@passwordHash", SqlDbType.VarChar);
                cmd.Parameters["@passwordHash"].Value = person.passwordHash;

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
            sqlComm.CommandText = @"DELETE FROM person WHERE [personId] = @Id;";
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

        private void CheckPersonForRequiredValues(Person p, RepositoryUtils.RepositoryAction action)
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

        public void Insert(List<Person> batch)
        {
            batch.ForEach(x => Insert(x));
        }

        public void Update(List<Person> batch)
        {
            batch.ForEach(x => Update(x.personId, x));
        }

        public void Delete(List<int> batch)
        {
            batch.ForEach(x => Delete(x));
        }
    }
}
