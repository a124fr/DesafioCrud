using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (IClienteAppService clienteAppService = new ClienteAppService())
                {
                    var clientes = clienteAppService.CarregarTodos();


                    gridClientes.DataSource = clientes;
                    gridClientes.DataBind();
                }
            }
            catch { }
        }

        [WebMethod]
        public static string removerCliente(int id)
        {
            try
            {
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
    }
}