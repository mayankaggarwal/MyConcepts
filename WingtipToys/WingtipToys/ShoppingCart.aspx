<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WingtipToys.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
    <asp:GridView ID="CartList" runat="server" 
        AutoGenerateColumns="FALSE" 
        ShowFooter="true" 
        GridLines="Vertical" 
        CellPadding="4" 
        ItemType="WingtipToys.Models.CartItem" 
        SelectMethod="GetShoppingCartItems" 
        CssClass="table table-stripped table-ordered">
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="ID" SortExpression="ProductId" />
            <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />
            <asp:BoundField DataField="Product.UnitPrice" HeaderText="Unit Price" DataFormatString="{0:c}" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantity %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item Total">
                <ItemTemplate>
                    <%#: string.Format("{0:c}",((Convert.ToDouble(Item.Quantity)) * (Convert.ToDouble(Item.Product.UnitPrice)))) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
         <div>
             <p></p>
             <strong>
                 <asp:Label ID="LabelTotalText" runat="server" Text="Order Total:"></asp:Label>
                 <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
             </strong>
         </div>
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
            </td>
            <td>
                <asp:ImageButton ID="CheckoutImageBtn" runat="server" 
                    ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" 
                    Width="145" 
                    AlternateText="Check out with PayPal" 
                    OnClick="CheckoutImageBtn_Click" 
                    BackColor="Transparent" BorderWidth="0" />
            </td>
        </tr>
    </table>
</asp:Content>
