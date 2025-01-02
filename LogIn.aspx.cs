using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Learning
{
    public partial class LogIn : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text, password = TextBox2.Text;
            Session["SEmail"] = email;  
            string qurey = $"exec LogInProc '{email}','{password}' ";
            SqlCommand cmd = new SqlCommand(qurey, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (rdr["UserEmail"].Equals(email) && rdr["PasswordHash"].Equals(password))
                    {

                        Response.Redirect("UserHome.aspx"); // Add ur page where u redirect
                    }
                    else
                    {
                        Response.Write("<script>alert('Something Wrong!')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid User Credentials! Try again if not register please register')</script>");
            }
        }
    }
}