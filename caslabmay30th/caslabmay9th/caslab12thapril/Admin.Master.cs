using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace caslab12thapril
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            NewEmployeeID();
			
            if (!Page.IsPostBack)
            {
               
                Projectid.Items.Insert(0,new System.Web.UI.WebControls.ListItem(" Search ", " "));
                Projectid.AppendDataBoundItems = true;

                String strQuery = "select Id,Name from AddProject3 ";
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand();
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    //con.Open();
                    //Projectid.DataSource = cmd.ExecuteReader();
                    //Projectid.DataTextField = "Name";
                    //Projectid.DataValueField = "Id";
                    //Projectid.DataBind();

                    con.Open();
                    Projectid.DataSource = cmd.ExecuteReader();
                    Projectid.DataTextField = "Name";
                    Projectid.DataValueField = "Id";
                    Projectid.DataBind();
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

       
        protected void Projectid_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = this.GetData("SELECT Id, Name,ProjectName,ProjectDescription,EmpId FROM AddProject3 where Name= '" + Projectid.SelectedItem.Text + "' ");
            TreeView1.Nodes.Clear();
            this.PopulateTreeView(dt, 0, null);
            
        }
   private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }



        private void PopulateTreeView(DataTable dtParent, int parentId, TreeNode treeNode)
        {

            foreach (DataRow row in dtParent.Rows)
            {

                TreeNode child = new TreeNode
                {

                    Text = row["Name"].ToString(),
                    Value = row["Id"].ToString()


                };

                if (parentId == 0)
                {
                    TreeView1.Nodes.Add(child);

                    DataTable dtChild = this.GetData("SELECT Id, Name,TaskDescription,EmpId,UserName,projectid  FROM AddnewTask2 WHERE  projectid = '" + Projectid.SelectedItem.Text + "'");

                    PopulateTreeView(dtChild, int.Parse(child.Value), child);


                }
                else
                {
                    treeNode.ChildNodes.Add(child);



                }




            }
        }
        protected void homebutton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Admindashboard.aspx");
            TreeView1.Nodes.Clear();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Addemployee.aspx");
        }
    }
    }
    
