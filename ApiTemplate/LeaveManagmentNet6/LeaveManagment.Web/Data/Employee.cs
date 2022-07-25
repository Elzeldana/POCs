using Microsoft.AspNetCore.Identity;

namespace LeaveManagment.Web.Data
{
    public class Employee: IdentityUser
    {
        public string? Name { get; set; }
        public string? Lastame { get; set; }
        public string? TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
