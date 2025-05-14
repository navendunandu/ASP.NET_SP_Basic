<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="District.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                            <asp:TextBox ID="txt_district" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Button ID="btn_submit" CssClass="btn btn-success" runat="server" Style="text-align: center" Text="Submit" OnClick="btn_submit_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="my-5">
            <asp:GridView ID="grdDistrict" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                OnRowCommand="grdDistrict_RowCommand"
                OnRowDataBound="grdDistrict_RowDataBound"
                CssClass="table table-bordered table-striped table-hover"
                HeaderStyle-CssClass="thead-dark"
                PagerStyle-CssClass="pagination">

                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <asp:Label ID="lblSerial" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="District" DataField="district_name" />

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-sm btn-primary" ID="Edit" runat="server"
                                CommandArgument='<%# Eval("district_id") %>' CommandName="EditDist" Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-sm btn-danger" ID="btn_delete" runat="server"
                                CommandArgument='<%# Eval("district_id") %>' CommandName="DeleteDist" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>

