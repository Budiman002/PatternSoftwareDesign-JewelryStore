<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ProjectLabPSD.View.HomePage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 style="text-align: center; margin-top: 60px; justify-content: center;">Home Page</h1>
        
        <div style="width: 100%; margin-top: 0px; display: flex; justify-content: center;">
            <asp:GridView ID="JewelGridView" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" PageSize="5" OnPageIndexChanging="JewelGridView_PageIndexChanging" style="width: 100%;">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>

                            <div style="border: 1px solid #ddd; border-radius: 10px; padding: 15px; width: 100%; box-shadow: 0 7px 10px rgba(0,0,0,0.1); transition: transform 0.3s; height: 100%; margin-bottom: 40px;">
                                <div style="margin-bottom: 15px; display: flex; flex-direction: row; justify-content: space-between">
                                    <div style="margin-bottom: 5px;">ID: <%# Eval("JewelID") %></div>
                                    <div style="font-size: 18px; font-weight: bold; margin-bottom: 5px;"><%# Eval("JewelName") %></div>
                                    <div style="font-size: 16px; font-weight: bold; color: #3a7b4c;">$<%# Eval("JewelPrice", "{0:N0}") %></div>
                                </div>

                                <a href='DetailJewelPage.aspx?JewelID=<%# Eval("JewelID") %>' style="display: block; width: 60%; padding: 8px; 
                                        background-color: #d01010; color: white; text-align: center; border-radius: 4px; cursor: pointer; text-decoration: none; justify-self:center">
                                    Details
                                </a>
                            </div>

                        </ItemTemplate>
                        <ItemStyle Width="30%" />
                    </asp:TemplateField>
                </Columns>

                <EmptyDataTemplate>
                    <div style="text-align: center; padding: 40px; color: #666; font-style: italic;">No jewelry available.</div>
                </EmptyDataTemplate>

                <PagerStyle CssClass="SwitchPage" />
            </asp:GridView>
        </div>
    </div>

    <style>
        .SwitchPage {
            text-align: center;
            margin-top: 20px;
        }
        .SwitchPage a {
            padding: 5px 10px;
            margin: 0 2px;
            border: 1px solid #ddd;
            border-radius: 3px;
            text-decoration: none;
            color: #d01010;
        }
        .SwitchPage a:hover {
            background-color: #f5f5f5;
        }
        .SwitchPage span {
            padding: 5px 10px;
            margin: 0 2px;
            border: 1px solid #d01010;
            border-radius: 3px;
            background-color: #d01010;
            color: white;
        }
    </style>
</asp:Content>