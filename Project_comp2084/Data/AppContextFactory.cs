using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Project_comp2084.Data
{
    public class AppContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] arg)
        {
            var optBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optBuilder.UseSqlServer("Server=tcp:project-2084dbserver.database.windows.net,1433;Initial Catalog=Project_2084_db;Persist Security Info=False;User ID=Nitin011001;Password=Nitin2001@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new ApplicationDbContext(optBuilder.Options);
        }
    }
}

