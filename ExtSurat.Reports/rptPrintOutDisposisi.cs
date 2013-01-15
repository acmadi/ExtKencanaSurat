namespace ExtSurat.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using ExtSurat.BusinessObjects;

    /// <summary>
    /// Summary description for rptPrintOutDisposisi.
    /// </summary>
    public partial class rptPrintOutDisposisi : Telerik.Reporting.Report
    {
        public rptPrintOutDisposisi()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void rptPrintOutDisposisi_NeedDataSource(object sender, EventArgs e)
        {
            
        }
    }
}