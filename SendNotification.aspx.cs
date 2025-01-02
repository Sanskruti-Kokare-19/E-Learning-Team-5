using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Learning
{
    public partial class SendNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateUserDropdown();
            }
        }

        private void PopulateUserDropdown()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT UserEmail, UserName FROM UserRegistration", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlUsers.DataSource = reader;
                ddlUsers.DataTextField = "UserName";
                ddlUsers.DataValueField = "UserEmail";
                ddlUsers.DataBind();

                reader.Close();
            }

            ddlUsers.Items.Insert(0, new ListItem("Select All", "0"));
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string notificationText = txtNotification.Text;

            if (string.IsNullOrWhiteSpace(notificationText))
            {
                lblMessage.Text = "Please enter a notification message.";
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string selectedUserEmail = ddlUsers.SelectedValue;

                if (selectedUserEmail == "0") // Send to all users
                {
                    SqlCommand cmd = new SqlCommand("SELECT UserEmail, UserName FROM UserRegistration", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string userEmail = reader.GetString(0);
                        string userName = reader.GetString(1);

                        InsertNotification(userEmail, userName, notificationText, conn);
                        SendEmail(userEmail, notificationText);
                    }

                    reader.Close();
                }
                else // Send to selected user
                {
                    SqlCommand cmd = new SqlCommand("SELECT UserName FROM UserRegistration WHERE UserEmail = @UserEmail", conn);
                    cmd.Parameters.AddWithValue("@UserEmail", selectedUserEmail);
                    conn.Open();
                    string userName = cmd.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(userName))
                    {
                        InsertNotification(selectedUserEmail, userName, notificationText, conn);
                        SendEmail(selectedUserEmail, notificationText);
                    }
                }
            }

            Response.Write("<script>alert('Notification Send Successfully!')</script>");

            lblMessage.Text = "Notification sent successfully!";
            txtNotification.Text = string.Empty;

        }

        private void InsertNotification(string userEmail, string userName, string notificationText, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Notifications (UserEmail, UserName, NotificationText) VALUES (@UserEmail, @UserName, @NotificationText)", conn);
            cmd.Parameters.AddWithValue("@UserEmail", userEmail);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@NotificationText", notificationText);
            cmd.ExecuteNonQuery();
        }

        private void SendEmail(string toEmail, string message)
        {
            string fromEmail = "Adnin@gmail.com";
            string fromPassword = "Admin-code";

            MailMessage mail = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = "New Notification",
                Body = message,
                IsBodyHtml = true 
            };
            mail.To.Add(toEmail);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true
            };

            smtp.Send(mail);

        }
    }
}