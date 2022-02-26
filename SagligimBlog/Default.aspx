<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SagligimBlog.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lv_makaleler" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="arthicle">
                <div class="title">
                    <h2><%# Eval("Baslik") %></h2>
                </div>
                <div class="image">
                    <img src='MakaleResimleri/Cover/<%# Eval("KapakResim") %>' />
                </div>
                <div class="subcontent">
                    Kategori: <%# Eval("Kategori") %> | Yazar :  <%# Eval("Yazar") %>
                </div>
                <div class="summary">
                    <%# Eval("Ozet") %>
                </div>
                <div class="button">
                    <a href="MakaleDetay.aspx?mid= <%# Eval("ID") %>">Makalenin Devamı</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
