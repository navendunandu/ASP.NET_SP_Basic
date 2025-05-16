using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Basics_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btn_next1_Click(object sender, EventArgs e)
    {
        multiview.ActiveViewIndex = 1;
    }

    protected void btn_next2_Click(object sender, EventArgs e)
    {
        multiview.ActiveViewIndex = 2;
    }
}