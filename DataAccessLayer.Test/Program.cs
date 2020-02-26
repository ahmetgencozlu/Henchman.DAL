using DataAccessLayer.Repository;
using DataAccessLayer.Test.Repository;
using DataAccessLayer.Test.Entity;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer.Test.TestWorker;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var usertest = new UserTest(serviceProvider.GetService<IConfiguration>());

            usertest.UserRepositoryTestAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}
