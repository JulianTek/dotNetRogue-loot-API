using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Application.Interfaces;
using dotNetRogueLootAPI.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotNetRogueLootAPI.IntegrationTests.Common
{
    public class PresentationWebAppFactory<TEntryPoint> 
        : WebApplicationFactory<TEntryPoint> 
        where TEntryPoint : class
    {
        protected override IHostBuilder CreateHostBuilder() => 
            base.CreateHostBuilder().UseEnvironment("Testing");

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IAppDbContext));

                services.Remove(descriptor);

                services.AddDbContext<IAppDbContext, AppDbContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "dotNetRogueTests "));
            });
        }
    }
}
