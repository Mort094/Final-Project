using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Anmeldelse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM ratings
                                                INNER JOIN albums
                                            ON ratings.fk_albumId = albums.albumId
                                                LEFT JOIN users
                                            ON ratings.fk_userId = users.userId
                                                WHERE ratings.ratingAproved = 1 AND albums.albumId = @albumId
                                            ORDER BY ratingDate", conn);
            cmd.Parameters.AddWithValue("@albumId", Request.QueryString["Anmeldelse"]);

            conn.Open();
            repeater_content.DataSource = cmd.ExecuteReader();
            repeater_content.DataBind();
            conn.Close();

            cmd.CommandText = @"SELECT albumTitle, albumId FROM albums WHERE albumId = @albumId";

            

            conn.Open();
            repeater_head.DataSource = cmd.ExecuteReader();
            repeater_head.DataBind();
            conn.Close();
        }
    }
}