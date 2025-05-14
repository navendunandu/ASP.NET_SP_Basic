using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class User_Default : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection("Data Source = DESKTOP-N4JNRRR;Initial Catalog=db_new;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        if (!IsPostBack)
        {
            rvDob.MaximumValue = DateTime.Today.AddYears(-18).ToString("yyyy-MM-dd");
            fillDistrict();
            getUser();
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        // Register jQuery CDN for unobtrusive validation
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            CdnPath = "https://code.jquery.com/jquery-3.6.0.min.js",
            CdnDebugPath = "https://code.jquery.com/jquery-3.6.0.js",
            Path = "https://code.jquery.com/jquery-3.6.0.min.js" // Fallback path (can be same as CdnPath)
        });
    }

    protected void fillDistrict()
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
        sel_dist.Items.Insert(0, "Select District");
    }

    protected void fillPlace(int district)
    {
        SqlCommand cmd = new SqlCommand("getDistrictPlace", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("id", district);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        sel_place.DataSource = dt;
        sel_place.DataTextField = "place_name";
        sel_place.DataValueField = "place_id";
        sel_place.DataBind();
        sel_place.Items.Insert(0, "Select Place");
    }

    protected void getUser()
    {
        SqlCommand cmd = new SqlCommand("userProfile", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("id", Session["uid"]);
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        fillPlace(Convert.ToInt32(dt.Rows[0]["district_id"].ToString()));
        txt_name.Text = dt.Rows[0]["user_name"].ToString();
        txt_email.Text = dt.Rows[0]["user_email"].ToString();
        txt_contact.Text = dt.Rows[0]["user_contact"].ToString();
        txt_address.Text = dt.Rows[0]["user_address"].ToString();
        txt_dob.Text = dt.Rows[0]["user_dob"].ToString();
        rad_gender.Text = dt.Rows[0]["user_gender"].ToString();
        sel_dist.SelectedValue = dt.Rows[0]["district_id"].ToString();
        sel_dist.DataBind();
        sel_place.SelectedValue = dt.Rows[0]["place_id"].ToString();

    }
    protected void sel_dist_SelectedIndexChanged(object sender, EventArgs e)
    {
        int distId = Convert.ToInt32(sel_dist.SelectedValue);
        fillPlace(distId);
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("userProfileUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("id", Session["uid"]);
        cmd.Parameters.AddWithValue("name", txt_name.Text);
        cmd.Parameters.AddWithValue("email", txt_email.Text);
        cmd.Parameters.AddWithValue("address", txt_address.Text);
        cmd.Parameters.AddWithValue("contact", txt_contact.Text);
        cmd.Parameters.AddWithValue("dob", txt_dob.Text);
        cmd.Parameters.AddWithValue("gender", rad_gender.Text);
        cmd.Parameters.AddWithValue("place", sel_place.SelectedValue);
        cmd.ExecuteNonQuery();
        string script = "alert('Registration successful!');";
        ClientScript.RegisterStartupScript(this.GetType(), "RegistrationSuccess", script, true);
        Response.Redirect("MyProfile.aspx");
    }
}