using Microsoft.EntityFrameworkCore;
using UoStudents.Models;

namespace UoStudents.Data
{
    public class UopenDbContext : DbContext
    {
        public UopenDbContext(DbContextOptions<UopenDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
