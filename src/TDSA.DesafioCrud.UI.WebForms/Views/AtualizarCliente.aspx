<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AtualizarCliente.aspx.cs" Inherits="TDSA.DesafioCrud.UI.WebForms.Views.AtualizarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="col">
         <h1>Atualizar Cliente</h1>
        <div id="lblMensagensErros" runat="server">

        </div>
        <div>
            <asp:validationsummary CssClass="text-danger" runat="server"></asp:validationsummary>
        </div>
        <asp:HiddenField ID="txtID" runat="server" />
        <div class="form-group">
            <asp:label runat="server" text="Nome" ID="lblNome"></asp:label>
            <asp:textbox CssClass="form-control" runat="server" ID="txtNome"></asp:textbox>
            <asp:RequiredFieldValidator CssClass="text-danger" runat="server" ID="txtNomeValidator" ControlToValidate="txtNome"
            ErrorMessage="O Campo nome é obrigatório">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:label runat="server" text="Data Nascimento" ID="lblDataNascimento"></asp:label>
            <asp:textbox CssClass="form-control" runat="server" ID="txtDataNascimento"></asp:textbox>
            <asp:requiredfieldvalidator CssClass="text-danger" runat="server" errormessage="O Campo e-mail é obrigatório" ControlToValidate="txtDataNascimento">*</asp:requiredfieldvalidator>
        </div>
    
        <div>
            <asp:button runat="server" text="Atualizar" ID="btnAtualizar" OnClick="btnAtualizar_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
