using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BeepMan.Model
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasKey(i => i.Id);
            modelBuilder.Entity<Image>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Image>().HasOne(i => i.Product).WithMany(p => p.Images).HasForeignKey(k => k.Id).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasKey(i => i.Id);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasOne(p => p.User).WithMany(u => u.Products).HasForeignKey(k => k.Id).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().HasOne(c => c.SelectedProduct).WithMany(prop => prop.Customers).HasForeignKey(k => k.Id);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
