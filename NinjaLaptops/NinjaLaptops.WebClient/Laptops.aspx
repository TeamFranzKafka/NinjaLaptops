<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Laptops.aspx.cs" Inherits="NinjaLaptops.WebClient.Laptops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:BulletedList ID="BulletedListBrands" runat="server" DataTextField="BrandName" DataValueField="BrandId"></asp:BulletedList>
</asp:Content>
