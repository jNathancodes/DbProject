

using DbProject.Enums;
using System.ComponentModel.DataAnnotations;

namespace DbProject.Entities
{
    public class CaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Status Status { get; set; } = Status.NotStarted;
        public string? Comment { get; set; } 
        public string Content { get; set; } = null!;
        public CustomerEntity Customer { get; set; } = null!; 
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
