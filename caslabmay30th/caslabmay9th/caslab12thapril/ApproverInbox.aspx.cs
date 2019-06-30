using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace caslab12thapril
{
    public partial class ApproverInbox : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            username.Text = (string)Session["UserName"];

            string EmpId = (string)Session["EmpId"];
            employeeid.Text = (string)Session["EmpId"];
            if (!Page.IsPostBack)
            {
                approver.Items.Insert(0, new System.Web.UI.WebControls.ListItem("taskids"));
                approver.AppendDataBoundItems = true;
                String strQuery = "select TaskId from ApproverTaskDetails where EmpId=@EmpId";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@EmpId", employeeid.Text);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    approver.DataSource = cmd.ExecuteReader();
                    approver.DataTextField = "TaskId";
                    approver.DataValueField = "TaskId";
                    approver.DataBind();
                }
                 catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

            }
        }

        protected void approver_SelectedIndexChanged(object sender, EventArgs e)
        {

            String strQuery = " select TaskId,TaskTitle,Taskdescription,Chemical,Quantatity,Units,ProjectId from CreateTask where TaskId = @TaskId ";

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TaskId", approver.SelectedItem.Value);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            Panel1.Visible = true;
            //showgrid(Label10.Text);
            //GridView1.DataBind();
            //showgrid();
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Label10.Text = sdr.GetValue(0).ToString();
                    Label11.Text = sdr.GetValue(1).ToString();
                    Label12.Text = sdr.GetValue(2).ToString();

                   // Label14.Text = sdr.GetValue(6).ToString();
                    Label1.Text = sdr.GetValue(3).ToString();
                    Label2.Text = sdr.GetValue(4).ToString();
                    Label3.Text = sdr.GetValue(5).ToString();
                    //Label4.Text = sdr.GetValue(6).ToString();
                   // Label5.Text = sdr.GetValue(7).ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        //protected void submit_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand("insert into ApproverTaskdetails(EmpId,Approvername,TaskId,Comments,Status)values('" + employeeid.Text + "','" + appr.Text + "','" + DropDownList1.Text + "','" + comments.Text + "','" + status.Text + "')", con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    reset();
        //    label1.Text = "submitted sucessfully";
        //}

        ////protected void submit_Click(object sender, EventArgs e)
        ////{
        ////   
        ////}

        //private void reset()
        //{
        //    DropDownList1.SelectedItem.Text = "";
        //}
    }
}