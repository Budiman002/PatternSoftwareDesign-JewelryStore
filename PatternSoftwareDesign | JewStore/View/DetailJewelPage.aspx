<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="DetailJewelPage.aspx.cs" Inherits="ProjectLabPSD.View.DetailJewelPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; gap: 0vh; justify-content: center; align-items: center; height: 93vh ; margin: 0; width: 100vw; margin-top: 12vh; ">
        <h1>Jewel Detail</h1>

        <div style="display: flex; flex-direction: column; gap: 3vh; justify-content: center; align-items: center; font-size: 20px;">
            <asp:Label ID="lblJewelName" runat="server" />
            <asp:Label ID="lblCategory" runat="server" />
            <asp:Label ID="lblBrand" runat="server" />
            <asp:Label ID="lblCountry" runat="server" />
            <asp:Label ID="lblClass" runat="server" />
            <asp:Label ID="lblPrice" runat="server" />
            <asp:Label ID="lblYear" runat="server" />
        </div>

        <div style="display: flex; justify-content: center; width: 100%; font-size: 20px; padding-top: 2vh;">
            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" Visible="false" OnClick="btnAddToCart_Click" Width="150px" Height="60px" Font-Size="Medium"/>
        </div>

        <div style="display:flex; flex-direction:row; justify-content: center; font-size: 20px;  width: 100%; padding: 20px">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="false" OnClick="btnEdit_Click" Width="150px" Height="60px" Font-Size="Medium"/>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" OnClick="btnDelete_Click" Width="150px" Height="60px" Font-Size="Medium" />
        </div>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
    </div>
</asp:Content>
