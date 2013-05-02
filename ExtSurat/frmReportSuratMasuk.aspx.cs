using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtSurat.BusinessObjects;
using ExtSurat.Reports;

namespace ExtSurat
{
    public partial class frmReportSuratMasuk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int fromDate = 0;
            int fromMonth = 0;
            int fromYear = 0;
            int toDate = 0;
            int toMonth = 0;
            int toYear = 0;
            DateTime fromDateQuery = new DateTime();
            DateTime toDateQuery = new DateTime();
            if (!X.IsAjaxRequest)
            {
                if (Request.QueryString.Count == 0)
                    Response.Redirect("Default.aspx");
                if (Request.QueryString["fromDay"] != null)
                    fromDate = Convert.ToInt32(Request.QueryString["fromDay"].ToString());
                if (Request.QueryString["fromMonth"] != null)
                    fromMonth = Convert.ToInt32(Request.QueryString["fromMonth"].ToString());
                if (Request.QueryString["fromYear"] != null)
                    fromYear = Convert.ToInt32(Request.QueryString["fromYear"].ToString());
                if (Request.QueryString["toDay"] != null)
                    toDate = Convert.ToInt32(Request.QueryString["toDay"].ToString());
                if (Request.QueryString["toMonth"] != null)
                    toMonth = Convert.ToInt32(Request.QueryString["toMonth"].ToString());
                if (Request.QueryString["toYear"] != null)
                    toYear = Convert.ToInt32(Request.QueryString["toYear"].ToString());
                fromDateQuery = new DateTime(fromYear, fromMonth, fromDate);
                toDateQuery = new DateTime(toYear, toMonth, toDate);

                SuratmasukQuery smQ = new SuratmasukQuery("a");
                smQ.Select(smQ.Nomor, smQ.Judul, smQ.Tanggal, smQ.Dari.As("Sender_Receiver"), smQ.Keterangan);
                smQ.Where(smQ.Tanggal.Between(fromDateQuery, toDateQuery));
                smQ.OrderBy(smQ.Tanggal.Ascending, smQ.Nomor.Ascending);
                SuratmasukCollection smC = new SuratmasukCollection();
                smC.Load(smQ);
                if (smC.Count > 0)
                {
                    rptInboxOutbox rptInOut = new rptInboxOutbox();
                    rptInOut.DataSource = smC;
                    Telerik.Reporting.InstanceReportSource inst = new Telerik.Reporting.InstanceReportSource();
                    inst.ReportDocument = rptInOut;
                    this.ReportViewer1.ReportSource = inst;
                    this.ReportViewer1.RefreshReport();
                    this.ReportViewer1.Update();
                }
                else
                    X.Msg.Alert("Error", "No Data").Show();
            }
        }
    }
}