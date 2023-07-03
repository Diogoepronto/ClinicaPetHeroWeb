using ClinicaPetHeroWeb.Data.Entities;

namespace ClinicaPetHeroWeb.Data.Repos
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        private readonly DataContext _context;

        public AnimalRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
