using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ProductOverview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        AuthenticateAdministrator();
    }

    private void AuthenticateAdministrator()
    {
        if ((string)Session["type"] != "Administrator")
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
    }
}