using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Team6Workshop5.Models
{
    public class NewAccountBookingsDB
    {
        public List<int?> testList = new List<int?>();
        public static List<NEWAccountBookings> GetPackBookings()
        {
            List<NEWAccountBookings> accPackBookingsList = new List<NEWAccountBookings>();

            string sql1 = "Select C.CustFirstName, P.ProdName,BD.BasePrice, Pack.PkgName,Pack.PkgBasePrice,B.BookingId from "
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

            string sql2 = "Select C.CustFirstName, P.ProdName, BD.BasePrice, B.BookingId from "
                            + "Customers as C join Bookings as B "
                            + "on C.CustomerId= B.CustomerId "
                            + "join BookingDetails as BD "
                            + "on B.BookingId = BD.BookingId "
                            + "join  Products_Suppliers as PS "
                            + "on BD.ProductSupplierId= PS.ProductSupplierId "
                            + "join Products as P "
                            + "on Ps.ProductId=P.ProductId "
                            + "where B.BookingId != @BookingId AND C.CustomerId = 143 ";

            using (SqlConnection con = new SqlConnection(TravelExpertsDB.GetConnectionString()))
            {
                NEWAccountBookings packbooking;
                packbooking = new NEWAccountBookings();

                using (SqlCommand cmd = new SqlCommand(sql1, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    decimal? test = 0;

                    while (dr.Read())
                    {
                        packbooking.PACKCustFirstName = dr["CustFirstName"].ToString();
                        packbooking.PACKProdName = dr["ProdName"].ToString();
                        packbooking.PACKBasePrice = Convert.ToDecimal(dr["BasePrice"]);
                        packbooking.PACKPkgName = dr["PkgName"].ToString();
                        packbooking.PACKPkgBasePrice = Convert.ToDecimal(dr["PkgBasePrice"]);
                        packbooking.PACKBookingId = Convert.ToInt32(dr["BookingId"]);
                       
                        
                        test += packbooking.PACKBasePrice;
                        test += packbooking.PACKPkgBasePrice;

                        //sending the packes information to the list
                        accPackBookingsList.Add(packbooking);

                    }
                    dr.Close();

                    NEWAccountBookings packbookingtest = new NEWAccountBookings();
                    packbookingtest.PACKTotal = test;
                    accPackBookingsList.Add(packbookingtest);

                    con.Close();
                }
                using (SqlCommand cmd = new SqlCommand(sql2, con))
                {
                    cmd.Parameters.AddWithValue("@BookingId", packbooking.PACKBookingId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    NEWAccountBookings prodbooking;
                    
                    decimal? test = 0;
                    while (dr.Read())
                    {
                        prodbooking = new NEWAccountBookings();
                        prodbooking.PRODCustFirstName = dr["CustFirstName"].ToString();
                        prodbooking.PRODProdName = dr["ProdName"].ToString();
                        prodbooking.PRODBasePrice = Convert.ToDecimal(dr["BasePrice"]);
                        prodbooking.PRODBookingId = Convert.ToInt32(dr["BookingId"]);


                        
                        test += prodbooking.PRODBasePrice;
                        

                        //sending the packes information to the list
                        accPackBookingsList.Add(prodbooking);
                    }
                    dr.Close();

                    NEWAccountBookings prodbookingtest = new NEWAccountBookings();
                    prodbookingtest.PRODTotal = test;
                    accPackBookingsList.Add(prodbookingtest);
                }
            }
            return accPackBookingsList;
        }
    }
}