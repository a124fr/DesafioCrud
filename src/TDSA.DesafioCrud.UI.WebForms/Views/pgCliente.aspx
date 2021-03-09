<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pgCliente.aspx.cs" Inherits="TDSA.DesafioCrud.UI.WebForms.Views.pgCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .clienteDesativo {
            background-color:#DDD;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">    
    <br />

    <h1>Clientes</h1>
    <br />

    <div id="divMensagem" runat="server" class="alert alert-success" visible="false">
    </div>

    
    <a class="btn btn-primary" href="~/Views/CadastroCliente.aspx" runat="server">Adicionar Cliente</a>

    <asp:GridView ID="gridClientes" runat="server" AutoGenerateColumns="False"
        ItemType="TDSA.DesafioCrud.Application.ViewModels.ClienteViewModel" EnableViewState="False" CssClass="gridClientes table table-hover table-sm">
        <Columns>              
            <asp:BoundField DataField="Id" HeaderText="#" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />            
            <asp:BoundField DataField="DataNascimento" HeaderText="Data Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>         
                    <input type="hidden" data-item="<%#: Eval("Ativo") %>" value='<%#: Eval("Id") %>'/>
                    <a class="btn btn-primary" href="/Views/AtualizarCliente.aspx?Id=<%#: Eval("Id") %>">Atualizar</a>                      
                    <a class="btn btn-danger"href="#" onclick="excluirCliente(<%#: Eval("Id") %>, this)">Excluir</a>
                </ItemTemplate>
            </asp:TemplateField> 
        </Columns>
        
    </asp:GridView>
    

    <script type="text/javascript">

        $(".gridClientes").children().children().each(function () {            
            var linhaTr = $(this);
            $(this).children().find('input[type=hidden]').each(function () {
                //console.log($(this).attr('value'));
                //console.log($(this).attr('data-item'));
                
                var op = String($(this).attr('data-item')); 
                if (op == 'False') {
                    linhaTr.addClass("clienteDesativo");                    
                } else {
                    linhaTr.removeClass("clienteDesativo");                    
                }

            });
        });


        $(".gridClientes").children().children().click(function () {            
            var linhaTr = $(this);
            $(this).children().find('input[type=hidden]').each(function () {
                //console.log($(this).attr('value'));
                //console.log($(this).attr('data-item'));
                
                var id = $(this).attr('value');
                var op = String($(this).attr('data-item'));                
                var input = $(this);

                gerenciarSituacaoCliente(id, op, linhaTr, input);

            });
        });

        function gerenciarSituacaoCliente(id, op, linhaTr, input) {
            $.ajax({
                    type:"POST",
                    url: "pgCliente.aspx/GerenciarSituacaoCliente",
                    data: JSON.stringify({id:id, op:op}),
                    dataType: "json",
                    contentType: "application/json;charset=uft-8"
                })
                    .done(function (resposta) {                        
                        if (resposta.d == "OK") {

                            if (op == 'True') {
                                linhaTr.addClass("clienteDesativo");
                                input.attr("data-item", 'False');
                            } else {
                                linhaTr.removeClass("clienteDesativo");
                                input.attr("data-item", 'True');
                            }
                            
                            
                        } else {                            
                            alert("Ocorreu algum erro na operacao gerenciar situacao  do cliente! " + resposta.d);
                        }
                              
                    
                  });
        };

        function excluirCliente(id, item) {

            if (window.confirm("Deseja excluir o Cliente ID:"+id+" ?")) {
                $.ajax({
                    type:"POST",
                    url: "pgCliente.aspx/removerCliente",
                    data: JSON.stringify({id:id}),
                    dataType: "json",
                    contentType: "application/json;charset=uft-8"
                })
                    .done(function (resposta) {                        
                        if (resposta.d == "OK") {
                            alert('O cliente foi excluido com Sucesso!');
                            $(item).closest('tr').remove();
                        } else {
                            alert("Ocorreu algum erro ao tenta excluir cliente! " + resposta);
                        }
                              
                    
                  });
            }
                                        
        };
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
