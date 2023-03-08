

using DbProject.Enums;
using Microsoft.EntityFrameworkCore;

namespace DbProject.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class CustomerEntity

    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!; 
        public string PhoneNumber { get; set; } = null!;

    }
}
