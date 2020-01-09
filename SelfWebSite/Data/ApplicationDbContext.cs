using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SelfWebSite.Loggers;
using SelfWebSite.Models;
using SelfWebSite.Data.DataConfigurations;

namespace SelfWebSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //1 способ включения в БД сущностей
        //так как продукт содержинт навиг св-во на компани то в БД создасться 2 таблицы
        public DbSet<Product> Products { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<ApplicationUser> AspNetUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        #region Логгирование
        // устанавливаем фабрику логгера
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            //для использования встроенного ASP Net Loggera нужен пакет nuget Microsoft.Extensions.Logging.Console
            //builder.AddConsole();
            // или так с более детальной настройкой
            //builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
            //            && level == LogLevel.Information)
            //       .AddConsole();


            //использование своего собственного провайдера логгирования
            builder.AddProvider(new MyLoggerDbProvider());    // указываем наш провайдер логгирования
            builder.AddFilter((category, level) =>
                {
                    return category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information;
                })
                .AddProvider(new MyLoggerDbProvider());
        });
        
        #endregion

        //добавляем настройку логгирования
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);

            //Подгрузка конфигураций таблиц
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturesProductsConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());


            #region Создание таблиц и свойств - исключение таблиц

            //2 способ создания таблиц в БД при помощи Fluent API
            // modelBuilder.Entity<Country>().ToTable("Countries"); // 2 способ задать имя таблицы в БД .ToTable("OtherCountries");


            //исключение из БД сущности - таж де будут удалены поля из таблиц ссылающих на эту сущьность
            //modelBuilder.Ignore<Company>();
            //3 способ не включать в БД сущность при помощи анностаций [NotMapped]

            //1 способ исключение свойства из контекста БД и второй [NotMapped]
            //modelBuilder.Entity<Product>().Ignore(b => b.Rate);



            #endregion

            #region Задание названий столбцов, ключи таблиц

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


            #endregion

            #region Генерация значений столбцов + значения по умолчанию + составные значения

            //отключение актогенерации на стороне БД
            //modelBuilder.Entity<Person>().Property(b => b.Id).ValueGeneratedNever();
            //специальное включнеие автогенерации
            //modelBuilder.Entity<Person>().Property(b => b.Id).ValueGeneratedOnAdd();
            //включение значения по умолчанию
            //modelBuilder.Entity<Person>().Property(u => u.Age).HasDefaultValue(18);
            //Установка но умолчанию используя SQL синтаксис
            //modelBuilder.Entity<Person>()
            //    .Property(u => u.CreatedAt)
            //    .HasComputedColumnSql("GETDATE()");

            //modelBuilder.Entity<Person>()
            //   .Property(u => u.Name)
            //    .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            #endregion


            #region Ограничения

            //modelBuilder.Entity<Person>().Property(u => u.FirstName).HasColumnType("varchar(200)");
            //modelBuilder.Entity<Person>().Property(u => u.LastName).HasColumnType("varchar(200)");

            #endregion
        }



    }
}
