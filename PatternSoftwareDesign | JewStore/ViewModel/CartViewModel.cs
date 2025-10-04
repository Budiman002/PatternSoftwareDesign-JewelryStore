using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.ViewModel
{
    public class CartViewModel
    {
        public int JewelID { get; set; }
        public string JewelName { get; set; }
        public string BrandName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Subtotal { get; set; }
    }
}