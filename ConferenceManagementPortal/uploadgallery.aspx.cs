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
                        string query = "insert into uploaded_files_tbl values (@Data, @member_id,@title,@category,@description,@Name, @ContentType)";
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
                           
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            Response.Write("<script>alert('Uploaded Succesfully. Thanks')</script>");
            GridView1.DataBind();
            
        }
    }
}