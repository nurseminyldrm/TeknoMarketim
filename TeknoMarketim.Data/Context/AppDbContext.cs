

using Microsoft.EntityFrameworkCore;
using TeknoMarketim.Data.Configurations;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Context;

public class AppDbContext:DbContext
{
    public AppDbContext()
    {

    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    */

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TeknoMarketimDB;" +
                "Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    } */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        //modelBuilder.ApplyConfiguration(new CustomerAddressConfiguration());

        //modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        


    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<CustomerCard> CustomerCards { get; set; }
    public DbSet<WishList> WishLists { get; set; }

}
