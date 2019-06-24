using Domain.Entities;
using Domain.RepositoryInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для работы со школами
    /// </summary>
    public interface ISchoolRepository : IRepositoryBase<School, int>
    {
        IQueryable<School> GetAll(int RegionId);
        IQueryable<School> GetAll(string CityName);
    }
}
