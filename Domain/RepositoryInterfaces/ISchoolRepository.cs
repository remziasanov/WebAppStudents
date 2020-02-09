using Domain.Entities;
using Domain.RepositoryInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для работы со школами
    /// </summary>
    public interface ISchoolRepository : IRepositoryBase<School, int>
    {
        IQueryable<School> GetAll(int RegionId);
        IQueryable<School> GetAll(string CityName);
        Task<School> Get(string SchoolName);
    }
}