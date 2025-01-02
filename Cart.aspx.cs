using Razorpay.Api;
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
    public partial class Cart : System.Web.UI.Page
    {
        SqlConnection _conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string config = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            _conn = new SqlConnection(config);
            _conn.Open();
            if (!IsPostBack)
            {
                FetchCourse();
            }
        }

        public void FetchCourse()
        {
            string suser = Session["username"].ToString();
            string q = $"exec FetchCartByUser '{suser}'";
            SqlCommand cmd = new SqlCommand(q, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            findTotal();
        }

        public void findTotal()
        {
            string suser = Session["username"].ToString();
            string q = $"exec findGrandTotal '{suser}'";
            SqlCommand cmd = new SqlCommand(q, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            string amt = reader["grandTotal"].ToString();
            Label9.Text = amt;
            Session["totalAmount"] = amt;
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           Label l1 = GridView1.Rows[e.RowIndex].FindControl("Label1") as Label;
            string pid = l1.Text;

            string q = $"exec deleteProductFromCartById '{pid}'";
            SqlCommand cmd = new SqlCommand(q, _conn);
            cmd.ExecuteNonQuery();
            FetchCourse();

        }

        protected void BuyBtn_Click(object sender, EventArgs e)
        {
            string keyId = "rzp_test_Kl7588Yie2yJTV";
            string keySecret = "6dN9Nqs7M6HPFMlL45AhaTgp";

            RazorpayClient razorpayClient = new RazorpayClient(keyId, keySecret);

            double amount = double.Parse(Session["totalAmount"].ToString());


            // Create an order
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amount * 100); // Amount should be in paisa (multiply by 100 for rupees)
            options.Add("currency", "INR");
            options.Add("receipt", "order_receipt_123");
            options.Add("payment_capture", 1); // Auto capture payment

            Razorpay.Api.Order order = razorpayClient.Order.Create(options);

            string orderId = order["id"].ToString();

            // Generate checkout form and redirect user to Razorpay payment page
            string razorpayScript = $@"
            var options = {{
                'key': '{keyId}',
                'amount': {amount * 100},
                'currency': 'INR',
                'name': 'Masstech Business Solutions Pvt.Ltd',
                'description': 'Checkout Payment',
                'order_id': '{orderId}',
                'handler': function(response) {{
                    // Handle successful payment response
                    alert('Payment successful. Payment ID: ' + response.razorpay_payment_id);
                }},
                'prefill': {{
                    'name': 'Krish Kheloji',
                    'email': 'khelojikrish@gmail.com',
                    'contact': '7208921898'
                }},
                'theme': {{
                    'color': '#F37254'
                }}
            }};
            var rzp1 = new Razorpay(options);
            rzp1.open();";

            // Register the script on the page

            ClientScript.RegisterStartupScript(this.GetType(), "razorpayScript", razorpayScript, true);

        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    string sus = Session["MyUser"].ToString();
        //    string query = $"exec FindUsernameByEmail '{sus}'";
        //    SqlCommand _cmd = new SqlCommand(query, _conn);
        //    SqlDataReader _rdr = _cmd.ExecuteReader();
        //    _rdr.Read();

        //    string us2 = _rdr["Username"].ToString();
        //    string q = $"exec CheckoutProc '{us2}'";  //need to create checkout table and it's procedure
        //    SqlCommand cmd = new SqlCommand(q, _conn);
        //    int row = cmd.ExecuteNonQuery();
        //    if (row > 0)
        //    {
        //        string q2 = $"exec deleteProductFromCart '{us2}'";//sp
        //        SqlCommand sql = new SqlCommand(q2, _conn);
        //        sql.ExecuteNonQuery();
        //        Response.Redirect("Payment.aspx");
        //    }
        //    else
        //    {
        //        Response.Write("wrong");
        //    }
        //}
    }
}