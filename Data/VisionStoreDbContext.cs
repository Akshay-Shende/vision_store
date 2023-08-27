using Microsoft.EntityFrameworkCore;
using VisionStore.Models;

namespace VisionStore.Data
{
    public class VisionStoreDbContext : DbContext
    {
        public VisionStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<DiscountTable> discounts { get; set; }
        public DbSet<PreferredPaymentMethod> preferredPaymentMethods { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<DeliveryMethods> deliveryMethods { get; set; }
        public DbSet<UserMaster> userMasters { get; set; }
        public DbSet<Manufacturer> manufacturers { get; set; }
        public DbSet<PurchaseProducts> purchaseProducts { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                 .Property(p => p.SelectedUnits)
                 .HasDefaultValue(1);
        }
    }
}
