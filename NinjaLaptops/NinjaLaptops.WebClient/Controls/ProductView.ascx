<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductView.ascx.cs" Inherits="NinjaLaptops.WebClient.Controls.ProductView" %>

<asp:DetailsView runat="server"
    ID="DetailsViewLaptop"
    AutoGenerateRows="false"
    AutoGenerateColumns="false"
    ItemType="NinjaLaptops.Models.Product">
    <Fields>
        <asp:TemplateField>
            <ItemTemplate>
                <img src="<%# Item.PictureLink %>" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
               <strong>Model: </strong> <%# Item.Model %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
               <strong>Price: </strong> <%# Item.Price %>
            </ItemTemplate>

        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
              <strong>Brand: </strong> <%# Item.Brand.BrandName %>
            </ItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>




