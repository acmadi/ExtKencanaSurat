﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtSurat.BusinessObjects;

namespace ExtSurat
{
    public partial class frmOutboxWindowAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                
            }
        }

        [DirectMethod]
        public void SaveData()
        {
            string keluarid = txtKeluarId.Text;
            string penomoransurat = txtPenomoranSurat.Text;
            string nomorsurat = txtNomorSuratKencana.Text;
            //ADD
            //if (isAdd)
            //{
            if (string.IsNullOrEmpty(txtPenomoranSurat.Text) || string.IsNullOrEmpty(txtNomorSuratKencana.Text)
                || string.IsNullOrEmpty(txtKepada.Text)
                || string.IsNullOrEmpty(txtJudul.Text) || string.IsNullOrEmpty(txtKeterangan.Text))                
                return;
            if (dfTanggal.SelectedDate == null)
                return;
            if (string.IsNullOrEmpty(dfTanggal.SelectedDate.ToShortDateString().Trim()))
                return;
            Suratkeluar sk = new Suratkeluar();
            //Suratmasuk sm = new Suratmasuk();
            sk.Userid = "toro";
            sk.Nomorid = "1";
            sk.Kepada = txtKepada.Text;
            sk.Nomor = txtNomorSuratKencana.Text;
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
    }
}