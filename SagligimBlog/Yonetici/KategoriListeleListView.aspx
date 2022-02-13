<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="KategoriListeleListView.aspx.cs" Inherits="SagligimBlog.Yonetici.KategoriListeleListView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="formContainer">
       <div class="formtitle">
           <h3>Kategoriler</h3>
       </div>
       <div class="formContent contenttable">
           <asp:ListView ID="lv_kategoriler" runat="server">
               <LayoutTemplate>
                   <table class="listTable" cellspacing="0" cellpadding="0">
                       <tr>
                           <th>ID</th>
                           <th>Isim</th>
                           <th>Seçenekler</th>
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                       <td><%# Eval("ID") %></td>
                       <td><%# Eval("Isim") %></td>
                       <td>
                           <a href="#" class="tablebutton update">Güncelle</a>
                           <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablebutton delete">Sil</asp:LinkButton>
                       </td>
                   </tr>
               </ItemTemplate>
           </asp:ListView>
       </div>
   </div>
</asp:Content>
