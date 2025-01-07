using Microsoft.EntityFrameworkCore;
using PetStore.Domain;
using PetStore.Persistance.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Persistance
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext(DbContextOptions<PetStoreDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Pets)
                .UsingEntity<Dictionary<string, object>>(
                    "PetTag",
                    j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                    j => j.HasOne<Pet>().WithMany().HasForeignKey("PetId")
                );
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Categories)
                .WithMany()
                .HasForeignKey(p => p.CategoriesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
            .HasOne(o => o.Pet)
            .WithMany()
            .HasForeignKey(o => o.PetId);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());

        }
    }
}


