<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="ProjectLabPSD.View.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; margin-top: 80px; justify-content: center;">Transaction Detail</h1>

    <div style="margin-top: 0px; display: flex; flex-direction:column; justify-content: center; align-items: center; font-size: 15px;">
        <p><strong>Transaction ID:</strong> <asp:Label ID="lblID" runat="server" /></p>
        <p><strong>Date:</strong> <asp:Label ID="lblDate" runat="server" /></p>
        <p><strong>Status:</strong> <asp:Label ID="lblStatus" runat="server" /></p>
    </div>

    <div style="width: 100%; margin-top: 0px; display: flex; justify-content: center;">
        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="JewelName" HeaderText="Jewel" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
            </Columns>
        </asp:GridView>
    </div>

    <div style="display: flex; flex-direction:column; justify-content: center; align-items: center; font-size: 20px;">
        <p><strong>Total:</strong> <asp:Label ID="lblTotal" runat="server" /></p>
    </div>
</asp:Content>
