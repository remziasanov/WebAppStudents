using Domain.Entities;
using Domain.RepositoryInterfaces.Base;
using System.Linq;

namespace Domain.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для групп МАН 
    /// </summary>
    public interface IGroupRepository : IRepositoryBase<Group, int>
    {
        IQueryable<Group> GetAll(int DepartmentId);
        IQueryable<Group> GetAll(string DepartmentName);
    }
}
