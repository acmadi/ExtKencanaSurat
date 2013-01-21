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
    public partial class frmMasterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.storeUser.DataSource = GetUser();
                this.storeUser.DataBind();
            }
        }

        public DataTable GetUser()
        {
            UserQuery uQ = new UserQuery();
            uQ.SelectAll();
            DataTable dU = uQ.LoadDataTable();
            return dU;
        }

        [DirectMethod]
        public void storeUser_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeUser.DataSource = GetUser();
            this.storeUser.DataBind();
        }

        [DirectMethod]
        public void EditUser()
        {
 
        }

        [DirectMethod]
        public void Refresh_Grid()
        {
 
        }
    }
}