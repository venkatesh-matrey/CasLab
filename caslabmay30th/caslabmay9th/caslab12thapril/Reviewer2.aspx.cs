using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using PdfSharp.Pdf.IO;


namespace caslab12thapril
{
    public partial class Reviewer2 : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        
        public string HostAdd { get; private set; }
        public string FromEmailid { get; private set; }
        public string Pass { get; private set; }
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
            labeldata.Text = (string)Session["UserName"];



            if (!Page.IsPostBack)
            {

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
                        if (admindata.Approver == labeldata.Text)
                        {
                            labeldata.Text = (string)Session["Approver"];
                            //Binddropdown();

                            //GridView3.Visible = false;
                            usernamelabel.Visible = false;
                            usernamedata.Visible = false;
                            reviewerdata.Visible = false;
                            reviewer.Visible = false;
                            approverlabel.Visible = false;
                            approver.Visible = false;
                            list.Visible = false;
                            distributor.Visible = false;
                            submit.Visible = false;
                            testbutton.Visible = false;


                        }
                        else if (admindata.Reviewer == labeldata.Text)
                        {
                            labeldata.Text = (string)Session["Reviewer"];
                            usernamedatabind();
                            reviewerdatabind();
                            approverdatabind();
                            //GridView3.Visible = false;
                            submit.Visible = false;
                            usernamelabel.Visible = false;
                            usernamedata.Visible = false;
                            reviewerdata.Visible = false;
                            reviewer.Visible = false;
                            approverlabel.Visible = false;
                            approver.Visible = false;
                            list.Visible = false;
                            distributor.Visible = false;
                            finalsave.Visible = false;

                        }
                        else
                        {
                            //usernamebind();
                            //reviewerbind();
                            //approverbind();
                            //GridView3.Visible = false;
                            //reviewerdropdown();
                            //approverdropdown();
                            RadioButtonList1.Visible = false;
                            testbutton.Visible = false;
                            reviewercomments.Visible = false;
                            commentbox.Visible = false;
                            finalsave.Visible = false;


                        }
                    }
                    catch (Exception)
                    {

                    }
                    con.Close();
                }




                taskid.Text = Session["Name"] as String;
                label10.Text = taskid.Text;
            }
            //bindtextvalues(Label10.Text);



        }

        protected void reviewerdropdown()
        {

            DataBind();

            reviewer.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Reviewers", " "));
            reviewer.AppendDataBoundItems = true;



            String strQuery = "select UserName from AddEmployee where position = @position";
            SqlConnection con = new SqlConnection(str);

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@position", "Reviewer");
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                reviewer.DataSource = cmd.ExecuteReader();
                reviewer.DataTextField = "UserName";
                reviewer.DataValueField = "UserName";
                reviewer.DataBind();
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
        protected void approverdropdown()
        {

            DataBind();

            approver.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Approvers", " "));
            approver.AppendDataBoundItems = true;



            String strQuery = "select UserName from AddEmployee where position = @position";
            SqlConnection con = new SqlConnection(str);

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@position", "Approver");
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                approver.DataSource = cmd.ExecuteReader();
                approver.DataTextField = "UserName";
                approver.DataValueField = "UserName";
                approver.DataBind();
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
        private void reviewerbind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select Reviewer from AddEmployee where UserName = '" + Session["UserName"] + "'", con);
            con.Open();
            Session["Reviewer"] = cmd.ExecuteScalar();
            con.Close();
            reviewer.Text = Convert.ToString(Session["Reviewer"]);
        }


        private void usernamebind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select UserName from AddEmployee where UserName = '" + labeldata.Text + "'", con);
            con.Open();
            Session["UserName"] = cmd.ExecuteScalar();
            con.Close();
            usernamedata.Text = Convert.ToString(Session["UserName"]);
        }
        private void approverbind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select Approver from AddEmployee where UserName = '" + Session["UserName"] + "'", con);
            con.Open();
            Session["Approver"] = cmd.ExecuteScalar();
            con.Close();
            approver.Text = Convert.ToString(Session["Approver"]);
        }
        private void reviewerdatabind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select Reviewer from AddEmployee where Reviewer = '" + Session["Reviewer"] + "'", con);
            con.Open();
            Session["Reviewer"] = cmd.ExecuteScalar();
            con.Close();
            reviewer.Text = Convert.ToString(Session["Reviewer"]);
        }


        private void usernamedatabind()
        {
            SqlConnection con = new SqlConnection(str);
            labeldata.Text = (string)Session["UserName"];
            SqlCommand cmd = new SqlCommand("select UserName from AddEmployee where Reviewer = '" + labeldata.Text + "'", con);
            con.Open();
            Session["UserName1"] = cmd.ExecuteScalar();
            con.Close();
            usernamedata.Text = Convert.ToString(Session["UserName1"]);

        }
        private void approverdatabind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select Approver from AddEmployee where Approver = '" + Session["Approver"] + "'", con);
            con.Open();
            Session["Approver"] = cmd.ExecuteScalar();
            con.Close();
            approver.Text = Convert.ToString(Session["Approver"]);
        }



        private void reset()
        {
            label10.Text = "";

        }
        private void acceptdata()
        {
            SqlConnection con = new SqlConnection(str);


            labeldata.Text = (string)Session["UserName"];
            taskid.Text = Session["Name"] as String;
            SqlCommand status = new SqlCommand("update Inboxdetails set Reviewerstatus='ACCEPTED' , reviewercomments =@reviewercomments where Reviewer=@Reviewer and TaskId=@TaskId", con);
            try
            {
                con.Open();
                status.Parameters.AddWithValue("@TaskId", taskid.Text);
                status.Parameters.AddWithValue("@Reviewer", labeldata.Text);
                status.Parameters.AddWithValue("@reviewercomments", reviewercomments.Text);
                status.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }


        }


        protected void AddDataTableToPDF()
        {
            String pathin = System.Web.HttpContext.Current.Server.MapPath("~/frontpagepdf/" + taskid.Text + ".pdf");
            String pathout = System.Web.HttpContext.Current.Server.MapPath("~/frontpageeditpdf/" + taskid.Text + ".pdf");
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(pathin);
            PdfStamper stamper = new PdfStamper(reader, new FileStream(pathout, FileMode.Create));
            int n = reader.NumberOfPages;

            for (var i = 1; i <= n; i++)
            {



                PdfPCell cell = null;
                PdfPTable table = null;
                DataTable dt = GetDataTable();
                if (dt != null)
                {
                    Font font8 = FontFactory.GetFont("ARIAL", 12);
                    table = new PdfPTable(dt.Columns.Count);
                    cell = new PdfPCell(new Phrase(new Chunk("DATE", font8)));
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(new Chunk("Name", font8)));
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(new Chunk("Reviewer", font8)));
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(new Chunk("Approver", font8)));
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(new Chunk("Status", font8)));
                    table.AddCell(cell);
                    for (int rows = 0; rows < dt.Rows.Count; rows++)
                    {
                        for (int column = 0; column < dt.Columns.Count; column++)
                        {
                            cell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font8)));
                            table.AddCell(cell);
                        }
                    }
                }

                ColumnText ct = new ColumnText(stamper.GetOverContent(i));
                ct.AddElement(table);
                iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(46, 250, 560, 36);
                ct.SetSimpleColumn(36, 36, PageSize.A4.Width - 45, PageSize.A4.Height - 220);
                ct.Go();


            }
            stamper.Close();
            reader.Close();

        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);

            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 3f;
            cell.PaddingTop = 10f;
            return cell;
        }
        private DataTable GetDataTable()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT distinct  Date,TaskId,Reviewer,Approver,Status FROM Inboxdetails where TaskId='" + taskid.Text + "' and Status='RELEASED' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        private void approvertable()
        {

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;




            FileStream stream = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/frontpageeditpdf/" + taskid.Text + ".pdf"), FileMode.Open, FileAccess.Read);

            PdfWriter.GetInstance(pdfDoc, stream);
            int value = 0;

            value = stream.ReadByte();
            SqlConnection con = new SqlConnection(str);


            approverdata.Text = (string)Session["Approver"];
            taskid.Text = Session["Name"] as String;
            datelabel.Text = DateTime.Now.ToString("dd/MM/yyyy");

            SqlCommand status = new SqlCommand("update approverdata set Status='RELEASED' , Date=@Date,fronteditpdf=@fronteditpdf,fronteditdata=@fronteditdata where  TaskId=@TaskId", con);
            try
            {
                con.Open();
                status.Parameters.AddWithValue("@TaskId", taskid.Text);

                status.Parameters.AddWithValue("@Date", datelabel.Text);
                status.Parameters.AddWithValue("@fronteditpdf", "frontpageeditpdf\\" + taskid.Text + ".pdf");
                status.Parameters.AddWithValue("@fronteditdata", value);
                status.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }


        }
        private void acceptfinaldata()
        {
            SqlConnection con = new SqlConnection(str);


            approverdata.Text = (string)Session["UserName"];
            taskid.Text = Session["Name"] as String;
            datelabel.Text = DateTime.Now.ToString("dd/MM/yyyy");

            SqlCommand status = new SqlCommand("update Inboxdetails set Status='RELEASED' , approvercomments =@approvercomments,Date=@Date where Approver=@Approver and TaskId=@TaskId", con);
            try
            {
                con.Open();
                status.Parameters.AddWithValue("@TaskId", taskid.Text);
                status.Parameters.AddWithValue("@Approver", approverdata.Text);
                status.Parameters.AddWithValue("@approvercomments", reviewercomments.Text);
                status.Parameters.AddWithValue("@Date", datelabel.Text);
                status.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }


        }
        private void rejectfinaldata()
        {
            SqlConnection con = new SqlConnection(str);


            approverdata.Text = (string)Session["UserName"];
            taskid.Text = Session["Name"] as String;
            SqlCommand status = new SqlCommand("update Inboxdetails set Approverstatus='REJECTED' , approvercomments =@approvercomments where Approver=@Approver and TaskId=@TaskId", con);
            try
            {
                con.Open();
                status.Parameters.AddWithValue("@TaskId", taskid.Text);
                status.Parameters.AddWithValue("@Approver", approverdata.Text);
                status.Parameters.AddWithValue("@approvercomments", reviewercomments.Text);
                status.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }


        }
        private void rejectdata()
        {
            SqlConnection con = new SqlConnection(str);


            labeldata.Text = (string)Session["UserName"];
            taskid.Text = Session["Name"] as String;
            SqlCommand status = new SqlCommand("update Inboxdetails set Reviewerstatus='REJECTED' , reviewercomments =@reviewercomments where Reviewer=@Reviewer and TaskId=@TaskId", con);
            try
            {
                con.Open();
                status.Parameters.AddWithValue("@TaskId", taskid.Text);
                status.Parameters.AddWithValue("@Reviewer", labeldata.Text);
                status.Parameters.AddWithValue("@reviewercomments", reviewercomments.Text);
                status.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }


        }

        protected void testbutton_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem.Value == "ACCEPT")
            {
                acceptdata();
                string script = "alert(\"You accepted the task\")";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            }
            else if (RadioButtonList1.SelectedItem.Value == "REJECT")
            {
                rejectdata();
                string script = "alert(\"You Rejected the task\")";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            }

        }

        protected void submit_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            taskid.Text = Session["Name"] as String;
            SqlCommand command = new SqlCommand("select TaskId from Inboxdetails where TaskId='" + label10.Text + "'  ", con);
            con.Open();
            Session["TaskId"] = command.ExecuteScalar();
            con.Close();
            taskstatus.Text = Convert.ToString(Session["TaskId"]);
            //if (taskstatus.Text == label10.Text)
            //{
            //    string script1 = "alert(\"Already Submitted Please Check Your Status\")";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script1, true);
            //}
            //else
            //{
            //string filename = pdffile.PostedFile.FileName;
            //pdffile.SaveAs(Server.MapPath("~/storepdf/" +  filename));


            //string filename1 = Path.GetFileName(pdffile.PostedFile.FileName);
            //string contentType = pdffile.PostedFile.ContentType;
            //using (Stream fs = pdffile.PostedFile.InputStream)
            //{
            //    using (BinaryReader br = new BinaryReader(fs))
            //    {
            //        byte[] bytes = br.ReadBytes((Int32)fs.Length);
            SqlCommand cmd = new SqlCommand("multiple", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            if (distributor.Text.Contains(','))//checking for you are entered single value or multiple values  
            {
                string[] arryval = distributor.Text.Split(',');//split values with ‘,’  
                int j = arryval.Length;
                int i = 0;
                for (i = 0; i < j; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@EmployeeName", labeldata.Text);
                    cmd.Parameters.AddWithValue("@Reviewer", reviewer.Text);
                    cmd.Parameters.AddWithValue("@Approver", approver.Text);
                    cmd.Parameters.AddWithValue("@TaskId", taskid.Text);
                    cmd.Parameters.AddWithValue("@Reviewerstatus", "PENDING");
                    cmd.Parameters.AddWithValue("@distributor", arryval[i]);
                    cmd.Parameters.AddWithValue("@reviewercomments", "abc");


                    cmd.Parameters.AddWithValue("@Status", "PENDING");
                    cmd.ExecuteNonQuery();
                }

            }

            insertaddemployee();
            con.Close();
            reset();
            string script = "alert(\" Data Submitted Successfully\")";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
        protected void insertaddemployee()
        {
            SqlConnection con = new SqlConnection(str);
            usernamedata.Text = (string)Session["UserName"];
            taskid.Text = Session["Name"] as String;
            SqlCommand status = new SqlCommand("update Addemployee set Reviewer=@Reviewer ,Approver =@Approver where UserName=@UserName", con);
            try
            {
                con.Open();
                status.Parameters.AddWithValue("@UserName", usernamedata.Text);
                status.Parameters.AddWithValue("@Reviewer", reviewer.Text);
                status.Parameters.AddWithValue("@Approver", approver.Text);
                status.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }


        }
        private void pdfdatabind()
        {


            SqlConnection con = new SqlConnection(str);

            string sql = "SELECT  s.Email ,h.taskid, h.pdfdata, s.UserName,hp.EmployeeName,hp.distributor,hp.TaskId FROM AddEmployee s INNER JOIN Inboxdetails hp on s.UserName = hp.distributor and hp.TaskId = '" + taskid.Text + "' INNER JOIN taskpdffile h on hp.TaskId = h.taskid where h.taskid ='" + taskid.Text + "'";
            //string sql = " SELECT  s.Email , s.UserName , h.taskid, h.pdfdata, hp.EmployeeName , hp.distributor , hp.TaskId FROM AddEmployee s INNER JOIN Inboxdetails hp    on s.UserName = hp.distributor INNER JOIN taskpdffile h on hp.TaskId = h.taskid";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                Session["pdfdata"] = cmd.ExecuteScalar();
                con.Close();
                emailbox.Text = Convert.ToString(Session["pdfdata"]);
            }
        }

        private void distributormail()
        {
            //emaildatabind();
            //string toEmail = "";
            //toEmail = memployee.Text;
            //pdfdatabind();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            //string sql = "SELECT  s.Email ,h.taskid, h.pdfdata, s.UserName,hp.EmployeeName,hp.distributor,hp.TaskId FROM AddEmployee s INNER JOIN Inboxdetails hp on s.UserName = hp.distributor and hp.TaskId = '" + taskid.Text + "' INNER JOIN taskpdffile h on hp.TaskId = h.taskid where h.taskid ='" + taskid.Text + "'";
            //string sql = " SELECT  s.Email , s.UserName , h.taskid, h.releasedpdfdata, hp.EmployeeName , hp.distributor , hp.TaskId FROM AddEmployee s INNER JOIN Inboxdetails hp    on s.UserName = hp.distributor ";
            string sql = "SELECT distinct  s.Email , s.UserName , hp.taskid, hp.releasedpdfdata, hp.EmployeeName , hp.distributor , hp.TaskId FROM AddEmployee s INNER JOIN Inboxdetails hp    on s.UserName = hp.distributor and hp.TaskId='" + label10.Text + "' ";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {


                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        memployee.Text = (string)dr["Email"];


                        //byte[] imagedata = (byte[])dr["pdfdata"];
                        //string img = Convert.ToBase64String(imagedata);

                        //emailbox.Text =  img;

                        //byte[] pdffile;
                        //pdffile = (byte[])dr["pdfdata"];
                        //emailbox.Text = pdffile.ToString();

                        //Reading sender Email credential from web.config file
                        HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                        FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
                        Pass = ConfigurationManager.AppSettings["Password"].ToString();

                        //creating the object of MailMessage
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress(FromEmailid); //From Email Id
                        mailMessage.Subject = "sample"; //Subject of Email

                        //Adding Multiple recipient email id logic
                        //ToEmail

                        mailMessage.Body = "Hello";


                        string[] Multi = memployee.Text.Split(','); //spiliting input Email id string with comma(,)
                        foreach (string Multiemailid in Multi)
                        {
                            mailMessage.To.Add(new MailAddress(Multiemailid));
                            //adding multi reciver's Email Id
                        }
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(Server.MapPath("~/finalreleasedpdf/" + taskid.Text + ".pdf"));
                        mailMessage.Attachments.Add(attachment);
                        SmtpClient smtp = new SmtpClient(); // creating object of smptpclient
                        smtp.Host = HostAdd; //host of emailaddress for example smtp.gmail.com etc

                        //network and security related credentials
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = mailMessage.From.Address;
                        NetworkCred.Password = Pass;
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;

                        smtp.Port = 25;
                        smtp.Send(mailMessage); //sending Email
                    }

                    dr.Close();
                }
            }
            con.Close();

        }


        protected void getfrontpage()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand summarycmd = new SqlCommand("select distinct  fronteditpdf from approverdata where  TaskId= '" + taskid.Text + "'", con);
            con.Open();

            Session["fronteditpdf"] = summarycmd.ExecuteScalar();
            frontpagedata.Text = Session["fronteditpdf"].ToString();
            con.Close();
        }
        protected void geteditorpage()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand summarycmd = new SqlCommand("select distinct  filename from approverdata where  TaskId= '" + taskid.Text + "'", con);
            con.Open();

            Session["filename"] = summarycmd.ExecuteScalar();
            editorpage.Text = Session["filename"].ToString();
            con.Close();
        }
        protected void CopyPages(PdfSharp.Pdf.PdfDocument from, PdfSharp.Pdf.PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }
        protected void mergepdf()
        {
            // writetoreleasedpdf();
            getfrontpage();
            geteditorpage();

            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            //FileStream stream = new FileStream(Server.MapPath("~/frontpagepdf/" + taskid.Text + ".pdf"), FileMode.Open, FileAccess.Write);

            //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

            //pdfDoc.Open();

            //PdfContentByte cb = writer.DirectContent;
            //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //cb.SetColorFill(BaseColor.DARK_GRAY);
            //cb.SetFontAndSize(bf, 10);
            //datelabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //cb.BeginText();
            ////string text = datelabel.Text.ToString();
            //// put the alignment and coordinates here
            //cb.ShowTextAligned(1, datelabel.Text, 20, 517, 0);
            //cb.EndText();
            //pdfDoc.Close();

            string frontpagelocation = frontpagedata.Text;

            string filelocation = editorpage.Text;

            taskid.Text = Session["Name"].ToString();

            string Filepath = Server.MapPath("~/" + filelocation);
            string frontpage = Server.MapPath("~/" + frontpagelocation);

            string finalpath = Server.MapPath("~/finalreleasedpdf/" + taskid.Text + ".pdf");

            using (PdfSharp.Pdf.PdfDocument one = PdfSharp.Pdf.IO.PdfReader.Open(frontpage, PdfDocumentOpenMode.Import))
            using (PdfSharp.Pdf.PdfDocument two = PdfSharp.Pdf.IO.PdfReader.Open(Filepath, PdfDocumentOpenMode.Import))

            using (PdfSharp.Pdf.PdfDocument outPdf = new PdfSharp.Pdf.PdfDocument())
            {

                CopyPages(one, outPdf);
                CopyPages(two, outPdf);

                outPdf.Save(finalpath);
            }

        }



        protected void writetoreleasedpdf()
        {
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            FileStream stream = new FileStream(Server.MapPath("~/frontpagepdf/" + taskid.Text + ".pdf"), FileMode.Open, FileAccess.Write);

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

            pdfDoc.Open();

            PdfContentByte cb = writer.DirectContent;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DARK_GRAY);
            cb.SetFontAndSize(bf, 10);

            cb.BeginText();
            datelabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cb.ShowTextAligned(1, datelabel.Text, 20, 517, 0);
            cb.EndText();
            cb.BeginText();
            string data = "hello";
            cb.ShowTextAligned(1, data, 20, 517, 0);
            cb.EndText();
            pdfDoc.Close();
        }


        protected void updatereleasepdf()
        {
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);




            FileStream stream = new FileStream(Server.MapPath("~/Releasedpdf/" + taskid.Text + ".pdf"), FileMode.Open, FileAccess.Read);

            PdfWriter.GetInstance(pdfDoc, stream);
            int value = 0;

            value = stream.ReadByte();
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update Inboxdetails set releasedpdf=@releasedpdf ,releasedpdfdata=@releasedpdfdata where TaskId=@TaskId ", con);

            cmd.Parameters.AddWithValue("@TaskId", taskid.Text);

            cmd.Parameters.AddWithValue("@releasedpdf", "Releasedpdf\\" + taskid.Text + ".pdf");
            cmd.Parameters.AddWithValue("@releasedpdfdata", value);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        protected void finalsave_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem.Value == "ACCEPT")
            {
                acceptfinaldata();
                AddDataTableToPDF();
                approvertable();

                mergepdf();
                distributormail();
                // GridView3.Visible = true;
                string script = "alert(\"You accepted the task\")";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            }
            else if (RadioButtonList1.SelectedItem.Value == "REJECT")
            {
                rejectfinaldata();
                //GridView3.Visible = false;
                string script = "alert(\"You Rejected the task\")";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

            }

        }





    }
}