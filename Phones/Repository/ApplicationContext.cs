using Microsoft.EntityFrameworkCore;
using Phones.Model;

namespace Phones.Repository;

public class ApplicationContext : DbContext
{
    public DbSet<Phone> Phones { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>().HasData(
            new Phone { Id = 1, Brand = "Nokia", Model = "3410",Date = new DateOnly(2005,10,1)},
            new Phone { Id = 2, Brand = "Nokia", Model = "1600",Date = new DateOnly(2007,6,1)},
            new Phone { Id = 3, Brand = "Nokia", Model = "E-71",Date = new DateOnly(2011,5,1)}
            );
    }
}