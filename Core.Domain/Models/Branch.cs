using Core.Domain.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class Branch : AuditableEntity
    {
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public Branch()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
