using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;
namespace Domain.Data.Repositories
{
    public class CityLocalRepository : BaseRepository<LocalCity, int, StudentDataContext>, ICityLocalRepository
    {
        public CityLocalRepository(StudentDataContext context) : base(context)
        {
        }
    }
}
