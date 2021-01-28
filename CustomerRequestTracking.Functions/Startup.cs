using CustomerRequestTracking.Functions.Data;
using CustomerRequestTracking.Functions.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(CustomerRequestTracking.Functions.Startup))]
namespace CustomerRequestTracking.Functions
{ 
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = Environment.GetEnvironmentVariable("SqlServerConnection");
            builder.Services.AddDbContext<DataContext>(x =>
            {
                x.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            });

            builder.Services.AddTransient<IRequestFormService, RequestFormService>();
        }
    }
}
