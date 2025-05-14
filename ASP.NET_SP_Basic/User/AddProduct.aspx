<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100px;
            border-style: solid;
            border-width: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container mt-5">
        <div class="card mx-auto shadow" style="max-width: 600px;">
            <div class="card-header text-center bg-primary text-white">
                <h4>Manage Products</h4>
            </div>
            <div class="card-body">
                <table align="center" class="table table-hover">
                    <tr>
                        <td colspan="2">
                            <asp:FileUpload runat="server" ID="file_product" CssClass="form-control"/></td>
                    </tr>
                    <tr>
                        <td>Product</td>
                        <td>
                            <asp:TextBox ID="txt_product" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Description</td>
                        <td>
                            <asp:TextBox ID="txt_desc" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Category</td>
                        <td>
                            <asp:DropDownList ID="sel_cat" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Price</td>
                        <td>
                            <asp:TextBox ID="txt_price" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btn_submit_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

