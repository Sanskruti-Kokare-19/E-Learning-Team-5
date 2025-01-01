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
    public partial class AddMasterCourse : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }
     
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlMasterCourse.SelectedValue))
            {
                if (fileUploadImage.HasFile)
                {
                    string CourseName = ddlMasterCourse.SelectedValue;
                    fileUploadImage.SaveAs(Server.MapPath("Image/") + Path.GetFileName(fileUploadImage.FileName));
                    string Img = "Image/" + Path.GetFileName(fileUploadImage.FileName);

                    string query = $"SELECT CourseId, CourseName FROM MasterCourses Where CourseName='{CourseName}'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int rows =  Convert.ToInt32(cmd.ExecuteScalar());
                    if(rows == 0)
                    {
                        string q = "insert into MasterCourses(CourseName,CourseImage) values(@CourseName,@CourseImage)";
                        SqlCommand sqlCommand = new SqlCommand(q, conn);
                        sqlCommand.Parameters.AddWithValue("@CourseName", CourseName);
                        sqlCommand.Parameters.AddWithValue("@CourseImage", Img);
                        sqlCommand.ExecuteNonQuery();

                        Response.Write("<script>alert('Add Master Course Successfully')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Master Course Already Added.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please Select Image.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please Select Master Course.')</script>");
            }            
        }
    }
}