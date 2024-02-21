using System.Collections.ObjectModel;

namespace ClientsApp.Model.ModelService
{
    public interface IClientService
    {
        ObservableCollection<Client> GetClients();

        // Метод, который должен быть
        //void AddClient(Client client);

        // Метод-заглушка
        Client AddClient();
        void RemoveClient(Client client);
        Client UpdateClient(Client client);
    }
}
