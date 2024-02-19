using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clients.Data.Repository.ClientsStatus
{
    [Table("Statuses")]
    [PrimaryKey(nameof(Id))]
    public sealed class DbStatus
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
