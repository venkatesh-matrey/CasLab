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
    public partial class Admin : System.Web.UI.MasterPage
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            NewEmployeeID();
        }
        private void NewEmployeeID()
        {

            string code = "CASLABEMPID-";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(EmpId) from AddEmployee", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtEmpid.Text = code + i.ToString();

        }



        protected void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
           
            SqlCommand cmd = new SqlCommand("insert into AddEmployee(EmpId,EmpName,UserName,Qualification,Phone,Email,Creator,Reviewer,Approver,Password) values(@EmpId,@EmpName,@UserName,@Qualification,@Phone,@Email,@Creator,@Reviewer,@Approver,@Password)", con);

            con.Open();
            cmd.Parameters.AddWithValue("@EmpId", txtEmpid.Text);
            cmd.Parameters.AddWithValue("@EmpName", txtempname.Text);
            cmd.Parameters.AddWithValue("@UserName", txtusername.Text);
            cmd.Parameters.AddWithValue("@Qualification", txtqualification.Text);
            cmd.Parameters.AddWithValue("@Phone", txtphonenumber.Text);
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@Creator", txtcreater.Text);
            cmd.Parameters.AddWithValue("@Reviewer", txtreviver.Text);
            cmd.Parameters.AddWithValue("@Approver", txtapprover.Text);
            cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
            cmd.ExecuteNonQuery();
            


            con.Close();
            reset();
        }
        private void reset()
        {
            txtempname.Text = String.Empty;
            txtusername.Text = String.Empty;
            txtemail.Text = String.Empty;
            txtqualification.Text = string.Empty;
            txtphonenumber.Text = string.Empty;
            txtreviver.Text = string.Empty;
            txtapprover.Text = string.Empty;
            txtcreater.Text = String.Empty;
            txtpassword.Text = String.Empty;
        }

       
        protected void homebutton_Click(object sender, EventArgs e)
        {

            Response.Redirect("Dashboard.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Addemployee.aspx");
        }
    }
    }
    
