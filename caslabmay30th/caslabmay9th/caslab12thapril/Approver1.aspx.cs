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
    public partial class Approver1 : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        public static string st1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            employeeid.Text = (string)Session["EmpId"];
            string EmpId = (string)Session["EmpId"];
            Sqldatasource2.SelectParameters["EmpId"].DefaultValue = EmpId;
            if (!Page.IsPostBack)
            {


                DataBind();

                approvername.Items.Insert(0, new System.Web.UI.WebControls.ListItem("   approvername   ", " "));
                approvername.AppendDataBoundItems = true;



                String strQuery = "select Approver from AddEmployee where EmpId=@EmpId";
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@EmpId", employeeid.Text);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    approvername.DataSource = cmd.ExecuteReader();
                    approvername.DataTextField = "Approver";
                    approvername.DataValueField = "Approver";
                    approvername.DataBind();
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

        protected void approvername_SelectedIndexChanged(object sender, EventArgs e)
        {

            String strQuery = "select EmpId from AddEmployee where EmpName =@EmpName";

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@EmpName", approvername.SelectedItem.Text);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    approverid.Text = sdr.GetValue(0).ToString();
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

        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("insert into ApproverTaskdetails(EmpId,Approvername,TaskId,Comments,Status)values(@EmpId,@Approvername,@TaskId,@Comments,@Status)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@EmpId", approverid.Text);
            cmd.Parameters.AddWithValue("@Approvername", approvername.Text);
            cmd.Parameters.AddWithValue("@TaskId", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@Comments", comments.Text);
            if (Accept.Checked)
                cmd.Parameters.AddWithValue("@Status", Accept.Text);
            if (Reject.Checked)
                cmd.Parameters.AddWithValue("@Status", Reject.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            reset();
            label1.Text = "submitted sucessfully";

            //if (Accept.Checked == true)
            //    st1 = Accept.Text;
            //else
            //    st1 = Reject.Text;
            //Approver1 app = new Approver1();
            //Response.Redirect("WebForm1.aspx");

        }

       

        private void reset()
        {
            DropDownList1.SelectedItem.Text = "";
        }

      
    }
}