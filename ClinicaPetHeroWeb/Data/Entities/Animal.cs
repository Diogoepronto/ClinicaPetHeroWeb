using ClinicaPetHeroWeb.Data.Entities.Abstract;

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

        public bool IsNeutered { get; set; }

    }
}
