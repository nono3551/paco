using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Paco.Areas.Identity.IdentityHostingStartup))]
namespace Paco.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {});
        }
    }
}