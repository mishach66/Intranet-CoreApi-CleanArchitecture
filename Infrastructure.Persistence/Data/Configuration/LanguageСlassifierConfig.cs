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
    public class LanguageСlassifierConfig : IEntityTypeConfiguration<LanguageСlassifier>
    {
        public void Configure(EntityTypeBuilder<LanguageСlassifier> builder)
        {
            builder.HasData(
                new LanguageСlassifier
                {
                    Id = new Guid("c47e86d8-87c7-413f-b569-19c53b3e45e6"),
                    LanguageName = "ინგლისური",
                },
                new LanguageСlassifier
                {
                    Id = new Guid("7bff9ed9-0226-4f22-b105-03d3bd13f328"),
                    LanguageName = "გერმანული",
                },
                new LanguageСlassifier
                {
                    Id = new Guid("d18fdd15-d0ca-43cc-bbf1-1847fd50f2ce"),
                    LanguageName = "ფრანგული",
                },
                new LanguageСlassifier
                {
                    Id = new Guid("f9ffedab-9141-4595-8c0e-59fbaebe5511"),
                    LanguageName = "ესპანური",
                },
                new LanguageСlassifier
                {
                    Id = new Guid("69b476fa-45bb-4046-bcf1-8eb975dc6158"),
                    LanguageName = "იტალიური",
                }
            );

            // builder.HasOne(e => e.Branch).WithMany(b => b.Employees).HasForeignKey(e => e.BranchId).OnDelete(DeleteBehavior.ClientSetNull);
            // builder.HasOne(e => e.Branch).WithMany(b => b.Employees).HasForeignKey(e => e.BranchId).OnDelete(DeleteBehavior.SetNull);
            // builder.HasOne(e => e.City).WithMany(c => c.Employees).HasForeignKey(e => e.CityId).OnDelete(DeleteBehavior.ClientNoAction);
            // builder.HasIndex(l => l.LanguageName).IsUnique();  // ეს საჭიროა ენების უნიკალურობისთვის

            // // builder.HasNoKey(); // Read only table
        }
    }
}
