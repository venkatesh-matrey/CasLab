using Api2PdfLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Api2PdfLibrary.Models;
using System.Web.SessionState;
using PdfSharp.Pdf;
using iTextSharp.text.pdf;
using PdfSharp.Pdf.IO;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System.Configuration;
using SautinSoft.Document;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace caslab12thapril
{
    /// <summary>
    /// Summary description for SaveToPdf
    /// </summary>
    public class SaveToPdf : IHttpHandler, IReadOnlySessionState
    {
       
        public WkHtmlToPdfHandler WkHtmlToPdf;
        //private string outputFileName;

        public string Pdf { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            using (var sr = new System.IO.StreamReader(context.Request.InputStream))
            {
                var data = sr.ReadToEnd();

               
                var model = JsonConvert.DeserializeObject<PdfModel>(data);

                context.Response.ContentType = "application/json";

                var a2pClient = new Api2Pdf("72e2fa4b-8d2a-425f-a017-02d33cc97f27");


                var pdfUrl = a2pClient.WkHtmlToPdf.FromHtml( model.Content).Pdf;
                

                string taskid = HttpContext.Current.Session["Name"].ToString();
                HttpContext.Current.Session.Timeout = 60;

                string savedFileName = System.Web.HttpContext.Current.Server.MapPath("~\\storepdf\\" + taskid + ".pdf");
                var client = new WebClient();
                
                client.DownloadFile(pdfUrl, savedFileName);
                var result = new
                {
                    pdfUrl = pdfUrl
                };




                context.Response.Write(JsonConvert.SerializeObject(result));


                //addhaederfooter();
                AddDataTableToPDF();
                updatereleasepdf();
            }
        }
       

        public class PdfModel
        {

            public string Content { get; set; }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private void addhaederfooter()
        {
            string taskid = HttpContext.Current.Session["Name"].ToString();
            HttpContext.Current.Session.Timeout = 60;
            string inputfile = System.Web.HttpContext.Current.Server.MapPath("~/storepdf/" + taskid + ".pdf");
            string outputfile = System.Web.HttpContext.Current.Server.MapPath("~/editorpdf/" + taskid + ".pdf");
            //string pictPath = "~/img/caslab.jpg";
            DocumentCore dc = DocumentCore.Load(inputfile);
            HeaderFooter header = new HeaderFooter(dc, HeaderFooterType.HeaderDefault);
            SautinSoft.Document.Paragraph par1 = new SautinSoft.Document.Paragraph(dc);
            par1.ParagraphFormat.Alignment = HorizontalAlignment.Left;
            //header.Content.Start.Insert("CASLAB", new CharacterFormat() { Size = 15.0, FontColor = Color.Blue });
            CharacterFormat cf1 = new CharacterFormat() { FontName = "Consolas", Size = 15.0, FontColor = Color.Blue };
            par1.Content.Start.Insert("CASLAB", cf1.Clone());
            header.Blocks.Add(par1);
            SautinSoft.Document.Paragraph par2 = new SautinSoft.Document.Paragraph(dc);
            par2.ParagraphFormat.Alignment = HorizontalAlignment.Right;
            //header.Content.Start.Insert("CASLAB", new CharacterFormat() { Size = 15.0, FontColor = Color.Blue });
            CharacterFormat cf2 = new CharacterFormat() { FontName = "Consolas", Size = 15.0 };
            par2.Content.Start.Insert(taskid, cf2.Clone());
            header.Blocks.Add(par2);
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
           
            //header.Content.Start.Insert(taskid, new CharacterFormat() { Size = 15.0, FontColor = Color.Black });
            par.Content.End.Insert(fPages.Content);

            header.Blocks.Add(par);
            SautinSoft.Document.Paragraph par3 = new SautinSoft.Document.Paragraph(dc);
            par3.ParagraphFormat.Alignment = HorizontalAlignment.Center;
            //header.Content.Start.Insert("CASLAB", new CharacterFormat() { Size = 15.0, FontColor = Color.Blue });
            CharacterFormat cf3 = new CharacterFormat() ;
            par3.Content.Start.Insert("______________________________________________________________________________________________", cf3.Clone());
            header.Blocks.Add(par3);
            //Picture pict1 = new Picture(dc, InlineLayout.Inline(new Size(100, 100)), pictPath);

            foreach (SautinSoft.Document.Section s in dc.Sections)
            {
                s.HeadersFooters.Add(header.Clone(true));
               

            }
            HeaderFooter footer = new HeaderFooter(dc, HeaderFooterType.FooterDefault);
            SautinSoft.Document.Paragraph par4 = new SautinSoft.Document.Paragraph(dc);
            par4.ParagraphFormat.Alignment = HorizontalAlignment.Center;
            //header.Content.Start.Insert("CASLAB", new CharacterFormat() { Size = 15.0, FontColor = Color.Blue });
            CharacterFormat cf4 = new CharacterFormat();
            par4.Content.Start.Insert("______________________________________________________________________________________________", cf4.Clone());
            footer.Blocks.Add(par4);
            par4.Content.End.Insert("This document and all the information contained here are confidential and exclusive  property of CASLAB and maynot be reproduced,disclosed,or made public in any manner prior to express written authorization by CASLAB.", new CharacterFormat() { Size = 12.0, FontColor = Color.Black });
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

            HttpContext.Current.Session.Timeout = 60;

            FileStream stream = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/editorpdf/" + taskid + ".pdf"), FileMode.Open, FileAccess.Read);

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
        protected void AddDataTableToPDF()
        {
            string taskid = HttpContext.Current.Session["Name"].ToString();

            HttpContext.Current.Session.Timeout = 60;
            String pathin = System.Web.HttpContext.Current.Server.MapPath("~/storepdf/" + taskid + ".pdf");
            String pathout = System.Web.HttpContext.Current.Server.MapPath("~/editorpdf/" + taskid  + ".pdf");
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(pathin);
            PdfStamper stamper = new PdfStamper(reader, new FileStream(pathout, FileMode.Create));
            int n = reader.NumberOfPages;
            string imageURL = System.Web.HttpContext.Current.Server.MapPath(".") + "/img/caslab.jpg";
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imageURL);
            img.SetAbsolutePosition(60f, 790f);
           
            for (var i = 1; i <= n; i++)
            {


                PdfContentByte over = null;


                over = stamper.GetOverContent(i);
                BaseFont bf_times = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "Cp1252", false);
                over.SetFontAndSize(bf_times, 10);
                over.AddImage(img);
                over.BeginText();
                over.ShowTextAligned(PdfContentByte.ALIGN_CENTER, taskid, 500, 800, 0);
                over.EndText();
                over.BeginText();
                string pagenumber = "Page  " + i + "  of  " + n + "";
                over.ShowTextAligned(1, pagenumber, 500, 790, 0);
                over.EndText();
                over.BeginText();
                string headerline = "_______________________________________________________________________________________";
                // put the alignment and coordinates here
                over.ShowTextAligned(1, headerline, 295, 780, 0);
                over.EndText();

                over.BeginText();
                string footerline = "________________________________________________________________________________________";
                // put the alignment and coordinates here
                over.ShowTextAligned(1, footerline, 295, 60, 0);
                over.EndText();

                over.BeginText();          
                string footer = "This document and all the information contained here are confidential and exclusive  property of CASLAB.";
                over.ShowTextAligned(PdfContentByte.ALIGN_CENTER, footer, 300, 40, 0);
                over.EndText();

                over.BeginText();
               string footer1 = "and maynot be reproduced,disclosed,or made public in any manner prior to express written authorization by CASLAB.";
                over.ShowTextAligned(PdfContentByte.ALIGN_CENTER, footer1, 300, 30, 0);
                over.EndText();

            }
            stamper.Close();
            reader.Close();

        }
    }
}

