using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace ExtSurat
{
    public partial class frmReportSurat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void btnSearch_Click()
        {
            string fromDate;
            string fromMonth;
            string fromYear;
            string toDate;
            string toMonth;
            string toYear;
            if (dfTo.IsEmpty)
                return;
            if (dfFrom.IsEmpty)
            {
                fromDate = "1";
                fromMonth = "1";
                fromYear = "1990";
            }
            else
            {
                fromDate = dfFrom.SelectedDate.Day.ToString().Trim();
                fromMonth = dfFrom.SelectedDate.Month.ToString().Trim();
                fromYear = dfFrom.SelectedDate.Year.ToString().Trim();
            }
            toDate = dfTo.SelectedDate.Day.ToString().Trim();
            toMonth = dfTo.SelectedDate.Month.ToString().Trim();
            toYear = dfTo.SelectedDate.Year.ToString().Trim();
            var win = new Window()
            {
                ID = "wdwSuratMasuk",
                Title = "Laporan Surat Masuk",
                Width = Unit.Pixel(800),
                Height = Unit.Pixel(600),
                Modal = true,
                AutoRender = false,
                Collapsed = false,
                Maximizable = false, 
                Maximized = true,
                Hidden = true,
                Draggable = false,
                Resizable = false,
                Closable = true
            };

            win.AutoLoad.Url = "~/frmReportSuratMasuk.aspx?fromDay=" + fromDate + "&fromMonth=" +fromMonth+"&fromYear="+fromYear+"&toDay="+toDate+"&toMonth="+toMonth+"&toYear="+toYear;
            win.AutoLoad.Mode = LoadMode.IFrame;
            win.AutoLoad.ShowMask = true;
            win.Render(this.Form);
            win.Show();
        }
    }
}