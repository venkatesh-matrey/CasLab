using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.IO;
using iTextSharp.text;

using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace caslab12thapril
{
    public partial class editor : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["MyDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            taskid.Text = Session["Name"] as string;
            Session.Timeout = 60;
        }

        

        protected void backbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPage2.aspx");
        }
    }
} 