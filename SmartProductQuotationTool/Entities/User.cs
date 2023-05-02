using Microsoft.AspNetCore.Identity;

namespace SmartProductQuotationTool.Entities
{
    public class User : IdentityUser
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Website { get; set; }
        public double? Discount { get; set; }
    }
}
