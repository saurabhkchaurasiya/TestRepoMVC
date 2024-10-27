using Microsoft.Extensions.WebEncoders.Testing;

namespace MVCWebApplication.Models
{
    public class People
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Address { get; set; } = "Test";
    }
}
