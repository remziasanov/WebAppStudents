﻿using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Repositories
{
    public class SchoolRepository : BaseRepository<School, int, StudentDataContext>, ISchoolRepository
    {
        public SchoolRepository(StudentDataContext context) : base(context)
        {
        }

        public async Task<School> Get(string SchoolName)
        {
            Task<School> school =  _dbContext.Schools.Where(x => x.Title == SchoolName).FirstOrDefaultAsync();
            return await school;
        }

        public IQueryable<School> GetAll(int RegionId)
        {
            IQueryable<School> schools = _dbContext.Schools.Where(x => x.CityId == RegionId);
            return schools;
        }

        public IQueryable<School> GetAll(string RegionName)
        {
            Region region = _dbContext.Regions.SingleOrDefault(x => x.NameRegion == RegionName);
            if (region != null)
            {
                return GetAll(region.Id);
            }
            return null;
        }
    }
}
