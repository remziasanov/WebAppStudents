using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Domain.DataContext
{
    public class StudentDataContext : DbContext
    {
        public StudentDataContext(DbContextOptions<StudentDataContext> dbContextOption) : base(dbContextOption)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
