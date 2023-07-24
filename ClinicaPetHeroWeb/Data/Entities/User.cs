using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClinicaPetHeroWeb.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }


        public string LastName { get; set; }


        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
