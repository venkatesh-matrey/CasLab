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
				ViewState["Filter"] = "ALL";
                GridView1.DataBind();
                grid();
            }
        }

		  protected void replacerawmaterialcode()
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#Replace').modal('show')", true);
            DataBind();
            //foreach (GridViewRow row in GridView1.Rows)

            //{
            //    string namerawmaterial = row.Cells[2].Text;


                DropDownList2.Items.Insert(0, new System.Web.UI.WebControls.ListItem(" RawMaterialCode    ", " "));
                DropDownList2.AppendDataBoundItems = true;



                String strQuery = "select rawmaterialcode from AddRawmaterial where rawmaterialname='"+editname.Text+"' ";
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    DropDownList2.DataSource = cmd.ExecuteReader();
                    DropDownList2.DataTextField = "rawmaterialcode";
                    DropDownList2.DataValueField = "rawmaterialcode";
                    DropDownList2.DataBind();
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

            //}
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
            cmd.Parameters.AddWithValue("@intermsof", termsof.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", txtinforamation.Text);
            cmd.Parameters.AddWithValue("@miniumquantitytomaintain", txtmin.Text);
            cmd.Parameters.AddWithValue("@expiry", RadioButton1.Text);
            cmd.Parameters.AddWithValue("@date", date.Text);
            cmd.Parameters.AddWithValue("@info", info.Text);
            cmd.Parameters.AddWithValue("@status", "Enabled");
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            grid();
        }

        protected void radio()
        {


        }



        protected void EditButton_Click(object sender, EventArgs e)
        {
            string RawmaterialCode1 = editcode.Text;
            SqlConnection con = new SqlConnection(str);

            SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, typeofmaterial=@typeofmaterial, quantity=@quantity,intermsof=@intermsof, supplierinformation=@supplierinformation,EditedDate=@EditedDate,Editedreason=@Editedreason where rawmaterialcode='" + RawmaterialCode1 + "'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@rawmaterialname", editname.Text);
            cmd.Parameters.AddWithValue("@typeofmaterial", editmaterial.Text);

            cmd.Parameters.AddWithValue("@quantity", editquantaity.Text);
			cmd.Parameters.AddWithValue("@intermsof", editunits.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", editdocumentname.Text);
            cmd.Parameters.AddWithValue("@EditedDate", editdate.Text);
            cmd.Parameters.AddWithValue("@Editedreason", editreason.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            grid();
        }

        protected void editpopup_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#listofrawmaterialedit').modal('show')", true);
            GridView1.DataBind();
            grid();
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
            SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, typeofmaterial=@typeofmaterial, quantity=@quantity,intermsof=@intermsof, supplierinformation=@supplierinformation,EditedDate=@Deleteddate,Deletereason=@Deletereason, status='Deleted' where rawmaterialcode='" + RawmaterialCode2 + "'", con);

            con.Open();

            cmd.Parameters.AddWithValue("@rawmaterialname", namedelete.Text);
            cmd.Parameters.AddWithValue("@typeofmaterial", materialdelete.Text);
            cmd.Parameters.AddWithValue("@quantity", quandelete.Text);
			cmd.Parameters.AddWithValue("@intermsof",unitsdelete.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", documentdelete.Text);
            cmd.Parameters.AddWithValue("@Deleteddate", datedelete.Text);
            cmd.Parameters.AddWithValue("@Deletereason", reasondelete.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            grid();
        }

        protected void popupdelete_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#deleteramaterial').modal('show')", true);
            GridView1.DataBind();
            grid();
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

                if (e.Row.Cells[7].Text == "Deleted")
                {
                    radiobutton1.Enabled = false;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                    //e.Row.ForeColor = System.Drawing.Color.White;

                }
                else if (e.Row.Cells[7].Text == "Disabled")
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
          
            bool isselected = false;
            bool checkallselect = false;
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                GridViewRow header = GridView1.HeaderRow;
                RadioButton chck = gvrow.FindControl("RadioButton1") as RadioButton;
                RadioButton chckall = GridView1.HeaderRow.FindControl("chkAll") as RadioButton;
                if (chck != null && chck.Checked)
                {
                    isselected = true;

                }
                else if (chckall != null && chckall.Checked)
                {
                    checkallselect = true;

                }
            }
            if (isselected)
            {
                GridView grdxport = GridView1;

                grdxport.Columns[0].Visible = false;
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    grdxport.Rows[gvrow.RowIndex].Visible = false;
                    RadioButton chck = gvrow.FindControl("RadioButton1") as RadioButton;
                    if (chck != null && chck.Checked)
                    {
                        grdxport.Rows[gvrow.RowIndex].Visible = true;
                    }
                }

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.ms-excel";


                StringWriter swr = new StringWriter();
                HtmlTextWriter htmlwtr = new HtmlTextWriter(swr);
                grdxport.RenderControl(htmlwtr);
                Response.Output.Write(swr.ToString());
                Response.End();

            }
            else if (checkallselect)
            {
                
                GridView1.AllowPaging = false;
                GridView1.AllowSorting = false;
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "RAWMATERIAL" + DateTime.Now + ".xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                GridView1.GridLines = GridLines.Both;
                GridView1.HeaderStyle.Font.Bold = true;

                GridView1.HeaderRow.Cells[0].Visible = false;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridViewRow row = GridView1.Rows[i];
                    row.Cells[0].Visible = false;
                }
                GridView1.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
                


            }
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
			editunits.Text=gvr.Cells[5].Text;
            editdocumentname.Text = gvr.Cells[6].Text;


            codedelete.Text = gvr.Cells[1].Text;
            namedelete.Text = gvr.Cells[2].Text;
            materialdelete.Text = gvr.Cells[3].Text;
            quandelete.Text = gvr.Cells[4].Text;
			unitsdelete.Text=gvr.Cells[5].Text;
            documentdelete.Text = gvr.Cells[6].Text;

            Textbox1.Text = gvr.Cells[1].Text;
            Textbox2.Text = gvr.Cells[2].Text;
            Textbox3.Text = gvr.Cells[3].Text;
            Textbox4.Text = gvr.Cells[4].Text;
			txtintermsof.Text= gvr.Cells[5].Text;
            Textbox5.Text = gvr.Cells[6].Text;



            Textbox8.Text = gvr.Cells[1].Text;
            Textbox9.Text = gvr.Cells[2].Text;
            Textbox10.Text = gvr.Cells[3].Text;
            Textbox11.Text = gvr.Cells[4].Text;
			intermsof.Text = gvr.Cells[5].Text;
            Textbox12.Text = gvr.Cells[6].Text;

            Textbox15.Text = gvr.Cells[1].Text;

        }

        protected void disablepopup_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#disableramaterial').modal('show')", true);
            GridView1.DataBind();
            grid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string RawmaterialCode3 = Textbox1.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, typeofmaterial=@typeofmaterial, quantity=@quantity,intermsof=@intermsof, supplierinformation=@supplierinformation,disabledate=@disabledate,disablereason=@disablereason, status='Disabled' where rawmaterialcode='" + RawmaterialCode3 + "'", con);

            con.Open();

            cmd.Parameters.AddWithValue("@rawmaterialname", Textbox2.Text);
            cmd.Parameters.AddWithValue("@typeofmaterial", Textbox3.Text);
            cmd.Parameters.AddWithValue("@quantity", Textbox4.Text);
			cmd.Parameters.AddWithValue("@intermsof",txtintermsof.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", Textbox5.Text);
            cmd.Parameters.AddWithValue("@disabledate", Textbox6.Text);
            cmd.Parameters.AddWithValue("@disablereason", Textbox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            grid();
        }

        protected void enablepopup_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#enableramaterial').modal('show')", true);
            GridView1.DataBind();
            grid();
        }

        protected void enable_Click(object sender, EventArgs e)
        {
            string RawmaterialCode4 = Textbox8.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, typeofmaterial=@typeofmaterial, quantity=@quantity,intermsof=@intermsof,supplierinformation=@supplierinformation,Enabledate=@Enabledate,Enablereason=@Enablereason,status='Enabled' where rawmaterialcode='" + RawmaterialCode4 + "'", con);

            con.Open();

            cmd.Parameters.AddWithValue("@rawmaterialname", Textbox9.Text);
            cmd.Parameters.AddWithValue("@typeofmaterial", Textbox10.Text);
            cmd.Parameters.AddWithValue("@quantity", Textbox11.Text);
			cmd.Parameters.AddWithValue("@intermsof",intermsof.Text);
            cmd.Parameters.AddWithValue("@supplierinformation", Textbox12.Text);
            cmd.Parameters.AddWithValue("@Enabledate", Textbox13.Text);
            cmd.Parameters.AddWithValue("@Enablereason", Textbox14.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            grid();
        }

       

        protected void OnPaging(object sender, GridViewPageEventArgs e)

        {

            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();
            grid();


        }
        
		
		private void reset()
		{
			Textbox16.Text="";
		}

        protected void searchbutton_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(str);
            SqlCommand  cmd = new SqlCommand("select rawmaterialcode, rawmaterialname, typeofmaterial, quantity,intermsof, supplierinformation, status from AddRawmaterial where rawmaterialname like '%' +@rawmaterialname+'%'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@rawmaterialname", Textbox16.Text.Trim());
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            con.Close();
	
           
        }
         protected void CountryChanged(object sender, EventArgs e)
        {
            DropDownList ddlCountry = (DropDownList)sender;
            ViewState["Filter"] = ddlCountry.SelectedValue;
            this.grid();
        }
        protected void grid()
        {
			string searchdata=Textbox16.Text.Trim();
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager
                        .ConnectionStrings["MyDbCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("spx_Getmaterialtype");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Filter", ViewState["Filter"].ToString());
			cmd.Parameters.AddWithValue("@rawmaterialname",searchdata);
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //DropDownList ddlCountry =
            //    (DropDownList)GridView1.HeaderRow.FindControl("ddlCountry");
            //this.BindCountryList(ddlCountry);
            
        }
        private void BindCountryList(DropDownList ddlCountry)
        {
            String strConnString = System.Configuration.ConfigurationManager
                        .ConnectionStrings["MyDbCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("select distinct typeofmaterial" +
                            " from AddRawmaterial");
            cmd.Connection = con;
            con.Open();
            ddlCountry.DataSource = cmd.ExecuteReader();
            ddlCountry.DataTextField = "typeofmaterial";
            ddlCountry.DataValueField = "typeofmaterial";
            ddlCountry.DataBind();
            con.Close();
            ddlCountry.Items.FindByValue(ViewState["Filter"].ToString())
                    .Selected = true;
        }
		

  protected void replacerawmaterail_Click(object sender, EventArgs e)
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#Replace').modal('show')", true);
            SqlConnection con = new SqlConnection(str);
            //int i = 0;
            //if (i == 0)
            //{
                string RawmaterialCode5 = Textbox15.Text;
                
                SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialcode=@rawmaterialcode, reasonforaction=@reasonforaction ,distributionlistforaction=@distributionlistforaction where rawmaterialcode='" + RawmaterialCode5 + "'", con);

                con.Open();

                cmd.Parameters.AddWithValue("@rawmaterialcode", DropDownList2.Text);
                cmd.Parameters.AddWithValue("@reasonforaction", reasonforaction.Text);
                cmd.Parameters.AddWithValue("@distributionlistforaction", dis.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                grid();
            //}
            //int k = 0;
            //if (k == 0)
            //{
            //    //SqlConnection con = new SqlConnection(str);
            //    SqlCommand cmd1 = new SqlCommand("pro_Replacerawmaterialdetails", con);
            //    cmd1.CommandType = CommandType.StoredProcedure;
            //    con.Open();

            //    if (dis.Text.Contains(','))//checking for you are entered single value or multiple values  
            //    {
            //        string[] arryval = dis.Text.Split(',');//split values with ‘,’  
            //        int j = arryval.Length;
            //        int p = 0;
            //        for (p = 0; p < j; i++)
            //        {
            //            //cmd1.Parameters.AddWithValue("@statement", "insert");
            //            cmd1.Parameters.AddWithValue("@rawmaterialcode", Textbox15.Text);
            //            cmd1.Parameters.AddWithValue("@replacerawmaterialcode", DropDownList2.SelectedItem.Text);
            //            cmd1.Parameters.AddWithValue("@reasonforaction", reasonforaction.Text);
            //            cmd1.Parameters.AddWithValue("@distributionlistforaction", arryval[i]);




            //            cmd1.ExecuteNonQuery();
                      
            //        }

            //    }
            //}
        }
		
		    protected void replce_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#Replace').modal('show')", true);
            GridView1.DataBind();
            grid();
            replacerawmaterialcode();
        }
		 protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#Replace').modal('show')", true);
        }
    }
}
