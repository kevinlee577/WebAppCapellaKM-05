using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAppCapellaKM_05.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
    //    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string AuthorFirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
    //    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string AuthorLastName { get; set; }
        [Display(Name = "Author Name")]
        public string AuthorFullName
        {
            get
            {
                return AuthorLastName + ", " + AuthorFirstName;
            }
        }

        public ICollection<PubWork> Articles { get; set; }

    //    public Publication Publication { get; set; }

  
    }
}
