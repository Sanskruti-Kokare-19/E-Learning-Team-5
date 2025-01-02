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
    public partial class UserProfile : System.Web.UI.Page
    {
        SqlConnection _conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string config = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            _conn = new SqlConnection(config);
            _conn.Open();

            if(!IsPostBack)
            {
                FetchCourse();
            }

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                string q = $"exec findCourseById '{e.CommandArgument.ToString()}'";
                SqlCommand cmd = new SqlCommand(q, _conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string course_name = dr["CourseTopicName"].ToString();
                string mastercourse_name = dr["MasterCourseName"].ToString();
                string course_img = dr["CourseTopicPic"].ToString();
                double course_price = double.Parse(dr["CourseTopicPrice"].ToString());
                int mastercourse_id = int.Parse(dr["MasterCourseId"].ToString());

                string trandate = DateTime.Now.ToString("dd/MM/yyyy");
                
                string suser = Session["MyUser"].ToString();

                string q2 = $"exec AddToCartProc '{course_name}','{course_img}','{course_price}','{mastercourse_name}','{mastercourse_id}','{trandate}','{suser}'";
                SqlCommand cm = new SqlCommand(q2, _conn);

                cm.ExecuteNonQuery();
                Response.Redirect("Cart.aspx");

            }
        }

        public void FetchCourse()
        {
            string query = $"exec fetchCourseDetailsProc";
            SqlCommand _cmd = new SqlCommand(query, _conn);
            SqlDataReader dr = _cmd.ExecuteReader();
            DataList1.DataSource = dr;
            DataList1.DataBind();

        }

    }
}
