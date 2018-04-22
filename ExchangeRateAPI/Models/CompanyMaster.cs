using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRateAPI.Models
{
    public class CompanyMaster
    {
        public int  CM_ID { get; set; }
        public String CM_NAME_ENG { get; set; }
        public String CM_NAME_ARB { get; set; }
        public String CM_PHONE { get; set; }
        public String CM_MOBILE { get; set; }
        public String CM_FAX { get; set; }
        public String CM_EMAIL { get; set; }
        public String CM_WEB { get; set; }
        public String CM_ADDRESS_L1 { get; set; }
        public String CM_ADDRESS_L2 { get; set; }
        public String CM_ADDRESS_L3 { get; set; }
        public String CM_BR_CNT { get; set; }
        public String CM_LOGO { get; set; }
        public DateTime CM_CREATED_DATE { get; set; }
        public int CM_CREATED_BY { get; set; }
        public DateTime CM_LAST_UPDATED { get; set; }
        public Boolean CM_IS_DELETED { get; set; }
    }
}