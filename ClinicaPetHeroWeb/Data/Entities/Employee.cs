using System.ComponentModel.DataAnnotations;
using ClinicaPetHeroWeb.Data.Entities.Abstract;

namespace ClinicaPetHeroWeb.Data.Entities
{
    public class Employee : Person
    {
        [Required]
        public string Position { get; set; }
    }
}
