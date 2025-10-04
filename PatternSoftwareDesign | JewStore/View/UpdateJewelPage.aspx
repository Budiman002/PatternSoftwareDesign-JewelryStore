<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateJewelPage.aspx.cs" Inherits="ProjectLabPSD.View.UpdateJewelPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; gap: 2vh; justify-content: center; align-items: center; height: 93vh ; margin: 0; width: 100vw; margin-top: 12vh; ">
        <h1>Update Jewel</h1>

        <div style="display: flex; flex-direction: column; gap: 0vh; justify-content: center; align-items: center; font-size: 23px;">
            <label>Jewel Name:</label>
            <asp:TextBox ID="txtName" runat="server" />
        </div>

        <div style="font-size: 23px;">
            <label>Category:</label>
            <asp:DropDownList ID="ddlCategory" runat="server" />
        </div>

        <div style="font-size: 23px;">
            <label>Brand:</label>
            <asp:DropDownList ID="ddlBrand" runat="server" />
        </div>

        <div style="display: flex; flex-direction: column; gap: 0vh; justify-content: center; align-items: center; font-size: 23px;">
            <label>Price:</label>
            <asp:TextBox ID="txtPrice" runat="server" />
        </div>

        <div style="display: flex; flex-direction: column; gap: 0vh; justify-content: center; align-items: center; font-size: 23px;">
            <label>Release Year:</label>
            <asp:TextBox ID="txtYear" runat="server" />
        </div>

        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="Update Jewel" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="~/View/HomePage.aspx" />

        <asp:Label ID="lblError" runat="server" ForeColor="Red" />
    </div>
</asp:Content>
