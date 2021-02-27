<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AtualizarCliente.aspx.cs" Inherits="TDSA.DesafioCrud.UI.WebForms.Views.AtualizarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
     <h1>Atualizar Cliente</h1>
    <div id="lblMensagensErros" runat="server">

    </div>
    <div>
        <asp:label runat="server" text="Nome" ID="lblNome"></asp:label>
        <asp:textbox runat="server" ID="txtNome"></asp:textbox>
    </div>

    <div>
        <asp:label runat="server" text="Data Nascimento" ID="lblDataNascimento"></asp:label>
        <asp:textbox runat="server" ID="txtDataNascimento" TextMode="Date"></asp:textbox>
    </div>
    
    <div>
        <asp:button runat="server" text="Atualizar" ID="btnAtualizar" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
