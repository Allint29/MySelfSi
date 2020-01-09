using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SelfWebSite.Models
{
    public class ManufacturesProductsConfiguration: IEntityTypeConfiguration<ManufacturesProducts>
    {
        public void Configure(EntityTypeBuilder<ManufacturesProducts> builder)
        {
            //настройка связи многие ко многим в отношении производителей и товара
            builder
                .HasKey(k => new {k.ManufactureId, k.ProductId});

            builder
                .HasOne(mp => mp.Product)
                .WithMany(p => p.ManufacturesProducts)
                .HasForeignKey(mp => mp.ProductId);

            builder
                .HasOne(mp => mp.Manufacture)
                .WithMany(m => m.ManufacturesProducts)
                .HasForeignKey(mp => mp.ManufactureId);

        }
    }
}
