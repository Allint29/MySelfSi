using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SelfWebSite.Models
{
    /// <summary>
    /// страна в которой живут и работают люди и существуют компании
    /// </summary>
    public class Country
    {
        [HiddenInput(DisplayValue = false)]
        //[ScaffoldColumn(false)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public long Population { get; set; }
        public int Code { get; set; }

        //навигация для связи один ко многим
        public List<Person> Persons { get; set; }

        //навигация для связи один ко многим
        public List<Company> Companies { get; set; }

    }
}
