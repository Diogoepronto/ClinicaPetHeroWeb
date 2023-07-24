using ClinicaPetHeroWeb.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicaPetHeroWeb.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Veterinary> Veterinaries { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
