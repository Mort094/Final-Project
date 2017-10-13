using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Anmeldelser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null && Request.QueryString["album"] != null)
        {
            panel_comment.Visible = true;
        }

        SqlConnection conn = new SqlConnection(Helpers.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"SELECT * FROM albums
                                INNER JOIN genres
                            ON albums.fk_genreId = genres.genreId
                                INNER JOIN ratings
                            ON albums.albumId = ratings.fk_albumId
                                WHERE ratingAproved = 1 
                            ORDER BY albumDate DESC";
        if (Request.QueryString["album"] != null)
        {
            cmd.CommandText = @"SELECT * FROM albums
                                INNER JOIN genres
                            ON albums.fk_genreId = genres.genreId
                                INNER JOIN ratings
                            ON albums.albumId = ratings.fk_albumId
                                WHERE ratingAproved = 1 AND albumId = @albumId
                            ORDER BY albumDate DESC";
            cmd.Parameters.AddWithValue("@albumId", Request.QueryString["Album"]);
            
        }
        else
        {
            lbl_fejl.Text = "Der er ingen anmeldelser til dette album endnu";
        }
        if (Session["userId"] != null)
        {
            cmd.CommandText = @"SELECT * FROM albums
                                INNER JOIN genres
                            ON albums.fk_genreId = genres.genreId
                                INNER JOIN ratings
                            ON albums.albumId = ratings.fk_albumId
                                INNER JOIN users
                            ON ratings.fk_userId = users.userId
                                WHERE ratingAproved = 1
                            ORDER BY albumDate DESC";
            cmd.Parameters.AddWithValue("@userId", Session["userId"]);
        }

        conn.Open();
        repeater_content.DataSource = cmd.ExecuteReader();
        repeater_content.DataBind();
        conn.Close();


    }
    protected void btn_send_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["album"] != null)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = @"INSERT INTO ratings (ratingTitle, ratingText, fk_userId, ratingAproved, fk_albumId) 
                                        VALUES (@title, @text, @user, 0, @album)";
            cmd.Parameters.AddWithValue("@user", Session["userId"]);
            cmd.Parameters.AddWithValue("@album", Request.QueryString["album"].ToString());
            cmd.Parameters.AddWithValue("@title", tb_title.Text);
            cmd.Parameters.AddWithValue("@text", tb_text.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect(Request.RawUrl);
           

        }
        else
        {
            lbl_fejl.Text = "Det kan du ikke få lov til, da vi ikke ved hvilket album du vil kommenter";
        }
    }
}