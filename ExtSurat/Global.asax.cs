using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using EntitySpaces.Loader;

namespace ExtSurat
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            EntitySpaces.Interfaces.esProviderFactory.Factory = new esDataProviderFactory();
            AuthorizeRequest += new EventHandler(Global_AuthorizeRequest);
        }

        void Global_AuthorizeRequest(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.RawUrl.ToLower();
            if (url.Contains("ext.axd"))
            {
                HttpContext.Current.SkipAuthorization = true;
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
