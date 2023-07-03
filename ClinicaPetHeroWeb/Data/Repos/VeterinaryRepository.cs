using ClinicaPetHeroWeb.Data.Entities;

namespace ClinicaPetHeroWeb.Data.Repos
{
    public class VeterinaryRepository : GenericRepository<Veterinary>, IVeterinaryRepository
    {
        private readonly DataContext _context;

        public VeterinaryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
