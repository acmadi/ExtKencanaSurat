using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtSurat.BusinessObjects;

namespace ExtSurat
{
    public partial class frmInboxWindowEdit : System.Web.UI.Page
    {
        private bool isAdd = false;
        private string masukIds = "";
        private int masukid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
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
                    masukIds = Request.QueryString["masukid"].ToString().Trim();
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
                    else
                        X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
                }
                else
                    X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
            }
        }

        [DirectMethod]
        public void SaveData()
        {
            masukIds = txtMasukId.Text.Trim();
            if (!int.TryParse(masukIds, out masukid))
                masukid = 0;
            string nomorid = txtNomorSurat.Text;
            string nomor = txtNomorSuratKencana.Text;
            string noasal = txtNomorSuratAsli.Text;
            
            //EDIT            
                if (string.IsNullOrEmpty(txtDari.Text) || string.IsNullOrEmpty(txtJudul.Text)
                    || string.IsNullOrEmpty(txtKeterangan.Text) || string.IsNullOrEmpty(txtMasukId.Text)
                    || string.IsNullOrEmpty(txtNomorSurat.Text) || string.IsNullOrEmpty(txtNomorSuratAsli.Text)
                    || string.IsNullOrEmpty(txtNomorSuratKencana.Text))
                    return;
                Suratmasuk smt = new Suratmasuk();
                if (smt.LoadByPrimaryKey(masukid))
                {
                    try
                    {
                        smt.Userid = HttpContext.Current.Session["user"].ToString().Trim();
                        smt.Nomorid = nomorid;
                        smt.Nomor = nomor;
                        smt.Noasal = noasal;
                        string jud = txtJudul.Text;
                        smt.Judul = txtJudul.Text;
                        smt.Tanggal = dfTanggal.SelectedDate;
                        smt.Dari = txtDari.Text;
                        smt.Keterangan = txtKeterangan.Text;
                        smt.Berkas = "kosong";
                        smt.Lastedited = DateTime.Now;
                        smt.Save();
                        HttpContext.Current.Session["isEditInbox"] = true;
                    }
                    catch (Exception ex)
                    {
                        frmPanelMain.Title = ex.Message;
                    }
                }
            X.Js.AddScript("parentAutoLoadControl.close(); Delay='2' ");
            //X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
        }

        [DirectMethod]
        public void Cancel()
        {
            X.AddScript("parentAutoLoadControl.close(); Delay='2' ");            
        }
    }
}