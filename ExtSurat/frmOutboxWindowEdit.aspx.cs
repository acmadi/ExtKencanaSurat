using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtSurat.BusinessObjects;
using System.Data;

namespace ExtSurat
{
    public partial class frmOutboxWindowEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                //load datasource for combo box
                this.storeFormatSurat.DataSource = GetDataFormatSurat();
                this.storeFormatSurat.DataBind();

                if (Request.QueryString["keluarid"] != null)
                {
                    HttpContext.Current.Session["keluarid"] = Request.QueryString["keluarid"].ToString().Trim();
                    string keluarIds = HttpContext.Current.Session["keluarid"].ToString().Trim();
                    int keluarid = 0;
                    if (!int.TryParse(keluarIds, out keluarid))
                        keluarid = 0;
                    Suratkeluar sk = new Suratkeluar();
                    if (sk.LoadByPrimaryKey(keluarid))
                    {
                        txtKeluarId.Text = HttpContext.Current.Session["keluarid"].ToString().Trim();
                        //txtPenomoranSurat.Text = sk.Nomorid;
                        txtNomorSuratKencana.Text = sk.Nomor;
                        txtKepada.Text = sk.Kepada;
                        txtJudul.Text = sk.Judul;
                        txtKeterangan.Text = sk.Keterangan;
                        dfTanggal.SelectedDate = (DateTime)sk.Tanggal;
                    }
                    else
                        X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
                }
                else
                    X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
            }
        }

        [DirectMethod]
        public DataTable GetDataFormatSurat()
        {
            NomorQuery n = new NomorQuery("a");
            n.Select(n.Format, n.Keterangan);
            DataTable dt = n.LoadDataTable();
            return dt;
        }

        [DirectMethod]
        public void storeFormatSurat_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeFormatSurat.DataSource = GetDataFormatSurat();
            this.storeFormatSurat.DataBind();
        }

        [DirectMethod]
        public void SaveData()
        {
            string keluarIds = HttpContext.Current.Session["keluarid"].ToString().Trim();
            int keluarid = 0;
            if (!int.TryParse(keluarIds, out keluarid))
                keluarid = 0;
            
            //EDIT            
            //if (string.IsNullOrEmpty(txtKeluarId.Text) || string.IsNullOrEmpty(txtPenomoranSurat.Text)
            //    || string.IsNullOrEmpty(txtNomorSuratKencana.Text) || string.IsNullOrEmpty(txtKepada.Text)
            //    || string.IsNullOrEmpty(txtJudul.Text) || string.IsNullOrEmpty(txtKeterangan.Text))                
            //    return;
            if (string.IsNullOrEmpty(txtKeluarId.Text)
                || string.IsNullOrEmpty(txtNomorSuratKencana.Text) || string.IsNullOrEmpty(txtKepada.Text)
                || string.IsNullOrEmpty(txtJudul.Text) || string.IsNullOrEmpty(txtKeterangan.Text))
                return;
            if (dfTanggal.SelectedDate == null)
                return;
            Suratkeluar sk = new Suratkeluar();
            if (sk.LoadByPrimaryKey(keluarid))
            {
                sk.Userid = "toro";
                //sk.Nomorid = txtPenomoranSurat.Text;
                sk.Kepada = txtKepada.Text;
                //sk.Nomor = txtNomorSuratKencana.Text;
                sk.Judul = txtJudul.Text;
                sk.Tanggal = dfTanggal.SelectedDate;
                sk.Berkas = "path";
                sk.Keterangan = txtKeterangan.Text;
                sk.Lastedited = DateTime.Now;
                sk.Save();
                HttpContext.Current.Session["isEditInbox"] = true;
                X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
            }
            else
            {
                X.Msg.Alert("error", "an error has occured");
                return;
            }            
        }
    }
}