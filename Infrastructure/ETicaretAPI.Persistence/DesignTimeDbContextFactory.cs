using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ETicaretAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretApiDbContext>
    {
        public ETicaretApiDbContext CreateDbContext(string[] args)
        {            
            DbContextOptionsBuilder<ETicaretApiDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new ETicaretApiDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
