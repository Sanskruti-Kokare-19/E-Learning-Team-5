using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace le
{
    public partial class LeaveManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            DateTime fromDate = calFromDate.SelectedDate;
            DateTime toDate = calToDate.SelectedDate;

            if (fromDate == DateTime.MinValue || toDate == DateTime.MinValue)
            {
                Label1.Text = "Please select both dates.";
                return;
            }

            if (fromDate > toDate)
            {
                Label1.Text = "From Date cannot be after To Date.";
                return;
            }

            int totalDays = 0;
            for (var date = fromDate; date <= toDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    totalDays++;
                }
            }

            Label1.Text = totalDays.ToString();
        }
    }
    
}