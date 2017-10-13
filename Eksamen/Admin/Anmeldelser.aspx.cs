using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Anmeldelser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

        
       
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        if (Convert.ToInt32(Request.QueryString["godkendt"]) == 2)
        {
            cmd.CommandText = @"SELECT * FROM ratings
                                INNER JOIN albums
                            ON ratings.fk_albumId = albums.albumId";
        }


        if (Convert.ToInt32(Request.QueryString["godkendt"]) == 1)
        {
            cmd.CommandText = @"SELECT * FROM ratings
                                INNER JOIN albums
                            ON ratings.fk_albumId = albums.albumId
                                WHERE ratingAproved = 1";
        }
        if (Convert.ToInt32(Request.QueryString["godkendt"]) == 0)
        {
            cmd.CommandText = @"SELECT * FROM ratings
                                INNER JOIN albums
                            ON ratings.fk_albumId = albums.albumId
							    WHERE ratingaproved = 0";
        }

        conn.Open();
        re_content.DataSource = cmd.ExecuteReader();
        re_content.DataBind();
        conn.Close();
        }

    }


    protected void lbtn_all_Click(object sender, EventArgs e)
    {
        Response.Redirect("Anmeldelser.aspx?godkendt=2");
    }

    protected void lbtn_ok_Click(object sender, EventArgs e)
    {
        Response.Redirect("Anmeldelser.aspx?godkendt=1");
    }

    protected void lbtn_nook_Click(object sender, EventArgs e)
    {
        Response.Redirect("Anmeldelser.aspx?godkendt=0");
    }

    protected void re_content_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        if (e.CommandName == "ok")
        {

            cmd.CommandText = @"UPDATE ratings SET ratingAproved = 1 WHERE ratingId = @ratingId";

            cmd.Parameters.AddWithValue("@ratingId", e.CommandArgument);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Anmeldelser.aspx?godkendt=1");


        }
        if (e.CommandName == "notok")
        {
            cmd.CommandText = @"UPDATE ratings SET ratingAproved = 0 WHERE ratingId = @ratingId";

            cmd.Parameters.AddWithValue("@ratingId", e.CommandArgument);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Anmeldelser.aspx?godkendt=0");

        }
        if (e.CommandName == "delete")
        {

            cmd.Connection = conn;
            cmd.CommandText = @"DELETE FROM ratings WHERE ratingId = @ratingId";
            cmd.Parameters.AddWithValue("@ratingId", e.CommandArgument);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Anmeldelser.aspx?godkendt=2");
        }
    }
}