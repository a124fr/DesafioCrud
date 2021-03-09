using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDSA.DesafioCrud.Application.Interfaces;
using TDSA.DesafioCrud.Application.Services;

namespace TDSA.DesafioCrud.UI.WebForms.Handlers
{
    public class ContextModuleHandler : IHttpModule
    {
        private IClienteAppService _clienteAppService;

        public void Init(HttpApplication context)
        {              
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }
       
        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;

            if(application != null)
            {
                var request = application.Request;

                if(request.Path.Equals("/Views/pgCliente.aspx"))
                {
                    _clienteAppService = new ClienteAppService();
                    HttpContext.Current.Items["_EFCONTEXT"] = _clienteAppService;
                }


                //var response = application.Response;
            }

            
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            if(_clienteAppService != null)
                _clienteAppService.Dispose();
        }

        public void Dispose()
        {   
        }
    }
}