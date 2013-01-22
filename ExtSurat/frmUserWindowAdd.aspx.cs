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
    public partial class frmUserWindowAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                List<object> list = new List<object>
                {
                    new {Text = "User", Value = "User"},
                    new {Text = "Admin", Value = "Admin"}                    
                };

                this.Store1.DataSource = list;
                this.Store1.DataBind();                
            }
        }

        [DirectMethod]
        public void SaveData()
        {
            if (txtPassword.Text.Trim() != txtPasswordConfirm.Text.Trim())
            {
                X.Msg.Alert("Error","Please review password, both must be same").Show();
                return;
            }
            if (cmbLevel.IsEmpty)
            {
                X.Msg.Alert("Error", "Please select a level for this user").Show();
                return;
            }

            User u = new User();
            u.Userid = txtUserId.Text.Trim();
            u.Password = HelperCrypto.MD5(txtPassword.Text.Trim());
            u.Level = cmbLevel.SelectedItem.Value;
            u.Nama = txtNama.Text.Trim();
            u.Jabatan = txtJabatan.Text;
            u.Divisi = txtBagian.Text;
            u.Lokasi = txtLokasi.Text;
            u.Save();
            HttpContext.Current.Session["isEditUser"] = true;
            X.AddScript("parentAutoLoadControl.close(); Delay='2' ");
        }
    }
}