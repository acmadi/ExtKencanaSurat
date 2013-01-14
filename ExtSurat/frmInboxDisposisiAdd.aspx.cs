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
        private string masukid = string.Empty;
        private string nomorsurat = string.Empty;
        private int masukID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!X.IsAjaxRequest)
            {
                //Show disposition from main surat masuk form
                if (Request.QueryString["masukid"] != null)
                    masukid = Request.QueryString["masukid"].ToString().Trim();
                else
                {
                    //show add new disposition from after new surat masuk save process
                    if (Request.QueryString["nomorsurat"] != null)
                        nomorsurat = Request.QueryString["nomorsurat"].ToString().Trim();
                }
                HttpContext.Current.Session["isEditInbox"] = false;
                HttpContext.Current.Session["isAddDisposition"] = false;

                if (!int.TryParse(masukid, out masukID))
                    masukID = 0;
                Suratmasuk sm = new Suratmasuk();
                //This for Edit Disposition
                if (sm.LoadByPrimaryKey(masukID))
                {
                    this.txtSuratNo.Text = sm.Nomor;
                    nomorsurat = sm.Nomor;
                    DisposisiQuery dQ = new DisposisiQuery("a");
                    dQ.SelectAll();
                    dQ.Where(dQ.Nomorsurat == sm.Nomor);
                    //get total dispositions records
                    DisposisiCollection dC = new DisposisiCollection();
                    dC.Load(dQ);
                    //Disposition already exist, edit instead
                    if (dC.Count > 0)
                    {

                        foreach (Disposisi d in dC)
                        {
                            this.pnlMain.Title = "Edit Disposition for letter : " + d.Nomorsurat;
                            txtAgendaNo.Text = d.Agendanomor;
                            txtAsalSurat.Text = d.Asalsurat;
                            txtDiteruskanKe.Text = d.Diteruskanke;
                            txtHtmlCatatan.Text = d.Catatan;
                            txtSuratNo.Text = d.Nomorsurat;
                            dfTanggal.SelectedDate = (DateTime)d.Tanggal;
                        }
                    }
                }
                else
                {
                    this.pnlMain.Title = "Add new Disposition for letter ; " + nomorsurat;
                    this.txtSuratNo.Text = nomorsurat;
                    //HttpContext.Current.Session["isEditInbox"] = true;
                    //HttpContext.Current.Session["isAddDisposition"] = false;
                    //X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
                }
                HttpContext.Current.Session["isEditInbox"] = false;
                HttpContext.Current.Session["isAddDisposition"] = false;
            }
        }

        [DirectMethod]
        public void btnSave_Click()
        {
            int disposisiId = 0;
            DisposisiQuery dQ = new DisposisiQuery("a");
            dQ.SelectAll();
            dQ.Where(dQ.Nomorsurat == txtSuratNo.Text.Trim());
            DisposisiCollection dC = new DisposisiCollection();
            dC.Load(dQ);
            if (dC.Count > 0)
            {
                foreach (Disposisi D in dC)
                {
                    disposisiId = (int)D.Disposisiid;
                }
            }
            
            // SAVE NEW
            Disposisi d = new Disposisi();
            if (disposisiId == 0)
            {
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
                d.Catatan = txtHtmlCatatan.Text;
                d.Save();
            }
            //SAVE EDIT
            else
            {
                if (d.LoadByPrimaryKey(disposisiId))
                {
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
                    d.Catatan = txtHtmlCatatan.Text;
                    d.Save();
                }
            }
            HttpContext.Current.Session["isEditInbox"] = true;
            HttpContext.Current.Session["isAddDisposition"] = false;
            X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
        }
    }
}