using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using SelfWebSite.Data;

namespace SelfWebSite.Models
{
    /// <summary>
    /// Сущность описывает человека его данные и принадлежнось к компаниям и стране
    /// </summary>
    public class Person
    {
        [HiddenInput(DisplayValue = false)]
        //[ScaffoldColumn(false)]
        public int Id { get; set; }
        
        public string Name { get; set; }

        //задание ограничений при помощи аннотаций
        //[Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Поле имени должно быть заполнено")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        //задание ограничений при помощи аннотаций
        //[Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Поле фамилии должно быть заполнено")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }


        private int _age;

        [Display(Name = "Возраст")]
        public int Age
        {
            get => _age;

            set
            {
                value = Birthday.Year;
                if (value < 1900)
                {  
                    int age = DateTime.Today.Year - value;
                    if (Birthday > DateTime.Today.AddYears(-age)) age--;
                    _age = age;
                }
                else
                {
                    _age = 0;
                }
            }


        }

        //[Column()]
        //[Range(1700, 2000, ErrorMessage = "Недопустимый год")]
        [Required(ErrorMessage = "Поле даты рождения должно быть заполнено")]
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }

        
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }
        [Display(Name = "Серия паспорта")]
        public string PassportSeria { get; set; }

        //связь к главной сущности в отношении 1-1
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //связь к главной сущности в отношении 1-1
        public int? CountryId { get; set; }
        public Country Country { get; set; }

    }
}
