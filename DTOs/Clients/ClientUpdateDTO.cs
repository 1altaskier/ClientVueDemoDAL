using PorchFinal.Models;

namespace PorchFinal.DTOs.Clients
{
    public class ClientUpdateDto
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsArchived { get; set; }
        public List<PhoneDto> Phones { get; set; } = new();
    }

    public class PhoneWriteDto
    {
        public int PhoneId { get; set; }  // 0 = new
        public string PhoneNumber { get; set; } = string.Empty;
        public int PhoneTypeId { get; set; }
    }
}
