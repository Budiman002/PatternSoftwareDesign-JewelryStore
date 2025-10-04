using ProjectLabPSD.Handler;
using ProjectLabPSD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Controller
{
    public class CartController
    {
        public static List<CartViewModel> GetCart(int userId) => CartHandler.GetCart(userId);

        public static decimal GetCartTotal(List<CartViewModel> cart) => CartHandler.GetTotal(cart);

        public static void UpdateCartItem(int userId, int jewelId, int qty) => CartHandler.UpdateItem(userId, jewelId, qty);

        public static void RemoveCartItem(int userId, int jewelId) => CartHandler.RemoveItem(userId, jewelId);

        public static void ClearCart(int userId) => CartHandler.ClearCart(userId);

        public static void Checkout(int userId, string payment) => CartHandler.Checkout(userId, payment);
    }
}