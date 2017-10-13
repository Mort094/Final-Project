using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Albumet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM albums 
                                    INNER JOIN genres
                                ON albums.fk_genreId = genres.genreId 
                                    INNER JOIN prices
                                ON albums.fk_priceId = prices.priceId
                                    WHERE albumId = @albumId";

            cmd.Parameters.AddWithValue("@albumId", Request.QueryString["Album"]);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["fk_genreId"] = reader["fk_genreId"];
                Session["priceValue"] = reader["priceValue"];

            }
            conn.Close();

            conn.Open();
            repeater_info.DataSource = cmd.ExecuteReader();
            repeater_info.DataBind();
            conn.Close();

            cmd.CommandText = @"SELECT TOP(3) * FROM albums 
                                                INNER JOIN genres  
                                            ON albums.fk_genreId = genres.genreId
                                                WHERE fk_genreId = @fk_genreId
                                            ORDER BY NEWID()";
            cmd.Parameters.AddWithValue("@fk_genreId", Session["fk_genreId"]);

            conn.Open();
            repeater_samegenre.DataSource = cmd.ExecuteReader();
            repeater_samegenre.DataBind();
            conn.Close();


        }
    }
    protected void btn_kob_Click(object sender, EventArgs e)
    {

        if (Session["userId"] != null)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ToString());

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
          
            cmd.CommandText = @"INSERT INTO orders (orderDate, fk_albumId, fk_userId) 
                                VALUES (GETDATE(), @albumId, @userId); 
                                UPDATE users SET userGrunker = (userGrunker - @price) WHERE userId = @userID;
                                UPDATE albums SET albumBuy = albumBuy + 1 WHERE albumId = @albumId" ;
            cmd.Parameters.AddWithValue("@userId", Session["userId"]);
            cmd.Parameters.AddWithValue("albumId", Request.QueryString["Album"]);
            cmd.Parameters.AddWithValue("@price", Session["priceValue"]);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect(Request.RawUrl);
            lbl_fejl1.Text = "Du har nu købt dette album!";
        }
        else
        {
            lbl_fejl.Text = "Du skal være logget ind for at købe!";
        }
    }

   

}