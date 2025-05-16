using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Basics_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind data to FormView
            EmployeeFormView.DataSource = GetEmployee();
            EmployeeFormView.DataBind();
        }
    }

    private DataTable GetEmployee()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("EmployeeID", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Department", typeof(string));
        dt.Columns.Add("Salary", typeof(decimal));

        // Sample data (single record)
        dt.Rows.Add(101, "John Doe", "IT", 75000);

        return dt;
    }

    protected void EmployeeFormView_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        // Switch FormView mode (e.g., ReadOnly to Edit)
        EmployeeFormView.ChangeMode(e.NewMode);
        EmployeeFormView.DataSource = GetEmployee();
        EmployeeFormView.DataBind();
    }

    protected void EmployeeFormView_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        // Retrieve updated values
        string name = ((TextBox)EmployeeFormView.FindControl("NameTextBox")).Text;
        string department = ((TextBox)EmployeeFormView.FindControl("DepartmentTextBox")).Text;
        decimal salary;
        bool isSalaryValid = decimal.TryParse(((TextBox)EmployeeFormView.FindControl("SalaryTextBox")).Text, out salary);

        if (!isSalaryValid)
        {
            // Handle invalid salary input (e.g., show error)
            return;
        }

        // Simulate updating the database
        // In a real app, update the database here using ADO.NET or Entity Framework

        // Switch back to ReadOnly mode
        EmployeeFormView.ChangeMode(FormViewMode.ReadOnly);
        EmployeeFormView.DataSource = GetEmployee(); // Refresh data
        EmployeeFormView.DataBind();
    }
}