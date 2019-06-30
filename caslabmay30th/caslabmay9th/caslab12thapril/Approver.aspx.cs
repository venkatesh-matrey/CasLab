using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace caslab12thapril
{
    public partial class Approver : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string EmpId = (string)Session["EmpId"];
            SqlDataSource3.SelectParameters["EmpId"].DefaultValue = EmpId;
            Sqldatasource2.SelectParameters["EmpId"].DefaultValue = EmpId;

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("insert into ApproverTaskdetails(EmpId,Approvername,TaskId,Comments,Status)values('" + employeeid.Text + "','" + appr.Text + "','" + DropDownList1.Text + "','"+comments.Text+"','"+status.Text+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            reset();
            label1.Text = "submitted sucessfully";
        }

        //protected void submit_Click(object sender, EventArgs e)
        //{
        //   
        //}

        private void reset()
        {
            DropDownList1.SelectedItem.Text ="" ;
        }
    }
}