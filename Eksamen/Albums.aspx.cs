using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Albums : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(Helpers.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;


        if (Request.QueryString["sortby"] == "1")
        {
            cmd.CommandText = @"SELECT * FROM albums
                                INNER JOIN genres
                            ON albums.fk_genreId = genres.genreId
            
            ORDER BY 
               albumTitle ASC
           ";
        }
        if (Request.QueryString["sortby"] == "2")
        {
            cmd.CommandText = @"SELECT * FROM albums
                                INNER JOIN genres
                            ON albums.fk_genreId = genres.genreId
            
            ORDER BY 
               albumArtist ASC
          ";
        }
        if (Request.QueryString["sortby"] == "3")
        {
            cmd.CommandText = @"SELECT * FROM albums
                                INNER JOIN genres
                            ON albums.fk_genreId = genres.genreId
            
            ORDER BY 
               genreName ASC
           ";
        }
        if (Request.QueryString["sortby"] == "4")
        {
            cmd.CommandText = @"SELECT * FROM albums
                                INNER JOIN genres
                            ON albums.fk_genreId = genres.genreId
            
            ORDER BY 
               albumDate DESC
          ";
        }


        conn.Open();
        re_content.DataSource = cmd.ExecuteReader();
        re_content.DataBind();
        conn.Close();
    }
   
    protected void lbtn_title_Click(object sender, EventArgs e)
    {
        Response.Redirect("Albums.aspx?sortby=1");
    }
    protected void lbtn_artist_Click(object sender, EventArgs e)
    {
        Response.Redirect("Albums.aspx?sortby=2");
    }
    protected void lbtn_genre_Click(object sender, EventArgs e)
    {
        Response.Redirect("Albums.aspx?sortby=3");
    }
    protected void lbtn_date_Click(object sender, EventArgs e)
    {
        Response.Redirect("Albums.aspx?sortby=4");
    }
}