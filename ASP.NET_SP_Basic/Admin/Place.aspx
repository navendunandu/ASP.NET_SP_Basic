<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Place.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container mt-5">
        <div class="card mx-auto shadow" style="max-width: 600px;">
            <div class="card-header text-center bg-primary text-white">
                <h4>Manage District</h4>
            </div>
            <div class="card-body">
    <table class="table table-hover">
        <tr>
            <td>District</td>
            <td>
                <asp:DropDownList CssClass="form-select" ID="sel_dist" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Place</td>
            <td>
                <asp:TextBox CssClass="form-control" ID="txt_place" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btn_submit" CssClass="btn btn-success" runat="server" OnClick="btn_submit_Click" Text="Submit" />
            </td>
        </tr>
    </table>
                </div>
        </div>
        <div class="my-5">
    <asp:GridView ID="grdPlace" runat="server" AutoGenerateColumns="False" OnRowCommand="grdPlace_RowCommand" OnRowDataBound="grdPlace_RowDataBound"
                CssClass="table table-bordered table-striped table-hover"
                HeaderStyle-CssClass="thead-dark"
                PagerStyle-CssClass="pagination">
        <Columns>
            <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <asp:Label ID="lblSerial" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
            <asp:BoundField DataField="place_name" HeaderText="Place" />
            <asp:BoundField DataField="district_name" HeaderText="District" />
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-primary" ID="btn_edit" runat="server" CommandArgument='<%# Eval("place_id") %>' Text="Edit" CommandName="EditPlace"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btn_delete" CssClass="btn btn-danger" runat="server" CommandArgument='<%# Eval("place_id") %>' CommandName="DeletePlace" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </div>

    </div>
</asp:Content>

