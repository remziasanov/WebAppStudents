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
    }
}
