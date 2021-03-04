using Microsoft.EntityFrameworkCore;
using Paco.Entities.Models;

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

        public static T Upsert<T>(this IDbContextFactory<ApplicationDbContext> factory, T entity) where T: IDbEntity
        {
            using var db = factory.CreateDbContext();
            
            if (db.Entry(entity).GetDatabaseValues() != null)
            {
                db.Update(entity);
            }
            else
            {
                db.Add(entity);
            }

            db.SaveChanges();

            return entity;
        }
        
        public static T Find<T>(this IDbContextFactory<ApplicationDbContext> factory, params object[] keys) where T: class, IDbEntity
        {
            using var db = factory.CreateDbContext();
            
            return db.Find<T>(keys);
        }
    }
}