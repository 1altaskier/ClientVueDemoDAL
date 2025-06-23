namespace PorchFinal.DTOs.Phones
{
    public class PhoneWriteDto
    {
        public int PhoneId { get; set; }  // 0 = new
        public string PhoneNumber { get; set; } = string.Empty;
        public int PhoneTypeId { get; set; }
        public int ClientId { get; set; }
    }
}
