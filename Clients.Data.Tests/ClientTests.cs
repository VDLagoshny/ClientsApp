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
                var surname = "AddSurname";
                var name = "AddName";
                var middleName = "AddMiddleName";
                var dateOfBirth = DateTime.Now.ToString();
                var status = "1";
                string? placeOfBirth = null;
                var phone = "0001-0001";
                var email = "AddEmail";

                var addedClient = await AddClient(
                    surname,
                    name,
                    middleName,
                    dateOfBirth,
                    status,
                    placeOfBirth: placeOfBirth,
                    phone: phone,
                    email: email
                );

                Assert.That(addedClient == null, Is.False);
            }
            catch (Exception ex)
            {
                Assert.Warn(ex.Message ?? ex.InnerException?.Message ?? string.Empty);
            }
        }

        [Test]
        public async Task UpdateClient()
        {
            try
            {
                var surname = "AddForUpdateSurname";
                var name = "AddForUpdateName";
                var middleName = "AddForUpdateMiddleName";
                var dateOfBirth = DateTime.Now.ToString();
                var status = "1";
                string? placeOfBirth = null;
                var phone = "AddForUpdatePhone";
                var email = "AddForUpdateEmail";

                var addedClient = await AddClient(
                    surname,
                    name,
                    middleName,
                    dateOfBirth,
                    status,
                    placeOfBirth: placeOfBirth,
                    phone: phone,
                    email: email
                );

                if (addedClient == null) throw new Exception("The client was not added");

                addedClient.Surname = "UpdateSurname";
                addedClient.Name = "UpdateName";
                addedClient.MiddleName = "UpdateMiddleName";
                addedClient.PlaceOfBirth = "UpdatePlaceOfBirth";
                addedClient.Email = "UpdateEmail";
                addedClient.Phone = "UpdatePhone";
                addedClient.StatusId = 2;


                var updatedClient = await UpdateClient(addedClient);


                Assert.That(updatedClient == null, Is.False);
            }
            catch (Exception ex)
            {
                Assert.Warn(ex.Message ?? ex.InnerException?.Message ?? string.Empty);
            }
        }

        [Test]
        public async Task DeleteClient()
        {
            try
            {
                var surname = "AddForDeleteSurname";
                var name = "AddForDeleteName";
                var middleName = "AddForDeleteMiddleName";
                var dateOfBirth = DateTime.Now.ToString();
                var status = "1";
                string? placeOfBirth = null;
                var phone = "AddForDeletePhone";
                var email = "AddForDeleteEmail";

                var addedClient = await AddClient(
                    surname,
                    name,
                    middleName,
                    dateOfBirth,
                    status,
                    placeOfBirth: placeOfBirth,
                    phone: phone,
                    email: email
                );

                if (addedClient == null) throw new Exception("The client was not added");


                var deletedClient = await DeleteClient(addedClient);


                Assert.That(deletedClient, Is.Null);
            }
            catch (Exception ex)
            {
                Assert.Warn(ex.Message ?? ex.InnerException?.Message ?? string.Empty);
            }
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
                Assert.Warn(ex.Message ?? ex.InnerException?.Message ?? string.Empty);
            }
        }




        private async Task<DbClient?> AddClient(
            string surname, 
            string name, 
            string middleName,
            string? dateOfBirth,
            string? status, 
            string? placeOfBirth = null, 
            string? phone = null, 
            string? email = null)
        {
            var newClient = new DbClient()
            {
                Surname = surname ?? throw new Exception($"{nameof(DbClient.Surname)} is empty"),
                Name = name ?? throw new Exception($"{nameof(DbClient.Name)} is empty"),
                MiddleName = middleName ?? throw new Exception($"{nameof(DbClient.MiddleName)} is empty"),
                DateOfBirth =  DateTime.TryParse(dateOfBirth, out DateTime _dateOfBirth) ? _dateOfBirth : throw new Exception($"{nameof(DbClient.DateOfBirth)} is empty"),
                PlaceOfBirth = placeOfBirth,
                Phone = phone,
                Email = email,
                StatusId = long.TryParse(status, out long _status ) ? _status : throw new Exception($"{nameof(DbClient.StatusId)} is empty")
            };

            await _dataService.Clients.CreateAsync(newClient);
            await _dataService.SaveAsync();

            var clients = _dataService.Clients.GetQueryable().ToList();

            if (clients == null) throw new Exception("Client list is empty");

            return clients.FirstOrDefault(
                    c => c.Surname == surname
                    && c.Name == name
                    && c.MiddleName == middleName);
        }

        private async Task<DbClient?> UpdateClient(DbClient client)
        {
            _dataService.Clients.Update(client);
            await _dataService.SaveAsync();

            var clients = _dataService.Clients.GetQueryable().ToList();

            if (clients == null) throw new Exception("Client list is empty");

            return clients.FirstOrDefault(
                    c => c.Surname == client.Surname
                    && c.Name == client.Name
                    && c.MiddleName == client.MiddleName);
        }

        private async Task<DbClient?> DeleteClient(DbClient client)
        {
            _dataService.Clients.Delete(client);
            await _dataService.SaveAsync();

            var clients = _dataService.Clients.GetQueryable().ToList();

            if (clients == null) throw new Exception("Client list is empty");

            return clients.FirstOrDefault(
                    c => c.Surname == client.Surname
                    && c.Name == client.Name
                    && c.MiddleName == client.MiddleName);
        }
    }
}