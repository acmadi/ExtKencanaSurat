using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Ext.Net;
using ExtSurat.BusinessObjects;

namespace ExtSurat
{
    public partial class frmInbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.storeInbox.DataSource = GetInbox();
                this.storeInbox.DataBind();
            }            
        }

        public DataTable GetInbox()
        {
            DataTable dt = new DataTable();
            SuratmasukQuery smQ = new SuratmasukQuery();
            smQ.SelectAll();
            dt = smQ.LoadDataTable();
            return dt;
        }

        [DirectMethod]
        public void storeInbox_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeInbox.DataSource = this.GetInbox();
            this.storeInbox.DataBind();
        }

        [DirectMethod]
        public void btnAddSurat()
        {
 
        }

        [DirectMethod]
        public void EditSurat(string masukid)
        {
            int masukId = 0;
            HttpContext.Current.Session["isEditInbox"] = false;
            if (!int.TryParse(masukid.Trim(), out masukId))
                masukId = 0;
            Suratmasuk sm = new Suratmasuk();
            if (sm.LoadByPrimaryKey(masukId))
            {
                var win = new Window()
                {
                    ID = "EditSuratWindow",
                    Title = "Edit Surat Masuk No. " + sm.Nomor,
                    Width = Unit.Pixel(800),
                    Height = Unit.Pixel(600),
                    Modal = true,
                    AutoRender = false,
                    Collapsed = false,
                    Maximizable = false,
                    Hidden = true,
                    Draggable = false,
                    Resizable = false
                };

                win.AutoLoad.Url = "~/frmInboxWindow.aspx";
                win.Render(this.Form);
                win.Show();
            }
            else
                return;
        }

        [DirectMethod]
        public void Refresh_Grid()
        {
            if (HttpContext.Current.Session["isEditInbox"] == null)
            {
                taskManager1.StopAll();
                return;
            }

            if ((bool)HttpContext.Current.Session["isEditInbox"] == false)
                return;
            else
            {
                this.storeInbox.DataSource = GetInbox();
                this.storeInbox.DataBind();
                HttpContext.Current.Session["isEditInbox"] = false;
                taskManager1.StopAll();
            }
        }
    }
}