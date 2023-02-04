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
    internal class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            //builder.HasMany(x => x.Employees).WithOne(b => b.Branch).HasForeignKey(b => b.BranchId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
