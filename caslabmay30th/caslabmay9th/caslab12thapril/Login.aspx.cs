using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace caslab12thapril
{
    public partial class Login1 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        static String lockstatus;
       

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public class admin
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string EmpId { get; set; }
            public string Reviewer { get; set; }
            public string Approver { get; set; }
            public string position { get; set; }
            public string status { get; set; }
            public string EmpPosition { get; set; }
        }
        private void setlockstatus(String username1)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                String updatedata = "Update Addemployee set status='Locked' where UserName='" + username1 + "'";
                
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {



            if (txtUserName.Text == "admin" && txtPassword.Text == "caslab")
            {
                Response.Redirect("Admindashboard.aspx");
            }
          

            else
            {
                          int attemptcount = 0;
                int id = 0;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    admin admindata = new admin();
                    string oString = "  select EmpId,Reviewer,UserName,Approver,Password,position,status,EmpPosition from AddEmployee where UserName=@UserName ";
                    SqlCommand cmd = new SqlCommand(oString, con);

                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    con.Open();
                    using (SqlDataReader oReader1 = cmd.ExecuteReader())
                    {
                        while (oReader1.Read())
                        {
                                  
                            admindata.UserName = oReader1["UserName"].ToString();
                            admindata.Password = oReader1["Password"].ToString();
                            admindata.EmpId = oReader1["EmpId"].ToString();
                            admindata.Reviewer = oReader1["Reviewer"].ToString();
                            admindata.Approver = oReader1["Approver"].ToString();
                            admindata.position = oReader1["position"].ToString();
                            admindata.status = oReader1["status"].ToString();
                            admindata.EmpPosition = oReader1["EmpPosition"].ToString();

                         
                                if ((admindata.status == "Active"))
                                {
                                 
                                 if ((admindata.UserName == txtUserName.Text) && (admindata.Password == txtPassword.Text) && (admindata.position == "creator"))
                                {
                                    Session["UserName"] = admindata.UserName;
                                    Session["EmpId"] = admindata.EmpId;
                                    admindata.Reviewer = oReader1["Reviewer"].ToString();
                                    admindata.Approver = oReader1["Approver"].ToString();
                                    Response.Redirect("~/WebForm1.aspx");
									attemptcount = 0;
                                }
                                else if ((admindata.UserName == txtUserName.Text) && (admindata.Password == txtPassword.Text) && (admindata.position == "Reviewer"))
                                {
                                    Session["UserName"] = admindata.UserName;

                                    Session["Approver"] = admindata.Approver;
                                    Session["Reviewer"] = admindata.Reviewer;
                                    Response.Redirect("~/WebForm1.aspx");
                                }
                                else if ((admindata.UserName == txtUserName.Text) && (admindata.Password == txtPassword.Text) && (admindata.position == "Approver"))
                                {
                                    Session["UserName"] = admindata.UserName;

                                    Session["Approver"] = admindata.Approver;
                                    Session["Reviewer"] = admindata.Reviewer;
                                    Response.Redirect("~/WebForm1.aspx");
                                }
                                
                                else
                                {


                                    Label3.Text = "Invalid Username or Password - Relogin with Correct Username Password- No. of Attemps Remaining : " + (2 - attemptcount);
                                    attemptcount = attemptcount + 1;

                                }
                            }

                            else
                            {
                                if ((admindata.UserName == txtUserName.Text) && (admindata.Password == txtPassword.Text) && (admindata.EmpPosition == "Resigned"))
                                {
                                    Label3.Text = "you cannot login";
                                }
                               
                            }
                        }
                        
                        if (attemptcount == 3)
                        {
                            Label3.Text = "Your Account Has Been Locked Due to Three Invalid Attempts - Contact Administrator";
                            setlockstatus(txtUserName.Text);
                            attemptcount = 0;
                        }

                        con.Close();

                        string message = string.Empty;
                        switch (id)
                        {
                            case -1:
                                message = "Username and/or password is incorrect.";
                                break;
                            case -2:
                                message = "Account has not been activated.";
                                break;

                        }
                    }


                }
            }



        }
    }
}
