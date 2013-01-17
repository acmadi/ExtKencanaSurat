namespace ExtSurat.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using ExtSurat.BusinessObjects;
    using Ext.Net;
    using Telerik.Reporting.Charting;

    /// <summary>
    /// Summary description for rptChartInboxMonthly.
    /// </summary>
    public partial class rptChartInboxMonthly : Telerik.Reporting.Report
    {
        public rptChartInboxMonthly()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void rptChartInboxMonthly_NeedDataSource(object sender, EventArgs e)
        {
            //Get Month and Year of all surat masuk
            //SuratkeluarQuery skq = new SuratkeluarQuery();
            //skq.Select(skq.Tanggal);
            //skq.es.Distinct = true;
            SuratkeluarQuery skQ = new SuratkeluarQuery("a");
            NomorQuery nQ = new NomorQuery("b");
            skQ.Select(nQ.Keterangan,skQ.Nomorid, skQ.Nomor.Count().As("jumlahsurat"));
            skQ.InnerJoin(nQ).On(skQ.Nomorid == nQ.Format);
            skQ.GroupBy(skQ.Nomorid);
            SuratkeluarCollection skC = new SuratkeluarCollection();
            skC.Load(skQ);
            if (skC.Count > 0)
            {
                foreach (Suratkeluar sk in skC)
                {
                    try
                    {
                        string jumlahSurat = sk.GetColumn("jumlahsurat").ToString();
                        //string Keterangan = sk.GetColumn(NomorMetadata.ColumnNames.Keterangan).ToString();
                        double JumlahSurat = 0;
                        if (!double.TryParse(jumlahSurat, out JumlahSurat))
                            JumlahSurat = 0;

                        ChartSeries cs = new ChartSeries();
                        cs.Name = "Surat Keluar";
                        cs.Type = ChartSeriesType.Bar;
                        cs.AddItem(JumlahSurat, sk.Nomorid);
                        this.chartSuratMasuk.Series.Add(cs);
                    }
                    catch (Exception ex)
                    { Ext.Net.X.Msg.Alert("error",ex.Message).Show(); }
                }
            }
        }
    }
}