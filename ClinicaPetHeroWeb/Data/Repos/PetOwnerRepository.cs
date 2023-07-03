using ClinicaPetHeroWeb.Data.Entities;

namespace ClinicaPetHeroWeb.Data.Repos
{
    public class PetOwnerRepository : GenericRepository<PetOwner>, IPetOwnerRepository
    {
        private readonly DataContext _context;

        public PetOwnerRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
