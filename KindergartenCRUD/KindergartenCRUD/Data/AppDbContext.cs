using KindergartenCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace KindergartenCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<KindergartenGroup> KindergartenGroups { get; set; }
    }
}
