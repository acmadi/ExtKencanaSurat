using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;

using SimpleTools.RoleAdmin.API;
using SimpleTools.RoleAdmin.API.Collections;
using SimpleTools.RoleAdmin.API.Objects;
using SimpleTools.RoleAdmin.API.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace ExtSurat
{
    public class BasePage : Page
    {
        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);
            string RoleNormal = "3d903fbb57c7d8006105c8546ba88fa7";
            string RoleAdmin = "f74954e20b90f501ae67f0d1914b4893";
            bool isValidUser = false;


            string ApiKey = "0DFxXBb8GIOi6IjdytI8XHNEcjqAmfzpDADJBuRy6WW2WRlR";
            Connection con = new Connection("http://localhost:88/RoleAdmin/Admin/api", "trogalko@gmail.com", ApiKey);
            Tools.Connection = con;
            Roles.Connection = con;
            Members.Connection = con;
            AuditEvents.Connection = con;
            AuditEventDatails.Connection = con;

            List<Role> _Role = Roles.GetMemberRoles(CurrentUserName);
            string roles = string.Empty;
            foreach (Role r in _Role)
            {
                roles = roles + " " + r.Name;
                if (MD5hash(r.Name) == RoleAdmin || MD5hash(r.Name) == RoleNormal)
                {
                    isValidUser = true;
                    return;
                }                    
            }
            if (!isValidUser)
                Response.Redirect("~/Default.aspx");
        }

        public static string Md5Hash(string pass)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            return sb.ToString();
        }

        public static string MD5hash(string password)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }

        protected string CurrentUserName
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }
    }
}