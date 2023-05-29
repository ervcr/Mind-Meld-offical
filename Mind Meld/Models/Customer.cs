using Microsoft.EntityFrameworkCore;

namespace Mind_Meld.Models
{
    [Keyless]
    public class Customer
    {
        public string CustomerId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }   
    }
}
