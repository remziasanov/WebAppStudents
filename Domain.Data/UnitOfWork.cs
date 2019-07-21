using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Data.Repositories;
using Domain.DataContext;
using Domain.RepositoryInterfaces;

namespace Domain.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentDataContext _context;
        private bool disposed = false;
        public UnitOfWork(StudentDataContext context)
        {
            _context = context;
            Cities = new CityLocalRepository(_context);
            Departments = new DepartmentRepository(_context);
            Documents = new DocumentRepository(_context);
            Groups = new GroupRepository(_context);
            Regions = new RegionRepository(_context);
            Schools = new SchoolRepository(_context);
            Students = new StudentRepository(_context);
        }

        public ICityLocalRepository Cities { get; private set; }

        public IDepartmentRepository Departments { get; private set; }

        public IDocumentRepository Documents { get; private set; }

        public IGroupRepository Groups { get; private set; }

        public IRegionRepository Regions { get; private set; }

        public ISchoolRepository Schools { get; private set; }

        public IStudentRepository Students { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
