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
            fillGrid();
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (editId == 0)
        {
            SqlCommand cmd = new SqlCommand("createDistrict", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("district", txt_district.Text);
            cmd.ExecuteNonQuery();
            txt_district.Text = "";
            fillGrid();
            string script = "alert('District Submitted');";
            ClientScript.RegisterStartupScript(this.GetType(), "DistrictSubmitted", script, true);
        }
        else
        {
            SqlCommand cmd = new SqlCommand("updateDistrict", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("district", txt_district.Text);
            cmd.Parameters.AddWithValue("id", editId);
            cmd.ExecuteNonQuery();
            fillGrid();
            editId = 0;
            txt_district.Text = "";
            string script = "alert('District Updated');";
            ClientScript.RegisterStartupScript(this.GetType(), "DistrictUpdated", script, true);
        }
    }

    protected void fillGrid()
    {
        SqlCommand cmd = new SqlCommand("selectDistrict", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        grdDistrict.DataSource = dt;
        grdDistrict.DataBind();
    }

    protected void grdDistrict_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Calculate serial number considering page index
            int serialNumber = e.Row.RowIndex + 1 + (grdDistrict.PageSize * grdDistrict.PageIndex);
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = serialNumber.ToString();
        }
    }

    protected void grdDistrict_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int districtId = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "DeleteDist")
        {
            SqlCommand cmd = new SqlCommand("deleteDistrict", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", districtId);
            cmd.ExecuteNonQuery();
            fillGrid();
            string script = "alert('District Deleted');";
            ClientScript.RegisterStartupScript(this.GetType(), "DistrictDeleted", script, true);
        }
        else
        {
            SqlCommand cmd = new SqlCommand("getDistrict", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", districtId);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txt_district.Text = dt.Rows[0]["district_name"].ToString();
            editId = districtId;
        }
    }
    }