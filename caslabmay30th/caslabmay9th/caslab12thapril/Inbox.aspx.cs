using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using iTextSharp.text.html.simpleparser;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace caslab12thapril
{
    public partial class Inbox1 : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            username.Text = (string)Session["UserName"];


            using (SqlConnection con = new SqlConnection(str))
            {

                admin admindata = new admin();
                SqlCommand cmd = new SqlCommand("select EmpId,Reviewer,UserName,Approver,Password from AddEmployee where Reviewer= '" + Session["UserName"] + "' OR  Approver = '" + Session["UserName"] + "'", con);

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
                    }
                }
                try
                {
                    if (admindata.Approver == username.Text)
                    {
                        username.Text = (string)Session["UserName"];
                        viewstatus.Visible = false;
                        bull1.Visible = false;
                        BulletedList2.Visible = false;
                        //GridView1.Visible = false;

                        string Reviewer = (string)Session["UserName"];
                        sql2.SelectParameters["Approver"].DefaultValue = Reviewer;
                        SqlCommand comm = new SqlCommand("select count(distinct TaskId) from Inboxdetails where Approver= '" + username.Text + "' and  Reviewerstatus='ACCEPTED' and Status='PENDING' ", con);
                        Button1.Text = "Inbox(" + comm.ExecuteScalar().ToString() + ")";
                    }
                    else if (admindata.Reviewer == username.Text)
                    {
                        username.Text = (string)Session["UserName"];
                        SqlCommand command = new SqlCommand("select count(distinct TaskId) from Inboxdetails where Reviewer= '" + username.Text + "' and  Reviewerstatus='PENDING' ", con);
                        Button1.Text = "Inbox(" + command.ExecuteScalar().ToString() + ")";
                        string Reviewer = (string)Session["UserName"];
                        sql1.SelectParameters["Reviewer"].DefaultValue = Reviewer;
                        viewstatus.Visible = false;
                        BulletedList1.Visible = false;
                        BulletedList2.Visible = false;

                    }
                    else
                    {
                        //GridView1.Visible = false;
                        username.Text = (string)Session["UserName"];
                        BulletedList1.Visible = false;
                        SqlCommand command = new SqlCommand("select count(distinct TaskId) from Inboxdetails where EmployeeName= '" + username.Text + "' and  Reviewerstatus='REJECTED' or   Status='REJECTED' ", con);
                        Button1.Text = "Inbox(" + command.ExecuteScalar().ToString() + ")";
                        bull1.Visible = false;
                        string Reviewer = (string)Session["UserName"];
                        sql3.SelectParameters["UserName"].DefaultValue = Reviewer;
                    }
                }
                catch (Exception)
                {

                }
                con.Close();
            }








        }
        protected void Binddropdown()
        {
            if (!Page.IsPostBack)
            {
                //conenction path for database
                using (SqlConnection con = new SqlConnection(str))
                {
                    //con.Open();
                    //SqlCommand cmd = new SqlCommand("select TaskId from Inboxdata", con);
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds);
                    //rd1.DataSource = ds;
                    //    rd1.DataTextField = "TaskId";
                    //    rd1.DataValueField = "TaskId";
                    //    rd1.DataBind();
                    //    rd1.Items.Insert(0, new ListItem("--TaskId--"));
                    //con.Close();
                }
            }
        }




        protected void bull1_Click1(object sender, BulletedListEventArgs e)
        {

            System.Web.UI.WebControls.ListItem item = bull1.Items[e.Index];

            Label3.Text = item.Text;

            Session["Name"] = Label3.Text;
            Response.Redirect("ViewPage2.aspx");
        }

        protected void homebutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inbox.aspx");

        }

        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {
            System.Web.UI.WebControls.ListItem item = BulletedList1.Items[e.Index];

            Label3.Text = item.Text;

            Session["Name"] = Label3.Text;
            Response.Redirect("ViewPage2.aspx");
        }

        protected void BulletedList2_Click(object sender, BulletedListEventArgs e)
        {
            System.Web.UI.WebControls.ListItem item = BulletedList2.Items[e.Index];

            Label3.Text = item.Text;

            Session["Name"] = Label3.Text;
            Response.Redirect("ViewPage2.aspx");
        }



        protected void Button2_Click1(object sender, EventArgs e)
        {
            taskid.Text = Session["Name"] as String;
            label10.Text = taskid.Text;
            Response.Redirect("Reviewer2.aspx");
        }



        //protected void pdfdocapp_Click1(object sender, EventArgs e)
        //{

        //    int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
        //    string filelocation = GridView2.Rows[rowIndex].Cells[3].Text;
        //    string Filepath = Server.MapPath("~/" + filelocation);
        //    WebClient User = new WebClient();
        //    Byte[] FileBuffer = User.DownloadData(Filepath);
        //    if (FileBuffer != null)
        //    {
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-length", FileBuffer.Length.ToString());
        //        Response.BinaryWrite(FileBuffer);
        //    }
        //}

        //protected void send_Click(object sender, EventArgs e)
        //{
        //    int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
        //    Session["Name"] = GridView2.Rows[rowIndex].Cells[1].Text;
        //    taskid.Text = Session["Name"].ToString();
        //    Response.Redirect("Reviewer2.aspx");
        //}

        //protected void pdfdo_Click(object sender, EventArgs e)
        //{
        //    int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
        //    string filelocation = GridView1.Rows[rowIndex].Cells[3].Text;
        //    string Filepath = Server.MapPath("~/" + filelocation);
        //    WebClient User = new WebClient();
        //    Byte[] FileBuffer = User.DownloadData(Filepath);
        //    if (FileBuffer != null)
        //    {
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-length", FileBuffer.Length.ToString());
        //        Response.BinaryWrite(FileBuffer);
        //    }
        //}

        //protected void send_Click1(object sender, EventArgs e)
        //{

        //    int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
        //    Session["Name"] = GridView1.Rows[rowIndex].Cells[0].Text;
        //    taskid.Text = Session["Name"].ToString();
        //    Response.Redirect("Reviewer2.aspx");

        //}



    }
}