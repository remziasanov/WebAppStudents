using System.Linq;
using System.Threading.Tasks;
using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data.Repositories
{
    public class CityLocalRepository : BaseRepository<LocalCity, int, StudentDataContext>, ICityLocalRepository
    {
        public CityLocalRepository(StudentDataContext context) : base(context)
        {
        }

        public IQueryable<LocalCity> GetAll(int RegionId)
        {
            IQueryable<LocalCity> cities = _dbContext.Cities
                                            .Where(x => x.RegionId == RegionId);
            return cities;                    
        }
        public IQueryable<LocalCity> GetAll(string RegionName)
        {
            Region region = _dbContext.Regions.SingleOrDefault(x => x.NameRegion == RegionName);
            if(region!=null)
            {
                return GetAll(region.Id);
            }
            return null;
        }
    }
}
