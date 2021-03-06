﻿<%@ Page Title="" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="OrderDetails.aspx.cs"
    Inherits="NinjaLaptops.WebClient.OrderDetails" %>

<%@ Register Src="~/Notifier/ErrorSuccessNotifier/ErrorSuccessNotifier.ascx" TagPrefix="ninja" TagName="ErrorSuccessNotifier" %>


<asp:Content ID="ContentOrderDetails" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" class="panel"
                UpdateMode="Conditional">
                <ContentTemplate>   
                    <div id="orders">
                        <ninja:ErrorSuccessNotifier runat="server" ID="ErrorSuccessNotifier" />
                        <asp:GridView ID="GridViewOrderedProducts" runat="server"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            PageSize="5"
                            ItemType="NinjaLaptops.Models.Product"
                            AllowSorting="true"
                            GridLines="None"
                            ShowFooter="True"
                            CellPadding="7"
                            ForeColor="#333333"
                            SelectMethod="GridViewOrderedProducts_GetData"
                            OnRowDataBound="GridViewOrderedProducts_RowDataBound">

                            <Columns>
                                <asp:TemplateField HeaderText="Brand">
                                    <ItemTemplate>
                                        <strong><%#Eval("Brand.BrandName") %></strong>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />

                                <asp:TemplateField HeaderText="Picture" FooterText="Total:">
                                    <ItemTemplate>
                                        <img  src='<%#Eval("PictureLink") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:c}" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButtonDeleteOrder"
                                            runat="server"
                                            Text="Remove"
                                            CommandArgument="<%# Item.ProductId %>"
                                            OnClientClick="return confirm('Do you want to delete?');"
                                            OnCommand="LinkButtonDeleteOrder_Command" CssClass="btn btn-danger"/>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <asp:Button ID="ButtonBuyOrder" Text="Buy" runat="server" CssClass="btn btn-success" OnClick="ButtonBuyOrder_Click" />
                   
                </ContentTemplate>
            </asp:UpdatePanel>
        </LoggedInTemplate>
                    
                
        <AnonymousTemplate>
            <div class="jumbotron">
                <h1>You are not logged in!</h1>
            </div>
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>
