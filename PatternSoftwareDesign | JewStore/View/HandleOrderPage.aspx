<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="HandleOrderPage.aspx.cs" Inherits="ProjectLabPSD.View.HandleOrderPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; margin-top: 60px; justify-content: center;">Handle Orders</h1>
     
    <div style="width: 100%; margin-top: 0px; display: flex; justify-content: center;">
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" OnRowCommand="gvOrders_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnAction" runat="server" 
                        Text='<%# GetActionText(Eval("TransactionStatus").ToString()) %>'
                        CommandName="ChangeStatus"
                        CommandArgument='<%# Eval("TransactionID") %>' 
                        Visible='<%# Eval("TransactionStatus").ToString() != "Arrived" %>' />
                    <asp:Label runat="server" Text="Waiting for user confirmation..." 
                        Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
