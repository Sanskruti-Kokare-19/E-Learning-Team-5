using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Elearning
{
    public partial class ViewCourses : System.Web.UI.Page
    {
        private SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);

            if (!IsPostBack)
            {
                conn.Open();
                LoadMasterCourses();
                LoadCourses();
                LoadTopics();
            }
        }

        private void LoadMasterCourses()
        {
            string query = "SELECT CourseId, CourseName, CourseImage FROM MasterCourses";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void LoadCourses()
        {
            string query = @"SELECT c.CourseId, mc.CourseName AS MasterCourseName, 
                                    c.CourseName, c.CoursePrice, c.CourseImage
                             FROM Courses c
                             INNER JOIN MasterCourses mc ON c.MasterCourseId = mc.CourseId";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        private void LoadTopics()
        {
            string query = "SELECT TopicId, TopicName, YouTubeURL FROM Topics";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }

        private void ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters = null)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                cmd.ExecuteNonQuery();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                SqlParameter[] parameters = { new SqlParameter("@CourseId", id) };
                ExecuteStoredProcedure("DeleteMasterCourse", parameters);
                LoadMasterCourses();

                string script = "alert('MasterCourse deleted successfully.');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                SqlParameter[] parameters = { new SqlParameter("@CourseId", id) };
                ExecuteStoredProcedure("DeleteCourse", parameters);
                LoadCourses();

                string script = "alert('Course deleted successfully.');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                int id = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Edit")
                {
                    Response.Write("<script>alert('Edit functionality for Topic ID " + id + " is under implementation.');</script>");
                }
                else if (e.CommandName == "Delete")
                {
                    SqlParameter[] parameters = { new SqlParameter("@TopicId", id) };
                    ExecuteStoredProcedure("DeleteTopic", parameters);
                    LoadTopics();

                    string script = "alert('Topic deleted successfully.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
