using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.IO;
using iTextSharp.text;
using SautinSoft.Document;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using SautinSoft.Document.Drawing;
using PdfSharp.Pdf.IO;

namespace caslab12thapril
{
    public partial class ViewPage2 : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        public static string st1 = "";
        public static string st2 = "";

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
            label.Text = (string)Session["UserName"];

            bindtextvalues();
            if (!IsPostBack == true)
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
                        if (admindata.Approver == label.Text)
                        {
                            label.Text = (string)Session["Approver"];
                            //Binddropdown();
                            LinkButton1.Visible = false;


                        }
                        else if (admindata.Reviewer == label.Text)
                        {
                            label.Text = (string)Session["Reviewer"];
                            //Binddropdown();

                            LinkButton1.Visible = false;


                        }
                        else
                        {

                        }
                    }
                    catch (Exception)
                    {

                    }
                    con.Close();
                }

                assigntask.Visible = false;
                taskid.Text = Session["Name"] as String;
                Panel1.Visible = true;
                Label10.Text = taskid.Text;
                label.Text = taskid.Text;

                finddescription(Label10.Text);
                aftersummarytext.Visible = false;
                //myframe.Visible = true;
                //folder.Text = "~/Releasedpdf/" + taskid.Text + ".pdf";
                //myframe.Attributes["src"] = folder.Text.ToString();
                icon.Visible = false;
                // bindimage();
                //bindgrid();
                summarytextbind();
                if (string.IsNullOrEmpty(aftersummarytext.Text))
                {
                    summarytext.Visible = true;
                    aftersummarytext.Visible = false;
                }
                else
                {
                    summarytext.Visible = false;
                    aftersummarytext.Visible = true;
                }
                getiframe();
                if (string.IsNullOrEmpty(iframesource.Text))
                {

                    myframe.Visible = false;
                    Panel1.Visible = true;
                }
                else
                {

                    logo.Visible = false;
                    Panel1.Visible = false;
                    myframe.Visible = true;
                    LinkButton1.Visible = false;
                    mergepdf();
                    folder.Text = "~/Releasedpdf/" + taskid.Text + ".pdf";
                    myframe.Attributes["src"] = folder.Text.ToString();
                    butedit.Visible = false;
                    //updatereleasepdf();

                }
                releasereviewerdatabind();
                releaseapproverdatabind();
                if (reviewerstatus.Text == "ACCEPTED" && approverstatus.Text == "RELEASED")
                {
                    summarytext.Visible = false;
                    icon.Visible = true;

                    assigntask.Visible = false;
                    LinkButton1.Visible = false;
                    folder.Text = "~/finalreleasedpdf/" + taskid.Text + ".pdf";
                    myframe.Attributes["src"] = folder.Text.ToString();
                }
                else
                {

                    icon.Visible = false;
                }

            }



        }

        protected void getfrontpage()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand summarycmd = new SqlCommand("select distinct  frontpdf from approverdata where  TaskId= '" + taskid.Text + "'", con);
            con.Open();

            Session["frontpdf"] = summarycmd.ExecuteScalar();
            frontpagedata.Text = Session["frontpdf"].ToString();
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

            string finalpath = Server.MapPath("~/Releasedpdf/" + taskid.Text + ".pdf");

            using (PdfSharp.Pdf.PdfDocument one = PdfSharp.Pdf.IO.PdfReader.Open(frontpage, PdfDocumentOpenMode.Import))
            using (PdfSharp.Pdf.PdfDocument two = PdfSharp.Pdf.IO.PdfReader.Open(Filepath, PdfDocumentOpenMode.Import))

            using (PdfSharp.Pdf.PdfDocument outPdf = new PdfSharp.Pdf.PdfDocument())
            {

                CopyPages(one, outPdf);
                CopyPages(two, outPdf);

                outPdf.Save(finalpath);
            }

        }

        protected void getiframe()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand summarycmd = new SqlCommand("select filename,TaskId from approverdata where  TaskId= '" + taskid.Text + "'", con);
            con.Open();

            Session["filename"] = summarycmd.ExecuteScalar();
            iframesource.Text = Session["filename"].ToString();
            con.Close();
        }
        private DataTable GetData()
        {

            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT distinct  h.Date,hp.Name,s.Reviewer ,s.Approver, h.Status FROM AddEmployee s INNER JOIN AddnewTask2 hp on s.UserName = hp.UserName  INNER JOIN approverdata h on hp.Name = h.TaskId and h.TaskId='" + taskid.Text + "'"))
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

        private void addhaederfooter()
        {

            string inputfile = System.Web.HttpContext.Current.Server.MapPath("~/storepdf/" + taskid.Text + ".pdf");
            string outputfile = System.Web.HttpContext.Current.Server.MapPath("~/editorpdf/" + taskid.Text + ".pdf");
            //string pictPath = "~/img/caslab.jpg";
            DocumentCore dc = DocumentCore.Load(inputfile);
            HeaderFooter header = new HeaderFooter(dc, HeaderFooterType.HeaderDefault);
            SautinSoft.Document.Paragraph par = new SautinSoft.Document.Paragraph(dc);
            par.ParagraphFormat.Alignment = HorizontalAlignment.Right;
            CharacterFormat cf = new CharacterFormat() { FontName = "Consolas", Size = 12.0 };
            par.Content.Start.Insert("Page", cf.Clone());
            Field fPage = new Field(dc, FieldType.Page);
            fPage.CharacterFormat = cf.Clone();
            par.Content.End.Insert(fPage.Content);
            par.Content.End.Insert(" of ", cf.Clone());
            Field fPages = new Field(dc, FieldType.NumPages);
            fPages.CharacterFormat = cf.Clone();
            par.Content.End.Insert(fPages.Content);
            header.Blocks.Add(par);
            header.Content.Start.Insert("CASLAB", new CharacterFormat() { Size = 15.0, FontColor = Color.Blue });
            //Picture pict1 = new Picture(dc, InlineLayout.Inline(new Size(100, 100)), pictPath);

            foreach (SautinSoft.Document.Section s in dc.Sections)
            {
                s.HeadersFooters.Add(header.Clone(true));

            }
            HeaderFooter footer = new HeaderFooter(dc, HeaderFooterType.FooterDefault);
            footer.Content.Start.Insert("This document and all the information contained here are confidential and exclusive  property of CASLAB and maynot be reproduced,disclosed,or made public in any manner prior to express written authorization by CASLAB.", new CharacterFormat() { Size = 12.0, FontColor = Color.Black });
            foreach (SautinSoft.Document.Section s in dc.Sections)
            {
                s.HeadersFooters.Add(footer.Clone(true));
            }
            dc.Save(outputfile);

        }
        protected void updatereleasepdf()
        {
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
            string taskid = HttpContext.Current.Session["Name"].ToString();



            FileStream stream = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/storepdf/" + taskid + ".pdf"), FileMode.Open, FileAccess.Read);

            PdfWriter.GetInstance(pdfDoc, stream);
            int value = 0;

            value = stream.ReadByte();
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update approverdata set filename=@filename ,filedata=@filedata where TaskId=@TaskId ", con);

            cmd.Parameters.AddWithValue("@TaskId", taskid);

            cmd.Parameters.AddWithValue("@filename", "editorpdf\\" + taskid + ".pdf");
            cmd.Parameters.AddWithValue("@filedata", value);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void bindgrid()
        {
            DataTable dt = this.GetData();

            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            html.Append("<table border = '1',text-align=center>");

            //Building the Header row.
            html.Append("<tr height='40px'>");

            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td width='200px', height='30px'>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }

            //Table end.
            html.Append("</table>");

            //Append the HTML string to Placeholder.
            //PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
        private void summarytextbind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select  summarytext,  TaskId from approverdata where  TaskId = '" + taskid.Text + "'", con);
            con.Open();
            Session["summarytext"] = cmd.ExecuteScalar();
            con.Close();
            aftersummarytext.Text = Convert.ToString(Session["summarytext"]);
        }
        private void releasereviewerdatabind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(" SELECT DISTINCT  Reviewerstatus,Reviewer ,TaskId FROM Inboxdetails WHERE Reviewer = '" + Session["Reviewer"] + "' and TaskId = '" + Label10.Text + "' ", con);

            con.Open();
            Session["Reviewerstatus"] = cmd.ExecuteScalar();
            con.Close();
            reviewerstatus.Text = Convert.ToString(Session["Reviewerstatus"]);
        }
        private void releaseapproverdatabind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(" SELECT DISTINCT  Status,Approver ,TaskId FROM Inboxdetails WHERE Approver = '" + Session["Approver"] + "' and TaskId = '" + Label10.Text + "' ", con);

            con.Open();
            Session["Status"] = cmd.ExecuteScalar();
            con.Close();
            approverstatus.Text = Convert.ToString(Session["Status"]);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        private string GridViewToHtml(Panel grdResultDetails)
        {
            StringBuilder objStringBuilder = new StringBuilder();
            StringWriter objStringWriter = new StringWriter(objStringBuilder);
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            grdResultDetails.RenderControl(objHtmlTextWriter);
            return objStringBuilder.ToString();
        }




        public void btn1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("update AddnewTask2 set TaskDescription=@TaskDescription,Chemical=@Chemical,Quantity=@Quantity,Units=@Units where Name=@Name", con);
            try
            {
                con.Open();

                cmd.Parameters.AddWithValue("@TaskDescription", TextBox4.Text);
                cmd.Parameters.AddWithValue("@Chemical", Textbox1.Text);
                cmd.Parameters.AddWithValue("@Quantity", quantity.Text);

                cmd.Parameters.AddWithValue("@Units", units.Text);
                cmd.Parameters.AddWithValue("@Name", Textbox3.Text);



                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }

        }


        private void finddescription(String Name)
        {
            String myquery = "Select * from AddnewTask2 where Name='" + Name + "'";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                Label12.Text = ds.Tables[0].Rows[0]["TaskDescription"].ToString();

            }

            con.Close();
        }


        protected void bindtextvalues()
        {

            String strQuery = "select * from AddnewTask2 where Name = '" + Session["Name"] + "' ";

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Textbox3.Text = Session["Name"].ToString();

                    TextBox4.Text = sdr.GetValue(2).ToString();
                    Textbox1.Text = sdr.GetValue(3).ToString();
                    quantity.Text = sdr.GetValue(4).ToString();
                    units.Text = sdr.GetValue(5).ToString();

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



            //String myquery = "Select * from AddnewTask2 where Name='" + Name + "'";
            //SqlConnection con = new SqlConnection(str);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = myquery;
            //cmd.Connection = con;
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    Textbox3.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //    //TextBox2.Text = ds.Tables[0].Rows[0]["TaskName"].ToString();
            //    TextBox4.Text = ds.Tables[0].Rows[0]["TaskDescription"].ToString();
            //    Textbox1.Text = ds.Tables[0].Rows[0]["Chemical"].ToString();
            //    quantity.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
            //    units.Text = ds.Tables[0].Rows[0]["Units"].ToString();

            //}

            //con.Close();
        }











        private void bindimage()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand photocommand = new SqlCommand("select photodata from AddnewTask2 where Name='" + Label10.Text + "'", con);
            con.Open();
            SqlDataReader dr = photocommand.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    byte[] imagedata = (byte[])dr["photodata"];
                    string img = Convert.ToBase64String(imagedata, 0, imagedata.Length);
                    picture.ImageUrl = "data:iamge/jpg;base64," + img;
                }
            }
            con.Close();
        }



        protected void pdf_Click1(object sender, EventArgs e)
        {
            Response.Redirect("editor.aspx");
        }










        protected void createpdf()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 60f, 60f, 20f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            FileStream stream = new FileStream(Server.MapPath("~/frontpagepdf/" + Label10.Text + ".pdf"), FileMode.Create);

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
            string imagepath = Server.MapPath("img");
            pdfDoc.Open();
            pdfDoc.AddHeader("", "");

            string imageURL = Server.MapPath(".") + "/img/caslab.jpg";
            PdfContentByte cb = writer.DirectContent;
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DARK_GRAY);
            cb.SetFontAndSize(bf, 10);
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            jpg.SetAbsolutePosition(60f, 790f);
            pdfDoc.Add(jpg);
            //cb.SetLineWidth(1);
            //cb.MoveTo(60, 770);
            //cb.LineTo(pdfDoc.PageSize.Width, 770);
            //cb.Stroke();
            //cb.BeginText();
            //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, taskid.Text, 500, 800, 0);
            //cb.EndText();
            //cb.BeginText();
            //string description = Label12.Text.ToString();
            //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, description, 250, 500, 0);
            //cb.EndText();
            //cb.BeginText();TaskDescription
            //string pagenumber = "Page  " + i + "  of  " + n + ""; 
            //cb.ShowTextAligned(1, pagenumber, 500, 790, 0);
            //cb.EndText();
            cb.BeginText();
            string headerline = "_______________________________________________________________________________________";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, headerline, 295, 770, 0);
            cb.EndText();
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(Chunk.NEWLINE);
            //cb.BeginText();
            SqlConnection con = new SqlConnection(str);
            //SqlCommand summarycmd = new SqlCommand("select  summarytext from approverdata where  TaskId= '" + taskid.Text + "'",con);
            //con.Open();
            //Session["summarytext"]= summarycmd.ExecuteScalar();
            //con.Close();

            //string summarytext = Session["summarytext"].ToString();
            //// put the alignment and coordinates here
            //cb.ShowTextAligned(-200, summarytext, 40, 440, 0);
            //cb.EndText();

            //PdfGState gState = new PdfGState();
            //gState.setFillOpacity(0.1f);
            //cb.setGState(gState);
            //string date = "06/11/2019";
            //cb.BeginText();

            //// put the alignment and coordinates here
            //cb.ShowTextAligned(1, date, 90, 560, 0);
            //cb.EndText();
            cb.BeginText();

            string footerline = "_________________________________________________________________________________________";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, footerline, 295, 60, 0);
            cb.EndText();

            //cb.SetLineWidth(1);

            //cb.LineTo(pdfDoc.PageSize.Width, 60);
            //cb.MoveTo(60, 60);
            //cb.Stroke();
            cb.BeginText();
            string footer = "This document and all the information contained here are confidential and exclusive  property of CASLAB";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, footer, 320, 40, 0);
            cb.EndText();
            cb.BeginText();
            string footer1 = "and maynot be reproduced,disclosed,or made public in any manner prior to express written authorization by CASLAB.";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, footer1, 320, 30, 0);
            cb.EndText();
            htmlparser.Parse(sr);


            int value = 0;

            value = stream.ReadByte();

            SqlCommand cmd = new SqlCommand("update approverdata set frontpdf=@frontpdf,frontpdfdata=@frontpdfdata where TaskId=@TaskId ", con);

            cmd.Parameters.AddWithValue("@TaskId", Label10.Text);

            cmd.Parameters.AddWithValue("@frontpdf", "frontpagepdf\\" + Label10.Text + ".pdf");
            cmd.Parameters.AddWithValue("@frontpdfdata", value);
            pdfDoc.Close();
            stream.Close();
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void acceptdata()
        {
            SqlConnection con = new SqlConnection(str);


            label.Text = (string)Session["Reviewer"];
            Label10.Text = Session["Name"] as String;
            SqlCommand status = new SqlCommand("update Inboxdetails set Reviewerstatus='ACCEPTED' where Reviewer=@Reviewer and TaskId=@TaskId", con);
            try
            {
                con.Open();


                status.Parameters.AddWithValue("@TaskId", Label10.Text);
                status.Parameters.AddWithValue("@Reviewer", label.Text);



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


            label.Text = (string)Session["Reviewer"];
            Label10.Text = Session["Name"] as String;
            SqlCommand status = new SqlCommand("update Inboxdetails set Reviewerstatus='REJECTED' where Reviewer=@Reviewer and TaskId=@TaskId", con);
            try
            {
                con.Open();


                status.Parameters.AddWithValue("@TaskId", Label10.Text);
                status.Parameters.AddWithValue("@Reviewer", label.Text);



                status.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }


        }

        //protected void approverbutton_Click(object sender, EventArgs e)
        //{
        //    st1 = taskid.Text;
        //    label.Text = (string)Session["Reviewer"];
        //    st2 = label.Text;
        //    Reviewer2 r = new Reviewer2();
        //    Response.Redirect("Reviewer2.aspx");
        //}

        //protected void finalbutton_Click(object sender, EventArgs e)
        //{
        //    st1 = taskid.Text;
        //    label.Text = (string)Session["Reviewer"];
        //    st2 = label.Text;
        //    Reviewer2 r = new Reviewer2();
        //    Response.Redirect("Reviewer2.aspx");
        //}



        protected void assigntask_Click1(object sender, EventArgs e)
        {
            Response.Redirect("assigntask.aspx");
        }
        int i = 0;
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Textbox3.Visible = false; ;

            TextBox4.Visible = false;
            Textbox1.Visible = false;
            quantity.Visible = false;
            units.Visible = false;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update approverdata set summarytext=@summarytext where TaskId=@TaskId ", con);
            cmd.Parameters.AddWithValue("@summarytext", summarytext.Text);

            cmd.Parameters.AddWithValue("@TaskId", Label10.Text);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            bindgrid();
            int i = 0;
            if (i == 0)
            {
                createpdf();
                i++;
            }
            else
            {

            }
            Response.Redirect("editor.aspx");
        }







    }

}