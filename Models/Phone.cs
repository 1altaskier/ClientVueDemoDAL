using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PorchFinal.Models
{
    public class Phone
    {
        [Required]
        [Column("phone_id")]
        public int PhoneId { get; set; }

        // Optional: if using PhoneType
        public int PhoneTypeId { get; set; }
        [Column("phone_type_id")]
        public PhoneType PhoneType { get; set; } = null!;

        [Column("phone_number")]
        public string PhoneNumber { get; set; } = null!;

        // Foreign key to Client
        [Column("client_id")]
        public int ClientId { get; set; }

        // Navigation property to Client
        [JsonIgnore]
        public Client? Client { get; set; }
    }
}