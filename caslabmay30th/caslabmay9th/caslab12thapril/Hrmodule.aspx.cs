using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Collections;
using System.Drawing;

namespace caslab12thapril
{
    public partial class Hrmodule : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
          date.Text= DateTime.Today.ToString("dd/MM/yyyy");
            Newempcode();
            GridView1.DataBind();
        }


       
        private void Newempcode()
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

        

        protected void Submit_Click(object sender, EventArgs e)
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
                   
                    SqlCommand cmd = new SqlCommand("insert into AddEmployee(empid,EmpName,Qualification,fathername,address,email,Phone,pannumber,aadharnumber,bloodgroup,mattrialstatus,department,gender,dateofjoining,lastdateinthecompany,photodata,WorkLocation) values(@empid,@Empname,@Qualification,@fathername,@address,@email,@Phone,@pannumber,@aadharnumber,@bloodgroup,@mattrialstatus,@department,@gender,@dateofjoining,@lastdateinthecompany,@photodata,@WorkLocation)", con);
                    cmd.Parameters.AddWithValue("@empid", empcode.Text);

                    cmd.Parameters.AddWithValue("@EmpName", name.Text);
                    cmd.Parameters.AddWithValue("@Qualification", "B.Tech");
                    cmd.Parameters.AddWithValue("@fathername", fname.Text);
                    cmd.Parameters.AddWithValue("@address", address.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@Phone", phnum.Text);
                    cmd.Parameters.AddWithValue("@pannumber", pan.Text);
                    cmd.Parameters.AddWithValue("@aadharnumber", aadharnum.Text);
                    cmd.Parameters.AddWithValue("@bloodgroup", bloodgroup.Text);
                    cmd.Parameters.AddWithValue("@mattrialstatus", mattrialstatus.Text);
                    cmd.Parameters.AddWithValue("@department", department.Text);
                    cmd.Parameters.AddWithValue("@gender", gender.Text);
                    
                    cmd.Parameters.AddWithValue("@dateofjoining", date.Text);
                    cmd.Parameters.AddWithValue("@lastdateinthecompany", lastdate.Text);
                    cmd.Parameters.AddWithValue("@WorkLocation", WorkLocation.Text);
                    cmd.Parameters.AddWithValue("@photodata", bytes);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    GridView1.DataBind();
                    reset();
                }
            }
        
    }

        private void reset()
        {
            name.Text = "";
            fname.Text = "";
            address.Text = "";
            email.Text = "";
            phnum.Text = "";
            pan.Text = "";
            aadharnum.Text = "";
            bloodgroup.Items.Clear();
            mattrialstatus.Items.Clear();
            department.Items.Clear();
            gender.Items.Clear();

            lastdate.Text = "";
        }




        protected void OnPaging(object sender, GridViewPageEventArgs e)

        {

            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();

         

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        protected void excel_Click(object sender, EventArgs e)
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

        protected void employeeeditpopup_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#employeedetailsedit').modal('show')", true);
            GridView1.DataBind();
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string cellValue = gvr.Cells[1].Text;
            editempid.Text = cellValue;
        }
    }
}