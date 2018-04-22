using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRateAPI.Models
{
    public class BranchMaster
    {
        public int BM_ID { get; set; }
        public String BM_NAME_ENG { get; set; }
        public String BM_NAME_ARB { get; set; }
        public String BM_PHONE { get; set; }
        public String BM_MOBILE { get; set; }
        public String BM_FAX { get; set; }
        public String BM_EMAIL { get; set; }
        public String BM_WEB { get; set; }
        public String BM_ADDRESS_L1 { get; set; }
        public String BM_ADDRESS_L2 { get; set; }
        public String BM_ADDRESS_L3 { get; set; }
        public int BM_IS_MAIN { get; set; }
        public DateTime BM_CREATED_DATE { get; set; }
        public int BM_CREATED_BY { get; set; }
        public DateTime BM_LAST_UPDATED { get; set; }
        public Boolean BM_IS_DELETED { get; set; }
    }
}