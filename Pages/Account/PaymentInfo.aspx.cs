using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_UserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        lblResult.Text = "Your order has been placed, thank you for shopping at our store";
    }
}