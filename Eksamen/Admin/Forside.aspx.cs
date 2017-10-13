using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Forside : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM frontpages", conn);


            conn.Open();
            repeater_text.DataSource = cmd.ExecuteReader();
            repeater_text.DataBind();
            conn.Close();
        }
    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
       


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM frontpages", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb_text.Text = reader["frontText"].ToString();

            }
            conn.Close();
      

    }

    protected void btn_gem_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand(@"UPDATE frontpages SET frontText = @text", conn);
                                           
        cmd.Parameters.AddWithValue("@text", tb_text.Text);
   

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect(Request.RawUrl);
    }


}