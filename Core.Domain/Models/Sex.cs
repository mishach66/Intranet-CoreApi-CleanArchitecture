using Core.Domain.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class Sex : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public Sex()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
