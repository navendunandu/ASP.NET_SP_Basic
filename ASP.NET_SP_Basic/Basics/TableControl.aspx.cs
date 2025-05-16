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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        TableRow TRow = new TableRow();

        TableCell rollnocell = new TableCell();
        rollnocell.Text = txtroll.Text;
        TRow.Cells.Add(rollnocell);

        TableCell namecell = new TableCell();
        namecell.Text = txtname.Text;
        TRow.Cells.Add(namecell);

        TableCell markcell = new TableCell();
        markcell.Text = txtmark.Text;
        TRow.Cells.Add(markcell);

        Table1.Rows.Add(TRow);




    }
}