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
        public void EditSurat(string commandName, string masukid )
        {
            taskManager1.StartAll();
            HttpContext.Current.Session["isEditInbox"] = false;
            int masukId = 0;
            HttpContext.Current.Session["isEditInbox"] = false;
            HttpContext.Current.Session["isAddDisposition"] = false;
            if (!int.TryParse(masukid.Trim(), out masukId))
                masukId = 0;
            Suratmasuk sm = new Suratmasuk();
            //EDIT
            if (sm.LoadByPrimaryKey(masukId) && commandName.Trim() == "Edit")
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

                win.AutoLoad.Url = "~/frmInboxWindowEdit.aspx?masukid=" + masukId.ToString().Trim() + "&isadd=0";
                win.AutoLoad.Mode = LoadMode.IFrame;
                win.AutoLoad.ShowMask = true;
                win.Render(this.Form);
                win.Show();
            }
            //ADD new surat
            if (commandName.Trim() == "New")
            {
                if (masukid.Trim() != "new")
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

                    win.AutoLoad.Url = "~/frmInboxWindow.aspx?masukid=new&isadd=1";
                    win.AutoLoad.Mode = LoadMode.IFrame;
                    win.AutoLoad.ShowMask = true;
                    win.Render(this.Form);
                    win.Show();
                }
            }
            //Add new Disposition
            if (commandName.Trim() == "Disposition")
            {
                var win = new Window()
                {
                    ID = "AddDisposition",
                    Title = "Add Disposisi",
                    Width = Unit.Pixel(800),
                    Height = Unit.Pixel(600),
                    Modal = true,
                    AutoRender = false,
                    Collapsed = false,
                    Maximizable = false,
                    Hidden = true,
                    Draggable = false,
                    Resizable = false,
                    Closable = true                    
                };

                win.AutoLoad.Url = "~/frmInboxDisposisiAdd.aspx?masukid=" + masukId.ToString().Trim();
                win.AutoLoad.Mode = LoadMode.IFrame;
                win.AutoLoad.ShowMask = true;
                win.Render(this.Form);
                win.Show();
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

            if ((bool)HttpContext.Current.Session["isEditInbox"] == false && (bool)HttpContext.Current.Session["isAddDisposition"] == false)
                return;
            //Finish add new letter and no add disposition
            if ((bool)HttpContext.Current.Session["isEditInbox"] == true && (bool)HttpContext.Current.Session["isAddDisposition"] == false)
            {
                this.storeInbox.DataSource = GetInbox();
                this.storeInbox.DataBind();
                HttpContext.Current.Session["isEditInbox"] = false;
                taskManager1.StopAll();
            }
            //Finish add new letter and create new disposition
            if ((bool)HttpContext.Current.Session["isEditInbox"] == false && (bool)HttpContext.Current.Session["isAddDisposition"] == true)
            {
                var win = new Window()
                {
                    ID = "AddDisposition",
                    Title = "Add Disposisi",
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

                win.AutoLoad.Url = "~/frmInboxDisposisiAdd.aspx?nomorsurat=" + HttpContext.Current.Session["nomorsurat"].ToString().Trim();
                win.AutoLoad.Mode = LoadMode.IFrame;
                win.AutoLoad.ShowMask = true;
                win.Render(this.Form);
                win.Show();
            }
        }

        [DirectMethod]
        public void btnSearch_Click()
        {
            DateTime dtFrom = DateTime.Now;
            DateTime dtTo = DateTime.Now;
            if (dfFrom.IsEmpty)
                dtFrom = new DateTime(2000, 12, 31);
            else
                dtFrom = dfFrom.SelectedDate;
            if (dfTo.IsEmpty)
                dtTo = DateTime.Now;
            else
                dtTo = dfTo.SelectedDate;
            if (dtFrom > dtTo)
            {
                X.Msg.Alert("Error", "From Date must smaller than End Date").Show();
                return;
            }

            //SuratkeluarQuery skQ = new SuratkeluarQuery();
            SuratmasukQuery smQ = new SuratmasukQuery();
            smQ.SelectAll();
            if (dfFrom.SelectedDate == dfTo.SelectedDate)
            {
                smQ.Where(smQ.Tanggal == dfFrom.SelectedDate && smQ.Judul.Like("%" + txtJudul.Text.Trim() + "%")
                    && smQ.Keterangan.Like("%" + txtKeterangan.Text.Trim() + "%") && smQ.Nomor.Like("%" + txtNomorSurat.Text.Trim() +
                    "%") && smQ.Dari.Like("%" + txtPenerima.Text.Trim() + "%"));
            }
            else
            {
                smQ.Where(smQ.Tanggal.Between(dfFrom.SelectedDate, dfTo.SelectedDate) && smQ.Judul.Like("%" + txtJudul.Text.Trim() + "%")
                    && smQ.Keterangan.Like("%" + txtKeterangan.Text.Trim() + "%") && smQ.Nomor.Like("%" + txtNomorSurat.Text.Trim() +
                    "%") && smQ.Dari.Like("%" + txtPenerima.Text.Trim() + "%"));
            }

            DataTable dt = smQ.LoadDataTable();            
            this.storeInbox.DataSource = dt;
            this.storeInbox.DataBind();
        }
    }
}