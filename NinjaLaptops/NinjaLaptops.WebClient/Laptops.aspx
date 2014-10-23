<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Laptops.aspx.cs" Inherits="NinjaLaptops.WebClient.Laptops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:CheckBoxList ID="CheckBoxBrands" runat="server" DataTextField="BrandName" DataValueField="BrandId" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxBrands_SelectedIndexChanged"></asp:CheckBoxList>

    <asp:ListView ID="ListViewLaptops" runat="server" ItemType="NinjaLaptops.Models.Product">
        <LayoutTemplate>
            <h3>Name</h3>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <h2> <%#: Item.Model %></h2>
                <img src="<%#: Item.PictureLink %>" alt="<%#: Item.Model %>" />
                <div><%#: Item.Price %></div>
            </div>
            <asp:LinkButton ID="LinkButtonOrderProduct"
                                runat="server"
                                Text="Add To Basket"
                                CommandArgument="<%# Item.ProductId %>"                
                                OnCommand="LinkButtonOrderProduct_Command" />
            </ItemTemplate>
     
    </asp:ListView>
</asp:Content>
