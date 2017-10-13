using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kontakt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM infos", conn);


            conn.Open();
            repeater_info.DataSource = cmd.ExecuteReader();
            repeater_info.DataBind();
            conn.Close();

            cmd.CommandText = @"SELECT * FROM times";

            conn.Open();
            repeater_time.DataSource = cmd.ExecuteReader();
            repeater_time.DataBind();
            conn.Close();
        }
    }

    protected void btn_send_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand(@"INSERT INTO contacts 
                                            (contactUser, contactAddress, contactPhone, contactEmail, contactText) 
                                        VALUES
                                            (@name, @address, @phone, @email, @text)", conn);




        cmd.Parameters.AddWithValue("@name", tb_name.Text);
        cmd.Parameters.AddWithValue("@address", tb_address.Text);
        cmd.Parameters.AddWithValue("@phone", tb_phone.Text);
        cmd.Parameters.AddWithValue("@email", tb_email.Text);
        cmd.Parameters.AddWithValue("@text", tb_text.Text);
    }
}