using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using ExtSurat.BusinessObjects;

namespace ExtSurat
{
    public partial class frmOutbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.storeOutbox.DataSource = GetOutbox();
                this.storeOutbox.DataBind();
            }
        }

        public DataTable GetOutbox()
        {
            DataTable dt = new DataTable();
            SuratkeluarQuery smQ = new SuratkeluarQuery();
            smQ.SelectAll();
            dt = smQ.LoadDataTable();
            return dt;
        }

        [DirectMethod]
        public void storeOutbox_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeOutbox.DataSource = GetOutbox();
            this.storeOutbox.DataBind();
        }

        [DirectMethod]
        public void EditSurat(string keluarid)
        {
            taskManager1.StartAll();
            HttpContext.Current.Session["isEditInbox"] = false;
            int masukId = 0;
            HttpContext.Current.Session["isEditInbox"] = false;
            if (!int.TryParse(keluarid.Trim(), out masukId))
                masukId = 0;
            Suratmasuk sm = new Suratmasuk();
            //EDIT
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
                    Resizable = false,
                    Closable = false
                };

                win.AutoLoad.Url = "~/frmOutboxWindowEdit.aspx?masukid=" + masukId.ToString().Trim();
                win.AutoLoad.Mode = LoadMode.IFrame;
                win.AutoLoad.ShowMask = true;
                win.Render(this.Form);
                win.Show();
            }
            //ADD
            else
            {
                if (keluarid.Trim() != "new")
                    return;
                else
                {
                    var win = new Window()
                    {
                        ID = "EditSuratWindow",
                        Title = "Add Surat Masuk",
                        Width = Unit.Pixel(800),
                        Height = Unit.Pixel(600),
                        Modal = true,
                        AutoRender = false,
                        Collapsed = false,
                        Maximizable = false,
                        Hidden = true,
                        Draggable = false,
                        Resizable = false,
                        Closable = false
                    };

                    win.AutoLoad.Url = "~/frmOutboxWindowAdd.aspx";
                    win.AutoLoad.Mode = LoadMode.IFrame;
                    win.AutoLoad.ShowMask = true;
                    win.Render(this.Form);
                    win.Show();
                }
            }
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
                this.storeOutbox.DataSource = GetOutbox();
                this.storeOutbox.DataBind();
                HttpContext.Current.Session["isEditInbox"] = false;
                taskManager1.StopAll();
            }
        }
    }
}