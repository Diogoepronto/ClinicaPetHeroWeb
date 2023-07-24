using ClinicaPetHeroWeb.Data.Entities;
using ClinicaPetHeroWeb.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaPetHeroWeb.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext context, 
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }


        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync();

            
            // Create roles
            await _userHelper.CreateRoleIfNotExistAsync("Admin");
            await _userHelper.CreateRoleIfNotExistAsync("Employee");
            await _userHelper.CreateRoleIfNotExistAsync("PetOwner");


            // Create default user
            var user = await _userHelper.GetUserByEmailAsync("bta.diogo@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "Diogo",
                    LastName = "Alves",
                    Email = "bta.diogo@gmail.com",
                    UserName = "bta.diogo@gmail.com",
                    PhoneNumber = "1234567890"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");

            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }


            // Create mock data

            if (!_context.PetOwners.Any())
            {
                AddPetOwner("Diogo", "Alves", "M", new DateTime(), "Rua qualquer 12", "Viseu", "Viseu", "3215-152", "bta.diogo@gmail.com", "912351846");
                AddPetOwner("Julio", "Moreira", "M", new DateTime(), "Rua sem saída 19", "Lisboa", "Lisboa", "4355-189", "jumo@gmail.com", "963852741");
                AddPetOwner("Sandra", "Maria", "F", new DateTime(), "Rua sem nome 43", "Porto", "Porto", "5532-156", "sandrinha@gmail.com", "951753456");
                
                await _context.SaveChangesAsync();
            }

            if (!_context.Animals.Any())
            {
                AddAnimal("Lucia", 7, 5.4, "F", "Cão", true, 1);
                AddAnimal("Rex", 2, 40.7, "M", "Cão", false, 2);
                AddAnimal("Pipoquinha", 8, 5.1, "F", "Gato", true, 2);
                AddAnimal("Pitoco", 1, 2.7, "M", "Cão", true, 3);

                await _context.SaveChangesAsync();
            }

            if (!_context.Employees.Any())
            {
                AddVeterinary("Nicole", "Moraes", "F", new DateTime(), "QNJ 5", "Viseu", "Viseu", "3415-132", "nicolemoraes@gmail.com", "932159647", "Cães");
                AddVeterinary("Francisco", "Menezes", "M", new DateTime(), "Travessa da quinquilharia", "Porto", "Porto", "4325-185", "f.menezes@gmail.com", "934651279", "Cardiologia");

                AddEmployee("Julia", "Moraes", "F", new DateTime(), "Quinta do quadrilátero", "Viseu", "Viseu", "3856-132", "juju.moraes@gmail.com", "932164798", "Atendente");
                AddEmployee("Márcio", "Castro", "M", new DateTime(), "Travessa do Traquinas", "Porto", "Porto", "4896-179", "marcinho.cacau@gmail.com", "985634217", "Técnico de tosquia");
                
                await _context.SaveChangesAsync();
            }
        }

       

        private void AddPetOwner(string firstName, string lastName, string gender, DateTime dateTime, string address, string city, string state, string postalCode, string email, string phone)
        {
            _context.PetOwners.Add(new Entities.PetOwner
            { 
                FirstName = firstName, 
                LastName = lastName, 
                Gender = gender,
                DateOfBirth = dateTime,
                Address = address, 
                City = city, 
                State = state, 
                PostalCode = postalCode, 
                Email = email, 
                Phone = phone 
            });
        }

        private void AddAnimal(string name, int age, double weight, string sex, string species, bool isNeutered, int ownerId)
        {
            _context.Animals.Add(new Entities.Animal
            {
                Name = name,
                Age = age,
                Weight = weight,
                Sex = sex,
                Species = species,
                IsNeutered = isNeutered,
                Owner = _context.PetOwners.Where(o => o.Id == ownerId).FirstOrDefault()
            });
        }

        private void AddVeterinary(string firstName, string lastName, string gender, DateTime dateTime, string address, string city, string state, string postalCode, string email, string phone, string specialty)
        {
            _context.Veterinaries.Add(new Entities.Veterinary
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DateOfBirth = dateTime,
                Address = address,
                City = city,
                State = state,
                PostalCode = postalCode,
                Email = email,
                Phone = phone,
                Position = "Veterinary",
                Specialty = specialty
            });
        }

        private void AddEmployee(string firstName, string lastName, string gender, DateTime dateTime, string address, string city, string state, string postalCode, string email, string phone, string position)
        {
            _context.Employees.Add(new Entities.Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DateOfBirth = dateTime,
                Address = address,
                City = city,
                State = state,
                PostalCode = postalCode,
                Email = email,
                Phone = phone,
                Position = position,
            });
        }
    }
}
