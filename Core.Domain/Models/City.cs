using Core.Domain.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class City : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Branch>? Branches { get; set; }
        public City()
        {
            Employees = new HashSet<Employee>();
            Branches = new HashSet<Branch>();
        }
    }
}
