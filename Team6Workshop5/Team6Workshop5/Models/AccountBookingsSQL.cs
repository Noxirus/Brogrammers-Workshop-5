using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6Workshop5.Models
{
    public class AccountBookingsSQL
    {
        public static string SQLStatement()
        {
            //string sql = 
            //"if (Select PackageId From Bookings Where BookingId = 12) != '' "
            //            + "Begin "
            //                + 
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
                        //+ "END "
                        //+ "ELSE "
                        //+ "BEGIN "
                        //    + "Select C.CustFirstName, P.ProdName, BD.BasePrice, B.BookingId from "
                        //    + "Customers as C join Bookings as B "
                        //    + "on C.CustomerId= B.CustomerId "
                        //    + "join BookingDetails as BD "
                        //    + "on B.BookingId = BD.BookingId "
                        //    + "join  Products_Suppliers as PS "
                        //    + "on BD.ProductSupplierId= PS.ProductSupplierId "
                        //    + "join Products as P "
                        //    + "on Ps.ProductId=P.ProductId "
                        //    + "where C.CustomerId=143 "
                        //+ "END "
                        //+ "Select C.CustFirstName, P.ProdName,BD.BasePrice, Pack.PkgName,Pack.PkgBasePrice,B.BookingId from "
                        //+ "Customers as C join Bookings as B "
                        //+ "on C.CustomerId= B.CustomerId "
                        //+ "join Packages as Pack on "
                        //+ "B.PackageId = Pack.PackageId "
                        //+ "join BookingDetails as BD "
                        //+ "on B.BookingId = BD.BookingId "
                        //+ "join  Products_Suppliers as PS "
                        //+ "on BD.ProductSupplierId= PS.ProductSupplierId "
                        //+ "join Products as P "
                        //+ "on Ps.ProductId=P.ProductId "
                        //+ "where C.CustomerId=143 ";

            return (sql);


        }
    }
}