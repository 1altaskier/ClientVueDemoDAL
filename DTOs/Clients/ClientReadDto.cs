namespace PorchFinal.DTOs.Clients
{
    public class ClientReadDto
    {
        public int ClientId { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsArchived { get; set; }
        public List<PhoneReadDto> Phones { get; set; } = new();
    }

    public class PhoneReadDto
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string PhoneType { get; set; } = string.Empty; // e.g. "Mobile", "Home"
    }
}
