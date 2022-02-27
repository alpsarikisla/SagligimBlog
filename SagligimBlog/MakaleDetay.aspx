<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="SagligimBlog.MakaleDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="arthicle">
        <div class="title">
            <h2>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal></h2>
        </div>
        <div class="image">
            <asp:Image ID="img_resim" runat="server" />
        </div>
        <div class="subcontent">
            Kategori:
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            | Yazar : 
            <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
        </div>
        <div class="summary">
            <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
        </div>

    </div>
    <div style="min-height: 500px;">
        <div class="yorum" style="margin-top:50px;">
            <div class="yorumPanelBaslik"><h2>Yorumlar</h2></div>
            <asp:Panel ID="pnl_girisVar" runat="server" Visible="false">
                <br /><br />
                <h3>Yorumunuzu Yazınız</h3>
                <asp:TextBox ID="tb_yorum" TextMode="MultiLine" runat="server" CssClass="YorumKutu"></asp:TextBox>
                <br /><br /><br />
                <asp:LinkButton ID="lbtn_yorumYap" runat="server" Text="Yorum Yap" OnClick="lbtn_yorumYap_Click" CssClass="yorumYapButton"></asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="pnl_girisyok" runat="server" style="margin:20px 0;">
                <h2>Yorum yapabilmek için lütfen <a href="uyegiris.aspx">giriş yapınız </a></h2>
            </asp:Panel>
            <asp:Repeater ID="rp_yorumlar" runat="server">
                <ItemTemplate>
                    <div class="yorumitem">
                        <label><%# Eval("Uye") %></label> | <label><%# Eval("Tarih") %></label>
                        <br />
                        <p><%# Eval("Icerik") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>
</asp:Content>
