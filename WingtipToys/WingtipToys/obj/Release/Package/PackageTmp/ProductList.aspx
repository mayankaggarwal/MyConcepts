<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="WingtipToys.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <asp:ListView ID="productList" runat="server" DataKeyNames="ProductID" GroupItemCount="4" ItemType="WingtipToys.Models.Product" SelectMethod="GetProducts">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>Mo Data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td></td>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceHolderContainer" runat="server">
                        <td id="itemPlaceHolder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productID=<%#:Item.ProductID %>">
                                        <img src="/Catalog/Images/Thumbs/<%#:Item.ImagePath %>" width="100" height="75" style="border: solid" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productID=<%#:Item.ProductID %>">
                                        <span>
                                            <%#:Item.ProductName %>
                                        </span>
                                        </a>
                                        <br />
                                        <span>
                                            <b>Price: </b><%#:String.Format("{0:c}",Item.UnitPrice) %>
                                        </span>
                                        <br />
                                    <a href="/AddToCart.aspx?productId=<%#: Item.ProductID %>">
                                        <span class="ProductListItem">
                                            <b>Add To Cart</b>
                                        </span>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <p></p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceHolderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceHolder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
