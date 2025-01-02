using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Learning
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection _conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string config = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            _conn = new SqlConnection(config);
            _conn.Open();
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string uname = EmailTxt.Text, pass = PasswordTxt.Text;
            string q = $"exec LoginProc '{uname}','{pass}'";
            SqlCommand cmd = new SqlCommand(q, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    string status = reader["UserStatus"].ToString();


                    if (status == "Blocked")
                    {
                        // User is blocked
                        Response.Write("<script>alert('You are blocked by the admin. Please contact to admin.')</script>");
                        return;
                    }
                    if ((reader["UserName"].Equals(uname) || reader["UserEmail"].Equals(uname)) && reader["PasswordHash"].Equals(pass) && reader["Urole"].Equals("Admin"))
                    {


                        Session["email"] = reader["UserEmail"].ToString();
                        Session["username"] = reader["UserName"].ToString();
                        Session["userid"] = reader["UserId"].ToString();
                        Session["MyUser"] = uname;
                        Response.Redirect("AdminProfile.aspx");

                    }
                    if ((reader["UserName"].Equals(uname) || reader["UserEmail"].Equals(uname)) && reader["PasswordHash"].Equals(pass) && reader["Urole"].Equals("User"))
                    {

                        Session["email"] = reader["UserEmail"].ToString();
                        Session["username"] = reader["UserName"].ToString();
                        Session["userid"] = reader["UserId"].ToString();
                        Session["MyUser"] = uname;
                        Response.Redirect("UserProfile.aspx");
                    }

                }
            }
            else
            {
                Response.Write("<script>alert('Inavlid User Crenditals !! try agian')</script>");
            }
        }
    }
}