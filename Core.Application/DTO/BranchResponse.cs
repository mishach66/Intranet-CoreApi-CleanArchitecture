using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTO
{
    public class BranchResponse
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public Guid CityId { get; set; }
    }
}
