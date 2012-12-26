using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;

namespace ExtSurat
{
    public partial class ExtSurat : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["activetab"] != null)
            {
                TabPanel1.SetActiveTab(Request.QueryString["activetab"].ToString().Trim());
                this.lblWelcome.Text = Request.QueryString["activetab"].ToString().Trim();
            }

            if (HttpContext.Current.Session["activetab"] != null)
            {
                TabPanel1.SetActiveTab(HttpContext.Current.Session["activetab"].ToString().Trim());
            }
        }
        
        [DirectMethod]
        public void btnMasterUser_Click()
        {
            //this.pnlMain.Loader.SuspendScripting();
            //this.pnlMain.Loader.Url = "http://10.4.4.27/rscm/bku";
            //this.pnlMain.Loader.DisableCaching = true;
            //this.pnlMain.LoadContent();
        }

        [DirectMethod]
        public void loadUserControl(string buttonID)
        {
            //if (this.pnlMain.ContentControls != null)
            //{
            //    Ext.Net.Utilities.ControlUtils.FindControls<AbstractComponent>(this.pnlMain).ForEach(c =>
            //    {
            //        if (!c.IsLazy)
            //        {
            //            c.Destroy();
            //        }
            //    });
            //}

            //if (this.pnlMain.ContentControls != null)
            //    this.pnlMain.ContentControls.Clear();

            //Control cc = this.LoadControl("~/Master/ucMasterUser.ascx");
            //cc.ID = "ucMasterUser";
            //this.pnlMain.ContentControls.Add(cc);
            //this.pnlMain.UpdateContent();

            //if (buttonID == "btnInbox")
            //{
            //    TabPanel1.ResumeEvents();
            //    HttpContext.Current.Session["activetab"] = ((Ext.Net.Panel)TabPanel1.FindControl("Panel2")).ID;
            //    this.Response.Redirect("~/frmInbox.aspx");
            //}
            //else if (buttonID == "btnOutbox")
            //{
            //    TabPanel1.ResumeEvents();
            //    this.Response.Redirect("~/frmOutbox.aspx?activetab=" + ((Ext.Net.Panel)TabPanel1.FindControl("Panel2")).ID);
            //}
            //else
            //    this.Response.Redirect("~/Default.aspx");

            switch (buttonID)
            {
                case "btnMasterUser":
                    TabPanel1.ResumeEvents();
                    HttpContext.Current.Session["activetab"] = ((Ext.Net.Panel)TabPanel1.FindControl("Panel1")).ID;
                    this.Response.Redirect("~/frmMasterUser.aspx");
                    break;
                case "btnMasterGroup":
                    TabPanel1.ResumeEvents();
                    HttpContext.Current.Session["activetab"] = ((Ext.Net.Panel)TabPanel1.FindControl("Panel1")).ID;
                    this.Response.Redirect("~/frmMasterGroup.aspx");
                    break;
                case "btnInbox":
                    TabPanel1.ResumeEvents();
                    HttpContext.Current.Session["activetab"] = ((Ext.Net.Panel)TabPanel1.FindControl("Panel2")).ID;
                    this.Response.Redirect("~/frmInbox.aspx");
                    break;
                case "btnOutbox":
                    TabPanel1.ResumeEvents();
                    HttpContext.Current.Session["activetab"] = ((Ext.Net.Panel)TabPanel1.FindControl("Panel2")).ID;
                    this.Response.Redirect("~/frmOutbox.aspx");
                    break;
                case "btnReportInbox":
                    TabPanel1.ResumeEvents();
                    HttpContext.Current.Session["activetab"] = ((Ext.Net.Panel)TabPanel1.FindControl("Panel3")).ID;
                    this.Response.Redirect("~/frmReportInbox.aspx");
                    break;
                case "btnReportOutbox":
                    TabPanel1.ResumeEvents();
                    HttpContext.Current.Session["activetab"] = ((Ext.Net.Panel)TabPanel1.FindControl("Panel3")).ID;
                    this.Response.Redirect("~/frmReportOutbox.aspx");
                    break;
                case "btnReportDisposition":
                    TabPanel1.ResumeEvents();
                    HttpContext.Current.Session["activetab"] = ((Ext.Net.Panel)TabPanel1.FindControl("Panel3")).ID;
                    this.Response.Redirect("~/frmReportDisposition.aspx");
                    break;
                default:
                    this.Response.Redirect("~/Default.aspx");
                    break;
            }
        }

        [DirectMethod]
        public void OnTabChange()
        {
            TabPanel1.SuspendEvents(true);
        }

        [DirectMethod]
        public void btnMasterGroup_Click()
        {
            //if (this.pnlMain.ContentControls != null)
            //{
            //    Ext.Net.Utilities.ControlUtils.FindControls<AbstractComponent>(this.pnlMain).ForEach(c =>
            //    {
            //        if (!c.IsLazy)
            //        {
            //            c.Destroy();
            //        }
            //    });
            //}

            //this.pnlMain.ContentControls.Clear();
            //Control cc = this.LoadControl("~/Master/ucMasterAccess.ascx");
            //cc.ID = "ucMasterAccess";
            //this.pnlMain.ContentControls.Add(cc);            
            //this.pnlMain.UpdateContent();  
        }
    }
}