using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Basics_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind data to DataList
            ProductDataList.DataSource = GetProducts();
            ProductDataList.DataBind();
        }
    }

    private DataTable GetProducts()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ProductName", typeof(string));
        dt.Columns.Add("Price", typeof(decimal));
        dt.Columns.Add("Category", typeof(string));

        // Sample data
        dt.Rows.Add("Laptop", 999.99, "Electronics");
        dt.Rows.Add("Smartphone", 499.99, "Electronics");
        dt.Rows.Add("Headphones", 79.99, "Accessories");
        dt.Rows.Add("Desk Chair", 149.99, "Furniture");
        dt.Rows.Add("Mouse", 29.99, "Accessories");

        return dt;
    }
}