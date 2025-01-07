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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd(); 

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50); 


            builder.HasData(
                new Tag { Id = 1, Name = "Friendly" },
                new Tag { Id = 2, Name = "Energetic" },
                new Tag { Id = 3, Name = "Calm" },
                new Tag { Id = 4, Name = "Small" },
                new Tag { Id = 5, Name = "Large" }
            );
        }
    }
}
