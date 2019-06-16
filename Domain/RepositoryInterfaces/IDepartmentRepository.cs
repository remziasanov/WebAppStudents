using Domain.Entities;
using Domain.RepositoryInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для отделов МАН
    /// </summary>
    public interface IDepartmentRepository : IRepositoryBase<Department, int>
    {
    }
}
