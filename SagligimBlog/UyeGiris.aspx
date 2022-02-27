<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="SagligimBlog.UyeGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTitle">
        <h4>Üye Giriş</h4>
    </div>
    <div class="girisForm form">
        <div class="row" style="text-align:center">
            <img src="assets/Images/272354.png" class="loginpanelimage" />
        </div>
        <asp:panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:panel>
        <div class="row">
           <%-- <label>Mail:</label><br />
            <br />--%>
            <asp:TextBox ID="tb_mail" runat="server" CssClass="textbox" placeholder="Mail"></asp:TextBox>
        </div>
        <div class="row">
           <%-- <label>Şifre:</label><br />
            <br />--%>
            <asp:TextBox ID="tb_sifre" TextMode="Password" runat="server" CssClass="textbox" placeholder="Şifre"></asp:TextBox>
        </div>
        <div class="row" style="text-align:center">
            <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş Yap" OnClick="lbtn_giris_Click" CssClass="formbutton"></asp:LinkButton>
        </div>

    </div>
</asp:Content>
