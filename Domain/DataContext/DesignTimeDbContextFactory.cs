using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Domain.DataContext
{
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StudentDataContext>
    {
        public StudentDataContext CreateDbContext(string[] args)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пользователь\Desktop\WebAppStudents-master\Domain\DataContext\Database4.0.mdf;Integrated Security=True";
            var conntectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пользователь\Desktop\WebAppStudents-master\Domain\DataContext\Database3.mdf;Integrated Security=True";
            var builder = new DbContextOptionsBuilder<StudentDataContext>().UseSqlServer(connectionString);
            return new StudentDataContext(builder.Options);
        }
    }
}
