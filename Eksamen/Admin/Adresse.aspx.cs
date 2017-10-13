using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Adresse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM infos", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb_name.Text = reader["infoName"].ToString();
                tb_address.Text = reader["infoAddress"].ToString();
                tb_zip.Text = reader["infoZip"].ToString();
                tb_phone.Text = reader["infoPhone"].ToString();
                tb_email.Text = reader["infoEmail"].ToString();


            }
            conn.Close();
        }
    }
    protected void btn_gem_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand(@"UPDATE infos 
                                            SET infoName = @name, infoAddress = @address, infoZip = @zip, infoPhone = @phone, infoEmail = @email", conn);

        cmd.Parameters.AddWithValue("@name", tb_name.Text);
        cmd.Parameters.AddWithValue("@address", tb_address.Text);
        cmd.Parameters.AddWithValue("@zip", tb_zip.Text);
        cmd.Parameters.AddWithValue("@phone", tb_phone.Text);
        cmd.Parameters.AddWithValue("@email", tb_email.Text);


        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("Adresse.aspx");
    }
}