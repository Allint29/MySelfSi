using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfWebSite.Models;

namespace SelfWebSite.Data.DataConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //связь один к одному для ApplicationUser и Person Где ApplicationUser главная сущьность
            builder
                .HasOne(au => au.Person)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey<Person>(p => p.ApplicationUserId);

        }
    }
}
