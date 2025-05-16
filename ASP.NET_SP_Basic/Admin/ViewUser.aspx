<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewUser.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater runat="server">
        <HeaderTemplate>
            User List
        </HeaderTemplate>
        <ItemTemplate>
            <div>
                <h3>

                </h3>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

