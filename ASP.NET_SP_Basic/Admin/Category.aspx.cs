using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = DESKTOP-N4JNRRR;Initial Catalog=db_new;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        if (!IsPostBack)
        {
            fillGrid();
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
            SqlCommand cmd = new SqlCommand("insertCat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("place", txt_place.Text);
            cmd.ExecuteNonQuery();
            txt_place.Text = "";
            fillGrid();
            string script = "alert('Place Submitted');";
            ClientScript.RegisterStartupScript(this.GetType(), "PlaceSubmitted", script, true);   
    }

    protected void fillGrid()
    {
        SqlCommand cmd = new SqlCommand("fetchPlace", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        grdPlace.DataSource = dt;
        grdPlace.DataBind();
    }

    protected void grdPlace_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Calculate serial number considering page index
            int serialNumber = e.Row.RowIndex + 1 + (grdPlace.PageSize * grdPlace.PageIndex);
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = serialNumber.ToString();
        }
    }

    protected void grdPlace_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}