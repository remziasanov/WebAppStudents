using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student, int, StudentDataContext>, IStudentRepository
    {
        public StudentRepository(StudentDataContext context) : base(context)
        {

        }
        public override IQueryable<Student> GetAll()
        {
            IQueryable<Student> students;
            students = _dbContext.Students
                        .Include(v => v.Group1)
                        .Include(v => v.Group2)
                        .Include(v => v.Group3)
                        .Include(v => v.LocalCity)
                        .Include(v => v.School)
                        .Include(v => v.MainDocument);
            return students;
        }
        public override IQueryable<Student> GetAllWhere(Expression<Func<Student, bool>> predicate)
        {
            IQueryable<Student> students = base.GetAllWhere(predicate)
                                .Include(v => v.Group1)
                                .Include(v => v.Group2)
                                .Include(v => v.Group3)
                                .Include(v => v.LocalCity)
                                .Include(v => v.School)
                                .Include(v => v.MainDocument);
            return students;
        }
    }
}