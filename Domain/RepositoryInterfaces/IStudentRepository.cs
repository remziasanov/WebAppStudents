using Domain.Entities;
using Domain.RepositoryInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для студентов
    /// </summary>
    public interface IStudentRepository : IRepositoryBase<Student, int>
    {
        // для дополнительных методов для работы со студентами
    }
}
