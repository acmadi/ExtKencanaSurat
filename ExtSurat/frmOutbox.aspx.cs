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
                SuratAutonumber sa = new SuratAutonumber();
                //gpOutbox.Title = sa.GenNumber("0001/RSCM-K/M/YY",9,DateTime.Now.Year);
                //btnAddSuratKeluar.Text = sa.GenNumber("001/RSCM-K/YANMED/M/YY", 11, DateTime.Now.Year);
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
            Suratkeluar sm = new Suratkeluar();
            //EDIT 
            if (sm.LoadByPrimaryKey(masukId))
            {                
                var win = new Window()
                {
                    ID = "EditSuratWindow",
                    Title = "Edit Surat Keluar No. " + sm.Nomor,
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

                win.AutoLoad.Url = "~/frmOutboxWindowEdit.aspx?keluarid=" + masukId.ToString().Trim();
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
                        Title = "Add Surat Keluar",
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

                    win.AutoLoad.Url = "~/frmOutboxWindowAdd.aspx?keluarid=new";
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
                this.storeOutbox.DataBind();
                HttpContext.Current.Session["isEditInbox"] = false;
                taskManager1.StopAll();
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

            SuratkeluarQuery skQ = new SuratkeluarQuery();
            skQ.SelectAll();
            if (dtFrom == dtTo)
            {
                skQ.Where(skQ.Tanggal == dtFrom && skQ.Judul.Like("%" + txtJudul.Text.Trim() + "%")
                    && skQ.Keterangan.Like("%" + txtKeterangan.Text.Trim() + "%") && skQ.Nomor.Like("%" + txtNomorSurat.Text.Trim() +
                    "%") && skQ.Kepada.Like("%" + txtPenerima.Text.Trim() + "%"));
            }
            else
            {
                skQ.Where(skQ.Tanggal.Between(dtFrom,dtTo) && skQ.Judul.Like("%" + txtJudul.Text.Trim() + "%")
                    && skQ.Keterangan.Like("%" + txtKeterangan.Text.Trim() + "%") && skQ.Nomor.Like("%" + txtNomorSurat.Text.Trim() +
                    "%") && skQ.Kepada.Like("%" + txtPenerima.Text.Trim() + "%"));
            }

            DataTable dt = skQ.LoadDataTable();
            this.storeOutbox.DataSource = dt;
            this.storeOutbox.DataBind();            
        }
    }
}