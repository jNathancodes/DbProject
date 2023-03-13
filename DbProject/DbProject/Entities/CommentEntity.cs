using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Entities
{
    public class CommentEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Comment { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;

        [ForeignKey("CaseEntity")]
        public Guid CaseId { get; set; }
        public CaseEntity Case { get; set; }
    }
}
