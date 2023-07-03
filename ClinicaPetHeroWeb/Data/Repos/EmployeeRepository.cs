using ClinicaPetHeroWeb.Data.Entities;

namespace ClinicaPetHeroWeb.Data.Repos
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
