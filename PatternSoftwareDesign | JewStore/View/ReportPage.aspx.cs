using CrystalDecisions.CrystalReports.Engine;
using ProjectLabPSD.Datasets;
using ProjectLabPSD.Handler;
using ProjectLabPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSD.View
{
    public partial class ReportPage : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("~/Report/TransactionReport.rpt"));

                var dataset = ReportHandler.GetInstance().GetTransactionReport();
                report.SetDataSource(dataset);

                CrystalReportViewer1.ReportSource = report;
                CrystalReportViewer1.DataBind();
            }
        }
    }
}