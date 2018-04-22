using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRateAPI.Models
{
    public class UserMaster
    {
        public int UM_ID { get; set; }
        public String UM_NAME_ENG { get; set; }
        public String UM_USER_NAME { get; set; }
        public String UM_PWD { get; set; }
        public int UM_TYPE { get; set; }
        public int UM_ACTIVE { get; set; }
        public DateTime UM_CREATED_DATE { get; set; }
        public DateTime UM_LAST_UPDATED { get; set; }
    }


    public class Rate
    {
       
        public String CountryName_Eng { get; set; }
        public String CountryName_Arb { get; set; }
        public String Country_Flag { get; set; }
        public Decimal SellRate { get; set; }
        public Decimal  BuyRate { get; set; }
        public Decimal DD_TT { get; set; }
        
    }



}