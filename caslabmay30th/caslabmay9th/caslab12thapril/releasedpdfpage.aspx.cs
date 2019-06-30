using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace caslab12thapril
{
    public partial class releasedpdfpage : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CopyPages(PdfSharp.Pdf.PdfDocument from, PdfSharp.Pdf.PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }

       
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Session["Name"] = e.Row.Cells[0].Text;
                string frontpagelocation = e.Row.Cells[4].Text;

                string filelocation = e.Row.Cells[3].Text;

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
    }
}