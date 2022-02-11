using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConferenceManagementPortal
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == "")
                {
                    LinkButton1.Visible = true; //user login
                    LinkButton2.Visible = true; //signup

                    LinkButton3.Visible = false; //logout
                    LinkButton7.Visible = false; //hello user

                    LinkButton6.Visible = true; //admin login
                  
                    LinkButton10.Visible = false;

                    LinkButton5.Visible = false; //upload paper
                    LinkButton8.Visible = false; //edit-uploads



                }

                else if (Session["role"] == "user")
                {

                    LinkButton1.Visible = false; //user login
                    LinkButton2.Visible = false; //signup

                    LinkButton3.Visible = true; //logout
                    LinkButton7.Visible = true; //hello user
                    LinkButton7.Text = "Hello " + Session["username"].ToString();


                    LinkButton6.Visible = true; //admin login
                   
                    LinkButton10.Visible = false;

                     LinkButton5.Visible = true; //upload paper
                    LinkButton8.Visible = true; //edit-uploads

                }
                else if (Session["role"] == "admin")
                {
                    LinkButton1.Visible = false; //user login
                    LinkButton2.Visible = false; //signup

                    LinkButton3.Visible = true; //logout
                    LinkButton7.Visible = true; //hello user
                    LinkButton7.Visible = false;

                    LinkButton6.Visible = false; //admin login
                
                    LinkButton10.Visible = true;
                     LinkButton5.Visible = true; //upload paper
                    LinkButton8.Visible = true; //edit-uploads

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/edituploads.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/uploadgallery.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            //redirects
            Response.Redirect("~/adminmembermanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/userlogin.aspx");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/usersignup.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";
            Session["status"] = "";
            Session["fullname"] = "";

            LinkButton1.Visible = true; //user login
            LinkButton2.Visible = true; //signup

            LinkButton3.Visible = false; //logout
            LinkButton7.Visible = false; //hello user

            LinkButton6.Visible = true; //admin login
    
            LinkButton10.Visible = false; //member management

            Response.Redirect("homepage.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/uploadedpapers.aspx");
        }
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}