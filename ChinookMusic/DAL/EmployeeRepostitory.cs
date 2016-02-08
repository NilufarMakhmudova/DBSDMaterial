using ChinookMusic.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ChinookMusic.DAL
{
   public class EmployeeRepository:Repository
    {
       
        public IList<Employee> GetAllEmployees()
        {
            IList<Employee> empList = new List<Employee>();
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [EmployeeId]
                                          ,[LastName]
                                          ,[FirstName]
                                          ,[Title]
                                          ,[ReportsTo]
                                          ,[BirthDate]
                                          ,[HireDate]
                                          ,[Address]
                                          ,[City]
                                          ,[State]
                                          ,[Country]
                                          ,[PostalCode]
                                          ,[Phone]
                                          ,[Fax]
                                          ,[Email]
                                      FROM [dbo].[Employee]";
                    conn.Open();
                    using (DbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Employee e = new Employee()
                            {
                                EmployeeId = rdr.GetInt32(0),
                                LastName = rdr.GetString(1),
                                FirstName = rdr.GetString(2),
                                Title = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                                ReportsTo = rdr.IsDBNull(4)
                                           ? (int?)null : rdr.GetInt32(4),
                                BirthDate = rdr.IsDBNull(5)
  ? null as DateTime? : rdr.GetDateTime(5),
                                HireDate = rdr.IsDBNull(6)
  ? null as DateTime? : rdr.GetDateTime(6),
                                Address = rdr.IsDBNull(7) ? null : rdr.GetString(7),
                                City = rdr.IsDBNull(8) ? null : rdr.GetString(8),
                                State = rdr.IsDBNull(9) ? null : rdr.GetString(9),
                                Country = rdr.IsDBNull(10) ? null : rdr.GetString(10),
                                /*add missing fields yourself!*/
                                PostalCode = rdr.GetString(11),
                                Phone = rdr.GetString(12),
                                Fax = rdr.GetString(13),
                                Email = rdr.GetString(14)
                            };
                            empList.Add(e);
                        }
                    }
                }
            }
            return empList;

        }
        public void CreateEmployee(Employee emp)
        {
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Employee]
                                                           ([LastName]
                                                           ,[FirstName]
                                                           ,[Title]
                                                           ,[ReportsTo]
                                                           ,[BirthDate]
                                                           ,[HireDate]
                                                           ,[Address]
                                                           ,[City]
                                                           ,[State]
                                                           ,[Country]
                                                           ,[PostalCode]
                                                           ,[Phone]
                                                           ,[Fax]
                                                           ,[Email])
                                                     VALUES(
                                                            @LastName,
                                                            @FirstName,
                                                            @Title,
                                                            @ReportsTo,
                                                            @BirthDate,
                                                            @HireDate,
                                                            @Address,
                                                            @City,
                                                            @State,
                                                            @Country,
                                                            @PostalCode,
                                                            @Phone,
                                                            @Fax,
                                                            @Email)";

                    DbParameter pLn = cmd.CreateParameter();
                    pLn.DbType = System.Data.DbType.String;
                    pLn.ParameterName = "@LastName";
                    pLn.Value = emp.LastName;
                    cmd.Parameters.Add(pLn);

                    DbParameter pFn = cmd.CreateParameter();
                    pFn.DbType = System.Data.DbType.String;
                    pFn.ParameterName = "@FirstName";
                    pFn.Value = emp.FirstName;
                    cmd.Parameters.Add(pFn);

                    DbParameter pTitle = cmd.CreateParameter();
                    pTitle.DbType = System.Data.DbType.String;
                    pTitle.ParameterName = "@Title";
                    pTitle.Value = emp.Title;
                    cmd.Parameters.Add(pTitle);
                    /*add missing fields yourself!*/
                    DbParameter pReportsTo = cmd.CreateParameter();
                    pReportsTo.DbType = System.Data.DbType.Int32;
                    pReportsTo.ParameterName = "@ReportsTo";
                    pReportsTo.Value = emp.ReportsTo;
                    cmd.Parameters.Add(pReportsTo);

                    DbParameter pBirthDate = cmd.CreateParameter();
                    pBirthDate.DbType = System.Data.DbType.DateTime;
                    pBirthDate.ParameterName = "@BirthDate";
                    pBirthDate.Value = emp.BirthDate;
                    cmd.Parameters.Add(pBirthDate);


                    DbParameter pHireDate = cmd.CreateParameter();
                    pHireDate.DbType = System.Data.DbType.DateTime;
                    pHireDate.ParameterName = "@HireDate";
                    pHireDate.Value = emp.HireDate;
                    cmd.Parameters.Add(pHireDate);


                    DbParameter pAddress = cmd.CreateParameter();
                    pAddress.DbType = System.Data.DbType.String;
                    pAddress.ParameterName = "@Address";
                    pAddress.Value = emp.Address;
                    cmd.Parameters.Add(pAddress);


                    DbParameter pCity = cmd.CreateParameter();
                    pCity.DbType = System.Data.DbType.String;
                    pCity.ParameterName = "@City";
                    pCity.Value = emp.City;
                    cmd.Parameters.Add(pCity);


                    DbParameter pState = cmd.CreateParameter();
                    pState.DbType = System.Data.DbType.String;
                    pState.ParameterName = "@State";
                    pState.Value = emp.State;
                    cmd.Parameters.Add(pState);


                    DbParameter pCountry = cmd.CreateParameter();
                    pCountry.DbType = System.Data.DbType.String;
                    pCountry.ParameterName = "@Country";
                    pCountry.Value = emp.Country;
                    cmd.Parameters.Add(pCountry);


                    DbParameter pPostalCode = cmd.CreateParameter();
                    pPostalCode.DbType = System.Data.DbType.String;
                    pPostalCode.ParameterName = "@PostalCode";
                    pPostalCode.Value = emp.PostalCode;
                    cmd.Parameters.Add(pPostalCode);


                    DbParameter pPhone = cmd.CreateParameter();
                    pPhone.DbType = System.Data.DbType.String;
                    pPhone.ParameterName = "@Phone";
                    pPhone.Value = emp.Phone;
                    cmd.Parameters.Add(pPhone);


                    DbParameter pFax = cmd.CreateParameter();
                    pFax.DbType = System.Data.DbType.String;
                    pFax.ParameterName = "@Fax";
                    pFax.Value = emp.Fax;
                    cmd.Parameters.Add(pFax);


                    DbParameter pEmail = cmd.CreateParameter();
                    pEmail.DbType = System.Data.DbType.String;
                    pEmail.ParameterName = "@Email";
                    pEmail.Value = emp.Email;
                    cmd.Parameters.Add(pEmail);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
