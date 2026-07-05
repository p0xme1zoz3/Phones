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
            new Phone { Id = 3, Brand = "Nokia", Model = "E-71",Date = new DateOnly(2011,5,1)},
            new Phone { Id = 4, Brand = "HTC", Model = "Desire HD2",Date = new DateOnly(2013,1,1)},
            new Phone { Id = 5, Brand = "Samsung", Model = "B310E",Date = new DateOnly(2015,2,1), Price = 5000},
            new Phone { Id = 6, Brand = "Microsoft", Model = "Lumia 730",Date = new DateOnly(2015,3,22), Price = 30000},
            new Phone { Id = 7, Brand = "Meizu", Model = "M2 Mini",Date = new DateOnly(2016,9,1), Price = 70000},
            new Phone { Id = 8, Brand = "Xiaomi", Model = "Redmi Note 6 Pro",Date = new DateOnly(2018,12,30), Price = 80000}
            );
    }
}