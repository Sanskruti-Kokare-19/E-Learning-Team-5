using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Learning
{
    public partial class Registration : System.Web.UI.Page
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
            string userName = TextBox1.Text, 
                   email = TextBox2.Text, 
                   contact = TextBox3.Text,
                   alternateContact = TextBox4.Text,
                   password = TextBox5.Text;
            string userImg;

            FileUpload1.SaveAs(Server.MapPath("User Image/") + System.IO.Path.GetFileName(FileUpload1.FileName));
            userImg = "User Image/" + Path.GetFileName(FileUpload1.FileName);

            string query = $"exec CheckExistingUserProc '{email}'";
            SqlCommand cm = new SqlCommand(query, conn);
            SqlDataReader rdr = cm.ExecuteReader();
            if (rdr.HasRows)
            {
                Response.Write("<script>alert('User already exist')</script>");
            }
            else
            {
                string q = $"exec RegisterUserProc '{userName}', '{email}', '{contact}', '{alternateContact}', '{password}', '{userImg}' ";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('User Registered successfully');window.location.href='LogIn.aspx'</script>");
            }

        }
    }
}