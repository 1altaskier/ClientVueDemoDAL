using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorchFinal.Models
{
    public class PhoneType
    {
        [Required]
        [Column("phone_type_id")]
        public int PhoneTypeId { get; set; }

        [Required]
        [Column("phone_type")]
        public string Type { get; set; } = null!;
    }
}
