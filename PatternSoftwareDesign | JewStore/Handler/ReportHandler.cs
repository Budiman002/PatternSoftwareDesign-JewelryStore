using ProjectLabPSD.Datasets;
using ProjectLabPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Handler
{
    public class ReportHandler
    {
        private static ReportHandler _instance;

        private ReportHandler() { }

        public static ReportHandler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ReportHandler();
            }
            return _instance;
        }

        public TransactionReportDataset GetTransactionReport()
        {
            var dataset = new TransactionReportDataset();
            var transactions = new TransactionRepository().GetDoneTransactions();

            foreach (var item in transactions)
            {
                dataset.TransactionReport.AddTransactionReportRow(
                    item.TransactionID,
                    item.UserName,
                    item.PaymentMethod,
                    item.TransactionDate.ToString("yyyy-MM-dd"),
                    item.JewelName,
                    item.Quantity,
                    item.JewelPrice,
                    item.SubTotal,
                    item.TransactionStatus
                );
            }

            return dataset;
        }
    }
}