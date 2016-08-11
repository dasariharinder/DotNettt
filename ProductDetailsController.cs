using BidAndAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace BidAndAuction.Controllers
{
    public class ProductDetailsController : Controller
    {
        //
        // GET: /ProductDetails/
        public ActionResult Index()
        {
            return View();
        }
        
         public ActionResult ProductDetails(ProductDetailsModel pdm)
        {


            string str = "Data Source=ABTR14F1D;Initial Catalog=GreenHopper;Integrated Security=False;User ID=sa;Password=P@ssw0rd1;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            string CreatedBy = "Harinder";
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into ProductDets(ProdID,ProdTitle,ProdDesc,InitPrice,BidIncr,CreatedBy) values('" + pdm.ProdID + "','" + pdm.ProdTitle + "','" + pdm.ProdDesc + "','" + pdm.InitPrice + "','" + pdm.BidIncr + "','" + CreatedBy + "')";
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    Response.Write("Inserted.");
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

            return View();
        }




	}
}