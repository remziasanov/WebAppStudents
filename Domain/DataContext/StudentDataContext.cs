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
        public DbSet<Region> Regions { get; set; }
        public DbSet<LocalCity> Cities { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
