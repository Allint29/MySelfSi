using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SelfWebSite.Models
{
    /// <summary>
    /// Сущность описания продукта
    /// </summary>

    //атрибут позволяет задать имя таблицы в БД 1 способ [Table("Products2")]
    public class Product
    {
        private string _name;

        //способ задать имя столбца в БД [Column("user_id")]

        //способ задания ключа для таблицы [Key]
        //1 способ есть через Fluent Api отключаю автогенерацию ID [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //специально включаю генерацию [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        //[ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле названия товара должно быть заполнено")]
        [Display(Name = "Наименование")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Required(ErrorMessage = "Поле цены товара должно быть заполнено")]
        [Display(Name = "Цена")]
        public int Price { get; set; }

        //[NotMapped]
        // public int Rate { get; set; }

        // навигационное свойство
        //public int ManufactureId { get; set; }
        // public Manufacture Manufacture { get; set; }

        //навигация к таблице связи многие ко многим между произзводителем и товаром
        public List<ManufacturesProducts> ManufacturesProducts { get; set; }
        
        public Product()
        {
            ManufacturesProducts = new List<ManufacturesProducts>();
        }
    }



}
