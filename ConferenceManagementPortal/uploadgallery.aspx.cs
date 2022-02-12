using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConferenceManagementPortal
{
    public partial class WebForm5 : System.Web.UI.Page
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
                        //fetch the session["username"] from the session and fill into the textbox
                        TextBox1.Text = Session["username"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select member_id, title, category,description,book_id, Name from uploaded_files_tbl";
                cmd.Connection = con;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();
            }
        }
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        string query = "insert into uploaded_files_tbl values (@Data, @member_id,@title,@category,@description,@Name, @ContentType,@member_name,@upload_date)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@title", TextBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@category", TextBox3.Text.Trim());
                            cmd.Parameters.AddWithValue("@description", TextBox6.Text.Trim());
                           
                            cmd.Parameters.AddWithValue("@Name", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@member_name", TextBox4.Text.Trim());
                            //only date
                            cmd.Parameters.AddWithValue("@upload_date", DateTime.Now.ToString("yyyy-MM-dd"));
                           
                           
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            clearForm();
            Response.Write("<script>alert('Uploaded Succesfully. Thanks')</script>");
           GridView1.DataBind();
           
            
        }

        private void clearForm()
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox6.Text = "";
            TextBox4.Text = "";
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