using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppCapellaKM_05.Models
{
    public class Publication
    {
        public int PublicationID { get; set; }
        [Required]
        [Display(Name = "Publication Name")]
        public string PublicationName { get; set; }
        [Display(Name = "Publisher")]
        public string PublicationPublisher { get; set; }

        public ICollection<PubWork> Articles { get; set; }
    }
}
