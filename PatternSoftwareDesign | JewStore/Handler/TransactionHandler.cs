using ProjectLabPSD.Models;
using ProjectLabPSD.Repository;
using ProjectLabPSD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjectLabPSD.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetUnfinishedTransactions()
        {
            return TransactionRepository.GetTransactionsByStatus(new List<string> { "Payment Pending", "Shipment Pending", "Arrived" });
        }

        public static void UpdateNextStatus(int transactionId)
        {
            var trx = TransactionRepository.GetTransactionById(transactionId);
            if (trx == null) return;

            if (trx.TransactionStatus == "Payment Pending")
                trx.TransactionStatus = "Shipment Pending";
            else if (trx.TransactionStatus == "Shipment Pending")
                trx.TransactionStatus = "Arrived";

            TransactionRepository.UpdateTransaction(trx);
        }

        public static List<TransactionHeader> GetTransactionsByUser(int userId)
        {
            return TransactionRepository.GetTransactionsByUser(userId);
        }

        public static void UpdateTransactionStatus(int trxId, string newStatus)
        {
            var trx = TransactionRepository.GetTransactionById(trxId);
            if (trx != null && trx.TransactionStatus == "Arrived")
            {
                trx.TransactionStatus = newStatus;
                TransactionRepository.UpdateTransaction(trx);
            }
        }


        public static TransactionHeader GetTransactionHeader(int id)
        {
            return TransactionRepository.GetTransactionById(id);
        }

        public static List<TransactionDetailViewModel> GetTransactionDetailView(int transactionId)
        {
            var details = TransactionRepository.GetTransactionDetails(transactionId);

            return details.Select(d => new TransactionDetailViewModel
            {
                JewelName = d.MsJewel.JewelName,
                BrandName = d.MsJewel.MsBrand.BrandName,
                Price = d.MsJewel.JewelPrice,
                Quantity = d.Quantity,
                Subtotal = d.Quantity * d.MsJewel.JewelPrice
            }).ToList();
        }
    }
}