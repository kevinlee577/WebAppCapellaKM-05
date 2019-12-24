using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCapellaKM_05.Models
{
    public class PubWork
    {
        [Key]
        public int PubWorkKeyID { get; set; }
        [Required]
        [Display(Name = "Article Title")]
        public string PubWorkName { get; set; }
        [Display(Name = "Article Abstract")]
        public string PubWorkAbstract { get; set; }
        [Display(Name = "Article Keywords")]
        public string PubWorkKeywords { get; set; }
        [Display(Name = "Notes")]
        public string PubWorkNote { get; set; }
        
     //   public int PubWorkPublicationID { get; set; }   
     //   public int PubWorkAuthorID { get; set; }

        [Required]
     //   [Column("PubWorkPublicationID")]
        [Display(Name = "Publication")]
        public int PublicationID { get; set; }

        [Required]
     //   [Column("PubWorkAuthorID")]
        [Display(Name = "Author")]
        public int AuthorID { get; set; }

    //    public IEnumerable<SelectListItem> Authors { get; set; }

        public Publication Publication { get; set; }

        public Author Author { get; set; }

    }
}
