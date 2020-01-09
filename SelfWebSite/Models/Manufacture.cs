using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SelfWebSite.Models
{
    /// <summary>
    /// Сущность производителя
    /// </summary>
    public class Manufacture
    {
        [HiddenInput(DisplayValue = false)]
        //[ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле наименования производителя должно быть заполнено")]
        [Display(Name = "Производитель")]
        public string Name { get; set; }


        //связь к главной сущности в отношении 1-1
        public int? CountryId { get; set; }
        public Country Country { get; set; }

        //Список всех продуктов компании отношение многие ко многим
        //public List<Product> Products { get; set; }

        //навигация к таблице связи многие ко многим между произзводителем и товаром
        public List<ManufacturesProducts> ManufacturesProducts { get; set; }

        public Manufacture()
        {
            ManufacturesProducts = new List<ManufacturesProducts>();
        }

    }
}
