using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clients.Data.Repository.ClientsStatus;
using Microsoft.EntityFrameworkCore;

namespace Clients.Data.Repository.Clients
{
    [Table("Clients")]
    [PrimaryKey(nameof(Id))]
    public sealed class DbClient
    {
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string MiddleName { get; set; }
        
        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        
        [Required]
        public long? StatusId { get; set; }
        public DbStatus PersonStatus { get; set; }
    }
}
