using ClinicaPetHeroWeb.Data.Entities;
using ClinicaPetHeroWeb.Models.Entities;

namespace ClinicaPetHeroWeb.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Animal ToAnimal(AnimalViewModel model, string animalImageUrl, bool isNew)
        {
            return new Animal
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Age = model.Age,
                Weight = model.Weight,
                Sex = model.Sex,
                Species = model.Species,
                Owner = model.Owner,
                IsNeutered = model.IsNeutered,
                AnimalImageUrl = animalImageUrl
            };
        }

        public AnimalViewModel ToAnimalViewModel(Animal animal)
        {
            return new AnimalViewModel
            {
                Id = animal.Id,
                Name = animal.Name,
                Age = animal.Age,
                Weight = animal.Weight,
                Sex = animal.Sex,
                Species = animal.Species,
                Owner = animal.Owner,
                IsNeutered = animal.IsNeutered,
                AnimalImageUrl = animal.AnimalImageUrl
            };
        }

        public PetOwner ToPetOwner(PetOwnerViewModel model, string profileImageUrl, bool isNew)
        {
            return new PetOwner
            {
                Id = isNew ? 0 : model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
                Email = model.Email,
                Phone = model.Phone,
                User = model.User,
                ProfileImageUrl = profileImageUrl
            };
        }

        public PetOwnerViewModel ToPetOwnerViewModel(PetOwner petOwner)
        {
            return new PetOwnerViewModel
            {
                Id = petOwner.Id,
                FirstName = petOwner.FirstName,
                LastName = petOwner.LastName,
                Gender = petOwner.Gender,
                DateOfBirth = petOwner.DateOfBirth,
                Address = petOwner.Address,
                City = petOwner.City,
                State = petOwner.State,
                PostalCode = petOwner.PostalCode,
                Email = petOwner.Email,
                Phone = petOwner.Phone,
                User = petOwner.User,
                ProfileImageUrl = petOwner.ProfileImageUrl
            };
        }


        public Employee ToEmployee(EmployeeViewModel model, string profileImageUrl, bool isNew)
        {
            return new Employee
            {
                Id = isNew ? 0 : model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
                Email = model.Email,
                Phone = model.Phone,
                User = model.User,
                Position = model.Position,
                ProfileImageUrl = profileImageUrl
            };
        }

        public EmployeeViewModel ToEmployeeViewModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
                Address = employee.Address,
                City = employee.City,
                State = employee.State,
                PostalCode = employee.PostalCode,
                Email = employee.Email,
                Phone = employee.Phone,
                User = employee.User,
                Position = employee.Position,
                ProfileImageUrl = employee.ProfileImageUrl
            };
        }        

        public Veterinary ToVeterinary(VeterinaryViewModel model, string profileImageUrl, bool isNew)
        {
            return new Veterinary
            {
                Id = isNew ? 0 : model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
                Email = model.Email,
                Phone = model.Phone,
                User = model.User,
                Position = model.Position,
                Specialty = model.Specialty,
                ProfileImageUrl = profileImageUrl
            };
        }

        public VeterinaryViewModel ToVeterinaryViewModel(Veterinary veterinary)
        {
            return new VeterinaryViewModel
            {
                Id = veterinary.Id,
                FirstName = veterinary.FirstName,
                LastName = veterinary.LastName,
                Gender = veterinary.Gender,
                DateOfBirth = veterinary.DateOfBirth,
                Address = veterinary.Address,
                City = veterinary.City,
                State = veterinary.State,
                PostalCode = veterinary.PostalCode,
                Email = veterinary.Email,
                Phone = veterinary.Phone,
                User = veterinary.User,
                Position = veterinary.Position,
                Specialty = veterinary.Specialty,
                ProfileImageUrl = veterinary.ProfileImageUrl
            };
        }
    }
}
