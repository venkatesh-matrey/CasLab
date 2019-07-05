﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace caslab12thapril
{
    public partial class EmployeeLogin1 : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;



        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            //GridView1.DataBind();
            if (!Page.IsPostBack)
            {


                DataBind();

                ecode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  select Ecode    ", " "));
                ecode.AppendDataBoundItems = true;



                String strQuery = "select empid from AddEmployee where UserName is Null";
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand();
                //cmd.Parameters.AddWithValue("@EmpId", empid.Text);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ecode.DataSource = cmd.ExecuteReader();
                    ecode.DataTextField = "empid";
                    ecode.DataValueField = "empid";
                    ecode.DataBind();
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
        }



 protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();

        }


        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            int i = 0;
            if (i == 0)
            {
                SqlCommand cmd = new SqlCommand("pro_employeelogindetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@statement", "update");
                cmd.Parameters.AddWithValue("@EmpId", Convert.ToString(ecode.Text.Trim()));
                cmd.Parameters.AddWithValue("@Name", Convert.ToString(txtname.Text.Trim()));
                cmd.Parameters.AddWithValue("@LoginID", Convert.ToString(txtlogin.Text.Trim()));
                cmd.Parameters.AddWithValue("@Password", Convert.ToString(txtpass.Text.Trim()));
                cmd.Parameters.AddWithValue("@EmailID", Convert.ToString(email.Text.Trim()));
                //cmd.Parameters.AddWithValue("@UserName", Convert.ToString(txtlogin.Text.Trim()));
                //cmd.Parameters.AddWithValue("@pass", Convert.ToString(txtpass.Text.Trim()));
                //cmd.Parameters.AddWithValue("@compenymail", Convert.ToString(email.Text.Trim()));
                cmd.Parameters.AddWithValue("@status", "nostatus");
                cmd.ExecuteNonQuery();
                con.Close();


            }
            int j = 0;
            if (j == 0)
            {
                SqlCommand cmd = new SqlCommand("pro_employeelogindetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@statement", "insert");
                cmd.Parameters.AddWithValue("@EmpId", Convert.ToString(ecode.Text.Trim()));
                cmd.Parameters.AddWithValue("@Name", Convert.ToString(txtname.Text.Trim()));
                cmd.Parameters.AddWithValue("@LoginID", Convert.ToString(txtlogin.Text.Trim()));
                cmd.Parameters.AddWithValue("@Password", Convert.ToString(txtpass.Text.Trim()));
                cmd.Parameters.AddWithValue("@EmailID", Convert.ToString(email.Text.Trim()));
                //cmd.Parameters.AddWithValue("@UserName", Convert.ToString(txtlogin.Text.Trim()));
                //cmd.Parameters.AddWithValue("@pass", Convert.ToString(txtpass.Text.Trim()));
                //cmd.Parameters.AddWithValue("@compenymail", Convert.ToString(email.Text.Trim()));
                cmd.Parameters.AddWithValue("@status", "nostatus");
                cmd.ExecuteNonQuery();
                con.Close();

            }
            GridView1.DataBind();
        }



        //protected void gridview1()
        //{
        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand(" select employeelogindetails.Ecode,employeelogindetails.Name, employeelogindetails.LoginID ,employeelogindetails.Password, createemployee.Department,employeelogindetails.EmailID,createemployee.WorkLocation from createemployee inner join employeelogindetails on createemployee.empcode = employeelogindetails.Ecode ", con);
        //    con.Open();
        //    SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "createemployee");
        //    GridView1.DataSource = ds.Tables["createemployee"];
        //    GridView1.DataBind();
        //    con.Close();
        //}

        //protected void ecode_SelectedIndexChanged(object sender, EventArgs e)
        //{



        //    String strQuery = "select * from createemployee where empcode=@empcode ";

        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.AddWithValue("@empcode", ecode.SelectedItem.Text);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = strQuery;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            txtname.Text = sdr.GetValue(2).ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //    }

        //    ClientScript.RegisterStartupScript(this.GetType(), "popup", "$('#addrawmaterial').modal('Show')", true);

        //}


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#Creatpasswor').modal('show')", true);


            String strQuery = "select * from AddEmployee where empid=@empid ";

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@empid", ecode.SelectedItem.Text);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    txtname.Text = sdr.GetValue(2).ToString();
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
        }


        
        //protected void editbutton_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand("update AddEmployee set compenymail=@compenymail where Ecode=@Ecode", con);
        //    con.Open();
        //    cmd.Parameters.AddWithValue("@EmailID", editemail.Text);
        //    cmd.Parameters.AddWithValue("@Ecode", editcode.Text);
        //    cmd.ExecuteNonQuery();
        //    GridView1.DataBind();
        //    con.Close();


        //}


        //protected void editbutton_Click1(object sender, EventArgs e)
        //{

        //    string ecode = editcode.Text;
        //    SqlConnection con = new SqlConnection(str);

        //    SqlCommand cmd = new SqlCommand("update employeelogindetails set  txtname=@txtname, txtlogin=@txtlogin, txtpass=@txtpass,email=@email where code='" + ecode + "'", con);
        //    con.Open();
        //    cmd.Parameters.AddWithValue("@txtname", editname.Text);
        //    cmd.Parameters.AddWithValue("@txtlogin", editloginid.Text);

        //    cmd.Parameters.AddWithValue("@txtpass", editpassword.Text);
        //    cmd.Parameters.AddWithValue("@email", editemail.Text);

        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    GridView1.DataBind();
        //}

        //protected void editpopup_Click(object sender, EventArgs e)
        //{


        //}



        //protected void editpopup_Click(object sender, EventArgs e)
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#updateemployee').modal('show')", true);
        //    GridView1.DataBind();


        //    int id = Convert.ToInt32(Request.Form["RadioButton1"]);
        //    editcode.Text = GridView1.Rows[id - 1].Cells[1].Text;
        //    editname.Text = GridView1.Rows[id - 1].Cells[2].Text;
        //    editloginid.Text = GridView1.Rows[id - 1].Cells[3].Text;
        //    editpassword.Text = GridView1.Rows[id - 1].Cells[4].Text;
        //    editemail.Text = GridView1.Rows[id - 1].Cells[5].Text;
        
        

        //}

        

        protected void editpopup_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#updateemployee').modal('show')", true);

            GridView1.DataBind();

            int id = Convert.ToInt32(Request.Form["RadioButton1"]);
            editcode.Text = GridView1.Rows[id - 1].Cells[1].Text;
            editname.Text = GridView1.Rows[id - 1].Cells[2].Text;
            editloginid.Text = GridView1.Rows[id - 1].Cells[3].Text;
            editpassword.Text = GridView1.Rows[id - 1].Cells[4].Text;
            editemail.Text = GridView1.Rows[id - 1].Cells[5].Text;
           
        }

        protected void editbutton_Click(object sender, EventArgs e)
        {
           string Ecode = editcode.Text;
            using (SqlConnection con = new SqlConnection(str))
            {

                SqlCommand cmd = new SqlCommand("update AddEmployee set   UserName=@UserName, Password=@Password,compenymail=@compenymail where EmpId=@EmpId", con);


                try
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@UserName", editloginid.Text);
                    cmd.Parameters.AddWithValue("@Password", editpassword.Text);
                    cmd.Parameters.AddWithValue("@compenymail", editemail.Text);
                    cmd.Parameters.AddWithValue("@EmpId", Ecode);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                }
                catch
                {

                }
            }
        }

        protected void unlock_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.Form["RadioButton1"]);
            string employeecode = GridView1.Rows[id - 1].Cells[1].Text;
            using (SqlConnection con = new SqlConnection(str))
            {
                
                SqlCommand cmd = new SqlCommand("update AddEmployee set status='Unlocked'where EmpId=@EmpId", con);


                try
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@EmpId", employeecode);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                }
                catch
                {

                }
            }
        }
    }
}
