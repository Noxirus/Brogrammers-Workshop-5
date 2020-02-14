using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Team6Workshop5.Models
{
    public class AccountBookingsDB
    {
        public static List<AccountPackBookings> GetPackBookings()
        {
            List<AccountPackBookings> accPackBookingsList = new List<AccountPackBookings>();
            
            string sql = "Select C.CustFirstName, P.ProdName,BD.BasePrice, Pack.PkgName,Pack.PkgBasePrice,B.BookingId from "
                            + "Customers as C join Bookings as B "
                            + "on C.CustomerId= B.CustomerId "
                            + "join Packages as Pack on "
                            + "B.PackageId = Pack.PackageId "
                            + "join BookingDetails as BD "
                            + "on B.BookingId = BD.BookingId "
                            + "join  Products_Suppliers as PS "
                            + "on BD.ProductSupplierId= PS.ProductSupplierId "
                            + "join Products as P "
                            + "on Ps.ProductId=P.ProductId "
                            + "where C.CustomerId=143 ";

            using (SqlConnection con = new SqlConnection(TravelExpertsDB.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    AccountPackBookings accbooking;
                    while (dr.Read())
                    {
                        accbooking = new AccountPackBookings();
                        accbooking.CustFirstName = dr["CustFirstName"].ToString();
                        accbooking.ProdName = dr["ProdName"].ToString();
                        accbooking.BasePrice = Convert.ToDecimal(dr["BasePrice"]);
                        accbooking.PkgName = dr["PkgName"].ToString();
                        accbooking.PkgBasePrice = Convert.ToDecimal(dr["PkgBasePrice"]);
                        accbooking.BookingId = Convert.ToInt32(dr["BookingId"]);
                        accPackBookingsList.Add(accbooking);
                    }
                    dr.Close();
                }
            }
            return accPackBookingsList;
        }

        public static List<AccountProdBookings> GetProdBookings()
        {
            List<AccountProdBookings> accProdBookingsList = new List<AccountProdBookings>();

            string sql = "Select C.CustFirstName, P.ProdName, BD.BasePrice, B.BookingId from "
                            + "Customers as C join Bookings as B "
                            + "on C.CustomerId= B.CustomerId "
                            + "join BookingDetails as BD "
                            + "on B.BookingId = BD.BookingId "
                            + "join  Products_Suppliers as PS "
                            + "on BD.ProductSupplierId= PS.ProductSupplierId "
                            + "join Products as P "
                            + "on Ps.ProductId=P.ProductId "
                            + "where C.CustomerId = 143 ";

            using (SqlConnection con = new SqlConnection(TravelExpertsDB.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    AccountPackBookings bookingId = new AccountPackBookings();
                    //cmd.Parameters["@BookingId"].Value = bookingId.BookingId;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    AccountProdBookings accbooking;
                    while (dr.Read())
                    {
                        accbooking = new AccountProdBookings();
                        accbooking.CustFirstName = dr["CustFirstName"].ToString();
                        accbooking.ProdName = dr["ProdName"].ToString();
                        accbooking.BasePrice = Convert.ToDecimal(dr["BasePrice"]);
                        accbooking.BookingId = Convert.ToInt32(dr["BookingId"]);
                        accProdBookingsList.Add(accbooking);
                    }
                    dr.Close();
                }
            }
            return accProdBookingsList;
        }
    }
}