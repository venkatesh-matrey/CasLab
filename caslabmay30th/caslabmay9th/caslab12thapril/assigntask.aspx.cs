using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace caslab12thapril
{
    public partial class assigntask : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            taskid.Text = Session["Name"] as String;
            Textbox3.Text = taskid.Text;
        }

        protected void taskdata_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);


           
            Textbox3.Text = Session["Name"] as String;
            SqlCommand status = new SqlCommand("update AddnewTask2 set EmpId='" + empid.Text + "' ,  UserName ='" + employeename.Text + "' where Name=@Name", con);
            try
            {
                con.Open();


                status.Parameters.AddWithValue("@Name", Textbox3.Text);
               


                status.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }
            string script = "alert(\"You assigned  the task succesfully\")";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }
    }
}