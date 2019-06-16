using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.Data.Repositories
{
    public class DepartmentRepository : BaseRepository<Department, int, StudentDataContext>, IDepartmentRepository
    {
        public DepartmentRepository(StudentDataContext context) : base(context)
        {
        }
    }
}
