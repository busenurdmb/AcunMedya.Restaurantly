using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedya.Restaurantly.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Descriptiion{ get; set; }
        public decimal Price { get; set; }
        public string İmageUrl { get; set; }
    }
}