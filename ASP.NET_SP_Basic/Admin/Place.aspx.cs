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
    static int editId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        if (!IsPostBack)
        {
            fillDist();
            fillGrid();
        }
    }

    protected void fillDist()
    {
        SqlCommand cmd = new SqlCommand("selectDistrict", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        sel_dist.DataSource = dt;
        sel_dist.DataTextField = "district_name";
        sel_dist.DataValueField = "district_id";
        sel_dist.DataBind();
        sel_dist.Items.Insert(0,"Select District");
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

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (editId == 0)
        {
            SqlCommand cmd = new SqlCommand("insertPlace", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("place", txt_place.Text);
            cmd.Parameters.AddWithValue("districtId", sel_dist.SelectedValue);
            cmd.ExecuteNonQuery();
        }
        else
        {
            SqlCommand cmd = new SqlCommand("updatePlace", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("place", txt_place.Text);
            cmd.Parameters.AddWithValue("districtId", sel_dist.SelectedValue);
            cmd.Parameters.AddWithValue("id", editId);
            cmd.ExecuteNonQuery();
        }
        txt_place.Text = "";
        sel_dist.SelectedIndex = 0;
        fillGrid();
    }

    protected void grdPlace_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int placeId = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "DeletePlace")
        {
            SqlCommand cmd = new SqlCommand("deletePlace", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", placeId);
            cmd.ExecuteNonQuery();
            fillGrid();
            string script = "alert('Place Deleted');";
            ClientScript.RegisterStartupScript(this.GetType(), "PlaceDeleted", script, true);
        }
        else
        {
            SqlCommand cmd = new SqlCommand("getPlace", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", placeId);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txt_place.Text = dt.Rows[0]["place_name"].ToString();
            sel_dist.SelectedValue= dt.Rows[0]["district_id"].ToString();
            editId = placeId;
        }
    }
}