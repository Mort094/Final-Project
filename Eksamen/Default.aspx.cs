using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("Refresh", "6");
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM frontpages", conn);


            conn.Open();
            repeater_front.DataSource = cmd.ExecuteReader();
            repeater_front.DataBind();
            conn.Close();

            cmd = new SqlCommand(@"SELECT TOP(4) * FROM albums 
                                             ORDER BY albumBuy DESC", conn);
            conn.Open();
            repeater_top.DataSource = cmd.ExecuteReader();
            repeater_top.DataBind();
            conn.Close();

            cmd = new SqlCommand("SELECT TOP(3) * FROM albums ORDER BY NEWID()", conn);
            conn.Open();
            repeater_random.DataSource = cmd.ExecuteReader();
            repeater_random.DataBind();
            conn.Close();
        }

    }
}