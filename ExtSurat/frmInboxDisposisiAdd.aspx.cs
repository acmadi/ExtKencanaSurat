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
    public partial class frmInboxDisposisiAdd : System.Web.UI.Page
    {
        private string nomorsurat = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!X.IsAjaxRequest)
            {
                if (Request.QueryString["nomorsurat"] != null)
                    nomorsurat = Request.QueryString["nomorsurat"].ToString().Trim();
                HttpContext.Current.Session["isEditInbox"] = false;
                HttpContext.Current.Session["isAddDisposition"] = false;
                this.txtSuratNo.Text = nomorsurat;
            }
        }

        [DirectMethod]
        public void btnSave_Click()
        {
            string catatan = "";
            foreach (string s in txtCatatan.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                catatan = catatan + " " + s;
            }
            Disposisi d = new Disposisi();
            d.Agendanomor = txtAgendaNo.Text;            
            d.Nomorsurat = txtSuratNo.Text;            
            d.Tanggal = dfTanggal.SelectedDate;
            if (rdoBiasa.Checked)
                d.Sifatsuratid = 1;
            if (rdoPenting.Checked)
                d.Sifatsuratid = 3;
            if (rdoRahasia.Checked)
                d.Sifatsuratid = 4;
            if (rdoSegera.Checked)
                d.Sifatsuratid = 2;
            d.Asalsurat = txtAsalSurat.Text;
            d.Diteruskanke = txtDiteruskanKe.Text;
            d.Catatan = txtHtmlCatatan.Html;
            d.Save();
            HttpContext.Current.Session["isEditInbox"] = true;
            HttpContext.Current.Session["isAddDisposition"] = false;
            X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
        }
    }
}