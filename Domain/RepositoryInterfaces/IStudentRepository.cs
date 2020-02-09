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
    /// Репозиторий для студентов
    /// </summary>
    public interface IStudentRepository : IRepositoryBase<Student, int>
    {

    }
}
