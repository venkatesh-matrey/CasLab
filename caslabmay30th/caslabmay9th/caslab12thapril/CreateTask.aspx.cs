using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Specialized;

namespace caslab12thapril
{
    public partial class CreateTask : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {







            clear();
            NewtaskID();
            empid.Text = (string)Session["EmpId"];
            
            empname.Text = (string)Session["UserName"];
            //string EmpId = (string)Session["EmpId"];
            //SqlDataSource1.SelectParameters["EmpId"].DefaultValue = EmpId;
            id();
            if (!Page.IsPostBack)
            {


              
                SetInitialRow();

                DataBind();

                Projectid.Items.Insert(0, new System.Web.UI.WebControls.ListItem("  Created ProjectID's    ", " "));
                Projectid.AppendDataBoundItems = true;



                String strQuery = "select Id,Name from AddProject3 where EmpId=@EmpId";
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@EmpId", empid.Text);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    Projectid.DataSource = cmd.ExecuteReader();
                    Projectid.DataTextField = "Name";
                    Projectid.DataValueField = "Id";
                    Projectid.DataBind();
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
                empname.Visible = false;
            }
        }


        private void clear()
        {
            Taskid.Text = "";
            TaskDescription.Text = "";
           
        }




        //protected void Projectid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    String strQuery = "select ProjectId from CreateProject where ProjectId = @ProjectId";

        //    SqlConnection con = new SqlConnection(str);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.AddWithValue("@ProjectId", Projectid.SelectedItem.Value);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = strQuery;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            Projectid.Text = sdr.GetValue(0).ToString();
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
        //}

        private void id()
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(Id) from AddnewTask2", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            Textbox1.Text = i.ToString();
        }

        private void NewtaskID()
        {

            string code = "CASLAB001-D";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(Name) from AddnewTask2", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            Taskid.Text = code + i.ToString();
            Session["Name"] = Taskid.Text;
        }











        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Chemical", typeof(string)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("Units", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Chemical"] = string.Empty;
            dr["Quantity"] = string.Empty;
            dr["Units"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

private void employeeidbind()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select EmpId from AddEmployee where UserName = '" + Session["UserName"] + "'", con);
            con.Open();
            Session["EmpId"] = cmd.ExecuteScalar();
            con.Close();
            string employeeid = Convert.ToString(Session["EmpId"]);
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        DropDownList box1 = (DropDownList)GridView2.Rows[rowIndex].Cells[1].FindControl("chemical");
                        TextBox box2 = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("qun");
                        DropDownList box3 = (DropDownList)GridView2.Rows[rowIndex].Cells[3].FindControl("units");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Chemical"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Quantity"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Units"] = box3.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GridView2.DataSource = dtCurrentTable;
                    GridView2.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }


        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList box1 = (DropDownList)GridView2.Rows[rowIndex].Cells[1].FindControl("chemical");
                        TextBox box2 = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("qun");
                        DropDownList box3 = (DropDownList)GridView2.Rows[rowIndex].Cells[3].FindControl("units");

                        box1.Text = dt.Rows[i]["Chemical"].ToString();
                        box2.Text = dt.Rows[i]["Quantity"].ToString();
                        box3.Text = dt.Rows[i]["Units"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.BorderStyle = BorderStyle.None;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                 string statuschechimcal = "Enabled";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                var dropdown = (DropDownList)e.Row.FindControl("chemical");
                string query = "select rawmaterialname from AddRawmaterial where status='"+statuschechimcal+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                dropdown.DataSource = dt;
                dropdown.DataTextField = "rawmaterialname";
                dropdown.DataValueField = "rawmaterialname";
                dropdown.DataBind();
                dropdown.Items.Insert(0, new ListItem("---select chemical--"));



            }
        }

        private void InsertRecords(StringCollection sc)
        {
            SqlConnection conn = new SqlConnection(str);
            StringBuilder sb = new StringBuilder(string.Empty);
            string[] splitItems = null;
            foreach (string item in sc)
            {
                const string sqlStatement = "INSERT INTO addchemicals (TaskId,Chemicals,Quantity,Units) VALUES";
                if (item.Contains(","))
                {
                    splitItems = item.Split(",".ToCharArray());
                    sb.AppendFormat("{0}('{1}','{2}','{3}','{4}'); ", sqlStatement, splitItems[0], splitItems[1], splitItems[2], splitItems[3]);
                    
                }
            }
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand( sb.ToString(), conn);
               
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records are Saved Successfuly!');", true);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            int rowIndex = 0;
            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList box1 = (DropDownList)GridView2.Rows[rowIndex].Cells[1].FindControl("chemical");
                        TextBox box2 = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("qun");
                        DropDownList box3 = (DropDownList)GridView2.Rows[rowIndex].Cells[3].FindControl("units");
                       
                        Session["Name"] = Taskid.Text;
                        var taskdata = Session["Name"].ToString();
                       
                        

                        sc.Add(taskdata + "," + box1.Text + ", " + box2.Text + "," + box3.Text);
                        rowIndex++;
                    }
                    // Call the method   
                    InsertRecords(sc);
                }

            }
 employeeidbind();
            string employeeid = Convert.ToString(Session["EmpId"]);
            SqlConnection con = new SqlConnection(str);
             SqlCommand cmd = new SqlCommand("insert into AddnewTask2(Id,Name,TaskDescription,TaskTypeId,EmpId,UserName,projectid)values('" + Textbox1.Text + "','" + Taskid.Text + "','" + TaskDescription.Text + "','" + Projectid.Text + "','" + employeeid + "','" + empname.Text + "','" + Projectid.SelectedItem.Text + "')", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            SqlConnection con1 = new SqlConnection(str);
            SqlCommand command = new SqlCommand("insert into approverdata(TaskId,Status)values('" + Taskid.Text + "',@Status)", con1);
            command.Parameters.AddWithValue("@Status", "PENDING");


            con1.Open();
            command.ExecuteNonQuery();
            con1.Close();
        }
    }
}

    
      
