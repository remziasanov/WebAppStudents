using System.Linq;
using System.Threading.Tasks;
using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.Data.Repositories
{
    public class GroupRepository : BaseRepository<Group, int, StudentDataContext>, IGroupRepository
    {
        public GroupRepository(StudentDataContext context) : base(context)
        {

        }

        public Group Get(string groupName)
        {
            IQueryable<Group> groups = _dbContext.Groups
                                             .Where(x => x.Title == groupName);
            return groups.SingleOrDefault();
        }

        public IQueryable<Group> GetAll(int DepartmentId)
        {
            IQueryable<Group> groups = _dbContext.Groups
                                            .Where(x => x.DepartmentId == DepartmentId);
            return groups;
        }


        public IQueryable<Group> GetAll(string DepartmentName)
        {
            Department department = _dbContext.Departments.SingleOrDefault(x => x.Title == DepartmentName);
            if (department != null)
            {
                return GetAll(department.Id);
            }
            return null;
        }
    }
}