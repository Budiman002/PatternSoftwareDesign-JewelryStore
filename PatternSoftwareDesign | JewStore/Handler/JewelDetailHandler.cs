using ProjectLabPSD.Models;
using ProjectLabPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Handler
{
    public class JewelDetailHandler
    {
        public static MsJewel GetJewelById(int id)
        {
            return JewelDetailRepository.GetJewelById(id);
        }

        public static string AddToCart(int userId, int jewelId)
        {
            return JewelDetailRepository.AddToCart(userId, jewelId);
        }

        public static string DeleteJewel(int id)
        {
            return JewelDetailRepository.DeleteJewel(id);
        }
    }
}