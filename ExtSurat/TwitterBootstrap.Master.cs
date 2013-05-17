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
    public partial class TwitterBootstrap : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.DataBind();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.Header.DataBind();
        }

        protected string CurrentUserName
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }

        protected string CurrentMemberName
        {
            get
            {
                return Member.NameInCoookie();
            }
        }
    }
}