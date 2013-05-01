using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SimpleTools.RoleAdmin.API.Collections;
using SimpleTools.RoleAdmin.API.Objects;
using SimpleTools.RoleAdmin.API.Utilities;

namespace ExtSurat
{
    public partial class FormLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(Tools.SingleSignOnRedirectUrl(SingleSignOnRedirectTo.SignOut, Request.QueryString["ReturnUrl"]));
        }
    }
}