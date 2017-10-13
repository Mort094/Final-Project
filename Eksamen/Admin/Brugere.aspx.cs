using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Brugere : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT * FROM roles", conn);

            conn.Open();

            dd_role.DataSource = cmd.ExecuteReader();
            dd_role.DataBind();
            dd_role.Items.Insert(0, new ListItem("Select", ""));
            conn.Close();



            cmd.CommandText = @"SELECT * FROM users
                                                INNER JOIN roles
                                                ON users.fk_roleId = roles.roleId";


            conn.Open();
            repeater_data.DataSource = cmd.ExecuteReader();
            repeater_data.DataBind();
            conn.Close();
        }
    }

    protected void repeater_data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        if (e.CommandName == "edit")
        {

            cmd.CommandText = @"SELECT * FROM users WHERE userId = @userId";

            cmd.Parameters.AddWithValue("@userId", e.CommandArgument);

            ViewState["userId"] = e.CommandArgument;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb_name.Text = reader["userName"].ToString();
                tb_email.Text = reader["userName"].ToString();
                tb_password.Text = reader["userPassword"].ToString();
                dd_role.Text = reader["fk_roleId"].ToString();


            }
            conn.Close();
        

        }
        if (e.CommandName == "give")
        {
            cmd.CommandText = @"UPDATE users SET userGrunker = userGrunker +500 WHERE userId = @userId";

            cmd.Parameters.AddWithValue("@userId", e.CommandArgument);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Brugere.aspx");

        }
        if (e.CommandName == "delete")
        {

            cmd.Connection = conn;
            cmd.CommandText = @"DELETE FROM users WHERE userId = @userId";
            cmd.Parameters.AddWithValue("@userId", e.CommandArgument);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Brugere.aspx");
        }

    }

    protected void btn_gem_Click(object sender, EventArgs e)
    {
        if (tb_name.Text == "" || tb_name.Text == "" || tb_descri.Text == "")
        {
            lbl_fejl.Text = "Du skal skrive noget i alle felter";
        }
        else
        {

        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand(@"UPDATE users SET userName = @name, userEmail = @email, fk_roleId = @role WHERE userId = @userId", conn);


        cmd.Parameters.AddWithValue("@userId", ViewState["userId"]);
        cmd.Parameters.AddWithValue("@name", tb_name.Text);
        cmd.Parameters.AddWithValue("@email", tb_email.Text);
        cmd.Parameters.AddWithValue("@role", dd_role.SelectedValue);
       
        if (tb_password.Text != "")
        {
            cmd.CommandText = @"UPDATE users SET userName = @name, userEmail = @email, fk_roleId = @role, userPassword = @password WHERE userId = @userId";
            cmd.Parameters.AddWithValue("@password", tb_password.Text);
        }

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        Response.Redirect("Brugere.aspx");
        }
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand(@"UPDATE users SET userGrunker = 1500", conn);


        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("Brugere.aspx");
    }
}