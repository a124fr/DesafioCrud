using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TDSA.DesafioCrud.Application.Interfaces;
using TDSA.DesafioCrud.Application.Services;
using TDSA.DesafioCrud.Application.ViewModels;

namespace TDSA.DesafioCrud.UI.WebForms.Views
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        private IClienteAppService _clienteAppService;

        protected override void OnInit(EventArgs e)
        {
            _clienteAppService = new ClienteAppService();
            base.OnInit(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            if (_clienteAppService != null)
                _clienteAppService.Dispose();

            base.OnUnload(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string nome = txtNome.Text;
                    string dataNascimento = txtDataNascimento.Text;

                    var cliente = new ClienteViewModel();
                    cliente.Nome = nome;
                    cliente.DataNascimento = DateTime.Parse(dataNascimento);
                    cliente.Ativo = true;
                    _clienteAppService.Adicionar(cliente);

                    var mensagem = "O Cliente foi cadastrado com sucesso!";
                    Response.Redirect("~/Views/pgCliente.aspx?msg="+ mensagem);
                }
            }
            catch (Exception ex)
            {
                lblMensagensErros.InnerHtml = "<p>" + ex.Message + "</p>";
            }
        }
    }
}