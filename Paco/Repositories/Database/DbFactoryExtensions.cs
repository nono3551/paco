using Microsoft.EntityFrameworkCore;

namespace Paco.Repositories.Database
{
    public static class DbFactoryExtensions
    {
        public static void Remove(this IDbContextFactory<ApplicationDbContext> factory, object entity)
        {
            using var db = factory.CreateDbContext();
            db.Remove(entity);
            db.SaveChanges();
        }
        
        public static void Add(this IDbContextFactory<ApplicationDbContext> factory, object entity)
        {
            using var db = factory.CreateDbContext();
            db.Add(entity);
            db.SaveChanges();
        }
    }
}