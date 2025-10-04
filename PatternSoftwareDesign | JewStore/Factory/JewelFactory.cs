using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Factory
{
    public class JewelFactory
    {
        public static MsJewel CreateJewel(string name, int brandId, int categoryId, int price, int releaseYear)
        {
            return new MsJewel
            {
                JewelName = name,
                BrandID = brandId,
                CategoryID = categoryId,
                JewelPrice = price,
                JewelReleaseYear = releaseYear
            };
        }
    }
}