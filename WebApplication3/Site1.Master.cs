using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null || Session["role"].ToString() == "")
                {
                    LinkButton1.Visible = true;  // user login link button
                    LinkButton2.Visible = true;  // sign up link button

                    LinkButton3.Visible = false; // logout link button
                    LinkButton7.Visible = false; // user profile link button

                    LinkButton6.Visible = true;  // admin login link button
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false; // some other button

                    LinkButton8.Visible = false; // admin-related link button
                    LinkButton9.Visible = false; // admin-related link button
                    LinkButton10.Visible = false; // admin-related link button
                }
                else if (Session["role"].ToString().Equals("user"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                    LinkButton6.Visible = true;
                     LinkButton11.Visible = false;
                   
                    LinkButton12.Visible = false;

                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                }
                else if (Session["role"].ToString().Equals("admin"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello Admin";
                    LinkButton6.Visible = false;

                    LinkButton12.Visible = true;

                    LinkButton8.Visible = true;
                    LinkButton9.Visible = true;
                    LinkButton10.Visible = true;
                    LinkButton11.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] ="";
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;

            LinkButton3.Visible = false;
            LinkButton7.Visible = false;

            LinkButton6.Visible = true;

            LinkButton12.Visible = true;

            LinkButton8.Visible = false;
            LinkButton9.Visible = false;
            LinkButton10.Visible = false;
            Response.Redirect("homepage.aspx");  
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}