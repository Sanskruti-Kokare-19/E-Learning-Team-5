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
    public partial class UserList : System.Web.UI.Page
    {
        SqlConnection _conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string config = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            _conn = new SqlConnection(config);
            _conn.Open();

            if (!IsPostBack)
            {
                BindUserData();
            }
        }

        public void BindUserData()
        {
            string orderstatus = "Paid";
            string q = $"exec FetchUserList '{orderstatus}'";
            SqlCommand cmd = new SqlCommand(q, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();

        }

        protected void ChangeStatus(object sender, CommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            Label lblUsername = (Label)row.FindControl("Label1");
            string username = lblUsername.Text;
            string newStatus = e.CommandArgument.ToString();
            string query = $"exec UpdateAccountStatusProc '{newStatus}','{username}'";
            SqlCommand cmd = new SqlCommand(query,_conn);
            int r =cmd.ExecuteNonQuery();

            BindUserData();
        }
    }
}
