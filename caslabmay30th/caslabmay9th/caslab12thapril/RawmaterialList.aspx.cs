using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace caslab12thapril
{
    public partial class RawmaterialList : System.Web.UI.Page
    {

        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();


     private bool deleteclick = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtbatch.Text = "CAS" + DateTime.Now.ToString("HHmmddMMyyyy");
            Rawmaterialcode();
            if (!Page.IsPostBack)
            {
                GridView1.DataBind();

                editdate.Text = DateTime.Today.ToString("dd-MM-yyyy");

                datedelete.Text = DateTime.Today.ToString("dd-MM-yyyy");
                //if (deleteclick == true)
                //{
                //    deletemethod();

                //}
                //else
                //{
                //    GridView1.DataBind();
                //}
            }

        }



        private void Rawmaterialcode()
        {

            string code = "RAW-MAT-00";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(Rawmaterialcode) from Rawmaterial2", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtcode.Text = code + i.ToString();
        }





        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            string filename1 = Path.GetFileName(documentupload.PostedFile.FileName);
            string contentType = documentupload.PostedFile.ContentType;
            using (Stream fs = documentupload.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    SqlCommand cmd = new SqlCommand("insert into Rawmaterial2(RawmaterialCode,RawmaterialName,RawmaterialType,Quantity,Intermof,SupplierInformation,MinimumQuantity,BatchNumber,Document,DocumentName)values(@RawmaterialCode,@RawmaterialName,@RawmaterialType,@Quantity,@Intermof,@SupplierInformation,@MinimumQuantity,@BatchNumber,@Document,@DocumentName)", con);
                    cmd.Parameters.AddWithValue("@RawmaterialCode", txtcode.Text);
                    cmd.Parameters.AddWithValue("@RawmaterialName", txtname.Text);
                    cmd.Parameters.AddWithValue("@RawmaterialType", typeofmaterial.Text);
                    cmd.Parameters.AddWithValue("@Quantity", quntatity.Text);
                    cmd.Parameters.AddWithValue("@Intermof", termsof.Text);
                    cmd.Parameters.AddWithValue("@SupplierInformation", txtinforamation.Text);
                    cmd.Parameters.AddWithValue("@MinimumQuantity", txtmin.Text);
                    cmd.Parameters.AddWithValue("@BatchNumber", txtbatch.Text);
                    cmd.Parameters.AddWithValue("@Document", bytes);
                    cmd.Parameters.AddWithValue("@DocumentName", documentname.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();

                }
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow grow = GridView1.SelectedRow;

            editcode.Text = grow.Cells[1].Text;
            editname.Text = grow.Cells[2].Text;
            editmaterial.Text = grow.Cells[3].Text;
            editquantaity.Text = grow.Cells[4].Text;
            editdocumentname.Text = grow.Cells[5].Text;
          
      codedelete.Text = grow.Cells[1].Text;
      namedelete.Text = grow.Cells[2].Text;
      materialdelete.Text = grow.Cells[3].Text;
            quandelete.Text = grow.Cells[4].Text;
            documentdelete.Text = grow.Cells[5].Text;
          

        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            string RawmaterialCode1 = editcode.Text;
            SqlConnection con = new SqlConnection(str);
         
            SqlCommand cmd = new SqlCommand("update Rawmaterial2 set RawmaterialName=@RawmaterialName, RawmaterialType=@RawmaterialType, Quantity=@Quantity, DocumentName=@DocumentName,RawMaterialEditDate=@RawMaterialEditDate,ReasonforEdit=@ReasonforEdit where RawmaterialCode='" + RawmaterialCode1 + "'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@RawmaterialName", editname.Text);
            cmd.Parameters.AddWithValue("@RawmaterialType", editmaterial.Text);

            cmd.Parameters.AddWithValue("@Quantity", editquantaity.Text);
            cmd.Parameters.AddWithValue("@DocumentName", editdocumentname.Text);
            cmd.Parameters.AddWithValue("@RawMaterialEditDate", editdate.Text);
            cmd.Parameters.AddWithValue("@ReasonforEdit", editreason.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }




       

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

    


        protected void exporttoexcel_Click1(object sender, EventArgs e)
        {
            GridView1.AllowPaging = false;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=search.xls");
            Response.ContentType = "application/excel";

            StringWriter st = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(st);
            GridView1.HeaderRow.Cells[0].Visible = false;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                row.Cells[0].Visible = false;
            }
            GridView1.RenderControl(hw);
            Response.Write(st.ToString());
            GridView1.Columns.RemoveAt(0);
            //GridView1.Columns.RemoveAt(1);
            //gridview1.Column(0).visible = false;
            GridView1.Visible = true;
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");

            foreach (TableCell tablecell in GridView1.HeaderRow.Cells)
            {
                tablecell.Style["background-color"] = "#DB1818";
            }
            foreach (GridViewRow grid in GridView1.Rows)
            {
                grid.BackColor = System.Drawing.Color.White;
                foreach (TableCell ta in grid.Cells)
                {
                    ta.Style["background-color"] = "#f2f5f7";
                }
            }


            Response.End();
            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;
        }

       

        protected void deletemethod()
        {
            string RawmaterialCode2 = codedelete.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update Rawmaterial2 set RawmaterialName=@RawmaterialName, RawmaterialType=@RawmaterialType, Quantity=@Quantity, DocumentName=@DocumentName,deleteddate=@deleteddate,reasonfordelete=@reasonfordelete,deletestatus='Deleted' where RawmaterialCode='" + RawmaterialCode2 + "'", con);

            con.Open();
            
            cmd.Parameters.AddWithValue("@RawmaterialName", namedelete.Text);
            cmd.Parameters.AddWithValue("@RawmaterialType", materialdelete.Text);
            cmd.Parameters.AddWithValue("@Quantity", quandelete.Text);
            cmd.Parameters.AddWithValue("@DocumentName", documentdelete.Text);
            cmd.Parameters.AddWithValue("@deleteddate", datedelete.Text);
            cmd.Parameters.AddWithValue("@reasonfordelete", reasondelete.Text);
            cmd.ExecuteNonQuery();
            con.Close();
           
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            //deleteclick = true;
            deletemethod();

           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text=="Deleted")
                {
                    e.Row.Cells[0].Enabled = false;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                    //e.Row.ForeColor = System.Drawing.Color.White;

                }
               
            }

        }
    }
}