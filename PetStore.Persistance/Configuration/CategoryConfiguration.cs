using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Persistance.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            // Configure properties
            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Seed initial data
            builder.HasData(
                new Category { Id = 1, Name = "Dogs" },
                new Category { Id = 2, Name = "Cats" },
                new Category { Id = 3, Name = "Birds" },
                new Category { Id = 4, Name = "Fish" },
                new Category { Id = 5, Name = "Reptiles" }
            );
        }
    }
}
