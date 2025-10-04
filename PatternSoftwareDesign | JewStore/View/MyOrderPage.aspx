<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="MyOrderPage.aspx.cs" Inherits="ProjectLabPSD.View.MyOrderPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; margin-top: 80px; justify-content: center;">My Order Transactions</h1>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" />

    <div style="width: 100%; margin-top: 0px; display: flex; justify-content: center;">
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" OnRowCommand="gvOrders_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}" />
                <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnDetail" runat="server" Text="View Detail"
                            CommandName="ViewDetail" CommandArgument='<%# Eval("TransactionID") %>' />

                        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Package"
                            CommandName="Confirm" CommandArgument='<%# Eval("TransactionID") %>'
                            Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />

                        <asp:Button ID="btnReject" runat="server" Text="Reject Package"
                            CommandName="Reject" CommandArgument='<%# Eval("TransactionID") %>'
                            Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
