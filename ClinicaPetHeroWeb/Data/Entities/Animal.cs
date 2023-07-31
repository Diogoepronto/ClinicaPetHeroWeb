using ClinicaPetHeroWeb.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace ClinicaPetHeroWeb.Data.Entities
{
    public class Animal : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

        public string Sex { get; set; }

        public string Species { get; set; }

        public PetOwner Owner { get; set; }

        [Display(Name = "Is Neutered")]
        public bool IsNeutered { get; set; }

        [Display(Name = "Picture")]
        public string AnimalImageUrl { get; set; }

        public string AnimalImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(AnimalImageUrl))
                {
                    return null;
                }
                return $"https://localhost:44336//{AnimalImageUrl.Substring(1)}";
            }
        }

    }
}
