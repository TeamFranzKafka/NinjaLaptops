<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Laptops.aspx.cs" Inherits="NinjaLaptops.WebClient.Laptops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="menu panel panel-primary">
            <div class="panel-heading">
                <strong>Brands</strong>
            </div>
            <div class="panel-body">
                <asp:CheckBoxList ID="CheckBoxBrands" runat="server" DataTextField="BrandName" DataValueField="BrandId" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxBrands_SelectedIndexChanged"></asp:CheckBoxList>
            </div>
        </div>
        <div class="col-md-2">
        </div>

        <div class="col-md-10 text-center">
            <asp:ListView ID="ListViewLaptops" runat="server" ItemType="NinjaLaptops.Models.Product">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-md-3 text-center list-item-border">
                        <div class="list-item">
                            <a href="<%# "/LaptopDetails?id=" + Item.ProductId %>">
                                <h3><%#: Item.Model %></h3>
                                <img src="<%#: Item.PictureLink %>" alt="<%#: Item.Model %>" />
                                <br />
                                <br />
                                <div><%#: Item.Price %>$</div>
                            </a>
                        </div>
                        <asp:LinkButton ID="LinkButtonOrderProduct"
                            runat="server"
                            Text="Add To Basket"
                            CommandArgument="<%# Item.ProductId %>"
                            OnCommand="LinkButtonOrderProduct_Command" CssClass="btn btn-primary" />

                    </div>
                </ItemTemplate>

            </asp:ListView>
        </div>
    </div>
</asp:Content>
