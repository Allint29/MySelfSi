using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfWebSite.Models;

namespace SelfWebSite.Data.DataConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons").HasKey(p => p.Id).HasName("PersonsPrimaryKey");
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Age).HasMaxLength(3);
            builder.Property(p => p.PassportSeria).HasMaxLength(6);
            builder.Property(p => p.PassportNumber).HasMaxLength(10);
            builder.Property(p => p.Birthday).IsRequired();

            builder.Property(u => u.Name).HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
                
                
                


            //способ задать альтернативный ключ для таблицы - уникальные значения поля
            //builder.HasAlternateKey(u => new { u.PassportSeria, u.PassportNumber });

            //способ задать составной ключ для таблицы
            //modelBuilder.Entity<Person>().HasKey(u => new { u.PassportSeria, u.PassportNumber });



            //2 способ задать имя стлбца в БД
            //modelBuilder.Entity<Product>().Property(u => u.Id).HasColumnName("product_id");
            //способ задать ключ для таблицы и имя ограничения для первичного ключа
            //modelBuilder.Entity<Product>().HasKey(u => u.Id).HasName("ProductsPrimaryKey"); ;
            //способ задать составной ключ для таблицы
            //modelBuilder.Entity<Person>().HasKey(u => new { u.PassportSeria, u.PassportNumber });
            //способ задать альтернативный ключ для таблицы - уникальные значения поля
            //modelBuilder.Entity<Person>().HasAlternateKey(u => new { u.PassportSeria, u.PassportNumber });
            //настройка дополнительного индекса для таблицы
            //modelBuilder.Entity<Person>().HasIndex(u => u.PassportNumber);
        }
    }
}
