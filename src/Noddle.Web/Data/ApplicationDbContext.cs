using Microsoft.EntityFrameworkCore;
using Noddle.Web.Models;

namespace Noddle.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}