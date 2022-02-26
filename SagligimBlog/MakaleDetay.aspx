<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="SagligimBlog.MakaleDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="arthicle">
                <div class="title">
                    <h2><asp:literal ID="ltrl_baslik" runat="server"></asp:literal></h2>
                </div>
                <div class="image">
                    <asp:Image ID="img_resim" runat="server" />
                </div>
                <div class="subcontent">
                    Kategori: <asp:literal ID="ltrl_kategori" runat="server"></asp:literal> | Yazar :  <asp:literal ID="ltrl_yazar" runat="server"></asp:literal>
                </div>
                <div class="summary">
                   <asp:literal ID="ltrl_icerik" runat="server"></asp:literal>
                </div>
               
            </div>
</asp:Content>
