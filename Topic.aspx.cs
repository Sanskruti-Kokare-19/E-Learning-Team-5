using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Elearning
{
    public partial class Topic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve the connection string from Web.config
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

            if (!IsPostBack)
            {
                LoadCourses(cs);
            }
        }

        // Method to load courses into the DropDownList
        private void LoadCourses(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Debugging: Check if the connection is successful
                    Console.WriteLine("Connection successful!");

                    // Fetch courses from the database
                    string query = "SELECT CourseId, CourseName FROM Courses";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Debugging: Check if any rows are fetched
                        Console.WriteLine("Rows fetched successfully!");

                        DropDownList1.DataSource = reader;
                        DropDownList1.DataTextField = "CourseName";
                        DropDownList1.DataValueField = "CourseId";
                        DropDownList1.DataBind();
                    }
                    else
                    {
                        // Debugging: If no rows are returned
                        Console.WriteLine("No courses found in the database.");
                    }

                    reader.Close();

                    // Add a default "Select Course" item
                    DropDownList1.Items.Insert(0, new ListItem("--Select Course--", ""));
                }
                catch (Exception ex)
                {
                    // Log the exception message
                    Console.WriteLine("Error: " + ex.Message);
                    Response.Write("<script>alert('Error loading courses: " + ex.Message + "');</script>");
                }
            }
        }

        // Event handler for the Add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            string courseId = DropDownList1.SelectedValue;
            string topicName = TextBox1.Text;
            string youtubeUrl = TextBoxUrl.Text;

            if (string.IsNullOrEmpty(courseId) || string.IsNullOrEmpty(topicName) || string.IsNullOrEmpty(youtubeUrl))
            {
                Response.Write("<script>alert('Please fill all fields.');</script>");
                return;
            }

            // Retrieve the connection string from Web.config
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();

                    // Insert the topic data into the database
                    string query = "INSERT INTO Topics (CourseId, TopicName, YouTubeUrl) VALUES (@CourseId, @TopicName, @YouTubeUrl)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    cmd.Parameters.AddWithValue("@TopicName", topicName);
                    cmd.Parameters.AddWithValue("@YouTubeUrl", youtubeUrl);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Response.Write("<script>alert('Topic added successfully.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error adding topic.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
