using Paco.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Paco.Data
{
    public class WeatherForecastService
    {
        private readonly ApplicationDbContext _dbContext;

        public WeatherForecastService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var entity = _dbContext.ManagedSystems.FirstOrDefault();

            _dbContext.Add(new ManagedSystem()
            {
                Hostname = "asdsad"
            });

            if(entity != null)
            {
                entity.Login = "wiii";
                _dbContext.Update(entity);
                _dbContext.SaveChanges();
                _dbContext.Remove(entity);
            }

            _dbContext.SaveChanges();



            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
