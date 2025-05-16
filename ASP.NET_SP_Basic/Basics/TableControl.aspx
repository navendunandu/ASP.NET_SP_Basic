<%@ Page Title="" Language="C#" MasterPageFile="~/Basics/BasicMaster.master" AutoEventWireup="true" CodeFile="TableControl.aspx.cs" Inherits="Basics_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 91px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table class="style1">
        <tr>
            <td class="style2">
                RollNumber</td>
            <td>
                <asp:TextBox ID="txtroll" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Name</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Mark</td>
            <td>
                <asp:TextBox ID="txtmark" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
               <asp:Table ID="Table1" runat="server" BorderColor="DarkGreen" BorderWidth="1">  
                <asp:TableHeaderRow ForeColor="SeaGreen">  
                    <asp:TableHeaderCell>RollNumber</asp:TableHeaderCell>  
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>  
                    <asp:TableHeaderCell>Mark</asp:TableHeaderCell>  
                </asp:TableHeaderRow>  
               
                <asp:TableRow>  
                    <asp:TableCell>1</asp:TableCell>  
                    <asp:TableCell>ss</asp:TableCell>  
                    <asp:TableCell>33</asp:TableCell>
                </asp:TableRow>  
                
                </asp:Table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

