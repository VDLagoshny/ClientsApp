using Clients.Data.Repository.Clients;
using Clients.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Clients.Data.Tests
{
    [TestFixture]
    public sealed class ClientTests
    {
        private IDataService _dataService;
        public ClientTests() 
        {
            var services = new ServiceCollection()
                .AddServiceData(@"Data Source=ClientAppDbDemo.sqlite");
            var serviceProvider = services.BuildServiceProvider();

            _dataService = serviceProvider.GetRequiredService<IDataService>();
        }


        [Test]
        public async Task AddClient()
        {
            try
            {
                var newClient = new DbClient()
                {
                    Surname= "test_Surname",
                    Name= "test_Name",
                    MiddleName = "test_MiddleName",
                    DateOfBirth= DateTime.Now,
                    PlaceOfBirth = null,
                    Phone = "0001-0001",
                    Email = "test_Email",
                    StatusId= 1
                };
                
                await _dataService.Clients.CreateAsync(newClient);
                await _dataService.SaveAsync();

                var clients = _dataService.Clients.GetQueryable();

                Assert.That(clients.Count(), Is.GreaterThan(0));

                var addedClient = clients.ToList().FirstOrDefault(c => c.Surname == newClient.Surname);

                Assert.That(addedClient == null, Is.False);
            }
            catch (Exception ex)
            {
                Assert.Warn(ex.Message ?? ex.InnerException?.Message);
            }
        }

        [Test]
        public void UpdateClient()
        {

        }

        [Test]
        public void DeleteClient()
        {

        }

        [Test]
        public void GetClients()
        {
            try
            {
                var clients = _dataService.Clients.GetQueryable();

                Assert.That(clients.Count, Is.GreaterThan(0));
            }
            catch (Exception ex)
            {
                Assert.Warn(ex.Message ?? ex.InnerException?.Message);
            }
        }
    }
}