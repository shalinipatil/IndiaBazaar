﻿using System;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check if a user is logged in
        if(Session["login"] != null)
        {
            LabelLogin.Text = "Welcome " + Session["login"];
            LabelLogin.Visible = true;
            LinkButton1.Text = "Logout";
        }
        else
        {
            LabelLogin.Visible = false;
            LinkButton1.Text = "Login";
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //User logs in 
        if(LinkButton1.Text == "Login")
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
        else
        {
            //User logs out
            Session.Clear();
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
}
