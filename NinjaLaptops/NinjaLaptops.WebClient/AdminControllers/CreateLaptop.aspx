<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateLaptop.aspx.cs" Inherits="NinjaLaptops.WebClient.AdminControllers.CreateLaptop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Laptop</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="laptopForm">
                <div class="form-horizontal">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Model" CssClass="col-md-2 control-label">Model:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Model" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Model"
                                CssClass="text-danger" ErrorMessage="The model field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Price" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Price" CssClass="text-danger" ErrorMessage="The price field is required." />
                        </div>
                    </div>
                   <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="DropDownListBrands" CssClass="col-md-2 control-label">Brand:</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="DropDownListBrands" DataTextField="BrandName" DataValueField="BrandId" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListBrands" CssClass="text-danger" ErrorMessage="The brand field is required." />
                        </div>
                    </div>
                   <%-- <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="Create" Text="Create Laptop" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
                </p>
            </section>
        </div>
    </div>
</asp:Content>
