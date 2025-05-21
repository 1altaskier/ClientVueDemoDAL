using System.ComponentModel.DataAnnotations.Schema;

namespace PorchFinal.Models
{
    [Table("Clients")]
    public class Client
    {
        [Column("client_id")]
        public int ClientId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; } = null!;

        [Column("last_name")]
        public string LastName { get; set; } = null!;

        [Column("is_archived")]
        public bool? IsArchived { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        public ICollection<Phone>? Phones { get; set; } = new List<Phone>();
    }
}
