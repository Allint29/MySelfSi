using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfWebSite.Models
{
    /// <summary>
    /// связующая таблица для связи многие ко многим между продукцией и компаниями
    /// </summary>
    public class ManufacturesProducts
    {
            public int ProductId { get; set; }
            public Product Product { get; set; }

            public int ManufactureId { get; set; }
            public Manufacture Manufacture { get; set; }
    }
}
