namespace ExtSurat.Reports
{
    partial class rptChartInboxMonthly
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.chartSuratMasuk = new Telerik.Reporting.Chart();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(7.2999997138977051D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chartSuratMasuk});
            this.detail.Name = "detail";
            // 
            // chartSuratMasuk
            // 
            this.chartSuratMasuk.BitmapResolution = 96F;
            this.chartSuratMasuk.ChartTitle.TextBlock.Text = "Jumlah Surat Masuk per Bagian";
            this.chartSuratMasuk.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chartSuratMasuk.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010002215276472271D), Telerik.Reporting.Drawing.Unit.Cm(0.00010002215276472271D));
            this.chartSuratMasuk.Name = "chartSuratMasuk";
            this.chartSuratMasuk.PlotArea.EmptySeriesMessage.Appearance.Visible = true;
            this.chartSuratMasuk.PlotArea.EmptySeriesMessage.Visible = true;
            this.chartSuratMasuk.PlotArea.XAxis.MinValue = 1D;
            this.chartSuratMasuk.PlotArea.YAxis.MaxValue = 100D;
            this.chartSuratMasuk.PlotArea.YAxis.Step = 10D;
            this.chartSuratMasuk.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.999799728393555D), Telerik.Reporting.Drawing.Unit.Cm(7.299799919128418D));
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // rptChartInboxMonthly
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "rptChartInboxMonthly";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15D);
            this.NeedDataSource += new System.EventHandler(this.rptChartInboxMonthly_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.Chart chartSuratMasuk;
    }
}