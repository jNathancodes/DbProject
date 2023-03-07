using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "char(6)")]
        public string City { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PostalCode { get; set; } = string.Empty;

        public ICollection<CustomerEntity> Customer = new HashSet<CustomerEntity>();
    }
}
