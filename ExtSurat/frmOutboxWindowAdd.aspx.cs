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
    public partial class frmOutboxWindowAdd : System.Web.UI.Page
    {
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
                    X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
            }
        }
    }
}