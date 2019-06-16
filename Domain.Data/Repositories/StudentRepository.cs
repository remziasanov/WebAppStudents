using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student, int, StudentDataContext>, IStudentRepository
    {
        public StudentRepository(StudentDataContext context) : base(context)
        {

        }
    }
}
