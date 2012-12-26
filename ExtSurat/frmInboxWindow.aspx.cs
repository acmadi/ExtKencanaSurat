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
        private int masukid;
        protected void Page_Load(object sender, EventArgs e)
        {            
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
                        txtNomorSurat.Text = sm.Nomorid;
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
                X.AddScript("parentAutoLoadControl.close();");
        }

        [DirectMethod]
        public void SaveData()
        {
            //ADD
            if (isAdd)
            {
                if (string.IsNullOrEmpty(txtDari.Text) || string.IsNullOrEmpty(txtJudul.Text)
                    || string.IsNullOrEmpty(txtKeterangan.Text) 
                    || string.IsNullOrEmpty(txtNomorSurat.Text) || string.IsNullOrEmpty(txtNomorSuratAsli.Text)
                    || string.IsNullOrEmpty(txtNomorSuratKencana.Text))
                    return;
                Suratmasuk sm = new Suratmasuk();
                sm.Userid = "toro";
                sm.Nomorid = "1";
                sm.Nomor = txtNomorSuratKencana.Text;
                sm.Noasal = txtNomorSuratAsli.Text;
                sm.Judul = txtJudul.Text;
                sm.Tanggal = dfTanggal.SelectedDate;
                sm.Dari = txtDari.Text;
                sm.Keterangan = txtKeterangan.Text;
                sm.Berkas = "kosong";
                sm.Lastedited = DateTime.Now;
                sm.Save();
                X.AddScript("parentAutoLoadControl.close();");
            }
            //EDIT
            else
            {
                if (string.IsNullOrEmpty(txtDari.Text) || string.IsNullOrEmpty(txtJudul.Text)
                    || string.IsNullOrEmpty(txtKeterangan.Text) || string.IsNullOrEmpty(txtMasukId.Text)
                    || string.IsNullOrEmpty(txtNomorSurat.Text) || string.IsNullOrEmpty(txtNomorSuratAsli.Text)
                    || string.IsNullOrEmpty(txtNomorSuratKencana.Text))
                    return;
                Suratmasuk sm = new Suratmasuk();
                if (sm.LoadByPrimaryKey(masukid))
                {
                    sm.Userid = "toro";
                    sm.Nomorid = txtNomorSurat.Text;
                    sm.Nomor = txtNomorSuratKencana.Text;
                    sm.Noasal = txtNomorSuratAsli.Text;
                    sm.Judul = txtJudul.Text;
                    sm.Tanggal = dfTanggal.SelectedDate;
                    sm.Dari = txtDari.Text;
                    sm.Keterangan = txtKeterangan.Text;
                    sm.Berkas = "kosong";
                    sm.Lastedited = DateTime.Now;
                    sm.Save();
                    X.AddScript("parentAutoLoadControl.close();");
                }
            }
        }

        [DirectMethod]
        public void Cancel()
        {
            X.AddScript("parentAutoLoadControl.close();");
        }
    }
}