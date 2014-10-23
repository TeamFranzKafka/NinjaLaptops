<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LaptopDetails.aspx.cs" Inherits="NinjaLaptops.WebClient.LaptopDetails" %>

<%@ Register Src="~/Controls/ProductView.ascx" TagPrefix="uc1" TagName="ProductView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ProductView runat="server" ID="ProductViewLaptop" />
</asp:Content>
