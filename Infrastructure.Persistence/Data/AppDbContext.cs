using Core.Domain.Models;
using Infrastructure.Persistence.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfig());
        modelBuilder.ApplyConfiguration(new BranchConfig());
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Sex> Sexes { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
}
