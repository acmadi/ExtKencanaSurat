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
    public partial class frmInboxWindow : System.Web.UI.Page
    {
        private bool isAdd = false;
        private int masukid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                //load datasource for combo box
                this.storeFormatSurat.DataSource = GetDataFormatSurat();
                this.storeFormatSurat.DataBind(); 

                if (Request.QueryString["masukid"] != null)
                {
                    if (Request.QueryString["isadd"] != null)
                    {
                        if (Request.QueryString["isadd"].ToString() == "0")
                            isAdd = false;
                        else
                            isAdd = true;
                    }
                    string masukIds = Request.QueryString["masukid"].ToString().Trim();
                    if (!int.TryParse(masukIds, out masukid))
                        masukid = 0;
                    Suratmasuk sm = new Suratmasuk();
                    if (sm.LoadByPrimaryKey(masukid))
                    {
                        if (!isAdd)
                        {
                            txtMasukId.Text = sm.Masukid.ToString();
                            //txtNomorSurat.Text = sm.Nomorid;
                            txtNomorSuratKencana.Text = sm.Nomor;
                            txtNomorSuratAsli.Text = sm.Noasal;
                            txtJudul.Text = sm.Judul;
                            txtDari.Text = sm.Dari;
                            txtKeterangan.Text = sm.Keterangan;
                            dfTanggal.Value = (DateTime)sm.Tanggal;
                            frmPanelMain.Title = "Edit Surat Nomor : " + sm.Nomor;
                        }
                    }
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
            n.Where(n.Jenis == "suratmasuk");
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
            //string nomorid = txtNomorSurat.Text;
            string penomoransurat = cmbFormatPenomoran.SelectedItem.Value.Trim();
            string nomor = txtNomorSuratKencana.Text;
            string noasal = txtNomorSuratAsli.Text;
            string nomorsurat = string.Empty;
            //generate number
            SuratAutonumber sa = new SuratAutonumber();
            nomorsurat = sa.GenNumber(penomoransurat, dfTanggal.SelectedDate.Month, dfTanggal.SelectedDate.Year, 0);
            //ADD
            //if (isAdd)
            //{
                //if (string.IsNullOrEmpty(txtDari.Text) || string.IsNullOrEmpty(txtJudul.Text)
                //    || string.IsNullOrEmpty(txtKeterangan.Text) 
                //    || string.IsNullOrEmpty(cmbFormatPenomoran.SelectedItem.Value) || string.IsNullOrEmpty(txtNomorSuratAsli.Text)
                //    || string.IsNullOrEmpty(txtNomorSuratKencana.Text))
                //    return;
            Suratmasuk sm = new Suratmasuk();
            sm.Userid = HttpContext.Current.Session["user"].ToString().Trim();
            sm.Nomorid = penomoransurat;
            sm.Nomor = nomorsurat;
            sm.Noasal = txtNomorSuratAsli.Text;
            sm.Judul = txtJudul.Text;
            sm.Tanggal = dfTanggal.SelectedDate;
            sm.Dari = txtDari.Text;
            sm.Keterangan = txtKeterangan.Text;
            sm.Berkas = "kosong";
            sm.Lastedited = DateTime.Now;
            sm.Save();
            HttpContext.Current.Session["isEditInbox"] = true;

            if (chkCreateDisposition.Checked)
            {
                HttpContext.Current.Session["isAddDisposition"] = true;
                HttpContext.Current.Session["isEditInbox"] = false;
                HttpContext.Current.Session["nomorsurat"] = nomorsurat;
            }
            else
                HttpContext.Current.Session["isAddDisposition"] = false;
            //}
            //EDIT
            //else
            //{
            //    if (string.IsNullOrEmpty(txtDari.Text) || string.IsNullOrEmpty(txtJudul.Text)
            //        || string.IsNullOrEmpty(txtKeterangan.Text) || string.IsNullOrEmpty(txtMasukId.Text)
            //        || string.IsNullOrEmpty(txtNomorSurat.Text) || string.IsNullOrEmpty(txtNomorSuratAsli.Text)
            //        || string.IsNullOrEmpty(txtNomorSuratKencana.Text))
            //        return;
            //    Suratmasuk sm = new Suratmasuk();
            //    if (sm.LoadByPrimaryKey(masukid))
            //    {
            //        try
            //        {
            //            sm.Userid = "toro";
            //            sm.Nomorid = nomorid;
            //            sm.Nomor = nomor;
            //            sm.Noasal = noasal;
            //            sm.Judul = txtJudul.Text;
            //            sm.Tanggal = dfTanggal.SelectedDate;
            //            sm.Dari = txtDari.Text;
            //            sm.Keterangan = txtKeterangan.Text;
            //            sm.Berkas = "kosong";
            //            sm.Lastedited = DateTime.Now;
            //            sm.Save();
            //            HttpContext.Current.Session["isEditInbox"] = true;
            //        }
            //        catch (Exception ex)
            //        {
            //            frmPanelMain.Title = ex.Message;
            //        }
            //    }
            //}
            X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
        }

        [DirectMethod]
        public void Cancel()
        {
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
            txtNomorSuratKencana.Text = sa.GenPredictedNumber(numberingId, month, year, 0);
        }
    }
}