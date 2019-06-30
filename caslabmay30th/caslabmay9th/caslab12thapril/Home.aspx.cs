using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace caslab12thapril
{
    public partial class Inbox : System.Web.UI.Page
    {
        static Boolean taskidfound;
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            employeeid.Text = (string)Session["EmpId"];

            username.Text = (string)Session["UserName"];
            string EmpId = (string)Session["EmpId"];
            Sqldatasource1.SelectParameters["EmpId"].DefaultValue = EmpId;

         
            SqlDataSource2.SelectParameters["EmpId"].DefaultValue = EmpId;

        }


      
        protected void project_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strQuery = "select TaskId from CreateTask where ProjectId = @ProjectId";

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




        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    generate();
        //}
        //private string GridViewToHtml(Panel grdResultDetails)
        //{
        //    StringBuilder objStringBuilder = new StringBuilder();
        //    StringWriter objStringWriter = new StringWriter(objStringBuilder);
        //    HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
        //    grdResultDetails.RenderControl(objHtmlTextWriter);
        //    return objStringBuilder.ToString();
        //}
        //private void showgrid()
        //{

        //    DataTable dt = new DataTable();
        //    DataRow dr;

        //    dt.Columns.Add("TaskId");
        //    dt.Columns.Add("ProjectId");
        //    dt.Columns.Add("TaskTitle");
        //    dt.Columns.Add("Chemical");
        //    dt.Columns.Add("Quantatity");
        //    dt.Columns.Add("Units");
           
        //    SqlConnection scon = new SqlConnection(str);
        //    String myquery = "select * from CreateTask where TaskId='" + taskids + "'";
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = myquery;
        //    cmd.Connection = scon;
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    int totalrows = ds.Tables[0].Rows.Count;
        //    int i = 0;
           
        //    while (i < totalrows)
        //    {
        //        dr = dt.NewRow();
        //        dr["TaskId"] = ds.Tables[0].Rows[i]["Serialno"].ToString();
        //        dr["ProjectId"] = ds.Tables[0].Rows[i]["Productid"].ToString();
        //        dr["TaskTitle"] = ds.Tables[0].Rows[i]["Productname"].ToString();
        //        dr["Chemical"] = ds.Tables[0].Rows[i]["Quantity"].ToString();
        //        dr["Quantatity"] = ds.Tables[0].Rows[i]["Price"].ToString();
        //        dr["Units"] = ds.Tables[0].Rows[i]["Price"].ToString();

               
        //        dt.Rows.Add(dr);
                
        //    }
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();

          
        //}

        //private void generate()
        //{
        //    Label10.Text = taskids.Text;
        //    task(Label10.Text);
        //    if(taskidfound == true)
        //    {
        //        project(Label10.Text);
        //        tasktitle(Label10.Text);
        //        taskdescription(Label10.Text);
        //        //showgrid(Label10.Text);
        //        Panel1.Visible = true;
        //    }

        //    else
        //    {
        //       // Label9.Text = "particular taskid not found";
        //    }
        //}

        //private void project(string TaskId)
        //{
        //    string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;


        //    String myquery = "Select * from CreateTask where TaskId='" + taskids + "'";
        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = myquery;
        //    cmd.Connection = con;
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //        Label14.Text = ds.Tables[0].Rows[0]["ProjectId"].ToString();

        //    }

        //    con.Close();
        //}

        //private void tasktitle(string TaskId)
        //{
        //    String myquery = "Select * from CreateTask where TaskId='" + taskids + "'";
        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = myquery;
        //    cmd.Connection = con;
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //        Label11.Text = ds.Tables[0].Rows[0]["TaskTitle"].ToString();

        //    }

        //    con.Close();
        //}

        //private void taskdescription(string TaskId)
        //{
        //    String myquery = "Select * from CreateTask where TaskId='" + taskids + "'";
        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = myquery;
        //    cmd.Connection = con;
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //        Label12.Text = ds.Tables[0].Rows[0]["Taskdescription"].ToString();

        //    }

        //    con.Close();
        //}

        //private void task(string TaskId)
        //{
        //    String myquery = "Select * from CreateTask where TaskId='" + taskids + "'";
        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = myquery;
        //    cmd.Connection = con;
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {


        //        taskidfound = true;
        //    }
        //    else
        //    {
        //        taskidfound = false;
        //    }

        //    con.Close();
        //}

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