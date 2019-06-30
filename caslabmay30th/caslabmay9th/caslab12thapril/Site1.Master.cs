using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace caslab12thapril
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        public class admin
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string EmpId { get; set; }
            public string Reviewer { get; set; }
            public string Approver { get; set; }
        }
        public static string st1 = "";


        protected void Page_Load(object sender, EventArgs e)
        {

            username.Text = (string)Session["UserName"];

            if (!this.IsPostBack)
            {
                DataTable dt = this.GetData("SELECT Id, Name,ProjectName,ProjectDescription,EmpId FROM AddProject3 where EmpId= '" + Session["EmpId"] + "' ");
                this.PopulateTreeView(dt, 0, null);
            }
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                admin admindata = new admin();
                SqlCommand cmd = new SqlCommand("select EmpId,Reviewer,UserName,Approver,Password from AddEmployee where Reviewer= '" + Session["UserName"] + "' OR  Approver = '" + Session["UserName"] + "'", con);

                using (SqlDataReader oReader1 = cmd.ExecuteReader())
                {
                    while (oReader1.Read())
                    {

                        admindata.UserName = oReader1["UserName"].ToString();
                        admindata.Password = oReader1["Password"].ToString();
                        admindata.EmpId = oReader1["EmpId"].ToString();
                        admindata.Reviewer = oReader1["Reviewer"].ToString();
                        admindata.Approver = oReader1["Approver"].ToString();
                    }
                }
                try
                {
                    if (admindata.Approver == username.Text)
                    {
                        username.Text = (string)Session["Approver"];
                        //viewstatus.Visible = false;
                        //bull1.Visible = false;
                        //BulletedList2.Visible = false;
                        //GridView1.Visible = false;

                        string Reviewer = (string)Session["Reviewer"];
                        //sql2.SelectParameters["Reviewer"].DefaultValue = Reviewer;
                        SqlCommand comm = new SqlCommand("select count(distinct TaskId) from Inboxdetails where Approver= '" + username.Text + "' and  Reviewerstatus='ACCEPTED' and Status='PENDING' ", con);
                        Button1.Text = "Inbox(" + comm.ExecuteScalar().ToString() + ")";
                    }
                    else if (admindata.Reviewer == username.Text)
                    {
                        username.Text = (string)Session["Reviewer"];
                        SqlCommand command = new SqlCommand("select count(distinct TaskId) from Inboxdetails where Reviewer= '" + username.Text + "' and  Reviewerstatus='PENDING' ", con);
                        Button1.Text = "Inbox(" + command.ExecuteScalar().ToString() + ")";
                        string Reviewer = (string)Session["Reviewer"];
                        //sql1.SelectParameters["Reviewer"].DefaultValue = Reviewer;
                        //viewstatus.Visible = false;
                        //BulletedList1.Visible = false;
                        //BulletedList2.Visible = false;

                    }
                    else
                    {
                        //GridView1.Visible = false;

                        //BulletedList1.Visible = false;
                        SqlCommand command = new SqlCommand("select count(distinct TaskId) from Inboxdetails where EmployeeName= '" + username.Text + "' and  Reviewerstatus='REJECTED' or   Status='REJECTED' ", con);
                        Button1.Text = "Inbox(" + command.ExecuteScalar().ToString() + ")";
                        //bull1.Visible = false;
                        string Reviewer = (string)Session["Reviewer"];
                        //sql3.SelectParameters["Reviewer"].DefaultValue = Reviewer;
                    }
                }
                catch (Exception)
                {

                }
                con.Close();
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

                    DataTable dtChild = this.GetData("SELECT Id, Name,TaskDescription,EmpId,UserName  FROM AddnewTask2 WHERE TaskTypeId= '" + child.Value + "'  and  UserName= '" + Session["UserName"] + "' and EmpId= '" + Session["EmpId"] + "'");

                    PopulateTreeView(dtChild, int.Parse(child.Value), child);


                }
                else
                {
                    treeNode.ChildNodes.Add(child);



                }




            }
        }

        private void bindicon()
        {
            releasereviewerdatabind();
            releaseapproverdatabind();
            if (reviewerstatus.Text == "ACCEPTED" && approverstatus.Text == "ACCEPTED" && Label3.Text == Label2.Text)
            {


                TreeView1.LeafNodeStyle.ForeColor = System.Drawing.Color.Green;
                TreeView1.LeafNodeStyle.ImageUrl = "img/icon.png";

            }


            else
            {
                TreeView1.LeafNodeStyle.ForeColor = System.Drawing.Color.Gray;
                TreeView1.LeafNodeStyle.ImageUrl = "img/doticon.png";
            }
        }
        private void releasereviewerdatabind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(" SELECT DISTINCT Reviewerstatus, EmployeeName,Reviewer ,TaskId FROM Inboxdetails WHERE EmployeeName = '" + Session["UserName"] + "' and TaskId = '" + Label2.Text + "'", con);

            con.Open();
            Session["Reviewerstatus"] = cmd.ExecuteScalar();
            con.Close();
            reviewerstatus.Text = Convert.ToString(Session["Reviewerstatus"]);
        }
        private void releaseapproverdatabind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(" SELECT DISTINCT Approverstatus,EmployeeName, Approver ,TaskId FROM Inboxdetails WHERE EmployeeName = '" + Session["UserName"] + "' and TaskId = '" + Label2.Text + "'", con);

            con.Open();
            Session["Approverstatus"] = cmd.ExecuteScalar();
            con.Close();
            approverstatus.Text = Convert.ToString(Session["Approverstatus"]);
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




        protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
        {

            try
            {
                Label1.Text = "";

                Label1.Text = TreeView1.SelectedNode.Text.ToString();
                Session["Name"] = Label1.Text;
                Response.Redirect("ViewPage2.aspx");
            }
            catch { }

            //or ues this one also

            //st1 = TreeView1.SelectedNode.Text;

            //Reviewer2 r = new Reviewer2();
            //Response.Redirect("Reviewer2.aspx");


        }

        protected void homebutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inbox.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            taskid.Text = Session["Name"] as String;
            label10.Text = taskid.Text;
            Response.Redirect("Reviewer2.aspx");
        }
    }
}