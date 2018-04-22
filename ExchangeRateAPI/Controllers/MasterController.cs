using ExchangeRateAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System.Web.Http.Cors;
using System.Net;


namespace ExchangeRateAPI.Controllers
{
    public class MasterController : Controller
    {

        [HttpPost]
        [ActionName("Country")]
        public JsonResult Add(CountryMaster Obj)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ExchangeApiConnection"].ConnectionString;
            
            SqlCommand com = new SqlCommand("SP_ADD_COUNRTY_MASTER", myConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CN_NAME_ENG", Obj.CN_NAME_ENG);
            com.Parameters.AddWithValue("@CN_NAME_ARB", Obj.CN_NAME_ENG);
            com.Parameters.AddWithValue("@CN_FLAG_PATH", Obj.CN_FLAG_PATH);
            com.Parameters.AddWithValue("@CN_CURR_ID", Obj.CN_CURR_ID);
            com.Parameters.AddWithValue("@CN_CURRENCY_ENG", Obj.CN_CURRENCY_ENG);
            com.Parameters.AddWithValue("@CN_CURRENCY_ARB", Obj.CN_CURRENCY_ENG);
            com.Parameters.AddWithValue("@CN_CREATED_BY", Obj.CN_CREATED_BY);
            com.Parameters.AddWithValue("@CN_UPDATED_BY", Obj.CN_UPDATED_BY);
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


        [HttpGet]
        [ActionName("Country")]
        public JsonResult GetAll()
        {
            //return listuserObj.First(e => e.ID == id);  
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ExchangeApiConnection"].ConnectionString;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select CN_NAME_ENG,CN_CURRENCY_ENG,CN_ID,CN_CURR_ID from COUNTRY_MASTER";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            var data = new List<CountryMaster>();
           
            while (reader.Read())
            {
                CountryMaster userObj = new CountryMaster();
                userObj.CN_NAME_ENG = reader.GetValue(0).ToString();
                userObj.CN_CURRENCY_ENG = reader.GetValue(1).ToString();
                userObj.CN_ID = Convert.ToInt32(reader.GetValue(2)); ;
                userObj.CN_CURR_ID = Convert.ToInt32(reader.GetValue(3)); ;
                data.Add(userObj);

            }
            myConnection.Close();
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);

        }

    }
}
