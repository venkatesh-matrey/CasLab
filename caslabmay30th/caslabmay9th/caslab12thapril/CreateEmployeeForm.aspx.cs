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
    public partial class CreateEmployeeForm : System.Web.UI.Page
    {

        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Rawmaterialcode();
            //editdate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            reasondelete.Text = DateTime.Today.ToString("dd-MM-yyyy");
            //Textbox6.Text = DateTime.Today.ToString("dd-MM-yyyy");
            //Textbox13.Text = DateTime.Today.ToString("dd-MM-yyyy");

            if (!IsPostBack)
            {
                ViewState["Filter"] = "ALL";
                GridView1.DataBind();
                // grid();
            }
        }

        private void Rawmaterialcode()
        {

            string code = "MAT0000";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(empid) from AddEmployee", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            empcode.Text = code + i.ToString();
        }

        private void bindimage()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand photocommand = new SqlCommand("select photodata from AddEmployee where EmpId='" + codedelete.Text + "'", con);
            con.Open();
            SqlDataReader dr = photocommand.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    byte[] imagedata = (byte[])dr["photodata"];
                    string img = Convert.ToBase64String(imagedata, 0, imagedata.Length);
                    picture.ImageUrl = "data:image/jpg;base64," + img;
                }
            }
            con.Close();
        }

        protected void Save_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(str);
            string filename = photo.PostedFile.FileName;


            string filename1 = Path.GetFileName(photo.PostedFile.FileName);
            string contentType = photo.PostedFile.ContentType;
            using (Stream fs = photo.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    SqlCommand cmd = new SqlCommand("insert into AddEmployee(empid,EmpName,Qualification,fathername,address,email,Phone,pannumber,aadharnumber,bloodgroup,mattrialstatus,department,gender,dateofjoining,photodata,WorkLocation,position,status) values(@empid,@Empname,@Qualification,@fathername,@address,@email,@Phone,@pannumber,@aadharnumber,@bloodgroup,@mattrialstatus,@department,@gender,@dateofjoining,@photodata,@WorkLocation,@position,@status)", con);
                    cmd.Parameters.AddWithValue("@empid", empcode.Text);

                    cmd.Parameters.AddWithValue("@EmpName", name.Text);
                    cmd.Parameters.AddWithValue("@Qualification", "B.Tech");
                    cmd.Parameters.AddWithValue("@fathername", fname.Text);
                    cmd.Parameters.AddWithValue("@address", address.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@Phone", phnum.Text);
                    cmd.Parameters.AddWithValue("@pannumber", pan.Text);
                    cmd.Parameters.AddWithValue("@aadharnumber", aadharnum.Text);
                    cmd.Parameters.AddWithValue("@bloodgroup", bloodgroup.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@mattrialstatus", mattrialstatus.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@department", department.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@gender", gender.SelectedItem.Text);

                    cmd.Parameters.AddWithValue("@dateofjoining", date.Text);
                    //cmd.Parameters.AddWithValue("@lastdateinthecompany", lastdate.Text);
                    cmd.Parameters.AddWithValue("@WorkLocation", WorkLocation.Text);
                    cmd.Parameters.AddWithValue("@photodata", bytes);
                    cmd.Parameters.AddWithValue("@position", "creator");
                    cmd.Parameters.AddWithValue("@status", "Unlocked");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    GridView1.DataBind();
                    //reset();
                }
            }

        }

        protected void radio()
        {


        }



        protected void EditButton_Click(object sender, EventArgs e)
        {
            //string filename = FileUpload1.PostedFile.FileName;


            //string filename1 = Path.GetFileName(FileUpload1.PostedFile.FileName);
            //string contentType = FileUpload1.PostedFile.ContentType;
            //using (Stream fs = FileUpload1.PostedFile.InputStream)
            //{
            //    using (BinaryReader br = new BinaryReader(fs))
            //    {
            //        byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string empid = codedelete.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update AddEmployee set EmpName=@EmpName, fathername=@fathername, address=@address, Email=@Email,Phone=@Phone,pannumber=@pannumber,aadharnumber=@aadharnumber,bloodgroup=@bloodgroup,mattrialstatus=@mattrialstatus,Department=@Department,gender=@gender,dateofjoining=@dateofjoining,WorkLocation=@WorkLocation where EmpId='" + empid + "'", con);

            con.Open();

            cmd.Parameters.AddWithValue("@EmpName", Textbox2.Text);
            cmd.Parameters.AddWithValue("@fathername", Textbox3.Text);
            cmd.Parameters.AddWithValue("@address", Textbox4.Text);
            cmd.Parameters.AddWithValue("@Email", Textbox5.Text);
            cmd.Parameters.AddWithValue("@Phone", Textbox6.Text);
            cmd.Parameters.AddWithValue("@pannumber", Textbox7.Text);
            cmd.Parameters.AddWithValue("@aadharnumber", Textbox8.Text);
            cmd.Parameters.AddWithValue("@bloodgroup", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@mattrialstatus", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Department", DropDownList3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@gender", DropDownList4.SelectedItem.Text);
            //cmd.Parameters.AddWithValue("@photodata", bytes);
            cmd.Parameters.AddWithValue("@dateofjoining", Textbox9.Text);
            cmd.Parameters.AddWithValue("@WorkLocation", Textbox10.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }


        protected void editpopup_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#listofrawmaterialedit').modal('show')", true);
            GridView1.DataBind();
            //  grid();
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
            //string RawmaterialCode2 = codedelete.Text;
            //SqlConnection con = new SqlConnection(str);
            //SqlCommand cmd = new SqlCommand("update AddRawmaterial set rawmaterialname=@rawmaterialname, typeofmaterial=@typeofmaterial, quantity=@quantity,intermsof=@intermsof, supplierinformation=@supplierinformation,EditedDate=@Deleteddate,Deletereason=@Deletereason, status='Deleted' where rawmaterialcode='" + RawmaterialCode2 + "'", con);

            //con.Open();

            //cmd.Parameters.AddWithValue("@rawmaterialname", namedelete.Text);
            //cmd.Parameters.AddWithValue("@typeofmaterial", materialdelete.Text);
            //cmd.Parameters.AddWithValue("@quantity", quandelete.Text);
            //cmd.Parameters.AddWithValue("@intermsof", unitsdelete.Text);
            //cmd.Parameters.AddWithValue("@supplierinformation", documentdelete.Text);
            //cmd.Parameters.AddWithValue("@Deleteddate", datedelete.Text);
            //cmd.Parameters.AddWithValue("@Deletereason", reasondelete.Text);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //GridView1.DataBind();
            //grid();

            //string script = "alert(\" Please select one code\")";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            string empid1 = codedelete.Text;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update AddEmployee set EmpName=@EmpName, dateofjoining=@dateofjoining,Department=@Department,address=@address,Phone=@Phone,resigneddate=@resigneddate,EmpPosition='Resigned',status='Locked' where EmpId='" + empid1 + "'", con);

            con.Open();

            cmd.Parameters.AddWithValue("@EmpName", namedelete.Text);
            cmd.Parameters.AddWithValue("@dateofjoining", materialdelete.Text);
            cmd.Parameters.AddWithValue("@lastdateinthecompany", quandelete.Text);
            cmd.Parameters.AddWithValue("@Department", unitsdelete.Text);
            cmd.Parameters.AddWithValue("@address", documentdelete.Text);
            cmd.Parameters.AddWithValue("@Phone", datedelete.Text);
            cmd.Parameters.AddWithValue("@resigneddate", reasondelete.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }

        protected void popupdelete_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#deleteramaterial').modal('show')", true);
            GridView1.DataBind();
            // grid();
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

        //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{


        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        RadioButton radiobutton1 = (e.Row.FindControl("RadioButton1") as RadioButton);
        //        //RadioButton radiobutton1 = gvrow.FindControl("RadioButton1") as RadioButton;

        //        if (e.Row.Cells[7].Text == "Deleted")
        //        {
        //            radiobutton1.Enabled = false;
        //            e.Row.BackColor = System.Drawing.Color.LightGray;
        //            //e.Row.ForeColor = System.Drawing.Color.White;

        //        }
        //        else if (e.Row.Cells[7].Text == "Disabled")
        //        {
        //            e.Row.BackColor = System.Drawing.Color.Wheat;
        //        }


        //    }
        //}


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
                Response.AddHeader("content-disposition", "attachment;filename=Employee.xls");
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
                string FileName = "EMPLOYEEDETAILS" + DateTime.Now + ".xls";
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

            string constr = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

            //GridViewRow grow = GridView1.SelectedRow;
            //editcode.Text = grow.Cells[1].Text;
            RadioButton btn = (RadioButton)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            codedelete.Text = gvr.Cells[1].Text;
            namedelete.Text = gvr.Cells[2].Text;
            materialdelete.Text = gvr.Cells[3].Text;
            quandelete.Text = gvr.Cells[4].Text;
            unitsdelete.Text = gvr.Cells[5].Text;
            documentdelete.Text = gvr.Cells[6].Text;
            datedelete.Text = gvr.Cells[7].Text;
            bindimage();
            string query = "select * from AddEmployee where EmpId='" + codedelete.Text + "'";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Textbox1.Text = dt.Rows[0]["EmpId"].ToString();
                            Textbox2.Text = dt.Rows[0]["EmpName"].ToString();
                            Textbox3.Text = dt.Rows[0]["fathername"].ToString();
                            Textbox4.Text = dt.Rows[0]["address"].ToString();
                            Textbox5.Text = dt.Rows[0]["Email"].ToString();
                            Textbox6.Text = dt.Rows[0]["Phone"].ToString();
                            Textbox7.Text = Convert.ToString(dt.Rows[0]["pannumber"].ToString());
                            Textbox8.Text = dt.Rows[0]["aadharnumber"].ToString();
                            DropDownList1.Text = dt.Rows[0]["bloodgroup"].ToString();
                            DropDownList2.Text = dt.Rows[0]["mattrialstatus"].ToString();
                            DropDownList3.Text = dt.Rows[0]["Department"].ToString();
                            DropDownList4.Text = dt.Rows[0]["gender"].ToString();
                            Textbox9.Text = dt.Rows[0]["dateofjoining"].ToString();
                            Textbox10.Text = dt.Rows[0]["WorkLocation"].ToString();


                        }
                    }
                }
            }



        }

        //protected void enablepopup_Click(object sender, EventArgs e)
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#enableramaterial').modal('show')", true);
        //    GridView1.DataBind();
        //    grid();
        //}



        protected void OnPaging(object sender, GridViewPageEventArgs e)

        {

            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();
            //  grid();


        }


        //private void reset()
        //{
        //    Textbox16.Text = "";
        //}

        //protected void searchbutton_Click(object sender, EventArgs e)
        //{

        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand("select rawmaterialcode, rawmaterialname, typeofmaterial, quantity,intermsof, supplierinformation, status from AddRawmaterial where rawmaterialname like '%' +@rawmaterialname+'%'", con);
        //    con.Open();
        //    cmd.Parameters.AddWithValue("@rawmaterialname", Textbox16.Text.Trim());
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter sd = new SqlDataAdapter(cmd);
        //    sd.Fill(dt);
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();

        //    con.Close();

        //protected void grid()
        //        {
        //            string searchdata = Textbox16.Text.Trim();
        //            DataTable dt = new DataTable();
        //            String strConnString = System.Configuration.ConfigurationManager
        //                        .ConnectionStrings["MyDbCon"].ConnectionString;
        //            SqlConnection con = new SqlConnection(strConnString);
        //            SqlDataAdapter sda = new SqlDataAdapter();
        //            SqlCommand cmd = new SqlCommand("spx_Getmaterialtype");
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Filter", ViewState["Filter"].ToString());
        //            cmd.Parameters.AddWithValue("@rawmaterialname", searchdata);
        //            cmd.Connection = con;
        //            sda.SelectCommand = cmd;
        //            sda.Fill(dt);
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //            //DropDownList ddlCountry =
        //            //    (DropDownList)GridView1.HeaderRow.FindControl("ddlCountry");
        //            //this.BindCountryList(ddlCountry);

        //        }
        // }
        protected void CountryChanged(object sender, EventArgs e)
        {
            DropDownList ddlCountry = (DropDownList)sender;
            ViewState["Filter"] = ddlCountry.SelectedValue;
            //this.grid();
        }

        private void BindCountryList(DropDownList ddlCountry)
        {
            String strConnString = System.Configuration.ConfigurationManager
                        .ConnectionStrings["MyDbCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("select distinct typeofmaterial" + " from AddRawmaterial");
            cmd.Connection = con;
            con.Open();
            ddlCountry.DataSource = cmd.ExecuteReader();
            ddlCountry.DataTextField = "typeofmaterial";
            ddlCountry.DataValueField = "typeofmaterial";
            ddlCountry.DataBind();
            con.Close();
            ddlCountry.Items.FindByValue(ViewState["Filter"].ToString()).Selected = true;
        }
    }
}