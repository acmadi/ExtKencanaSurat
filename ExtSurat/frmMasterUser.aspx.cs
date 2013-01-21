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
        public void EditUser(string commandName, string userid)
        {
            taskManager1.StartAll();
            HttpContext.Current.Session["isEditUser"] = false;            
            HttpContext.Current.Session["isEditUser"] = false;

            BusinessObjects.User u = new User();
            //EDIT
            if (u.LoadByPrimaryKey(userid.Trim()) && commandName.Trim() == "Edit")
            {
                var win = new Window()
                {
                    ID = "EditUserWindow",
                    Title = "Edit User : " + u.Nama,
                    Width = Unit.Pixel(800),
                    Height = Unit.Pixel(600),
                    Modal = true,
                    AutoRender = false,
                    Collapsed = false,
                    Maximizable = false,
                    Hidden = true,
                    Draggable = false,
                    Resizable = false,
                    Closable = true
                };

                win.AutoLoad.Url = "~/frmUserWindowEdit.aspx?userid=" + userid.ToString().Trim();
                win.AutoLoad.Mode = LoadMode.IFrame;
                win.AutoLoad.ShowMask = true;
                win.Render(this.Form);
                win.Show();
            }
            //DELETE
            else if (u.LoadByPrimaryKey(userid.Trim()) && commandName.Trim() == "Delete")            
            {
                u.MarkAsDeleted();
                u.AcceptChanges();
            }
            else if (commandName.Trim() == "New")
            {
                var win = new Window()
                {
                    ID = "AddUserWindow",
                    Title = "Add User",
                    Width = Unit.Pixel(800),
                    Height = Unit.Pixel(600),
                    Modal = true,
                    AutoRender = false,
                    Collapsed = false,
                    Maximizable = false,
                    Hidden = true,
                    Draggable = false,
                    Resizable = false,
                    Closable = true
                };

                win.AutoLoad.Url = "~/frmUserWindowAdd.aspx?userid=new";
                win.AutoLoad.Mode = LoadMode.IFrame;
                win.AutoLoad.ShowMask = true;
                win.Render(this.Form);
                win.Show();
            }
        }

        [DirectMethod]
        public void Refresh_Grid()
        {
            if (HttpContext.Current.Session["isEditUser"] == null)
            {
                taskManager1.StopAll();
                return;
            }
            if ((bool)HttpContext.Current.Session["isEditUser"] == false)
                return;
            else
            {
                this.storeUser.DataSource = GetUser();
                this.storeUser.DataBind();
                HttpContext.Current.Session["isEditUser"] = false;
                taskManager1.StopAll();
            }
        }
    }
}