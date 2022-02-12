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
    public partial class WebForm10 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                  

                    if (!Page.IsPostBack)
                    {
                        GridView1.DataBind();
                        
                        
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            fetchrecord();
        }

         void fetchrecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from uploaded_files_tbl WHERE member_id='" + TextBox2.Text.Trim()+"' and book_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    
                    TextBox3.Text = dt.Rows[0]["title"].ToString();
                   
                    TextBox4.Text = dt.Rows[0]["category"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["description"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["upload_date"].ToString();
   

                  


                }
                else
                {
                    Response.Write("<script>alert('Wrong Member_ID or Reference ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }
        //update button
        protected void Button2_Click(object sender, EventArgs e)
        {
                updateBookByID();
        }



         void updateBookByID()
        {

            if (checkifpaperexists())
            {
                try
                {

                   
                    

                  

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE uploaded_files_tbl set title=@title, category=@category, description=@description, upload_date=@upload_date where book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@title", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@category",  TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@description",  TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@upload_date", DateTime.Now.ToString("yyyy-MM-dd"));
                    

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    clearform();
                    Response.Write("<script>alert('Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Member Id or Invalid Refernce ID');</script>");
            }
        }

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

        bool checkifpaperexists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from uploaded_files_tbl where book_id='" + TextBox1.Text.Trim() + "' and member_id='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        
        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            deletePaperbyID();
        }

        void deletePaperbyID()
        {
            if (checkifpaperexists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE from uploaded_files_tbl where book_id='" + TextBox1.Text.Trim() + "' and member_id='" + TextBox2.Text.Trim() + "';", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    clearform();
                    Response.Write("<script>alert('Deleted Successfully');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }

        }
        protected void DownloadFile(object sender, EventArgs e)
        {
        int book_id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType;
        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Name, Data, ContentType from uploaded_files_tbl where book_id=@book_id";
                cmd.Parameters.AddWithValue("@book_id", book_id);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["Data"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["Name"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush(); 
        Response.End();
    }
    }
}