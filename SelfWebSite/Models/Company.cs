using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SelfWebSite.Models
{
    /// <summary>
    /// Класс компании в которых работают люди
    /// </summary>
    public class Company
    {
        [HiddenInput(DisplayValue = false)]
        //[ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле наименования компании должно быть заполнено")]
        [Display(Name = "Компания")]
        public string Name { get; set; }


        //связь к главной сущности в отношении 1-1
        public int? CountryId { get; set; }
        public Country Country { get; set; }
    }
}
