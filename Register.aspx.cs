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
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection _conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string config = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            _conn = new SqlConnection(config);
            _conn.Open();
        }

        protected void RegisBtn_Click(object sender, EventArgs e)
        {
            string user = NameTxt.Text, email = EmailTxt.Text, contactno=contactTxt.Text,econtact=eContactTxt.Text, pass = PasswordTxt.Text, status = "Active",urole = "User";

            string query = $"exec FindExistingUserProc '{email}'";
            SqlCommand cm = new SqlCommand(query, _conn);
            SqlDataReader rdr = cm.ExecuteReader();
            if (rdr.HasRows)
            {
                Response.Write("<script>alert('User Already Exist!')</script>");
            }
            else
            {
                string q = $"exec RegisterUserProc '{user}','{email}','{contactno}','{econtact}','{pass}','{status}','{urole}'";
                SqlCommand cmd = new SqlCommand(q, _conn);
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Registered successfully');window.location.href='Login.aspx'</script>");
            }
        }
    }
}