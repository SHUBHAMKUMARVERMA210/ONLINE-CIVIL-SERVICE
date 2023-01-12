using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Web.SessionState;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Reporting;
using CrystalDecisions.Shared;

public partial class PRINT_CANCELLED_TRANSACTION : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-O2QMQG8\\SQLEXPRESS;Initial Catalog=MEGAPROJECT;Integrated Security=True");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PRINT_CANCELLED_TRANSACT", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ReportDocument rpt = new ReportDocument();
        rpt.Load(MapPath("~/REPORT/CANCEL_TRANSACTION_RPT.rpt"));
        rpt.SetDataSource(ds.Tables["Table"]);
        CrystalReportViewer1.ReportSource = rpt;
        rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CANCELLED LOG");     
    }
}