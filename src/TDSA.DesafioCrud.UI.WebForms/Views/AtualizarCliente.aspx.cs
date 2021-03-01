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
    public partial class AtualizarCliente : System.Web.UI.Page
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
            try
            {
                if (!IsPostBack)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    var cliente = _clienteAppService.CarregarUm(id);

                    if (cliente == null) Response.Redirect("~/Views/pgCliente.aspx");

                    txtID.Value = cliente.Id.ToString();
                    txtNome.Text = cliente.Nome;
                    txtDataNascimento.Text = cliente.DataNascimento.ToString("yyyy-MM-dd");
                    txtDataNascimento.TextMode = TextBoxMode.Date;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    string nome = txtNome.Text;
                    string dataNascimento = txtDataNascimento.Text;

                    var cliente = new ClienteViewModel();
                    cliente.Id = id;
                    cliente.Nome = nome;
                    cliente.DataNascimento = DateTime.Parse(dataNascimento);
                    cliente.Ativo = true;
                    _clienteAppService.Atualizar(cliente);

                    Response.Redirect("~/Views/pgCliente.aspx");
                }
            }
            catch (Exception ex)
            {
                lblMensagensErros.InnerHtml = "<p>" + ex.Message + "</p>";
            }
        }
    }
}