using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class User_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = DESKTOP-N4JNRRR;Initial Catalog=db_new;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        if (!IsPostBack)
        {
            fillDropDown();
        }
    }

    protected void fillDropDown()
    {
        SqlCommand cmd = new SqlCommand("fetchCat", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        sel_cat.DataSource = dt;
        sel_cat.DataTextField = "category_name";
        sel_cat.DataValueField = "category_id";
        sel_cat.DataBind();
        sel_cat.Items.Insert(0, "Select Category");
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("createProduct", con);
        cmd.CommandType = CommandType.StoredProcedure;
        string photoName = Path.GetFileName(file_product.PostedFile.FileName.ToString());
        file_product.SaveAs(Server.MapPath("../Assets/Files/Product/" + photoName));
        cmd.Parameters.AddWithValue("product", txt_product.Text);
        cmd.Parameters.AddWithValue("price", txt_price.Text);
        cmd.Parameters.AddWithValue("description", txt_desc.Text);
        cmd.Parameters.AddWithValue("image", txt_desc.Text);
        cmd.Parameters.AddWithValue("category", sel_cat.SelectedValue);
        cmd.ExecuteNonQuery();
        txt_desc.Text = "";
        txt_price.Text = "";
        txt_product.Text = "";
        sel_cat.SelectedIndex = 0;
        string script = "alert('Product Submitted');";
        ClientScript.RegisterStartupScript(this.GetType(), "ProductSubmitted", script, true);
    }
}