using Microsoft.EntityFrameworkCore;
using KindergartenApp.Models;

namespace KindergartenApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<KindergartenGroup> KindergartenGroups { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}