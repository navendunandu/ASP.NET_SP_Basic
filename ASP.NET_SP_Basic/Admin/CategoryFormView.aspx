<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="CategoryFormView.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .repeater-container { max-width: 600px; margin: 20px auto; }
        .header { background-color: #007bff; color: white; padding: 10px; font-weight: bold; text-align: center; }
        .item { border: 1px solid #ddd; padding: 10px; margin: 5px 0; background-color: #f9f9f9; }
        .alternate-item { border: 1px solid #ddd; padding: 10px; margin: 5px 0; background-color: #e9ecef; }
        .separator { border-top: 1px dashed #ccc; margin: 5px 0; }
        .footer { text-align: center; font-style: italic; color: #666; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container mt-5">
        <!-- Insert Place Form -->
        <div class="card mx-auto shadow" style="max-width: 600px;">
            <div class="card-header text-center bg-primary text-white">
                <h4>Manage Place</h4>
            </div>
            <div class="card-body">
                <table class="table table-hover">
                    <tr>
                        <td>Place</td>
                        <td>
                            <asp:TextBox ID="txt_place" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Button ID="btn_submit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <!-- FormView for Editing Place -->
        <div class="card mx-auto shadow mt-4" style="max-width: 600px;">
            <div class="card-header text-center bg-info text-white">
                <h4>Edit Place</h4>
            </div>
            <div class="card-body">
                <asp:FormView ID="fvPlace" runat="server" DataKeyNames="place_id"
                    OnItemUpdating="fvPlace_ItemUpdating" OnModeChanging="fvPlace_ModeChanging"
                    DefaultMode="ReadOnly">
                    <ItemTemplate>
                        <table class="table table-hover">
                            <tr>
                                <td><strong>ID:</strong></td>
                                <td><%# Eval("place_id") %></td>
                            </tr>
                            <tr>
                                <td><strong>Place:</strong></td>
                                <td><%# Eval("place_name") %></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-primary" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <table class="table table-hover">
                            <tr>
                                <td><strong>ID:</strong></td>
                                <td><%# Eval("place_id") %></td>
                            </tr>
                            <tr>
                                <td><strong>Place:</strong></td>
                                <td>
                                    <asp:TextBox ID="txtPlaceName" runat="server" Text='<%# Bind("place_name") %>' CssClass="form-control" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="UpdateButton" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-success" />
                                    <asp:Button ID="CancelButton" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-secondary" />
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <div class="text-center">Select a place to edit.</div>
                    </EmptyDataTemplate>
                </asp:FormView>
            </div>
        </div>

        <!-- Repeater for Listing Places -->
        <div class="repeater-container my-5">
            <h3>Places List (Repeater)</h3>
            <asp:Repeater ID="rptPlaces" runat="server" OnItemCommand="rptPlaces_ItemCommand">
                <HeaderTemplate>
                    <div class="header">
                        <span style="width: 100px; display: inline-block;">S.No</span>
                        <span style="width: 200px; display: inline-block;">Place ID</span>
                        <span style="width: 200px; display: inline-block;">Place Name</span>
                        <span>Action</span>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="item">
                        <span style="width: 100px; display: inline-block;"><%# Container.ItemIndex + 1 %></span>
                        <span style="width: 200px; display: inline-block;"><%# Eval("place_id") %></span>
                        <span style="width: 200px; display: inline-block;"><%# Eval("place_name") %></span>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditPlace" CommandArgument='<%# Eval("place_id") %>' CssClass="btn btn-sm btn-primary" />
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="alternate-item">
                        <span style="width: 100px; display: inline-block;"><%# Container.ItemIndex + 1 %></span>
                        <span style="width: 200px; display: inline-block;"><%# Eval("place_id") %></span>
                        <span style="width: 200px; display: inline-block;"><%# Eval("place_name") %></span>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditPlace" CommandArgument='<%# Eval("place_id") %>' CssClass="btn btn-sm btn-primary" />
                    </div>
                </AlternatingItemTemplate>
                <SeparatorTemplate>
                    <div class="separator"></div>
                </SeparatorTemplate>
                <FooterTemplate>
                    <div class="footer">End of Places List</div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>