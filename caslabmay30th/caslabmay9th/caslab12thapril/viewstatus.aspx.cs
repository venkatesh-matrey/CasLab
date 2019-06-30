using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace caslab12thapril
{
    public partial class viewstatus : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        public class taskdata
        {
            public string TaskId { get; set; }
            public string Reviewerstatus { get; set; }
            
            public string Reviewer { get; set; }
            public string Approver { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            reviewerdata.Text = (string)Session["Reviewer"];
            userdata.Text = (string)Session["UserName"];
            using (SqlConnection con = new SqlConnection(str))
            {
                taskdata details = new taskdata();

                con.Open();
                SqlCommand sqlcmd = new SqlCommand("select TaskId,EmployeeName,Reviewerstatus from Inboxdetails where Reviewer='" + reviewerdata.Text + "' and EmployeeName='" + userdata.Text + "' ", con);
               sqlcmd.CommandType = CommandType.Text;

                using (SqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                            details.TaskId = reader["TaskId"].ToString();
                            taskid.Text = details.TaskId;
                            details.Reviewerstatus = reader["Reviewerstatus"].ToString();
                            taskstatus.Text = details.Reviewerstatus;
                            if (taskstatus.Text == "ACCEPTED")
                            {
                                taskstatus.BackColor = System.Drawing.Color.Green;
                                taskstatus.ForeColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                taskstatus.BackColor = System.Drawing.Color.Red;
                                taskstatus.ForeColor = System.Drawing.Color.White;
                            }
                        
                    }
                    reader.Close();
                }
                
                con.Close();

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = e.Row.Cells[1];
                if (cell.Text == "REJECTED")
                {
                    
                    cell.ForeColor = System.Drawing.Color.Red;
                }
                else if (cell.Text == "ACCEPTED")
                {
                    
                    cell.ForeColor = System.Drawing.Color.Green;
                }
                TableCell cellapprover = e.Row.Cells[2];
                if (cellapprover.Text == "REJECTED")
                {

                    cellapprover.ForeColor = System.Drawing.Color.Red;
                }
                else if (cellapprover.Text == "ACCEPTED")
                {

                    cellapprover.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
    }

}
 
                       

                
