using Clients.Data.Service;
using ClientsApp.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ClientsApp.ViewModel
{
    public sealed class AppViewModel: INotifyPropertyChanged
    {
        private IDataService _dataService;
        private Client _selectedClients;
        public Client SelectedClients 
        { 
            get { return _selectedClients; } 
            set 
            { 
                _selectedClients = value; 
                OnPropertyChanged(nameof(SelectedClients));
            } 
        }
        public ObservableCollection<Client> Clients { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public AppComand AddCommand
        {
            get
            {
                return new AppComand(obj => 
                {
                    // БД
                    /*var dbClient = ModelsMapping.ClientMapToDb(SelectedClients);
                    _dataService.Clients.CreateAsync(dbClient);
                    _dataService.SaveAsync();*/

                    var client = new Client() { Id = 4, Surname = "Пшебышевский", Name = "Казимир", MiddleName = "Густавович", DateOfBirth = new DateTime(1944, 12, 4), Phone = "", Email = "ivan.ii@client.com", Status = "Active" };
                    Clients.Add(client);
                    SelectedClients = client;
                });
            }
        }

        public AppComand EditCommand
        {
            get
            {
                return new AppComand(obj =>
                {
                    // БД
                    /*var dbClient = ModelsMapping.ClientMapToDb(SelectedClients);
                    _dataService.Clients.Update(dbClient);*/

                    var client = SelectedClients;
                    var index = Clients.IndexOf(client);
                    Clients.RemoveAt(index);
                    Clients.Insert(index, client);
                    SelectedClients = client;
                });
            }
        }

        public AppComand DeleteCommand
        {
            get
            {
                return new AppComand(obj =>
                {
                    // БД
                    /*var dbClient = ModelsMapping.ClientMapToDb(SelectedClients);
                      _dataService.Clients.Delete(dbClient);*/

                    var client = SelectedClients;
                    Clients.Remove(client);
                });
            }
        }

        public AppViewModel(IDataService dataService)
        {
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
            Clients = clientsCollection;                    */

            Clients = new ObservableCollection<Client>()
            {
                new Client() {Id = 1, Surname = "Иванов", Name = "Иван", MiddleName = "Иванович", DateOfBirth = new DateTime(1944, 9, 4), Phone = "90-4", Email = "ivan.ii@client.com", Status = "Active"},
                new Client() {Id = 2, Surname = "Иванов", Name = "Иван", MiddleName = "Степанович", DateOfBirth = new DateTime(1944, 10, 4), Phone = "44.44.22", Email = "", Status = "Terminated"},
                new Client() {Id = 3, Surname = "Иванов", Name = "Иван", MiddleName = "Фомич", DateOfBirth = new DateTime(1944, 11, 4), Phone = "", Email = "", Status = "Active"},
                new Client() {Id = 4, Surname = "Иванов", Name = "Иван", MiddleName = "Кузьмич", DateOfBirth = new DateTime(1944, 12, 4), Phone = "", Email = "ivan.ii@client.com", Status = "Active"},
            };
        }
    }
}
