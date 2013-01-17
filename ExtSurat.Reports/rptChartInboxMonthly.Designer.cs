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
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.chart1 = new Telerik.Reporting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(3D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(7.2999997138977051D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chart1});
            this.detail.Name = "detail";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(3D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // chart1
            // 
            this.chart1.BitmapResolution = 96F;
            this.chart1.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045D));
            this.chart1.Name = "chart1";
            this.chart1.PlotArea.EmptySeriesMessage.Appearance.Visible = true;
            this.chart1.PlotArea.EmptySeriesMessage.Visible = true;
            this.chart1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.5D), Telerik.Reporting.Drawing.Unit.Cm(4D));
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
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.Chart chart1;
    }
}