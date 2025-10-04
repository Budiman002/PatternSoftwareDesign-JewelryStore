using ProjectLabPSD.Models;
using ProjectLabPSD.Repository;
using ProjectLabPSD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Handler
{
    public class CartHandler
    {
        public static List<CartViewModel> GetCart(int userId)
        {
            return CartRepository.GetCart(userId)
                .Select(c => new CartViewModel
                {
                    JewelID = c.JewelID,
                    JewelName = c.MsJewel.JewelName,
                    BrandName = c.MsJewel.MsBrand.BrandName,
                    Quantity = c.Quantity,
                    Price = c.MsJewel.JewelPrice,
                    Subtotal = c.Quantity * c.MsJewel.JewelPrice
                }).ToList();
        }

        public static decimal GetTotal(List<CartViewModel> cart)
        {
            return cart.Sum(i => i.Subtotal);
        }

        public static void UpdateItem(int userId, int jewelId, int qty) => CartRepository.UpdateQuantity(userId, jewelId, qty);

        public static void RemoveItem(int userId, int jewelId) => CartRepository.DeleteItem(userId, jewelId);

        public static void ClearCart(int userId) => CartRepository.ClearCart(userId);

        public static void Checkout(int userId, string payment)
        {
            var cart = CartRepository.GetCart(userId);
            if (!cart.Any()) return;

            var header = new TransactionHeader
            {
                UserID = userId,
                TransactionDate = DateTime.Now,
                PaymentMethod = payment,
                TransactionStatus = "Payment Pending"
            };

            TransactionRepository.CreateTransaction(header, cart.ToList());
            CartRepository.ClearCart(userId);
        }
    }
}