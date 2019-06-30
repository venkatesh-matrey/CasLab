using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace caslab12thapril
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            username.Text = (string)Session["UserName"];
            if (!this.IsPostBack)
            {
                DataTable dt = this.GetData("SELECT Id, Name,ProjectName,ProjectDescription,EmpId FROM AddProject3");
                this.PopulateTreeView(dt, 0, null);
            }

        }

        private void PopulateTreeView(DataTable dtParent, int parentId, TreeNode treeNode)
        {
            foreach (DataRow row in dtParent.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["Name"].ToString(),
                    Value = row["Id"].ToString()
                };
                if (parentId == 0)
                {
                    TreeView1.Nodes.Add(child);
                    DataTable dtChild = this.GetData("SELECT Id, Name,TaskName,TaskDescription,Chemical,Quantity,Units,EmpId FROM AddnewTask2 WHERE TaskTypeId=" + child.Value);
                    PopulateTreeView(dtChild, int.Parse(child.Value), child);
                }
                else
                {
                    treeNode.ChildNodes.Add(child);
                }
            }
        }



        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }

    }
}