<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LaptopDetails.aspx.cs" Inherits="NinjaLaptops.WebClient.LaptopDetails" %>

<%@ Register Src="~/Controls/ProductView.ascx" TagPrefix="uc1" TagName="ProductView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ProductView runat="server" ID="ProductViewLaptop" />
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <RoleGroups>
            <asp:RoleGroup Roles="admin">
                <ContentTemplate>
                    <div class="text-center">
                        <asp:Button ID="ButtonEditProduct" CssClass="btn btn-success" Text="Edit" runat="server" OnClick="ButtonEditProduct_Click" />
                        <asp:Button ID="ButtonDeleteProduct" CssClass="btn btn-danger" Text="Delete" runat="server" OnClientClick="return confirm('Do you want to delete?');" OnClick="ButtonDeleteProduct_Click" />
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>
