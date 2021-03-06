﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TDSA.DesafioCrud.Application.Interfaces;
using TDSA.DesafioCrud.Application.Services;

namespace TDSA.DesafioCrud.UI.WebForms.Views
{
    public partial class pgCliente : System.Web.UI.Page
    {
        private IClienteAppService _clienteAppService;

        //protected override void OnInit(EventArgs e)
        //{
        //    _clienteAppService = new ClienteAppService();
        //    base.OnInit(e);
        //}

        //protected override void OnUnload(EventArgs e)
        //{
        //    if (_clienteAppService != null)
        //        _clienteAppService.Dispose();

        //    base.OnUnload(e);
        //}

        protected override void OnInit(EventArgs e)
        {
            _clienteAppService = (IClienteAppService)HttpContext.Current.Items["_EFCONTEXT"];
            base.OnInit(e); 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                try
                {
                    var clientes = _clienteAppService.CarregarTodos();
                    gridClientes.DataSource = clientes;
                    gridClientes.DataBind();
                    
                    if(!String.IsNullOrEmpty(Request.QueryString["msg"]))
                    {
                        divMensagem.Visible = true;
                        divMensagem.InnerHtml = Request.QueryString["msg"];
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public static string removerCliente(int id)
        {
            try
            {
                //if (_clienteAppService == null)
                //{
                //    throw new Exception("Objeto Cliente Servicço nullo!");
                //}

                //_clienteAppService.Remover(id);

                using (IClienteAppService clienteAppService = new ClienteAppService())
                {
                    clienteAppService.Remover(id);
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static string GerenciarSituacaoCliente(int id, bool op)
        {
            try
            {
                //var clienteAppService = (IClienteAppService)HttpContext.Current.Items["_EFCONTEXT"];
                //if (clienteAppService == null)
                //{
                //    throw new Exception("Objeto Cliente Servicço nullo!");
                //}

                //clienteAppService.GerenciarSituacao(id, op);

                using (IClienteAppService clienteAppService = new ClienteAppService())
                {
                    clienteAppService.GerenciarSituacao(id, op);
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}