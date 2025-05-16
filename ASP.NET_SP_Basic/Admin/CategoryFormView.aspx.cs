using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-N4JNRRR;Initial Catalog=db_new;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con.Open();
            fillGrid();
            BindRepeater();
            // Initialize FormView with no data
            fvPlace.DataSource = null;
            fvPlace.DataBind();
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        using (SqlCommand cmd = new SqlCommand("insertCat", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("place", txt_place.Text);
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.ExecuteNonQuery();
            txt_place.Text = "";
            fillGrid();
            BindRepeater(); // Refresh Repeater
            string script = "alert('Place Submitted');";
            ClientScript.RegisterStartupScript(this.GetType(), "PlaceSubmitted", script, true);
        }
    }

    protected void fillGrid()
    {
        //using (SqlCommand cmd = new SqlCommand("fetchPlace", con))
        //{
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
        //    {
        //        DataTable dt = new DataTable();
        //        adp.Fill(dt);
        //        grdPlace.DataSource = dt;
        //        grdPlace.DataBind();
        //    }
        //}
    }

    protected void BindRepeater()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("fetchPlace", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    rptPlaces.DataSource = dt;
                    rptPlaces.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            string script = $"alert('Error: {ex.Message}');";
            ClientScript.RegisterStartupScript(this.GetType(), "Error", script, true);
        }
    }

    //protected void grdPlace_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        int serialNumber = e.Row.RowIndex + 1 + (grdPlace.PageSize * grdPlace.PageIndex);
    //        Label lblSerial = (Label)e.Row.FindControl("lblSerial");
    //        lblSerial.Text = serialNumber.ToString();
    //    }
    //}

    protected void grdPlace_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditPlace")
        {
            int placeId = Convert.ToInt32(e.CommandArgument);
            BindFormView(placeId);
        }
    }

    protected void rptPlaces_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditPlace")
        {
            int placeId = Convert.ToInt32(e.CommandArgument);
            BindFormView(placeId);
        }
    }

    private void BindFormView(int placeId)
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("SELECT place_id, place_name FROM tbl_place WHERE place_id = @place_id", con))
            {
                cmd.Parameters.AddWithValue("@place_id", placeId);
                if (con.State != ConnectionState.Open)
                    con.Open();
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    fvPlace.DataSource = dt;
                    fvPlace.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            string script = $"alert('Error: {ex.Message}');";
            ClientScript.RegisterStartupScript(this.GetType(), "Error", script, true);
        }
    }

    protected void fvPlace_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        fvPlace.ChangeMode(e.NewMode);
        if (e.NewMode == FormViewMode.Edit)
        {
            int placeId = (int)fvPlace.DataKey["place_id"];
            BindFormView(placeId);
        }
        else if (e.NewMode == FormViewMode.ReadOnly)
        {
            int placeId = (int)fvPlace.DataKey["place_id"];
            BindFormView(placeId);
        }
    }

    protected void fvPlace_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        int placeId = (int)fvPlace.DataKey["place_id"];
        string placeName = ((TextBox)fvPlace.FindControl("txtPlaceName")).Text;

        try
        {
            using (SqlCommand cmd = new SqlCommand("updatePlace", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@place_id", placeId);
                cmd.Parameters.AddWithValue("@place_name", placeName);
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd.ExecuteNonQuery();
            }

            fvPlace.ChangeMode(FormViewMode.ReadOnly);
            BindFormView(placeId);
            fillGrid();
            BindRepeater(); // Refresh Repeater
            string script = "alert('Place Updated');";
            ClientScript.RegisterStartupScript(this.GetType(), "PlaceUpdated", script, true);
        }
        catch (Exception ex)
        {
            string script = $"alert('Error: {ex.Message}');";
            ClientScript.RegisterStartupScript(this.GetType(), "Error", script, true);
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
            con.Close();
    }
}