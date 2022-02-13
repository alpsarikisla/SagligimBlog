<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="SagligimBlog.Yonetici.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formtitle">
            <h3>Kategori Ekle</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Kategori Ekleme İşlemi Başarıyla Gerçekleştirildi</label>
            </asp:Panel>
             <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" CssClass="formButton">Kategori Ekle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
