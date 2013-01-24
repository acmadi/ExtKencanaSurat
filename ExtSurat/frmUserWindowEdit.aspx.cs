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
    public partial class frmUserWindowEdit : System.Web.UI.Page
    {
        private string userid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                if (Request.QueryString["userid"] == null)
                    X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
                else
                {
                    userid = Request.QueryString["userid"].ToString().Trim();
                    HttpContext.Current.Session["userid"] = userid;
                    BusinessObjects.User u = new User();
                    if (u.LoadByPrimaryKey(userid))
                    {
                        //Populate the combobox
                        List<object> list = new List<object>
                        {
                            new {Text = "User", Value = "User"},
                            new {Text = "Admin", Value = "Admin"}                    
                        };
                        this.Store1.DataSource = list;
                        this.Store1.DataBind(); 

                        txtUserId.Text = u.Userid;
                        txtNama.Text = u.Nama;
                        txtLokasi.Text = u.Lokasi;
                        txtJabatan.Text = u.Jabatan;
                        txtBagian.Text = u.Divisi;
                        if (u.Level == "User")
                            cmbLevel.SelectedIndex = 0;
                        else
                            cmbLevel.SelectedIndex = 1;
                        if (u.Aktif == "Y")
                            chkAktif.Checked = true;
                        else if (u.Aktif == "N")
                            chkAktif.Checked = false;
                    }
                }
            }
        }

        [DirectMethod]
        public void SaveData()
        {
            if (string.IsNullOrEmpty(cmbLevel.SelectedItem.Value.Trim()))
                return;
            BusinessObjects.User u = new User();
            if (u.LoadByPrimaryKey(txtUserId.Text.Trim()))
            {
                u.Nama = txtNama.Text.Trim();
                u.Lokasi = txtLokasi.Text.Trim();
                u.Jabatan = txtJabatan.Text.Trim();
                u.Divisi = txtBagian.Text.Trim();
                u.Level = cmbLevel.SelectedItem.Value.Trim();
                if (chkAktif.Checked)
                    u.Aktif = "Y";
                else
                    u.Aktif = "N";
                u.Save();
            }
            HttpContext.Current.Session["isEditUser"] = true;
            X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
        }
    }
}