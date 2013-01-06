using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtSurat.BusinessObjects;
using System.Web.Security;

namespace ExtSurat
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void btnLogin_Click()
        {
            User u = new User();
            if (u.LoadByPrimaryKey(txtUser.Text.Trim()))
            {
                if (HelperCrypto.MD5(txtPassword.Text.Trim()) == u.Password.Trim())
                {
                    FormsAuthenticationTicket tkt;
                    string cookiestr;
                    HttpCookie ck;
                    tkt = new FormsAuthenticationTicket(1, txtUser.Text, DateTime.Now, DateTime.Now.AddHours(2), true, "");
                    cookiestr = FormsAuthentication.Encrypt(tkt);
                    ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                    ck.Expires = tkt.Expiration;
                    ck.Path = FormsAuthentication.FormsCookiePath;
                    Response.Cookies.Add(ck);
                    string strRedirect;
                    strRedirect = Request["ReturnUrl"];
                    if (strRedirect == null)
                        strRedirect = "default.aspx";
                    Response.Redirect(strRedirect, true);
                }
                else
                    this.pnlLogin.Title = HelperCrypto.MD5(txtPassword.Text.Trim());
            }
            else
                this.pnlLogin.Title = HelperCrypto.MD5(txtPassword.Text.Trim());
        }
    }
}