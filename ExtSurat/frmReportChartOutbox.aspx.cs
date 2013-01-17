using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtSurat.Reports;
using ExtSurat.BusinessObjects;
using Telerik.Reporting.Charting;


namespace ExtSurat
{
    public partial class frmReportChartOutbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                SuratkeluarQuery skQ = new SuratkeluarQuery("a");
                NomorQuery nQ = new NomorQuery("b");
                skQ.Select(nQ.Keterangan, skQ.Nomorid, skQ.Nomor.Count().As("jumlahsurat"));
                skQ.InnerJoin(nQ).On(skQ.Nomorid == nQ.Format);
                skQ.GroupBy(skQ.Nomorid);
                SuratkeluarCollection skC = new SuratkeluarCollection();
                skC.Load(skQ);

                rptChartInboxMonthly rptChart = new rptChartInboxMonthly();
                rptChart.DataSource = skC;

                //foreach (Suratkeluar sk in skC)
                //{
                //    string jumlahSurat = sk.GetColumn("jumlahsurat").ToString();
                //    string keterangan = sk.GetColumn(NomorMetadata.ColumnNames.Keterangan, "kosong").ToString();
                //    double JumlahSurat = 0;
                //    if (!double.TryParse(jumlahSurat, out JumlahSurat))
                //        JumlahSurat = 0;

                //    ChartSeries cs = new ChartSeries();
                //    cs.Name = "Surat Keluar";
                //    cs.Type = ChartSeriesType.Bar;
                //    cs.AddItem(JumlahSurat, sk.Nomorid);
                    
                //}

                Telerik.Reporting.InstanceReportSource inst = new Telerik.Reporting.InstanceReportSource();
                inst.ReportDocument = rptChart;
                this.ReportViewer1.ReportSource = inst;
                this.ReportViewer1.RefreshReport();
                this.ReportViewer1.Update();
            }
        }
    }
}