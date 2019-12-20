using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCapellaKM_05.Models
{
    public class PubWork
    {
        public int PubWorkID { get; set; }
        public string PubWorkName { get; set; }
        public string PubWorkNote { get; set; }
        public string PubWorkAbstract { get; set; }
        public string PubWorkKeywords { get; set; }
        public int PubWorkPublicationID { get; set; }
        public int PubWorkAuthorID { get; set; }

    }
}
