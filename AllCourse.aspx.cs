using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELearningProject
{
    public partial class AllCourse : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                BindDropdown();
            }
        }
        private void BindDropdown()
        {
            string query = "SELECT CourseId, CourseName FROM MasterCourses";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ddlMasterCourse.DataSource = reader;
            ddlMasterCourse.DataTextField = "CourseName";
            ddlMasterCourse.DataValueField = "CourseId";
            ddlMasterCourse.DataBind();
            ddlMasterCourse.Items.Insert(0, new ListItem("--Select Course--", "0"));
        }
        protected void btnFetch_Click(object sender, EventArgs e)
        {
            int MasterCourseId = Convert.ToInt32(ddlMasterCourse.SelectedValue);
            string command = $"select CourseName,CoursePrice,CourseImage from Courses where MasterCourseId={MasterCourseId}";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader r = cmd.ExecuteReader();
            dlCourses.DataSource = r;
            dlCourses.DataBind();
        }
    }
}