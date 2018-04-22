using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRateAPI.Models
{
    public class CountryMaster
    {
        public int CN_ID { get; set; }
        public string CN_NAME_ENG { get; set; }
     
        public string CN_NAME_ARB { get; set; }                    
        public string CN_FLAG_PATH { get; set; }                   
        public int CN_STATUS { get; set; }                         
                              
        public int CN_CURR_ID { get; set; }
        public string CN_CURRENCY_ENG { get; set; }
        public string CN_CURRENCY_ARB { get; set; }
        public DateTime CN_CREATED_ON { get; set; }            
        public int CN_CREATED_BY { get; set; }                  
        public int CN_UPDATED_BY { get; set; }              
        public int CN_IS_DELETED { get; set; }
        
    }                                                              
}                                                                  
                                                                   
                                                                    