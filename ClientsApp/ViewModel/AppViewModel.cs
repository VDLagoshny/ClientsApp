using ClientsApp.Model;
using ClientsApp.Model.ModelService;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientsApp.ViewModel
{
    public sealed class AppViewModel: INotifyPropertyChanged
    {
        private IClientService _clientService;
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
                    var client = _clientService.AddClient();

                    // Метод должен возвращать некую
                    // модель со статусом операции с БД
                    if (true)
                    {
                        Clients.Add(client);
                        SelectedClients = client;
                    }
                });
            }
        }

        public AppComand EditCommand
        {
            get
            {
                return new AppComand(obj =>
                {
                    var client = SelectedClients;

                    _clientService.UpdateClient(client);


                    // Метод должен возвращать некую
                    // модель со статусом операции с БД
                    if (true)
                    {
                        var index = Clients.IndexOf(client);
                        Clients.RemoveAt(index);
                        Clients.Insert(index, client);
                        SelectedClients = client;
                    }
                });
            }
        }

        public AppComand DeleteCommand
        {
            get
            {
                return new AppComand(obj =>
                {
                    var client = SelectedClients;
                    
                    // Метод должен возвращать некую
                    // модель со статусом операции с БД
                    _clientService.RemoveClient(client);
                    if (true)
                        Clients.Remove(client);
                });
            }
        }

        public AppViewModel(IClientService clientService)
        {
            _clientService= clientService;
            Clients = _clientService.GetClients();
        }
    }
}
