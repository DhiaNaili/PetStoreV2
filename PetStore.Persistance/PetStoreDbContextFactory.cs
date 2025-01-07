using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PetStore.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Persistence
{
    public class PetStoreDbContextFactory : IDesignTimeDbContextFactory<PetStoreDbContext>
    {

        public PetStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<PetStoreDbContext>();
            var connectionString = configuration.GetConnectionString("PetStoreDbContext");

            builder.UseNpgsql(connectionString);
            return new PetStoreDbContext(builder.Options);
        }
    }
}
