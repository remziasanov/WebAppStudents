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
    /// Репозиторий для населенных пунктов и городов
    /// </summary>
    public interface ICityLocalRepository : IRepositoryBase<LocalCity, int>
    {
        // можно добавить дополнительные методы для работы с населенными пунктами и городами
        IQueryable<LocalCity> GetAll(int RegionId);
        IQueryable<LocalCity> GetAll(string RegionName);
    }
}
