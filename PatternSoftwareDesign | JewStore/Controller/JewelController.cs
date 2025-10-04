using ProjectLabPSD.Handler;
using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Controller
{
    public class JewelController
    {
        public static List<MsCategory> GetAllCategories()
        {
            return JewelHandler.GetAllCategories();
        }

        public static List<MsBrand> GetAllBrands()
        {
            return JewelHandler.GetAllBrands();
        }

        public static string AddJewel(string name, int categoryId, int brandId, int price, int year)
        {
            return JewelHandler.ValidateAndAddJewel(name, categoryId, brandId, price, year);
        }

        public static MsJewel GetJewelById(int id)
        {
            return JewelHandler.GetJewelById(id);
        }

        public static string UpdateJewel(int id, string name, int categoryId, int brandId, int price, int year)
        {
            return JewelHandler.ValidateAndUpdateJewel(id, name, categoryId, brandId, price, year);
        }

    }
}