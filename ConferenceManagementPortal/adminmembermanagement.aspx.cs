using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConferenceManagementPortal
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        bool memberExists()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string query = "select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "';";


                //select* from member_master_tbl where member_id = 'neeraj-2' and password = 'neeraj@123';
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }


            return false;
        }


        void changeStatus(string status)
        {
            if (memberExists())
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    //string query = "select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "';";
                    string query = "update member_master_tbl set account_status='" + status + "' where member_id='" + TextBox1.Text.ToString() + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    TextBox7.Text = status;    //account stattus
                    Response.Write("<script>alert('Status have been updated as u said :)')</script>");




                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('You have entered some wrong member_id, can u plz verify for me :)')</script>");
            }
        }

        void clearForm()
        {
            TextBox2.Text = ""; //full name
            TextBox7.Text = "";//account stattus
            TextBox8.Text = ""; //dob
            TextBox3.Text = ""; //contact no
            TextBox4.Text = ""; //email_id
            TextBox9.Text = ""; //state
            TextBox10.Text = ""; //city
            TextBox11.Text = ""; //pin code
            TextBox6.Text = ""; //full postal address
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"]=="" || Session["role"]=="user")
            {
                Response.Write("<script>alert('You are not authorized to visit this page. Sorry. But First become admin then try to manage members!')</script>");
                Response.Redirect("~/homepage.aspx");
            }

             GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (memberExists())
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {

                    string query = "delete from member_master_tbl where member_id='" + TextBox1.Text.ToString() + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    GridView1.DataBind();
                    con.Close();
                    clearForm();

                    Response.Write("<script>alert('deleted :)')</script>");




                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You have entered some wrong member_id, can u plz verify for me :)')</script>");
            }
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (memberExists())
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    string query = "select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "';";
                    SqlCommand cmd = new SqlCommand(query, con);

                    //select* from member_master_tbl where member_id = 'neeraj-2' and password = 'neeraj@123';
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox2.Text = dr.GetValue(0).ToString(); //full name
                            TextBox7.Text = dr.GetValue(10).ToString(); //account stattus
                            TextBox8.Text = dr.GetValue(1).ToString(); //dob
                            TextBox3.Text = dr.GetValue(2).ToString(); //contact no
                            TextBox4.Text = dr.GetValue(3).ToString(); //email_id
                            TextBox9.Text = dr.GetValue(4).ToString(); //state
                            TextBox10.Text = dr.GetValue(5).ToString(); //city
                            TextBox11.Text = dr.GetValue(6).ToString(); //pin code
                            TextBox6.Text = dr.GetValue(7).ToString(); //full postal address

                        }
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }



            }
            else
            {
                Response.Write("<script>alert('You have entered some wrong member_id, can u plz verify for me :)')</script>");
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            changeStatus("active");
            GridView1.DataBind();
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            changeStatus("deactive");
            GridView1.DataBind();
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            changeStatus("pending");
            GridView1.DataBind();
        }

      
    }
}