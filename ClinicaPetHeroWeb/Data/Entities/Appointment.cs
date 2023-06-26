using System;
using ClinicaPetHeroWeb.Data.Entities.Abstract;

namespace ClinicaPetHeroWeb.Data.Entities
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public PetOwner Owner{ get; set; }

        public Animal Animal { get; set; }

        public Veterinary Veterinary { get; set; }
    }
}
