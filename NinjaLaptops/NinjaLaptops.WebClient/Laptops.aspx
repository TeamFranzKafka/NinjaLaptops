<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Laptops.aspx.cs" Inherits="NinjaLaptops.WebClient.Laptops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:BulletedList ID="BulletedListBrands" runat="server" DataTextField="BrandName" DataValueField="BrandId" DisplayMode="LinkButton" OnClick="BulletedListBrands_Click"></asp:BulletedList>
    <asp:ListView ID="ListViewLaptops" runat="server" ItemType="NinjaLaptops.Models.Product">
        <LayoutTemplate>
            <h3>Name</h3>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <strong> <%#: Item.Model %></strong>
                -
                <span> <%#: Item.Price %></span>
            </div>
            </ItemTemplate>
    </asp:ListView>
</asp:Content>
