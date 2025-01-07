using Microsoft.EntityFrameworkCore;
using PetStore.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PetStore.Identity.Configuration;

namespace PetStore.Identity
{
    public class PetStoreIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public PetStoreIdentityDbContext(DbContextOptions<PetStoreIdentityDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
