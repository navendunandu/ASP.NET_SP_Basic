﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Guest_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = DESKTOP-N4JNRRR;Initial Catalog=db_new;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        if (!IsPostBack)
        {
            rvDob.MaximumValue = DateTime.Today.AddYears(-18).ToString("yyyy-MM-dd");
            fillDistrict();
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

    protected void sel_dist_SelectedIndexChanged(object sender, EventArgs e)
    {
        int districtId = Convert.ToInt32(sel_dist.SelectedValue);
        SqlCommand cmd = new SqlCommand("getDistrictPlace", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("id", districtId);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        sel_place.DataSource = dt;
        sel_place.DataTextField = "place_name";
        sel_place.DataValueField = "place_id";
        sel_place.DataBind();
        sel_place.Items.Insert(0, "Select Place");
    }

    protected void btn_register_Click(object sender, EventArgs e)
    {
        string photoName = Path.GetFileName(file_photo.PostedFile.FileName.ToString());
        file_photo.SaveAs(Server.MapPath("../Assets/Files/User/" + photoName));
        SqlCommand cmd = new SqlCommand("CreateUser", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("name", txt_name.Text);
        cmd.Parameters.AddWithValue("email", txt_email.Text);
        cmd.Parameters.AddWithValue("contact", txt_contact.Text);
        cmd.Parameters.AddWithValue("dob", txt_dob.Text);
        cmd.Parameters.AddWithValue("gender", rad_gender.Text);
        cmd.Parameters.AddWithValue("address", txt_address.Text);
        cmd.Parameters.AddWithValue("password", txt_password.Text);
        cmd.Parameters.AddWithValue("place", sel_place.SelectedValue);
        cmd.Parameters.AddWithValue("photo", photoName);
        rad_gender.ClearSelection();
        sel_dist.SelectedIndex = 0;
        sel_place.Items.Clear();
        sel_place.Items.Add(new ListItem("Select Place", "Select Place"));
        string script = "alert('Registration successful!');";
        ClientScript.RegisterStartupScript(this.GetType(), "RegistrationSuccess", script, true);
    }
}