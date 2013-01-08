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
        protected void Page_Load(object sender, EventArgs e)
        {

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
            d.Agendanomor = "1";
            d.Nomorsurat = txtSuratNo.Text;
            d.Nomorsurat = "1";
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
            d.Catatan = txtCatatan.Html;
            d.Save();

        }
    }
}