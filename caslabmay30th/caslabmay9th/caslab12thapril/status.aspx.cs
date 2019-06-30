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
    public partial class status : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            reviewerdata.Text = (string)Session["Reviewer"];
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(str))
            {

                con.Open();
                SqlCommand sqlcmd = new SqlCommand("select Reviewerstatus,TaskId,Reviewer from Inboxdetails where Reviewer='" + reviewerdata.Text + "'", con);
                sqlcmd.CommandType = CommandType.Text;
                reader = sqlcmd.ExecuteReader();
                while (reader.Read())
                {

                    taskid.Text = reader["TaskId"].ToString();
                    taskstatus.Text = reader["Reviewerstatus"].ToString();

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
                con.Close();

            }

        }
    }
}