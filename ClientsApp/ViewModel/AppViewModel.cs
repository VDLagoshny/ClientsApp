using ClientsApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientsApp.ViewModel
{
    public sealed class AppViewModel: INotifyPropertyChanged
    {
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
                    var client = new Client() { Id = 5, Name = "Wladislaw", Status = "Active" };
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
                    // Получаем выбранный
                    var client = SelectedClients;
                    var index = Clients.IndexOf(client);

                    // Удаляем и вставляем новый объект
                    // на прежнее место
                    Clients.RemoveAt(index);
                    Clients.Insert(index, client);
                });
            }
        }

        public AppComand DeleteCommand
        {
            get
            {
                return new AppComand(obj =>
                {
                    // Выбранный Client
                    var client = SelectedClients;
                    Clients.Remove(client);
                });
            }
        }

        public AppViewModel()
        {
            // test
            Clients = new ObservableCollection<Client>()
            {
                new Client() {Id = 1, Name = "Vlad", Status = "Active"},
                new Client() {Id = 2, Name = "Vova", Status = "Active"},
                new Client() {Id = 3, Name = "Voldemar", Status = "Terminated"},
                new Client() {Id = 4, Name = "Victor", Status = "Active"},
            };
        }
    }
}
