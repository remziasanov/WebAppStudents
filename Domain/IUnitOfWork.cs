using Domain.RepositoryInterfaces;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ICityLocalRepository Cities { get; }
        IDepartmentRepository Departments { get; }
        IDocumentRepository Documents { get; }
        IGroupRepository Groups { get; }
        IRegionRepository Regions { get; }
        ISchoolRepository Schools { get; }
        IStudentRepository Students { get; }
        Task<int> SaveChanges();
    }
}
