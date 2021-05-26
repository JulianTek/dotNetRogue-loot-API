using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Application.Interfaces;
using dotNetRogueLootAPI.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace dotNetRogueLootAPI.IntegrationTests.Common
{
    public class IntegrationTestBase : IClassFixture<PresentationWebAppFactory<Startup>>, IDisposable
    {
        readonly PresentationWebAppFactory<Startup> _factory;
        readonly IServiceScope _serviceScope;

        protected IntegrationTestBase(PresentationWebAppFactory<Startup> factory)
        {
            _factory = factory;

            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            _serviceScope = scopeFactory?.CreateScope();
        }

        protected IAppDbContext GetDbContext()
        {
            var dbContext = _serviceScope.ServiceProvider.GetService<IAppDbContext>();
            return dbContext;
        }

        protected HttpClient CreateHttpClient()
        {
            return _factory.CreateClient();
        }

        public void Dispose()
        {
            _serviceScope?.Dispose();
        }
    }
}
