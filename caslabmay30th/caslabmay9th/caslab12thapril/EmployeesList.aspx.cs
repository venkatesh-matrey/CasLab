﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace caslab12thapril
{
    public partial class EmployeesList : System.Web.UI.Page
    {

        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        private void filldata()
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter("select EmpId,EmpName,Email,UserName,Password,position from AddEmployee", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "AddEmployee");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                filldata();
            }
        }


        public void save_Click1(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                //var checkbox = gvrow.FindControl("creatorlabel") as CheckBox;
                var checkbox1 = gvrow.FindControl("reviewerlabel") as CheckBox;
                var checkbox2 = gvrow.FindControl("approverlabel") as CheckBox;
                // var empid = gvrow.FindControl("Label1") as Label;

                String llbl = ((Label)gvrow.Cells[0].FindControl("label1")).Text;
                //Label lbCod = GridView1.Rows["Label1"].Cells["Label1"].Controls["Label1"] as Label;
                //Session["EmpId"] = gvrow.FindControl("approverlabel") as CheckBox;
                // GridViewRow row = GridView1.SelectedRow;

                // And you respective cell's value
                //var empid = row.Cells[0].Text;



                //if (checkbox.Checked)
                //{
                //    using (SqlConnection con = new SqlConnection(str))
                //    {

                //        SqlCommand cmd = new SqlCommand("update AddEmployee set position='creator' where EmpId=@EmpId", con);


                //        try
                //        {
                //            con.Open();
                //            cmd.Parameters.AddWithValue("@EmpId", llbl);
                //            cmd.ExecuteNonQuery();
                //            con.Close();
                //        }
                //        catch
                //        {

                //        }
                //    }
                //    checkbox1.Visible = false;
                //    checkbox2.Visible = false;

                //}

                if (checkbox1.Checked)
                {
                    checkbox2.Visible = false;
                    using (SqlConnection con = new SqlConnection(str))
                    {
                        //int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
                        //Session["EmpId"] = GridView1.Rows[rowIndex].Cells[0].Text;
                        SqlCommand cmd = new SqlCommand("update AddEmployee set position='Reviewer' where EmpId=@EmpId", con);


                        try
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@EmpId", llbl);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        catch
                        {

                        }
                    }



                }
                if (checkbox2.Checked)
                {
                    checkbox1.Visible = false;
                    using (SqlConnection con = new SqlConnection(str))
                    {
                        //int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
                        //Session["EmpId"] = GridView1.Rows[rowIndex].Cells[0].Text;
                        SqlCommand cmd = new SqlCommand("update AddEmployee set position='Approver'where EmpId=@EmpId", con);


                        try
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@EmpId", llbl);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        catch
                        {

                        }
                    }



                }
                filldata();
            }

        }
    }

}
