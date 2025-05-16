<%@ Page Title="" Language="C#" MasterPageFile="~/Basics/BasicMaster.master" AutoEventWireup="true" CodeFile="Multiview.aspx.cs" Inherits="Basics_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView runat="server" ID="multiview" ActiveViewIndex="0">
        <asp:View ID="view1" runat="server" >
            <h1 align="center">Welcome</h1>
            <asp:Button text="Next" ID="btn_next1" runat="server" OnClick="btn_next1_Click"/>
        </asp:View>
        <asp:View ID="view2" runat="server" >
            <h1 align="center">Home</h1>
            <asp:Button text="Next" ID="btn_next2" runat="server" OnClick="btn_next2_Click"/>
        </asp:View>
        <asp:View ID="view3" runat="server" >
            <h1 align="center">Hooman</h1>
        </asp:View>
    </asp:MultiView>
</asp:Content>

