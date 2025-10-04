using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Repository
{
    public class CartRepository
    {
        private static DatabaseJawelEntities db = Singleton.GetDatabase();

        public static List<Cart> GetCart(int userId)
        {
            return db.Carts
                .Where(c => c.UserID == userId)
                .ToList();
        }

        public static void AddOrUpdateCart(int userId, int jewelId, int quantity)
        {
            var existing = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);

            if (existing != null)
            {
                existing.Quantity += quantity; 
            }
            else
            {
                Cart newCart = new Cart
                {
                    UserID = userId,
                    JewelID = jewelId,
                    Quantity = quantity
                };
                db.Carts.Add(newCart);
            }

            db.SaveChanges();
        }


        public static void UpdateQuantity(int userId, int jewelId, int newQty)
        {
            var item = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (item != null)
            {
                item.Quantity = newQty;
                db.SaveChanges();
            }
        }


        public static void DeleteItem(int userId, int jewelId)
        {
            var item = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (item != null)
            {
                db.Carts.Remove(item);
                db.SaveChanges();
            }
        }

        public static void ClearCart(int userId)
        {
            var items = db.Carts.Where(c => c.UserID == userId).ToList();
            db.Carts.RemoveRange(items);
            db.SaveChanges();
        }
    }
}