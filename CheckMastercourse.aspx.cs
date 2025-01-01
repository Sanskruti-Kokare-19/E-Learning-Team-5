using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Elearning
{
    public partial class CheckMastercourse : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMasterCourses();
            }
        }

        private void LoadMasterCourses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CourseId, CourseName FROM MasterCourses";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DropDownList1.DataSource = reader;
                        DropDownList1.DataTextField = "CourseName";
                        DropDownList1.DataValueField = "CourseId";
                        DropDownList1.DataBind();
                    }

                    DropDownList1.Items.Insert(0, new ListItem("--Select Master Course--", ""));
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error loading master courses: " + ex.Message + "');</script>");
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {
                LoadCourses();
            }
        }

        private void LoadCourses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CourseId, CourseName FROM Courses WHERE MasterCourseId = @MasterCourseId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MasterCourseId", DropDownList1.SelectedValue);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DropDownList2.DataSource = reader;
                        DropDownList2.DataTextField = "CourseName";
                        DropDownList2.DataValueField = "CourseId";
                        DropDownList2.DataBind();
                    }

                    DropDownList2.Items.Insert(0, new ListItem("--Select Course--", ""));
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error loading courses: " + ex.Message + "');</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void LoadGridView()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            c.CourseId AS [ID],
                            mc.CourseName AS [MasterCourse Name],
                            c.CourseName AS [Course Name],
                            (SELECT COUNT(*) FROM Topics t WHERE t.CourseId = c.CourseId) AS [No. of Topics]
                        FROM Courses c
                        INNER JOIN MasterCourses mc ON c.MasterCourseId = mc.CourseId
                        WHERE (@MasterCourseId IS NULL OR mc.CourseId = @MasterCourseId)
                          AND (@CourseId IS NULL OR c.CourseId = @CourseId)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MasterCourseId", string.IsNullOrEmpty(DropDownList1.SelectedValue) ? (object)DBNull.Value : DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@CourseId", string.IsNullOrEmpty(DropDownList2.SelectedValue) ? (object)DBNull.Value : DropDownList2.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error loading grid data: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
