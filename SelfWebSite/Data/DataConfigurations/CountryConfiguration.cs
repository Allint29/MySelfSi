using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfWebSite.Models;

namespace SelfWebSite.Data.DataConfigurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries").HasKey(c=>c.Id);
            builder.Property(c => c.Code).IsRequired().HasMaxLength(5);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Population).HasDefaultValue(1000);

            builder
                .HasMany(c => c.Companies)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(c => c.Persons)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
