<%@ Page Title="" Language="C#" MasterPageFile="~/Basics/BasicMaster.master" AutoEventWireup="true" CodeFile="FormView.aspx.cs" Inherits="Basics_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .form-container { width: 350px; padding: 15px; border: 1px solid #ddd; border-radius: 5px; }
        .form-field { margin-bottom: 12px; }
        .form-field label { display: inline-block; width: 100px; }
        .form-field input { width: 200px; }
        .button { margin-right: 10px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Employee Details</h2>
            <asp:FormView ID="EmployeeFormView" runat="server" DataKeyNames="EmployeeID"
                OnItemUpdating="EmployeeFormView_ItemUpdating" OnModeChanging="EmployeeFormView_ModeChanging">
                <ItemTemplate>
                    <div class="form-container">
                        <div class="form-field">
                            <label>ID:</label>
                            <%# Eval("EmployeeID") %>
                        </div>
                        <div class="form-field">
                            <label>Name:</label>
                            <%# Eval("Name") %>
                        </div>
                        <div class="form-field">
                            <label>Department:</label>
                            <%# Eval("Department") %>
                        </div>
                        <div class="form-field">
                            <label>Salary:</label>
                            $<%# Eval("Salary") %>
                        </div>
                        <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" CssClass="button" />
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div class="form-container">
                        <div class="form-field">
                            <label>ID:</label>
                            <%# Eval("EmployeeID") %>
                        </div>
                        <div class="form-field">
                            <label>Name:</label>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </div>
                        <div class="form-field">
                            <label>Department:</label>
                            <asp:TextBox ID="DepartmentTextBox" runat="server" Text='<%# Bind("Department") %>' />
                        </div>
                        <div class="form-field">
                            <label>Salary:</label>
                            <asp:TextBox ID="SalaryTextBox" runat="server" Text='<%# Bind("Salary") %>' />
                        </div>
                        <asp:Button ID="UpdateButton" runat="server" Text="Update" CommandName="Update" CssClass="button" />
                        <asp:Button ID="CancelButton" runat="server" Text="Cancel" CommandName="Cancel" CssClass="button" />
                    </div>
                </EditItemTemplate>
            </asp:FormView>
</asp:Content>

