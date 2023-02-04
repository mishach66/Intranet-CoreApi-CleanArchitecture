using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Data.Configuration
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.HasData(
            //    new Employee
            //    {
            //        Id = new Guid("7739FBA1-D589-4536-A99F-70192E9110F9"),
            //        Givenname = "სახელი1",
            //        Surname = "გვარიიიი",
            //        CityId = Guid.Parse("46b5d769-cd3b-4d92-b3d0-85043758db10")
            //    },
            //    new Employee
            //    {
            //        Id = new Guid("B53D176F-55F8-4496-B30C-DBE907FFE632"),
            //        Givenname = "სახელი2",
            //        CityId = Guid.Parse("270ca43e-8105-44d1-977a-2c5cb6450d68")
            //    }
            //);

            builder.HasOne(e => e.Branch).WithMany(b => b.Employees).HasForeignKey(e => e.BranchId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(e => e.City).WithMany(c => c.Employees).HasForeignKey(e => e.CityId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
