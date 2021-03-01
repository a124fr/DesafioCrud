using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDSA.DesafioCrud.UI.WebForms.Handlers
{
    /// <summary>
    /// Summary description for TelefoneClienteHandler
    /// </summary>
    public class TelefoneClienteHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}