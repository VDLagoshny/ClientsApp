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

        public AppViewModel()
        {
            // test
            Clients = new ObservableCollection<Client>()
            {
                new Client() { Id = 1, Name = "Vlad", Status = "Active"},
                new Client() {Id = 2, Name = "Vova", Status = "Active"},
                new Client() {Id = 3, Name = "Voldemar", Status = "Terminated"},
                new Client() {Id = 4, Name = "Victor", Status = "Active"},
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
