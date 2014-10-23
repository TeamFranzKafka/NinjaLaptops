<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductView.ascx.cs" Inherits="NinjaLaptops.WebClient.Controls.ProductView" %>

<asp:ListView ID="DetailsViewLaptop" runat="server" ItemType="NinjaLaptops.Models.Product">
    <ItemTemplate>
        <div class="image-container">
            <img src="<%# Item.PictureLink %>" />
        </div>
        <div class="details-container">
            <p><strong>Model: </strong> <%# Item.Model %></p>
            <p><strong>Price: </strong> <%# Eval("Price", "{0:C}") %></p>
            <p><strong>Brand: </strong> <%# Item.Brand.BrandName %></p>
        </div>
    </ItemTemplate>
    <LayoutTemplate>
        <div class="span4" id="itemPlaceholder" runat="server">

        </div>
    </LayoutTemplate>
</asp:ListView>




