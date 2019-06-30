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
    public partial class ViewPage : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            employeeid.Text = (string)Session["EmpId"];

            username.Text = (string)Session["UserName"];
            string EmpId = (string)Session["EmpId"];
            Sqldatasource1.SelectParameters["EmpId"].DefaultValue = EmpId;


            if (!Page.IsPostBack)
            {


                DataBind();

                taskids.Items.Insert(0, new System.Web.UI.WebControls.ListItem("   taskids   ", " "));
                taskids.AppendDataBoundItems = true;



                String strQuery = "select Name from CreateTask where EmpId=@EmpId";
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
                    taskids.DataTextField = "Name";
                    taskids.DataValueField = "Name";
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


        protected void project_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strQuery = "select Name from CreateTask where ProjectId = @ProjectId";

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@projectId", idproject.SelectedItem.Value);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    taskids.Text = sdr.GetValue(0).ToString();
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


        protected void taskids_SelectedIndexChanged(object sender, EventArgs e)
        {

            String strQuery = " select TaskId,TaskTitle,Taskdescription,Chemical,Quantatity,Units,ProjectId from CreateTask where TaskId = @TaskId";

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
                    Label10.Text = sdr.GetValue(0).ToString();
                    Label11.Text = sdr.GetValue(1).ToString();
                    Label12.Text = sdr.GetValue(2).ToString();

                    Label14.Text = sdr.GetValue(6).ToString();
                    Label1.Text = sdr.GetValue(3).ToString();
                    Label2.Text = sdr.GetValue(4).ToString();
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