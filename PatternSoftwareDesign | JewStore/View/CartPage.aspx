<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="ProjectLabPSD.View.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center; margin-top: 80px; justify-content: center;">My Cart</h1>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" />

    <div style="width: 100%; margin-top: 0px; display: flex; justify-content: center;">
        <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCart_RowCommand">
            <Columns>
                <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
                <asp:BoundField DataField="JewelName" HeaderText="Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("Quantity") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateQty" CommandArgument='<%# Eval("JewelID") %>' />
                        <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="RemoveItem" CommandArgument='<%# Eval("JewelID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <hr />
    <p>Total: <asp:Label ID="lblTotal" runat="server" /></p>

    <asp:DropDownList ID="ddlPayment" runat="server" />
    <asp:Button ID="btnClear" runat="server" Text="Clear Cart" OnClick="btnClear_Click" />
    <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
</asp:Content>
