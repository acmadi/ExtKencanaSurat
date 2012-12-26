using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using ExtSurat.BusinessObjects;

namespace ExtSurat
{
    public partial class frmOutbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.storeOutbox.DataSource = GetOutbox();
                this.storeOutbox.DataBind();
            }
        }

        public DataTable GetOutbox()
        {
            DataTable dt = new DataTable();
            SuratkeluarQuery smQ = new SuratkeluarQuery();
            smQ.SelectAll();
            dt = smQ.LoadDataTable();
            return dt;
        }

        [DirectMethod]
        public void storeOutbox_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeOutbox.DataSource = GetOutbox();
            this.storeOutbox.DataBind();
        }

        [DirectMethod]
        public void btnAddSurat()
        {

        }
    }
}