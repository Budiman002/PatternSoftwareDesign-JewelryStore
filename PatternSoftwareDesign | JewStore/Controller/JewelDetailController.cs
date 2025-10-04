using ProjectLabPSD.Handler;
using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Controller
{
    public class JewelDetailController
    {
        public static MsJewel GetJewelById(int id)
        {
            return JewelDetailHandler.GetJewelById(id);
        }

        public static string AddToCart(int userId, int jewelId)
        {
            return JewelDetailHandler.AddToCart(userId, jewelId);
        }

        public static string DeleteJewel(int jewelId)
        {
            return JewelDetailHandler.DeleteJewel(jewelId);
        }
    }
}