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
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var erros = new List<string>();

            try
            {
                string nome = txtNome.Text;
                string dataNascimento = txtDataNascimento.Text;

                bool validacao = false;

                if(String.IsNullOrEmpty(nome))
                {
                    erros.Add("O Campo nome é obrigatório");
                    validacao = true;
                }

                if(String.IsNullOrEmpty(dataNascimento))
                {
                    erros.Add("O Campo E-mail é obrigatório");
                    validacao = true;
                }
                
                if(validacao)
                {
                    throw new Exception("Ocorreu um erro!");
                }

                var cliente = new ClienteViewModel();
                cliente.Nome = nome;
                cliente.DataNascimento = DateTime.Parse(dataNascimento);
                cliente.Ativo = true;

                using(IClienteAppService clienteAppService = new ClienteAppService())
                {
                    clienteAppService.Adicionar(cliente);
                }

                Response.Redirect("~/Default.aspx");
            }
            catch (Exception ex)
            {
                lblMensagensErros.InnerHtml = "<p>" + ex.Message + "</p>";

                erros.ForEach(erro =>
                {
                    lblMensagensErros.InnerHtml += "<p>" + erro + "</p>";
                });
            }
        }
    }
}