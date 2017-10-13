using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM infos", conn);


            conn.Open();
            repeater_footer.DataSource = cmd.ExecuteReader();
            repeater_footer.DataBind();
            conn.Close();
        }
        if (Session["userId"] != null)
        {
            lbtn_login.Visible = false;
            lbtn_logud.Visible = true;
        }
        if (Convert.ToInt32(Session["roleId"]) == 1)
        {
            lbtn_admin.Visible = true;
        }
    }

    protected void lbtn_logud_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Default.aspx");
    }
}
