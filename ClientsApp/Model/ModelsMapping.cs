using Clients.Data.Repository.Clients;
using Clients.Data.Repository.ClientsStatus;
using ClientsApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientsApp.ViewModel.Model
{
    internal static class ModelsMapping
    {
        public static List<Status> Statuses { get; set; } 


        internal static Status StatusMapFromDb(DbStatus dbStatus)
        {
            return new Status() { Id = dbStatus.Id, Name = dbStatus.Name };
        }

        internal static DbStatus StatusMapToDb(Status status)
        {
            return new DbStatus() { Id = status.Id, Name = status.Name };
        }

        internal static Client ClientMapFromDb(DbClient dbClient)
        {
            return new Client() 
            { 
                Id = dbClient.Id, 
                Surname = dbClient.Surname,
                Name = dbClient.Name,
                MiddleName = dbClient.MiddleName,
                DateOfBirth = dbClient.DateOfBirth,
                Phone = dbClient.Phone,
                Email = dbClient.Email,
                Status = Statuses.First(s => s.Id == dbClient.Id).Name,
            };
        }

        internal static DbClient ClientMapToDb(Client client)
        {
            return new DbClient()
            {
                Id = client.Id,
                Surname = client.Surname ?? throw new ArgumentNullException(nameof(Client.Surname)),
                Name = client.Name ?? throw new ArgumentNullException(nameof(Client.Name)),
                MiddleName = client.MiddleName ?? throw new ArgumentNullException(nameof(Client.MiddleName)),
                DateOfBirth = client.DateOfBirth ?? throw new ArgumentNullException(nameof(Client.DateOfBirth)),
                Phone = client.Phone,
                Email = client.Email,
            };
        }
    }
}
