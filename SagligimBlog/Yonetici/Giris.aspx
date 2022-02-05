<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="SagligimBlog.Yonetici.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sağlığım Blog Yönetici Panel Giriş</title>
    <link href="css/YoneticiGiris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="FormContainer">
            <div class="FormBaslik">
                <h3>Yönetici Giriş</h3>
            </div>
            <div class="contentcontainer">
               <asp:Panel ID="pnl_hata" runat="server" CssClass="hatamesaj" Visible="false">
                   <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
               </asp:Panel>
                <div>
                    <label>Mail</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu" placeholder="ornek@ornek.com"></asp:TextBox>
                </div>
                <div>
                    <label>Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="metinKutu" placeholder="Şifreniz"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btn_giris" runat="server" Text="Giriş Yap" OnClick="btn_giris_Click" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
