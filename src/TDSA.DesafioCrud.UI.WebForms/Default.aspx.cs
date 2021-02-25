using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TDSA.DesafioCrud.Application.Interfaces;
using TDSA.DesafioCrud.Application.Services;

namespace TDSA.DesafioCrud.UI.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (IClienteAppService clienteAppService = new ClienteAppService())
                {
                    grid.DataSource = clienteAppService.CarregarTodos();
                    grid.DataBind();
                }
            }
            catch { }   
        }
    }
}