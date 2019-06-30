using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace caslab12thapril
{
    public partial class RawMaterial : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Rawmaterialcode();
            editdate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            datedelete.Text = DateTime.Today.ToString("dd-MM-yyyy");
            Textbox6.Text = DateTime.Today.ToString("dd-MM-yyyy");
            Textbox13.Text = DateTime.Today.ToString("dd-MM-yyyy");

            if (!IsPostBack)
            {
                GridView1.DataBind();

            }
        }

        private void Rawmaterialcode()
        {

            string code = "RAW-MAT-00";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(rawmaterialcode) from AddRawmaterial", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtcode.Text = code + i.ToString();
        }



        protected void Save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("insert into AddRawmaterial(rawmaterialcode,rawmaterialname,typeofmaterial,quantity,intermsof,supplierinformation,miniumquantitytomaintain,expiry,date,info,status)values(@rawmaterialcode,@rawmaterialname,@typeofmaterial,@quantity,@intermsof,@supplierinformation,@miniumquantitytomaintain,@expiry,@date,@info,@status)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@rawmaterialcode", txtcode.Text);
            cmd.Parameters.AddWithValue("@rawmaterialname", txtname.Text);
            cmd.Parameters.AddWithValue("@typeofmaterial", typeofmaterial.Text);
            cmd.Parameters.AddWithValue("@quantity", quntatity.Text);
            cmd.Parameters.AddWithValue("@intermsof", termsof.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", txtinforamation.Text);
            cmd.Parameters.AddWithValue("@miniumquantitytomaintain", txtmin.Text);
            cmd.Parameters.AddWithValue("@expiry", RadioButton1.Text);
            cmd.Parameters.AddWithValue("@date", date.Text);
            cmd.Parameters.AddWithValue("@info", info.Text);
            cmd.Parameters.AddWithValue("@status", "Enabled");
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }

        protected void radio()
        {


        }




        protected void EditButton_Click(object sender, EventArgs e)
        {
            string RawmaterialCode1 = editcode.Text;
            SqlConnection con = new SqlConnection(str);

            SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, typeofmaterial=@typeofmaterial, quantity=@quantity, supplierinformation=@supplierinformation,EditedDate=@EditedDate,Editedreason=@Editedreason where rawmaterialcode='" + RawmaterialCode1 + "'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@rawmaterialname", editname.Text);
            cmd.Parameters.AddWithValue("@typeofmaterial", editmaterial.Text);

            cmd.Parameters.AddWithValue("@quantity", editquantaity.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", editdocumentname.Text);
            cmd.Parameters.AddWithValue("@EditedDate", editdate.Text);
            cmd.Parameters.AddWithValue("@Editedreason", editreason.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }

        protected void editpopup_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#listofrawmaterialedit').modal('show')", true);
            GridView1.DataBind();
            //foreach(GridViewRow grid in GridView1.Rows)
            //{ 
            //int id = GridView1.Rows.Count;
            //editcode.Text = GridView1.Rows[id - 1].Cells[1].Text;
            //editname.Text = GridView1.Rows[id - 1].Cells[2].Text;
            //editmaterial.Text = GridView1.Rows[id - 1].Cells[3].Text;
            //editquantaity.Text = GridView1.Rows[id - 1].Cells[4].Text;
            //editdocumentname.Text = GridView1.Rows[id - 1].Cells[5].Text;

            //}


        }



        protected void Delete_Click(object sender, EventArgs e)
        {
            string RawmaterialCode2 = codedelete.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, typeofmaterial=@typeofmaterial, quantity=@quantity, supplierinformation=@supplierinformation,EditedDate=@Deleteddate,Deletereason=@Deletereason, status='Deleted' where rawmaterialcode='" + RawmaterialCode2 + "'", con);

            con.Open();

            cmd.Parameters.AddWithValue("@rawmaterialname", namedelete.Text);
            cmd.Parameters.AddWithValue("@typeofmaterial", materialdelete.Text);
            cmd.Parameters.AddWithValue("@quantity", quandelete.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", documentdelete.Text);
            cmd.Parameters.AddWithValue("@Deleteddate", datedelete.Text);
            cmd.Parameters.AddWithValue("@Deletereason", reasondelete.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }

        protected void popupdelete_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#deleteramaterial').modal('show')", true);
            GridView1.DataBind();
            //foreach (GridViewRow grid in GridView1.Rows)
            //{
            //    int id = GridView1.Rows.Count;
            //    codedelete.Text = GridView1.Rows[id - 1].Cells[1].Text;
            //    namedelete.Text = GridView1.Rows[id - 1].Cells[2].Text;
            //    materialdelete.Text = GridView1.Rows[id - 1].Cells[3].Text;
            //    quandelete.Text = GridView1.Rows[id - 1].Cells[4].Text;
            //    documentdelete.Text = GridView1.Rows[id - 1].Cells[5].Text;
            //}

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadioButton radiobutton1 = (e.Row.FindControl("RadioButton1") as RadioButton);
                //RadioButton radiobutton1 = gvrow.FindControl("RadioButton1") as RadioButton;

                if (e.Row.Cells[6].Text == "Deleted")
                {
                    radiobutton1.Enabled = false;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                    //e.Row.ForeColor = System.Drawing.Color.White;

                }
                else if (e.Row.Cells[6].Text == "Disabled")
                {
                    e.Row.BackColor = System.Drawing.Color.Wheat;
                }


            }
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void exporttoexcel_Click(object sender, EventArgs e)
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

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //GridViewRow grow = GridView1.SelectedRow;
            //editcode.Text = grow.Cells[1].Text;
            RadioButton btn = (RadioButton)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            editcode.Text = gvr.Cells[1].Text;
            editname.Text = gvr.Cells[2].Text;
            editmaterial.Text = gvr.Cells[3].Text;
            editquantaity.Text = gvr.Cells[4].Text;
            editdocumentname.Text = gvr.Cells[5].Text;


            codedelete.Text = gvr.Cells[1].Text;
            namedelete.Text = gvr.Cells[2].Text;
            materialdelete.Text = gvr.Cells[3].Text;
            quandelete.Text = gvr.Cells[4].Text;
            documentdelete.Text = gvr.Cells[5].Text;

            Textbox1.Text = gvr.Cells[1].Text;
            Textbox2.Text = gvr.Cells[2].Text;
            Textbox3.Text = gvr.Cells[3].Text;
            Textbox4.Text = gvr.Cells[4].Text;
            Textbox5.Text = gvr.Cells[5].Text;



            Textbox8.Text = gvr.Cells[1].Text;
            Textbox9.Text = gvr.Cells[2].Text;
            Textbox10.Text = gvr.Cells[3].Text;
            Textbox11.Text = gvr.Cells[4].Text;
            Textbox12.Text = gvr.Cells[5].Text;

            Textbox15.Text = gvr.Cells[1].Text;

        }

        protected void disablepopup_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#disableramaterial').modal('show')", true);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string RawmaterialCode3 = Textbox1.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, typeofmaterial=@typeofmaterial, quantity=@quantity, supplierinformation=@supplierinformation,disabledate=@disabledate,disablereason=@disablereason, status='Disabled' where rawmaterialcode='" + RawmaterialCode3 + "'", con);

            con.Open();

            cmd.Parameters.AddWithValue("@rawmaterialname", Textbox2.Text);
            cmd.Parameters.AddWithValue("@typeofmaterial", Textbox3.Text);
            cmd.Parameters.AddWithValue("@quantity", Textbox4.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", Textbox5.Text);
            cmd.Parameters.AddWithValue("@disabledate", Textbox6.Text);
            cmd.Parameters.AddWithValue("@disablereason", Textbox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }

        protected void enablepopup_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#enableramaterial').modal('show')", true);
            GridView1.DataBind();
        }

        protected void enable_Click(object sender, EventArgs e)
        {
            string RawmaterialCode4 = Textbox8.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, typeofmaterial=@typeofmaterial, quantity=@quantity, supplierinformation=@supplierinformation,Enabledate=@Enabledate,Enablereason=@Enablereason,status='Enabled' where rawmaterialcode='" + RawmaterialCode4 + "'", con);

            con.Open();

            cmd.Parameters.AddWithValue("@rawmaterialname", Textbox9.Text);
            cmd.Parameters.AddWithValue("@typeofmaterial", Textbox10.Text);
            cmd.Parameters.AddWithValue("@quantity", Textbox11.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", Textbox12.Text);
            cmd.Parameters.AddWithValue("@Enabledate", Textbox13.Text);
            cmd.Parameters.AddWithValue("@Enablereason", Textbox14.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }

        protected void replacerawmaterail_Click(object sender, EventArgs e)
        {
            string RawmaterialCode5 = Textbox15.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, reasonforaction=@reasonforaction ,distributionlistforaction=@distributionlistforaction where rawmaterialcode='" + RawmaterialCode5 + "'", con);

            con.Open();

            cmd.Parameters.AddWithValue("@rawmaterialname", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@reasonforaction", reasonforaction.Text);
            cmd.Parameters.AddWithValue("@distributionlistforaction", dis.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)

        {

            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();



        }
        //protected void search()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection con = new SqlConnection(str);
        //    SqlDataAdapter adapt = new SqlDataAdapter("select rawmaterialcode,rawmaterialname,typeofmaterial,quantity,supplierinformation,status from AddRawmaterial where rawmaterialname='" + Textbox16.Text + "'", con);
        //    con.Open();
        //    adapt.Fill(dt);
        //    con.Close();
        //    GridView1.DataBind();
        //}

        //protected void searchbutton_Click1(object sender, EventArgs e)
        //{

        //    search();
        //}
    }
}