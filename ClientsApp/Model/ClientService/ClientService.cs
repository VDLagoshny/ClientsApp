using Clients.Data.Service;
using ClientsApp.ViewModel.Model;
using System;
using System.Collections.ObjectModel;

namespace ClientsApp.Model.ModelService
{
    internal sealed class ClientService: IClientService
    {
        private IDataService _dataService;
        public ClientService(IDataService dataService) 
        {
            _dataService = dataService;
        }


        public ObservableCollection<Client> GetClients()
        {
            var clients = _dataService.Clients.GetQueryable();

            // ВЫНОС ЛОГИКИ В MODEL!
            // БД
            /*_dataService = dataService;
            ModelsMapping.Statuses = _dataService.Statuses.GetQueryable()
                .Select(s => ModelsMapping.StatusMapFromDb(s))
                .ToList();

            var clientsCollection = new ObservableCollection<Client>();
            _dataService.Clients.GetQueryable()
                .ToList()
                .ForEach(c =>
                {
                    clientsCollection.Add(ModelsMapping.ClientMapFromDb(c));
                });
            Clients = clientsCollection;*/

            return new ObservableCollection<Client>()
            {
                new Client() {Id = 1, Surname = "Иванов", Name = "Иван", MiddleName = "Иванович", DateOfBirth = new DateTime(1944, 9, 4), Phone = "90-4", Email = "ivan.ii@client.com", Status = "Active"},
                new Client() {Id = 2, Surname = "Иванов", Name = "Иван", MiddleName = "Степанович", DateOfBirth = new DateTime(1944, 10, 4), Phone = "44.44.22", Email = "", Status = "Terminated"},
                new Client() {Id = 3, Surname = "Иванов", Name = "Иван", MiddleName = "Фомич", DateOfBirth = new DateTime(1944, 11, 4), Phone = "", Email = "", Status = "Active"},
                new Client() {Id = 4, Surname = "Иванов", Name = "Иван", MiddleName = "Кузьмич", DateOfBirth = new DateTime(1944, 12, 4), Phone = "", Email = "ivan.ii@client.com", Status = "Active"},
            };
        }

        // Метод, который должен быть
        public void AddClient(Client client)
        {
        }

        public Client AddClient()
        {
            return new Client() { Id = 4, Surname = "Пшебышевский", Name = "Казимир", MiddleName = "Густавович", DateOfBirth = new DateTime(1944, 12, 4), Phone = "", Email = "ivan.ii@client.com", Status = "Active" };
        }

        public Client UpdateClient(Client client)
        {
            /*var clientDb = ModelsMapping.ClientMapToDb(client);
            _dataService.Clients.Update(clientDb);*/

            return client;
        }

        public void RemoveClient(Client client)
        {
            // ВЫНОС ЛОГИКИ В MODEL!
            // БД
            /*var dbClient = ModelsMapping.ClientMapToDb(SelectedClients);
              _dataService.Clients.Delete(dbClient);*/


        }
    }
}
