using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;


namespace Domain.Data.Repositories
{
    public class RegionRepository : BaseRepository<Region, int, StudentDataContext>, IRegionRepository
    {
        public RegionRepository(StudentDataContext context) : base(context)
        {

        }
    }
}
