<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="store.Checkout.CheckoutReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <h1>Order Review</h1>
    <p></p>
    <p></p>
    <p></p>
    <h2>Cart</h2>
    <h3 style="padding-left: 33px">Products:</h3>
            <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="store.Models.CartProduct" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />        
        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />        
        <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}"/>     
        <asp:TemplateField   HeaderText="Quantity">            
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantity %>"></asp:TextBox> 
                </ItemTemplate>        
        </asp:TemplateField>    
        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Product.UnitPrice)))%>
                </ItemTemplate>        
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Remove Item">            
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>        
        </asp:TemplateField>    
        </Columns>    
    </asp:GridView>
        <h2>Your Information</h2>
        <div>
            <table>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="userFirstName" runat ="Server"></asp:TextBox>
                    </td>
                </tr>
                      <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="userLastName" runat ="Server"></asp:TextBox>
                    </td>
                </tr>
                      <tr>
                    <td>Adress</td>
                    <td>
                        <asp:TextBox ID="userAdress" runat ="Server"></asp:TextBox>
                    </td>
                </tr>
                      <tr>
                    <td>City</td>
                    <td>
                        <asp:TextBox ID="userCity" runat ="Server"></asp:TextBox>
                    </td>
                </tr>
                      <tr>
                    <td>Postal Code</td>
                    <td>
                        <asp:TextBox ID="userPostal" runat ="Server"></asp:TextBox>
                    </td>
                </tr>
                                      <tr>
                    <td>Phone</td>
                    <td>
                        <asp:TextBox ID="userPhone" runat ="Server"></asp:TextBox>
                    </td>
                </tr>
                                      <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="userEmail" runat ="Server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    <p></p>
    <hr />
    <%--<asp:Button ID="CheckoutComplete" runat="server" Text="Submit Order" OnClick="CheckoutComplete_Click" />--%>
     </div>
    </asp:Content>