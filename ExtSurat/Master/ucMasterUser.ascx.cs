using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtSurat.BusinessObjects;
using System.Data;

namespace ExtSurat.Master
{
    public partial class ucMasterUser : System.Web.UI.UserControl
    {
        private DataTable dtUser;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //base.OnPreRender(e);
            if (!X.IsAjaxRequest)
            {               
                //UserQuery uQ = new UserQuery();
                //uQ.Select(uQ.Userid, uQ.Nama, uQ.Jabatan, uQ.Divisi, uQ.Lokasi, uQ.Level);
                //uQ.Where(uQ.Aktif == 'Y');
                //dtUser = uQ.LoadDataTable();
                //this.gpUser.Title = dtUser.Rows.Count.ToString();
                //this.storeMasterUser.DataSource = dtUser;

                this.storeMasterUser.DataSource = this.GetUSerDatatable();
                this.storeMasterUser.DataBind();
                //this.storeMasterUser.DataBind();
                //this.storeMasterUser.DataBind();
                //X.Msg.Alert("count", this.dtUser.Rows.Count.ToString()).Show();
            }
        }

        [DirectMethod]
        public void storeMasterUser_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeMasterUser.DataSource = this.GetUSerDatatable();
            this.storeMasterUser.DataBind();
        }

        [DirectMethod]
        public void EditDataUser(string userid)
        {
            X.Msg.Alert("alert", userid).Show();
        }

        [DirectMethod]
        public void Reload()
        {
            this.storeMasterUser.DataSource = this.GetUSerDatatable();
            this.storeMasterUser.DataBind();
        }

        public DataTable GetUSerDatatable()
        {
            DataTable dt = new DataTable();
            UserQuery uQ = new UserQuery();
            uQ.Select(uQ.Userid,uQ.Nama,uQ.Jabatan, uQ.Divisi, uQ.Lokasi, uQ.Level);
            //uQ.Where(uQ.Aktif == 'Y');
            dt = uQ.LoadDataTable();
            dtUser = dt;
            //this.gpUser.Title = dt.Rows.Count.ToString();
            return dt;
        }
    }
}