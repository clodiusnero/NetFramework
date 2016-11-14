<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductDetails.aspx.cs" Inherits="store.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" ItemType="store.Models.Product" SelectMethod ="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ProductName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Images/<%#:Item.ImagePath %>" style="border:none; width:487px; height:609px" alt="<%#:Item.ProductName %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <span>Tag:&nbsp;<%#:Item.Tag %></span>
                        <br />
                        <span>Size:&nbsp;<%#:Item.Size %></span>
                        <br />
                        <br />
                        <b>Description</b><br /><%#:Item.Description %>
                        <br />
                        <br />
                        <b>Details</b><br /><%#:Item.Details %>
                        <br />
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></span>
                        <br />
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.ProductID %></span>
                        <br />
                        <br />
                        <a href="/AddToCart.aspx?productID=<%#:Item.ProductID %>">               
                            <span class="ProductListItem"><b>Add To Cart<b></span> 
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>