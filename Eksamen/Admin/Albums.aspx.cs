using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Albums : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM PRICES", conn);

            conn.Open();
            dd_price.DataSource = cmd.ExecuteReader();
            dd_price.DataBind();
            dd_price.Items.Insert(0, new ListItem("Vælg", ""));
            conn.Close();

            cmd.CommandText = @"SELECT * FROM genres";
            conn.Open();
            dd_genre.DataSource = cmd.ExecuteReader();
            dd_genre.DataBind();
            dd_genre.Items.Insert(0, new ListItem("Vælg", ""));
            conn.Close();

            cmd.CommandText = @"SELECT * FROM albums";


            conn.Open();
            re_content.DataSource = cmd.ExecuteReader();
            re_content.DataBind();
            conn.Close();
        }
    }

    protected void re_content_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        if (e.CommandName == "edit")
        {

            cmd.CommandText = @"SELECT * FROM albums WHERE albumId = @albumId";

            cmd.Parameters.AddWithValue("@albumId", e.CommandArgument);

            ViewState["albumId"] = e.CommandArgument;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb_title.Text = reader["albumTitle"].ToString();
                tb_artist.Text = reader["albumArtist"].ToString();
                tb_date.Text = reader["albumDate"].ToString();
                dd_price.Text = reader["fk_priceId"].ToString();
                dd_genre.Text = reader["fk_genreId"].ToString();
                hf_billede.Value = reader["albumCover"].ToString();



            }
            conn.Close();
            btn_opret.Visible = false;
            btn_gem.Visible = true;
            hf_billede.Visible = true;

        }
        if (e.CommandName == "delete")
        {
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM albums 
                                WHERE albumId = @albumId";
            cmd.Parameters.AddWithValue("@albumId", e.CommandArgument);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                //Skal med for at sletter billeder/filer i mapper når du sletter tingen på siden. Den ved allerede hvilken id det, så den skal også vide hvilken ting den skal slettet i mappen. Det finder du på sammen måde som når du SELECTER det til at kunne rette
                if (File.Exists(Server.MapPath("~/Images/Albums/") + reader["albumCover"].ToString()))
                {
                    File.Delete(Server.MapPath("~/Images/Albums/") + reader["albumCover"].ToString());
                }

                if (File.Exists(Server.MapPath("~/Images/Albums/Small/") + reader["albumCover"].ToString()))
                {
                    File.Delete(Server.MapPath("~/Images/Albums/Small/") + reader["albumCover"].ToString());
                }
                if (File.Exists(Server.MapPath("~/Images/Albums/Large/") + reader["albumCover"].ToString()))
                {
                    File.Delete(Server.MapPath("~/Images/Albums/Large/") + reader["albumCover"].ToString());
                }
                //if (File.Exists(Server.MapPath("~/billeder/plakater/original/") + reader["product_image"].ToString()))
                //{
                //    File.Delete(Server.MapPath("~/billeder/plakater/original/") + reader["product_image"].ToString());
                //}
            }
            cmd.CommandText = @"DELETE FROM albums WHERE albumId= @albumId";
            conn.Close();

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect(Request.RawUrl);
        }

    }

    protected void btn_opret_Click(object sender, EventArgs e)
    {
        opret();
    }
    protected void btn_gem_Click(object sender, EventArgs e)
    {
        gem();
    }
    private void opret()
    {
        if (tb_artist.Text == "" || tb_date.Text == "" || tb_title.Text == "" || dd_genre.SelectedValue == "" || dd_price.SelectedValue == "")
        {
            lbl_fejl.Text = "Du skal udfylde alle felterne!";
        }
        else
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = @"INSERT INTO albums (albumTitle, albumCover, albumArtist, albumDate, fk_priceId, fk_genreId) 
                                        VALUES (@title, @cover, @artist, @date, @price, @genre)";

            cmd.Parameters.AddWithValue("@title", tb_title.Text);
            cmd.Parameters.AddWithValue("@artist", tb_artist.Text);
            cmd.Parameters.AddWithValue("@date", tb_date.Text);
            cmd.Parameters.AddWithValue("@price", dd_price.SelectedValue);
            cmd.Parameters.AddWithValue("@genre", dd_genre.SelectedValue);

            string img_path = "intetbillede.jpg";

            //Hvis der er en fil i FilUploaden

            if (fu_billede.HasFile)
            {
                //NewGuid danner uniq navn for billeder
                img_path = Guid.NewGuid() + Path.GetExtension(fu_billede.FileName);
                // Opret



                String UploadeMappe = Server.MapPath("~/Images/Albums/");

                //string Kategori = dd_type.SelectedItem.Text;
                String Lille = "Small";
                String Stor = "Large";
                String Filnavn = DateTime.Now.ToFileTime() + fu_billede.FileName;
                img_path = Filnavn;

                //Gem det orginale Billede
                fu_billede.SaveAs(UploadeMappe + Filnavn);

                // Definer hvordan
                ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 50;
                BilledeSkalering.Height = 50;

                //Udfør skalleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, UploadeMappe + "/" + Lille + "/" + Filnavn, BilledeSkalering);

                //Lav nogle nye skalerings instillinger
                BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 200;
                BilledeSkalering.Height = 200;


                //Udfør selve skaleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, UploadeMappe + "/" + Stor + "/" + Filnavn, BilledeSkalering);

            }
            else
            {
                lbl_fejl.Text = "Du skal vælge et billede!";
            }
            // Tildel parameter-værdierne, fra input felterne.
            cmd.Parameters.AddWithValue("@cover", img_path);



            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect(Request.RawUrl);
        }
    }
    private void gem()
    {
        if (tb_artist.Text == "" || tb_date.Text == "" || tb_title.Text == "" || dd_genre.SelectedValue == "" || dd_price.SelectedValue == "")
        {
            lbl_fejl.Text = "Du skal udfylde alle felterne!";
        }
        else
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand(@"UPDATE albums
                                        SET albumTitle = @title, albumCover = @cover, albumArtist = @artist, albumDate = @date, fk_priceId = @price, fk_genreId = @genre
                                        WHERE albumId = @albumId", conn);

            cmd.Parameters.AddWithValue("@albumId", ViewState["albumId"]);
            cmd.Parameters.AddWithValue("@title", tb_title.Text);
            cmd.Parameters.AddWithValue("@artist", tb_artist.Text);
            cmd.Parameters.AddWithValue("@date", tb_date.Text);
            cmd.Parameters.AddWithValue("@price", dd_price.SelectedValue);
            cmd.Parameters.AddWithValue("@genre", dd_genre.SelectedValue);




            string img_path = hf_billede.Value;
            if (fu_billede.HasFile)
            {
                //NewGuid danner uniq navn for billeder
                img_path = Guid.NewGuid() + Path.GetExtension(fu_billede.FileName);
                // Opret



                String UploadeMappe = Server.MapPath("~/Images/Albums/");

                //string Kategori = dd_type.SelectedItem.Text;
                String Lille = "Small";
                String Stor = "Large";
                String Filnavn = DateTime.Now.ToFileTime() + fu_billede.FileName;
                img_path = Filnavn;

                //Gem det orginale Billede
                fu_billede.SaveAs(UploadeMappe + Filnavn);

                // Definer hvordan
                ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 50;
                BilledeSkalering.Height = 50;

                //Udfør skalleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, UploadeMappe + "/" + Lille + "/" + Filnavn, BilledeSkalering);

                //Lav nogle nye skalerings instillinger
                BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 200;
                BilledeSkalering.Height = 200;


                //Udfør selve skaleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, UploadeMappe + "/" + Stor + "/" + Filnavn, BilledeSkalering);

                // Tildel parameter-værdierne, fra input felterne.
                //cmd.Parameters.AddWithValue("@b_sti", user_img);
                //int x = Convert.ToInt32("@p_id");
                //cmd.Parameters.Add("@pk_film_id", SqlDbType.Int).Value = x;
                string old_img = hf_billede.Value;
                if (File.Exists(Server.MapPath("../Images/Albums/") + old_img))
                {
                    File.Delete(Server.MapPath("../Images/Albums/") + old_img);
                }
                if (File.Exists(Server.MapPath("../Images/Albums/Small/") + old_img))
                {
                    File.Delete(Server.MapPath("../Images/Albums/Small/") + old_img);
                }
                if (File.Exists(Server.MapPath("../Images/Albums/Large/") + old_img))
                {
                    File.Delete(Server.MapPath("../Images/Albums/Large/") + old_img);
                }
                //if (File.Exists(Server.MapPath("~/billeder/plakater/large/") + old_img))
                //{
                //    File.Delete(Server.MapPath("~//billeder/plakater/large/") + old_img);
                //}
            }
            else
            {
                lbl_fejl.Text = "Du skal vælge et billede!";
            }
            cmd.Parameters.AddWithValue("@cover", img_path);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect(Request.RawUrl);
        }
    }
    
}