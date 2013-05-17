using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SimpleTools.RoleAdmin.API.Objects;
using SimpleTools.RoleAdmin.API.Collections;
using SimpleTools.RoleAdmin.API.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace ExtSurat
{
    public partial class frmReportSuratOut : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string RoleNormal = "3D903FBB57C7D8006105C8546BA88FA7";
            //string RoleAdmin = "F74954E20B90F501AE67F0D1914B4893";
            
            //string ApiKey = "0DFxXBb8GIOi6IjdytI8XHNEcjqAmfzpDADJBuRy6WW2WRlR";
            //Connection con = new Connection("http://localhost:88/RoleAdmin/Admin/api", "trogalko@gmail.com", ApiKey);
            //Tools.Connection = con;
            //Roles.Connection = con;
            //Members.Connection = con;
            //AuditEvents.Connection = con;
            //AuditEventDatails.Connection = con;
            
            //List<Role> _Role = Roles.GetMemberRoles(CurrentUserName);
            //string roles = string.Empty;
            //foreach (Role r in _Role)
            //{
            //    roles = roles + " " + r.Name;
            //}
            
            //this.Title = roles;
            
        }

        //public static string Md5Hash(string pass)
        //{
        //    MD5 md5 = MD5CryptoServiceProvider.Create();
        //    byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(pass));
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < dataMd5.Length; i++)
        //        sb.AppendFormat("{0:x2}", dataMd5[i]);
        //    return sb.ToString();
        //}

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

            win.AutoLoad.Url = "~/frmReportSuratKeluar.aspx?fromDay=" + fromDate + "&fromMonth=" + fromMonth + "&fromYear=" + fromYear + "&toDay=" + toDate + "&toMonth=" + toMonth + "&toYear=" + toYear;
            win.AutoLoad.Mode = LoadMode.IFrame;
            win.AutoLoad.ShowMask = true;
            win.Render(this.Form);
            win.Show();
        }
    }
}