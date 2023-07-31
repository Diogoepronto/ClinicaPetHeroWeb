using ClinicaPetHeroWeb.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClinicaPetHeroWeb.Models.Entities
{
    public class VeterinaryViewModel : Veterinary
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
