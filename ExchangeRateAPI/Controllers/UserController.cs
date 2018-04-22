using ExchangeRateAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Http.Cors;
using System.Net;

namespace ExchangeRateAPI.Controllers
{
   
    public class UserController : Controller
    {





        [HttpPost]
        [ActionName("AddCustomer")]
        public JsonResult AddCustomer(UserMaster Obj)
        {
            try {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ExchangeApiConnection"].ConnectionString;
                //
                SqlCommand com = new SqlCommand("SP_USER_MASTER", myConnection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue(
                    "@UM_USER_NAME", Obj.UM_NAME_ENG);
                //com.Parameters.AddWithValue("@UM_NAME_ENG", Obj.UM_NAME_ENG);
                //com.Parameters.AddWithValue("@UM_PWD", Obj.UM_PWD);
                //com.Parameters.AddWithValue("@UM_TYPE", Obj.UM_TYPE);
                //com.Parameters.AddWithValue("@UM_ACTIVE", Obj.UM_ACTIVE);
                SqlParameter outputParam = com.Parameters.Add("@Status", SqlDbType.Int, 1);
                outputParam.Direction = ParameterDirection.Output;
                myConnection.Open();
                com.ExecuteNonQuery();
                int id = Convert.ToInt32(outputParam.Value);
                bool status = id == 0 ? false : true;
                if (!status)
                    return null;
                myConnection.Close();
                return Json(status);
            }
            catch(Exception ex)
            {
                string s = ex.Message.ToString();
                return null;
            }
        }



        [HttpPost]
        [ActionName("GetUserMasterByID")]
        public JsonResult Get(UserMaster Obj)
        {
            //return listuserObj.First(e => e.ID == id);  
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ExchangeApiConnection"].ConnectionString;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select count(um_name_eng) as NameCount  from User_master where upper(um_name_eng) ='"+ Obj.UM_NAME_ENG + "'";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            var data = new List<UserMaster>();
            UserMaster userObj = new UserMaster();
            while (reader.Read())
            {
                userObj = new UserMaster();
                //userObj.UM_ID = Convert.ToInt32(reader.GetValue(0));
                userObj.UM_ID = Convert.ToInt32(reader.GetValue(0));//reader.GetValue(1).ToString();
                //userObj.UM_TYPE = Convert.ToInt32(reader.GetValue(2));
                //data.Add(userObj);
            }
            myConnection.Close();
            if(userObj.UM_ID >= 1)
            {
                return Json("Sucess");
            }
            else
            {
                return null;
            }
            //return Json(data.ToList(), JsonRequestBehavior.AllowGet);

        }

       
        [ActionName("GetUserMaster")]
        public JsonResult GetAll()
        {
            //return listuserObj.First(e => e.ID == id);  
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ExchangeApiConnection"].ConnectionString;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select [UM_ID],[UM_NAME_ENG],[UM_TYPE] from USER_MASTER";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
             var data =  new List<UserMaster>() ;
 
            while (reader.Read())
            {
                UserMaster userObj = new UserMaster();
                userObj.UM_ID = Convert.ToInt32(reader.GetValue(0));
                userObj.UM_NAME_ENG = reader.GetValue(1).ToString();
                userObj.UM_TYPE = Convert.ToInt32(reader.GetValue(2));
                data.Add(userObj);

            }
            myConnection.Close();
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);

        }

        [ActionName("GetNews")]
        public JsonResult GetNews()
        {
            //return listuserObj.First(e => e.ID == id);  
           // SqlDataReader reader = null;
          //  SqlConnection myConnection = new SqlConnection();
           // myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ExchangeApiConnection"].ConnectionString;

           // SqlCommand sqlCmd = new SqlCommand();
            //sqlCmd.CommandType = CommandType.Text;
            //sqlCmd.CommandText = "Select [UM_NAME_ENG] from USER_MASTER";
            //sqlCmd.Connection = myConnection;
            //myConnection.Open();
            //reader = sqlCmd.ExecuteReader();
            List<string> lstNews = new List<string>();

          //  while (reader.Read())
           // {
               // var news1 = reader.GetValue(0).ToString();
            var news1 = "Rupee rallies for 3rd day, up 14 paise at 63.55 a dollar";
             news1+= "  Money Trade Coin launched in crypto market, UAE exchange";
                lstNews.Add(news1);
              //  lstNews.Add(news2);

          //  }
            //myConnection.Close();
            return Json(lstNews.ToList(), JsonRequestBehavior.AllowGet);

        }



        [ActionName("GetCurrentRates")]
        public JsonResult GetCurrentRates()
        {

            var rateData = new List<Rate>();

            //for (int i = 0; i < 11; i++)
            //{
                Rate rateObj = new Rate();
                rateObj.CountryName_Eng = "UAE";
                rateObj.CountryName_Arb = "الإمارات العربية المتحدة";
                rateObj.Country_Flag = "\\flag\\ae.png";
                rateObj.SellRate = Convert.ToDecimal("32.24");
                rateObj.BuyRate = Convert.ToDecimal("34.24");
                rateObj.DD_TT = Convert.ToDecimal("43.24");
                rateData.Add(rateObj);
                rateObj = null;

                rateObj = new Rate();
                rateObj.CountryName_Eng = "CANADA";
                rateObj.CountryName_Arb ="كندا";
                rateObj.Country_Flag = "\\flag\\ca.png";
                rateObj.SellRate = Convert.ToDecimal("22.24");
                rateObj.BuyRate = Convert.ToDecimal("24.24");
                rateObj.DD_TT = Convert.ToDecimal("23.24");
                rateData.Add(rateObj);
                rateObj = null;

                rateObj = new Rate();
                rateObj.CountryName_Eng = "CHINA";
                rateObj.CountryName_Arb = "الصين";
                rateObj.Country_Flag = "\\flag\\ch.png";
                rateObj.SellRate = Convert.ToDecimal("39.44");
                rateObj.BuyRate = Convert.ToDecimal("37.28");
                rateObj.DD_TT = Convert.ToDecimal("23.84");
                rateData.Add(rateObj);
                rateObj = null;

                 rateObj = new Rate();
                rateObj.CountryName_Eng = "INDIA";
                rateObj.CountryName_Arb = "الهند";
                rateObj.Country_Flag = "\\flag\\in.png";
                rateObj.SellRate = Convert.ToDecimal("45.24");
                rateObj.BuyRate = Convert.ToDecimal("44.24");
                rateObj.DD_TT = Convert.ToDecimal("33.24");
                rateData.Add(rateObj);
                rateObj = null;

                rateObj = new Rate();
                rateObj.CountryName_Eng = "GERMANY";
                rateObj.CountryName_Arb="ألمانيا";
                rateObj.Country_Flag = "\\flag\\ge.png";
                rateObj.SellRate = Convert.ToDecimal("12.24");
                rateObj.BuyRate = Convert.ToDecimal("14.24");
                rateObj.DD_TT = Convert.ToDecimal("13.24");
                rateData.Add(rateObj);
                rateObj = null;
           // }

            return Json(rateData.ToList(), JsonRequestBehavior.AllowGet);

        }


    }






}