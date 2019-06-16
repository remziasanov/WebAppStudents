using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Domain.DataContext
{
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StudentDataContext>
    {
        public StudentDataContext CreateDbContext(string[] args)
        {
            var conntectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\StudentsMAN\Domain\DataContext\Database1.mdf;Integrated Security=True";
            var builder = new DbContextOptionsBuilder<StudentDataContext>().UseSqlServer(conntectionString);
            return new StudentDataContext(builder.Options);
        }
    }
}
