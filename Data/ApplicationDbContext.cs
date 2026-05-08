using Microsoft.EntityFrameworkCore;

namespace StudentManagementApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public object Student { get; internal set; }
    }
}