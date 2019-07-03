using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VatService.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }

    }

    
}
