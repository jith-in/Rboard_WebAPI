using System;

namespace ExchangeRateAPI.Models
{
    public class CurrencyMaster
    {
        public int CR_ID { get; set; }
        public string CR_NAME_ENG { get; set; }

        public string CR_NAME_ARB { get; set; }
        public string CR_FLAG_PATH { get; set; }
        public int CR_STATUS { get; set; }

        
        public DateTime CR_CREATED_ON { get; set; }
        public int CR_CREATED_BY { get; set; }
        public int CR_UPDATED_BY { get; set; }
        public int CR_IS_DELETED { get; set; }

    }
}

