using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppCapellaKM_05.Models
{
    public class PubWork
    {
        public int PubWorkID { get; set; }
        [Required]
        public string PubWorkName { get; set; }
        public string PubWorkNote { get; set; }
        public string PubWorkAbstract { get; set; }
        public string PubWorkKeywords { get; set; }
        [Required]
        public int PubWorkPublicationID { get; set; }
        [Required]
        public int PubWorkAuthorID { get; set; }

        public int PublicationID { get; set; }
        [Required]
        public int AuthorID { get; set; }

        public Publication Publication { get; set; }

        public Author Author { get; set; }

    }
}
