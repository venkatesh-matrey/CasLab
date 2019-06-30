using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace caslab12thapril
{
    public partial class CreateProject : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            empid.Text = (string)Session["EmpId"];
            empname.Text = (string)Session["UserName"];
            //string EmpId = (string)Session["EmpId"];
            //SqlDataSource1.SelectParameters["EmpId"].DefaultValue = EmpId;
            NewProjectID();

            id();
        }

        private void id()
        {

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(Id) from AddProject3", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            Textbox1.Text = i.ToString();
        }


        private void NewProjectID()
        {

            string code = "CASLAB00-";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(Name) from AddProject3", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;

            txtprojectid.Text = code + i.ToString();
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("insert into AddProject3(Id,Name,ProjectName,ProjectDescription,EmpId,UserName) values(@Id,@Name,@ProjectName,@ProjectDescription,@EmpId,@UserName)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", Textbox1.Text);
            cmd.Parameters.AddWithValue("@Name", txtprojectid.Text);
            cmd.Parameters.AddWithValue("@ProjectName", txtprojectname.Text);
            cmd.Parameters.AddWithValue("@ProjectDescription", txtcomment.Text);
            cmd.Parameters.AddWithValue("@EmpId", empid.Text);
            cmd.Parameters.AddWithValue("@UserName", empname.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }

    }
}