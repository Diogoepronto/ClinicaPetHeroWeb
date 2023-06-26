using ClinicaPetHeroWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaPetHeroWeb.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PetOwner> Owners { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Veterinary> Veterinaries { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
