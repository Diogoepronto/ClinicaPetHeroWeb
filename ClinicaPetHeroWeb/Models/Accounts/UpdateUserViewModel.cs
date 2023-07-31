using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClinicaPetHeroWeb.Models.Accounts
{
    public class UpdateUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
