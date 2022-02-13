<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="KategoriListeleGridView.aspx.cs" Inherits="SagligimBlog.Yonetici.KategoriListeleGridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="formContainer">
       <div class="formtitle">
           <h3>Kategoriler</h3>
       </div>
       <div class="formContent">
           <asp:GridView ID="gv_kategoriler" runat="server"></asp:GridView>
       </div>
   </div>
</asp:Content>
