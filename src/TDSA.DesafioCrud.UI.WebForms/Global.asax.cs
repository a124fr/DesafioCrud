using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TDSA.DesafioCrud.Application.AutoMapper;
using TDSA.DesafioCrud.UI.WebForms.Handlers;

namespace TDSA.DesafioCrud.UI.WebForms
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AutoMapperConfig.RegisterMappings();
        }
    }
}