using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Tider : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM times", conn);


            conn.Open();
            repeater_time.DataSource = cmd.ExecuteReader();
            repeater_time.DataBind();
            conn.Close();
        }
    }

    protected void repeater_time_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
         SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        if (e.CommandName == "edit")
        {

            cmd.CommandText = @"SELECT * FROM times WHERE timeId = @Id";

            cmd.Parameters.AddWithValue("@Id", e.CommandArgument);

            ViewState["timeId"] = e.CommandArgument;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb_openTime.Text = reader["timeOpen"].ToString();
                tb_closeTime.Text = reader["timeClose"].ToString();
                lbl_day.Text = reader["timeDay"].ToString();
            }
            conn.Close();
           

        }
        
    }

    protected void btn_gem_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand(@"UPDATE times SET timeOpen = @open, timeClose = @close WHERE timeId = @Id", conn);


        cmd.Parameters.AddWithValue("@Id", ViewState["timeId"]);
        cmd.Parameters.AddWithValue("@open", tb_openTime.Text);
        cmd.Parameters.AddWithValue("@close", tb_closeTime.Text);
       

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect(Request.RawUrl);
    }
}