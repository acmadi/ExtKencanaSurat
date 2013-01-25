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
    public partial class frmOutboxWindowAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                if (Request.QueryString.Count == 0)
                    Response.Redirect("Default.aspx");
                //load datasource for combo box
                this.storeFormatSurat.DataSource = GetDataFormatSurat();
                this.storeFormatSurat.DataBind();     
            }
        }

        [DirectMethod]
        public DataTable GetDataFormatSurat()
        {
            NomorQuery n = new NomorQuery("a");
            n.Select(n.Format, n.Keterangan);
            n.Where(n.Jenis == "suratkeluar");
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
            string keluarid = txtKeluarId.Text;
            string penomoransurat = cmbFormatPenomoran.SelectedItem.Value.Trim();
            string nomorsurat = txtNomorSuratKencana.Text;
            //generate number
            SuratAutonumber sa = new SuratAutonumber();
            nomorsurat = sa.GenNumber(penomoransurat, dfTanggal.SelectedDate.Month, dfTanggal.SelectedDate.Year,1);
            //ADD
            //if (isAdd)
            //{
            if (string.IsNullOrEmpty(cmbFormatPenomoran.SelectedItem.Value) || string.IsNullOrEmpty(txtNomorSuratKencana.Text)
                || string.IsNullOrEmpty(txtKepada.Text)
                || string.IsNullOrEmpty(txtJudul.Text) || string.IsNullOrEmpty(txtKeterangan.Text))                
                return;
            if (dfTanggal.SelectedDate == null)
                return;
            if (string.IsNullOrEmpty(dfTanggal.SelectedDate.ToShortDateString().Trim()))
                return;
            Suratkeluar sk = new Suratkeluar();
            //Suratmasuk sm = new Suratmasuk();
            sk.Userid = HttpContext.Current.Session["user"].ToString().Trim();
            sk.Nomorid = penomoransurat;
            sk.Kepada = txtKepada.Text;
            sk.Nomor = nomorsurat;
            sk.Judul = txtJudul.Text;
            sk.Tanggal = dfTanggal.SelectedDate;
            sk.Berkas = "path";
            sk.Keterangan = txtKeterangan.Text;
            sk.Lastedited = DateTime.Now;
            sk.Save();
            //sm.Userid = "toro";
            //sm.Nomorid = "1";
            //sm.Nomor = txtNomorSuratKencana.Text;
            //sm.Noasal = txtNomorSuratAsli.Text;
            //sm.Judul = txtJudul.Text;
            //sm.Tanggal = dfTanggal.SelectedDate;
            //sm.Dari = txtDari.Text;
            //sm.Keterangan = txtKeterangan.Text;
            //sm.Berkas = "kosong";
            //sm.Lastedited = DateTime.Now;
            //sm.Save();
            HttpContext.Current.Session["isEditInbox"] = true;            
            X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
        }

        [DirectMethod]
        public void dfTanggal_Select()
        {
            if (cmbFormatPenomoran.IsEmpty)
                return;
            int year = dfTanggal.SelectedDate.Year;
            int month = dfTanggal.SelectedDate.Month;
            string numberingId = cmbFormatPenomoran.SelectedItem.Value.Trim();
            SuratAutonumber sa = new SuratAutonumber();
            txtNomorSuratKencana.Text = sa.GenPredictedNumber(numberingId, month, year, 1);
        }
    }
}