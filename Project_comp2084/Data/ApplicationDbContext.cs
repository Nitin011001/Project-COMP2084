using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_comp2084.Models;

namespace Project_comp2084.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project_comp2084.Models.Packages>? Packages { get; set; }
        public DbSet<Project_comp2084.Models.Premium>? Premium { get; set; }
        public DbSet<Project_comp2084.Models.Client>? Client { get; set; }
        public DbSet<Project_comp2084.Models.Vehicle>? Vehicle { get; set; }
    }
}