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
    public partial class Reviewer1 : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            employeeid.Text = (string)Session["EmpId"];

            
            string EmpId = (string)Session["EmpId"];
            SqlDataSource1.SelectParameters["EmpId"].DefaultValue = EmpId;
            if (!Page.IsPostBack)
            {

                
               
                DataBind();

                reviwername.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  Created Reviewer   ", " "));
                reviwername.AppendDataBoundItems = true;



                String strQuery = "select Reviewer from AddEmployee where EmpId=@EmpId";
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@EmpId", employeeid.Text);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    reviwername.DataSource = cmd.ExecuteReader();
                    reviwername.DataTextField = "Reviewer";
                    reviwername.DataValueField = "Reviewer";
                    reviwername.DataBind();
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

        protected void reviwername_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strQuery = "select EmpId from AddEmployee where EmpName =@EmpName";

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@EmpName", reviwername.SelectedItem.Text);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    revempid.Text = sdr.GetValue(0).ToString();
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
            SqlCommand cmd = new SqlCommand("insert into ReviewerTaskDetails(EmpId,Reviewername,TaskId)values(@EmpId,@Reviewername,@TaskId)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@EmpId", revempid.Text);
            cmd.Parameters.AddWithValue("@Reviewername", reviwername.Text);
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
