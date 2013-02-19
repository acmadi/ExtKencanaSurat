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
    public partial class frmReportListLetter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string inbox = string.Empty;
            if (!X.IsAjaxRequest)
            {
                if (Request.QueryString["inbox"] != null)
                    inbox = Request.QueryString["inbox"].ToString().Trim();
                if (inbox == "0")
                {
                    this.chkInbox.Checked = false;
                    this.chkOutbox.Checked = true;
                }
                else
                {
                    this.chkInbox.Checked = true;
                    this.chkOutbox.Checked = false;
                }
            }
        }

        [DirectMethod]
        public void btnSearch_Click()
        {
            DateTime from;
            DateTime to;
            bool isInbox = false;
            bool isOutbox = false;            
            if (chkInbox.Checked)
                isInbox = true;
            if (chkOutbox.Checked)
                isOutbox = true;
            if (dfTo.IsEmpty)
            {
                X.Msg.Alert("error", "To Date must be FILLED").Show();
                return;
            }
            if (dfFrom.SelectedDate > dfTo.SelectedDate)
            {
                X.Msg.Alert("error", "From Date can not BIGGER than To Date").Show();
                return;
            }
            if (dfFrom.IsEmpty)
                from = new DateTime(1453, 12, 31);
            else
                from = dfFrom.SelectedDate;
            this.ReportViewer1.Visible = true;
            to = dfTo.SelectedDate;

            if (isInbox & !isOutbox)
            {
                SuratmasukQuery smQ = new SuratmasukQuery("a");
                smQ.Select(smQ.Nomor, smQ.Judul, smQ.Tanggal, smQ.Dari.As("Sender_Receiver"), smQ.Keterangan);
                smQ.Where(smQ.Tanggal.Between(from, to));
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
            }

            if (!isInbox & isOutbox)
            {
                SuratkeluarQuery skQ = new SuratkeluarQuery("b");
                skQ.Select(skQ.Nomor, skQ.Judul, skQ.Tanggal, skQ.Kepada.As("Sender_Receiver"), skQ.Keterangan);
                skQ.Where(skQ.Tanggal.Between(from, to));
                skQ.OrderBy(skQ.Tanggal.Ascending, skQ.Nomor.Ascending);
                SuratkeluarCollection skC = new SuratkeluarCollection();
                skC.Load(skQ);
                if (skC.Count > 0)
                {                    
                    rptInboxOutbox rptInOut = new rptInboxOutbox();
                    rptInOut.DataSource = skC;
                    Telerik.Reporting.InstanceReportSource inst = new Telerik.Reporting.InstanceReportSource();
                    inst.ReportDocument = rptInOut;
                    this.ReportViewer1.ReportSource = inst;
                    this.ReportViewer1.RefreshReport();
                    this.ReportViewer1.Update();
                }
            }

            if (isInbox & isOutbox)
            {
                SuratkeluarQuery skQ = new SuratkeluarQuery("a");
                skQ.Select(skQ.Nomor, skQ.Judul, skQ.Tanggal, skQ.Kepada.As("Sender_Receiver"), skQ.Keterangan);
                skQ.Where(skQ.Tanggal.Between(from, to));
                SuratmasukQuery smQ = new SuratmasukQuery("b");
                smQ.Select(smQ.Nomor, smQ.Judul, smQ.Tanggal, smQ.Dari.As("Sender_Receiver"), smQ.Keterangan);
                smQ.Where(smQ.Tanggal.Between(from, to));
                skQ.Union(smQ);
                skQ.OrderBy(skQ.Tanggal.Ascending, skQ.Tanggal.Ascending);
                SuratkeluarCollection skC = new SuratkeluarCollection();
                skC.Load(skQ);
                if (skC.Count > 0)
                {
                    rptInboxOutbox rptInOut = new rptInboxOutbox();
                    rptInOut.DataSource = skC;
                    Telerik.Reporting.InstanceReportSource inst = new Telerik.Reporting.InstanceReportSource();
                    inst.ReportDocument = rptInOut;
                    this.ReportViewer1.ReportSource = inst;
                    this.ReportViewer1.RefreshReport();
                    this.ReportViewer1.Update();
                }
            }
        }
    }
}