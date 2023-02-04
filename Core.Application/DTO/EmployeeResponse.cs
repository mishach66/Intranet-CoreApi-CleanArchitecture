using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTO
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string Givenname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirtр { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Address { get; set; }
        public string AdditionalInfo { get; set; }
        public string PhotoPath { get; set; }
        public Guid? CityId { get; set; }
        //public City City { get; set; }
        public Guid? SexId { get; set; }
        //public Sex Sex { get; set; }
        public Guid? BranchId { get; set; }
        //public Branch Branch { get; set; }
    }
}
