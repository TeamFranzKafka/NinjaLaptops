<%@ Page Title="" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="OrderDetails.aspx.cs"
    Inherits="NinjaLaptops.WebClient.OrderDetails" %>

<asp:Content ID="ContentOrderDetails" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
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
                            <img src='<%#Eval("PictureLink") %>' runat="server" />
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
                                OnCommand="LinkButtonDeleteOrder_Command" />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Button ID="ButtonBuyOrder" Text="Buy" runat="server" OnClick="ButtonBuyOrder_Click" />
        </LoggedInTemplate>
        <AnonymousTemplate>
            <div class="jumbotron">
                <h1>You are not logged in!</h1>
            </div>
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>
