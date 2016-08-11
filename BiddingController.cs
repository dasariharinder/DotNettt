using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BidAndAuction.Models;

namespace BidAndAuction.Controllers
{
    public class BiddingController : Controller
    {
        //
        // GET: /Bidding/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Bidding()
        {
            string gettedProduct = Request.QueryString["value"];
            string str = "Data Source=ABTR14F1D;Initial Catalog=GreenHopper;Integrated Security=False;User ID=sa;Password=P@ssw0rd1;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Select ProdTitle  from ProductDets";
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    var list = new List<Bidding>();
                    if (sdr.HasRows)
                    {

                        while (sdr.Read())
                        {
                            var a = new Bidding();
                            a.ProdTitle = sdr[0].ToString();
                            list.Add(a);
                        }
                    }
                    sdr.Close();
                    ViewBag.prodList = list;
                   
                    cmd.CommandText = "Select * from ProductDets where ProdTitle='"+ gettedProduct +"'";
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader sdr1 = cmd.ExecuteReader();
                    
                    if (sdr1.HasRows)
                    {

                        while (sdr1.Read())
                        {
                            ViewBag.Title = sdr1[1].ToString();
                            ViewBag.Description = sdr1[2].ToString();
                            ViewBag.InitPrice = sdr1[3].ToString();
                            ViewBag.IncrPrice = sdr1[4].ToString();
                        }
                    }
                    sdr1.Close();
                    
                }


                catch (Exception e)
                {
                    throw e;
                }
              

            }


            return View();

        }

         public ActionResult Getdetails()
        {
              string str = "Data Source=ABTR14F1D;Initial Catalog=GreenHopper;Integrated Security=False;User ID=sa;Password=P@ssw0rd1;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
              using (SqlConnection conn = new SqlConnection(str))
              {


                  conn.Open();
                  SqlCommand cmd = new SqlCommand();
                  cmd.Connection = conn;
                  cmd.CommandText = "Select ProdTitle  from ProductDets";
                  cmd.CommandType = System.Data.CommandType.Text;

              }


            return View();
        }

    }
}