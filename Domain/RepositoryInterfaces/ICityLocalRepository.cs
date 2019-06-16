using Domain.Entities;
using Domain.RepositoryInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для населенных пунктов и городов
    /// </summary>
    public interface ICityLocalRepository : IRepositoryBase<LocalCity, int>
    {
        // можно добавить дополнительные методы для работы с населенными пунктами и городами
    }
}
