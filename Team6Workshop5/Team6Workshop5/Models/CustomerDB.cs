using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Team6Workshop5.Models
{
    public class CustomerDB
    {
        public static Customer GetCustomerDetails(int custId)
        {
            Customer cust = null;
            string query = "SELECT CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, " +
                           "CustHomePhone, CustBusPhone, CustEmail, AgentId, UserName " +
                           "FROM Customers " +
                           "WHERE CustomerId = @CustomerId";

            using (SqlConnection connection = new SqlConnection(TravelExpertsDB.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", custId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        cust = new Customer();
                        cust.CustFirstName = reader["CustFirstName"].ToString();
                        cust.CustLastName = reader["CustLastName"].ToString();
                        cust.CustAddress = reader["CustAddress"].ToString();
                        cust.CustCity = reader["CustCity"].ToString();
                        cust.CustProv = reader["CustProv"].ToString();
                        cust.CustPostal = reader["CustPostal"].ToString();
                        cust.CustCountry = reader["CustCountry"].ToString();
                        cust.CustHomePhone = reader["CustHomePhone"].ToString();
                        cust.CustBusPhone = reader["CustBusPhone"].ToString();
                        cust.CustEmail = reader["CustEmail"].ToString();
                        cust.AgentId = Convert.ToInt32(reader["AgentId"]);
                        cust.UserName = reader["UserName"].ToString();

                    }
                }
            }
            return cust;
        }
    }
}