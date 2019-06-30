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
    public partial class Reviwer : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(str);
            //SqlCommand cmd = new SqlCommand("select EmpId from AddEmployee where EmpName='" +revi.SelectedValue.ToString()+"'",con);
            //string querry = "select EmpId from AddEmployee where EmpName='" + revi.SelectedValue.ToString() + "'";
            //cmd.Parameters.AddWithValue("@EmpName", revi.Text);
           // emplyeeid.Text = querry;



            string EmpId = (string)Session["EmpId"];
            SqlDataSource1.SelectParameters["EmpId"].DefaultValue = EmpId;
            SqlDataSource2.SelectParameters["EmpId"].DefaultValue = EmpId;


        }


      

       
        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("insert into ReviewerTaskDetails1(EmpId,Reviewername,TaskId)values(@EmpId,@Reviewername,@TaskId)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@EmpId", emplyeeid.Text);
            cmd.Parameters.AddWithValue("@Reviewername", revi.Text);
            cmd.Parameters.AddWithValue("@TaskId", tasks.Text);
            
            cmd.ExecuteNonQuery();
            con.Close();
            reset();
            label1.Text = "submitted sucessfully";
        }

        private void reset()
        {
            //revi.SelectedItem.Text = "";
            //appr.SelectedItem.Text = "";
            tasks.SelectedItem.Text = "";
        }
    }
}