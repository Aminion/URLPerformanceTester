using System.Data.Entity;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Infrastructure
{
    public class PerformanceTesterContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}