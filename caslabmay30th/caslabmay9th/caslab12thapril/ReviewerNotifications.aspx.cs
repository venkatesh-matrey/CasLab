using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace caslab12thapril
{
    public partial class Notifications : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            employeeid.Text = (string)Session["EmpId"];
            if (!Page.IsPostBack)
            {


                DataBind();

                taskids.Items.Insert(0, new System.Web.UI.WebControls.ListItem("   taskids   ", " "));
                taskids.AppendDataBoundItems = true;



                String strQuery = "select TaskId from CreateTask where EmpId=@EmpId";
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@EmpId", employeeid.Text);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    taskids.DataSource = cmd.ExecuteReader();
                    taskids.DataTextField = "TaskId";
                    taskids.DataValueField = "TaskId";
                    taskids.DataBind();
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

        protected void taskids_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strQuery = " SELECT CreateTask.Taskid, ApproverTaskdetails.Status,ApproverTaskdetails.Comments FROM CreateTask INNER JOIN ApproverTaskdetails ON CreateTask.Taskid = ApproverTaskdetails.TaskId Where CreateTask.TaskId=@TaskId";

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TaskId", taskids.SelectedItem.Value);
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
                    Label1.Text = sdr.GetValue(0).ToString();
                    Label2.Text = sdr.GetValue(1).ToString();
                    Label3.Text = sdr.GetValue(2).ToString();
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
    }
}