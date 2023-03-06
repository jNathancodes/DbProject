

using DbProject.Enums;

namespace DbProject.Entities
{
    public class CaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Status Status { get; set; } = Status.NotStarted;
        public string Comment { get; set; } 
        public string Content { get; set; }
        public CustomerEntity Customer { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
