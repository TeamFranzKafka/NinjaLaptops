<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Laptops.aspx.cs" Inherits="NinjaLaptops.WebClient.Laptops" %>

<%@ Register Src="~/Notifier/ErrorSuccessNotifier/ErrorSuccessNotifier.ascx" TagPrefix="ninja" TagName="ErrorSuccessNotifier" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="menu panel panel-primary">
            <div class="panel-heading">
                <strong>Brands</strong>
            </div>
            <asp:UpdatePanel ID="UpdatePanelFilterBrands" runat="server" class="panel"
                UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="panel-body">
                        <asp:CheckBoxList ID="CheckBoxBrands" runat="server" DataTextField="BrandName" DataValueField="BrandId" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxBrands_SelectedIndexChanged"></asp:CheckBoxList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel ID="UpdatePanelListComputers" runat="server">
            <ContentTemplate>
           <%-- <ninja:ErrorSuccessNotifier runat="server" ID="ErrorSuccessNotifier" />--%>
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
                                        <h4><%#: Item.Model %></h4>
                                        <img src="<%#: Item.PictureLink %>" alt="<%#: Item.Model %>" />
                                        <br />
                                        <br />
                                        <div><%#: Item.Price %> лв.</div>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
