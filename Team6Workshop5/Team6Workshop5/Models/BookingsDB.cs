using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Team6Workshop5.Models
{
    public class BookingsDB
    {
        public static List<Bookings> GetBookings()
        {
            List<Bookings> bookingsList = new List<Bookings>();
            string sql = "SELECT BookingId, CustomerId, PackageId FROM Bookings";
            using (SqlConnection con = new SqlConnection(TravelExpertsDB.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Bookings booking;
                    while (dr.Read())
                    {
                        booking = new Bookings();
                        booking.BookingId = Convert.ToInt32(dr["BookingId"]);
                        if (booking.PackageId != null)
                            booking.PackageId = Convert.ToInt32(dr["PackageId"]);
                        else
                            booking.PackageId = 0;
                       booking.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                        bookingsList.Add(booking);
                    }
                    dr.Close();
                }
            }
            return bookingsList;
        }
    }
}