<%@ Page Title="" Language="C#" MasterPageFile="~/Basics/BasicMaster.master" AutoEventWireup="true" CodeFile="DataList.aspx.cs" Inherits="Basics_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .product-item {
            border: 1px solid #ccc;
            padding: 10px;
            margin: 5px;
            width: 200px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
            <h2>Product List</h2>
            <asp:DataList ID="ProductDataList" runat="server" RepeatColumns="4" RepeatDirection="Vertical">
                <ItemTemplate>
                    <div class="product-item">
                        <h4><%# Eval("ProductName") %></h4>
                        <p>Price: $<%# Eval("Price") %></p>
                        <p>Category: <%# Eval("Category") %></p>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
</asp:Content>

