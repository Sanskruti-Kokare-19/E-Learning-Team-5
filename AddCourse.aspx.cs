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
    public partial class AddCourse : System.Web.UI.Page
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int masterCourseId = int.Parse(ddlMasterCourse.SelectedValue);
            string courseName = txtCourseName.Text.Trim();
            decimal coursePrice = decimal.Parse(txtCoursePrice.Text.Trim());

            fileUploadImage.SaveAs(Server.MapPath("Image/") + Path.GetFileName(fileUploadImage.FileName));
            string pic = "Image/" + Path.GetFileName(fileUploadImage.FileName);
            string query = "INSERT INTO Courses (MasterCourseId, CourseName, CoursePrice, CourseImage) VALUES (@MasterCourseId, @CourseName, @CoursePrice, @CourseImage)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MasterCourseId", masterCourseId);
            cmd.Parameters.AddWithValue("@CourseName", courseName);
            cmd.Parameters.AddWithValue("@CoursePrice", coursePrice);
            cmd.Parameters.AddWithValue("@CourseImage", pic);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Added Course Successfully')</script>");

            txtCourseName.Text = "";
            txtCourseName.Text = "";
        }
    }
}



