using ProjectLabPSD.Handler;
using ProjectLabPSD.Models;
using ProjectLabPSD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Controller
{
    public class TransactionController
    {
        public static List<TransactionHeader> GetUnfinishedTransactions()
        {
            return TransactionHandler.GetUnfinishedTransactions();
        }

        public static void AdvanceTransactionStatus(int transactionId)
        {
            TransactionHandler.UpdateNextStatus(transactionId);
        }


        public static List<TransactionHeader> GetUserTransactions(int userId)
        {
            return TransactionHandler.GetTransactionsByUser(userId);
        }

        public static void UpdateTransactionStatus(int trxId, string newStatus)
        {
            TransactionHandler.UpdateTransactionStatus(trxId, newStatus);
        }



        public static TransactionHeader GetTransactionHeader(int id)
        {
            return TransactionHandler.GetTransactionHeader(id);
        }

        public static List<TransactionDetailViewModel> GetTransactionDetails(int transactionId)
        {
            return TransactionHandler.GetTransactionDetailView(transactionId);
        }
    }
}