using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data.Repositories
{
    public class SchoolRepository : BaseRepository<School, int, StudentDataContext>, ISchoolRepository
    {
        public SchoolRepository(StudentDataContext context) : base(context)
        {
        }
    }
}
