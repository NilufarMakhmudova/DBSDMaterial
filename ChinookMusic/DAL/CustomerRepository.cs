using ChinookMusic.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookMusic.DAL
{
    public class CustomerRepository : Repository
    {
        public IList<Customer> GetAllCustomers() {
            IList<Customer> cusList = new List<Customer>();
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [CustomerId]
                                              ,[FirstName]
                                              ,[LastName]
                                              ,[Company]
                                              ,[Address]
                                              ,[City]
                                              ,[State]
                                              ,[Country]
                                              ,[PostalCode]
                                              ,[Phone]
                                              ,[Fax]
                                              ,[Email]
                                              ,[SupportRepId]
                                          FROM [dbo].[Customer]";
                    conn.Open();
                    using (DbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Customer c = new Customer()
                            {
                                CustomerId = rdr.GetInt32(0),
                                FirstName = rdr.GetString(1),
                                LastName = rdr.GetString(2),                                
                                Company = rdr.IsDBNull(3) ? null : rdr.GetString(3),                               
                                Address = rdr.IsDBNull(4) ? null : rdr.GetString(4),
                                City = rdr.IsDBNull(5) ? null : rdr.GetString(5),
                                State = rdr.IsDBNull(6) ? null : rdr.GetString(6),
                                Country = rdr.IsDBNull(7) ? null : rdr.GetString(7),                                
                                PostalCode = rdr.IsDBNull(8) ? null : rdr.GetString(8),
                                Phone = rdr.IsDBNull(9) ? null : rdr.GetString(9),
                                Fax = rdr.IsDBNull(10) ? null : rdr.GetString(10),
                                Email = rdr.GetString(11),
                                SupportRepId =rdr.GetInt32(12)
                            };
                            cusList.Add(c);
                        }
                    }
                }
            }
            return cusList;

        
    }
        public void CreateCustomer(Customer cus)
        {
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Customer]
                                                        ([FirstName]
                                                        ,[LastName]
                                                        ,[Company]
                                                        ,[Address]
                                                        ,[City]
                                                        ,[State]
                                                        ,[Country]
                                                        ,[PostalCode]
                                                        ,[Phone]
                                                        ,[Fax]
                                                        ,[Email]
                                                        ,[SupportRepId])
                                                    VALUES(
                                                        @FirstName,
                                                        @LastName,
                                                        @Company,
                                                        @Address,
                                                        @City,
                                                        @State,
                                                        @Country,
                                                        @PostalCode,
                                                        @Phone,
                                                        @Fax,
                                                        @Email,
                                                        @SupportRepId)";

                    DbParameter pLn = cmd.CreateParameter();
                    pLn.DbType = System.Data.DbType.String;
                    pLn.ParameterName = "@LastName";
                    pLn.Value = cus.LastName;
                    cmd.Parameters.Add(pLn);

                    DbParameter pFn = cmd.CreateParameter();
                    pFn.DbType = System.Data.DbType.String;
                    pFn.ParameterName = "@FirstName";
                    pFn.Value = cus.FirstName;
                    cmd.Parameters.Add(pFn);

                    DbParameter pCompany = cmd.CreateParameter();
                    pCompany.DbType = System.Data.DbType.String;
                    pCompany.ParameterName = "@Company";
                    pCompany.Value = cus.Company;
                    cmd.Parameters.Add(pCompany);
                    
                    DbParameter pAddress = cmd.CreateParameter();
                    pAddress.DbType = System.Data.DbType.String;
                    pAddress.ParameterName = "@Address";
                    pAddress.Value = cus.Address;
                    cmd.Parameters.Add(pAddress);

                    DbParameter pCity = cmd.CreateParameter();
                    pCity.DbType = System.Data.DbType.String;
                    pCity.ParameterName = "@City";
                    pCity.Value = cus.City;
                    cmd.Parameters.Add(pCity);                               


                    DbParameter pState = cmd.CreateParameter();
                    pState.DbType = System.Data.DbType.String;
                    pState.ParameterName = "@State";
                    pState.Value = cus.State;
                    cmd.Parameters.Add(pState);


                    DbParameter pCountry = cmd.CreateParameter();
                    pCountry.DbType = System.Data.DbType.String;
                    pCountry.ParameterName = "@Country";
                    pCountry.Value = cus.Country;
                    cmd.Parameters.Add(pCountry);


                    DbParameter pPostalCode = cmd.CreateParameter();
                    pPostalCode.DbType = System.Data.DbType.String;
                    pPostalCode.ParameterName = "@PostalCode";
                    pPostalCode.Value = cus.PostalCode;
                    cmd.Parameters.Add(pPostalCode);


                    DbParameter pPhone = cmd.CreateParameter();
                    pPhone.DbType = System.Data.DbType.String;
                    pPhone.ParameterName = "@Phone";
                    pPhone.Value = cus.Phone;
                    cmd.Parameters.Add(pPhone);


                    DbParameter pFax = cmd.CreateParameter();
                    pFax.DbType = System.Data.DbType.String;
                    pFax.ParameterName = "@Fax";
                    pFax.Value = cus.Fax;
                    cmd.Parameters.Add(pFax);


                    DbParameter pEmail = cmd.CreateParameter();
                    pEmail.DbType = System.Data.DbType.String;
                    pEmail.ParameterName = "@Email";
                    pEmail.Value = cus.Email;
                    cmd.Parameters.Add(pEmail);

                    DbParameter pSupportRepId = cmd.CreateParameter();
                    pSupportRepId.DbType = System.Data.DbType.Int32;
                    pSupportRepId.ParameterName = "@SupportRepId";
                    pSupportRepId.Value = cus.SupportRepId;
                    cmd.Parameters.Add(pSupportRepId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
