using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockControl.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int quanitiy { get; set; }
        public float price { get; set; }
        public int userId { get; set; }
    }
}
