using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Repository
{
    public class TransactionRepository
    {
        static DatabaseJawelEntities db = Singleton.GetDatabase();

        public static List<TransactionHeader> GetTransactionsByStatus(List<string> statuses)
        {
            return db.TransactionHeaders.Where(th => statuses.Contains(th.TransactionStatus)).ToList();
        }

        public static TransactionHeader GetTransactionById(int id)
        {
            return db.TransactionHeaders.FirstOrDefault(th => th.TransactionID == id);
        }

        public static void UpdateTransaction(TransactionHeader trx)
        {
            db.SaveChanges();
        }

        public static void CreateTransaction(TransactionHeader header, List<Cart> cart)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();

            foreach (var item in cart)
            {
                db.TransactionDetails.Add(new TransactionDetail
                {
                    TransactionID = header.TransactionID,
                    JewelID = item.JewelID,
                    Quantity = item.Quantity
                });
            }
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetTransactionsByUser(int userId)
        {
            return db.TransactionHeaders
                     .Where(t => t.UserID == userId)
                     .OrderByDescending(t => t.TransactionDate)
                     .ToList();
        }

        public static List<TransactionDetail> GetTransactionDetails(int trxId)
        {
            return db.TransactionDetails
                     .Where(d => d.TransactionID == trxId)
                     .ToList();
        }

        public List<dynamic> GetDoneTransactions()
        {
            var query = from th in db.TransactionHeaders
                        where th.TransactionStatus == "Done"
                        join td in db.TransactionDetails on th.TransactionID equals td.TransactionID
                        join j in db.MsJewels on td.JewelID equals j.JewelID
                        join u in db.MsUsers on th.UserID equals u.UserID
                        select new
                        {
                            th.TransactionID,
                            u.UserName,
                            th.PaymentMethod,
                            th.TransactionDate,
                            j.JewelName,
                            td.Quantity,
                            j.JewelPrice,
                            SubTotal = td.Quantity * j.JewelPrice,
                            th.TransactionStatus
                        };

            return query.ToList<dynamic>();
        }
    }
}