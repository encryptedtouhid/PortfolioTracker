using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PortfolioTracking.Data.EntityModel
{

    

        public class DailyPrice
        {
 
            public string Open { get; set; }

            public string High { get; set; }

            public string Low { get; set; }

            public string Close { get; set; }

            public string Volume { get; set; }
        }
    
}
