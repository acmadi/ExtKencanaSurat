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
    public partial class frmReportDisposition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
            {
 
            }
        }

        [DirectMethod]
        public void btnSearch_Click()
        {
            DateTime from;
            DateTime to;
            string nomorsurat;
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
            DisposisiQuery dQ = new DisposisiQuery("a");            
            dQ.Select(dQ.Agendanomor, dQ.Tanggal,dQ.Biasa,dQ.Segera,dQ.Penting,dQ.Rahasia, dQ.Perihal, dQ.Asalsurat, dQ.Diteruskanke, dQ.Catatan);            
            if (string.IsNullOrEmpty(txtNomorSurat.Text))
                dQ.Where(dQ.Tanggal.Between(from, to));
            else
            {
                nomorsurat = txtNomorSurat.Text.Trim();
                dQ.Where(dQ.Tanggal.Between(from, to) && dQ.Nomorsurat.Like("%" + nomorsurat + "%"));
            }
            DisposisiCollection dC = new DisposisiCollection();
            dC.Load(dQ);
            if (dC.Count > 0)
            {
                rptPrintOutDisposisi rptDisposisi = new rptPrintOutDisposisi();
                rptDisposisi.DataSource = dC;
                //ReportViewer1.ReportSource = rptDisposisi;
                //ReportViewer1.RefreshReport();
                //Telerik.Reporting.Report rptDisposisi = new Telerik.Reporting.Report();
                Telerik.Reporting.InstanceReportSource inst = new Telerik.Reporting.InstanceReportSource();
                inst.ReportDocument = rptDisposisi;                
                this.ReportViewer1.ReportSource = inst;
                this.ReportViewer1.RefreshReport();
                this.ReportViewer1.Update();
            }
        }
    }
}