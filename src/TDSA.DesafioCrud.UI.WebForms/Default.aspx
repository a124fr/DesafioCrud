<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="TDSA.DesafioCrud.UI.WebForms.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Content" runat="server">
 <div>
    <asp:DataGrid ID="grid" runat="server"></asp:DataGrid>
</div>
<br />
<div>
    <asp:GridView ID="gridView" runat="server"></asp:GridView>
</div> 
</asp:Content>
