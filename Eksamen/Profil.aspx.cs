using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            if (!IsPostBack)
            {


                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand cmd = new SqlCommand(@"SELECT * FROM users WHERE userId = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", Session["userId"]);

                conn.Open();
                repeater_info.DataSource = cmd.ExecuteReader();
                repeater_info.DataBind();
                conn.Close();

                cmd.CommandText = @"SELECT * FROM orders
                                    INNER JOIN albums
                                    on orders.fk_albumId = albums.albumId WHERE fk_userId = @Id ORDER BY orderDate";
                cmd.Parameters.AddWithValue("@Id", Session["userId"]);
                conn.Open();
                repeater_latests.DataSource = cmd.ExecuteReader();
                repeater_latests.DataBind();
                conn.Close();
                btn_retProfil.Visible = true;
            }
        }
        else
        {
            lbl_fejl.Text = "Du skal være logget ind for at få vist noget info her";
        }


    }
    protected void btn_retProfil_Click(object sender, EventArgs e)
    {

        panel_ret.Visible = true;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"SELECT * FROM users WHERE userId = @userId";

        cmd.Parameters.AddWithValue("@userId", Session["userId"]);



        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            tb_name.Text = reader["userName"].ToString();
            tb_email.Text = reader["userEmail"].ToString();
            hf_billede.Value = reader["userImg"].ToString();
            tb_beskri.Text = reader["userDescription"].ToString();


        }
        conn.Close();

    }
    protected void btn_gem_Click(object sender, EventArgs e)
    {
        gem();
        lbl_fejl.Text = "Din information er nu opdateret";
    }
    private void gem()
    {
        if (tb_name.Text == "" || tb_email.Text == "" || tb_beskri.Text == "")
        {
            lbl_fejl2.Text = "Du skal udfylde alle felterne!";
        }
        else
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            string img_path = hf_billede.Value;
            if (fu_billede.HasFile)
            {
                //NewGuid danner uniq navn for billeder
                img_path = Guid.NewGuid() + Path.GetExtension(fu_billede.FileName);
                // Opret



                String UploadeMappe = Server.MapPath("~/Images/Users/");

                //string Kategori = dd_type.SelectedItem.Text;
                String Lille = "Scaled";
                //String Stor = "Large";
                String Filnavn = DateTime.Now.ToFileTime() + fu_billede.FileName;
                img_path = Filnavn;

                //Gem det orginale Billede
                fu_billede.SaveAs(UploadeMappe + Filnavn);

                // Definer hvordan
                ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 200;


                //Udfør skalleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, UploadeMappe + "/" + Lille + "/" + Filnavn, BilledeSkalering);

                //Lav nogle nye skalerings instillinger
                BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 65;

                // Tildel parameter-værdierne, fra input felterne.
                //cmd.Parameters.AddWithValue("@b_sti", user_img);
                //int x = Convert.ToInt32("@p_id");
                //cmd.Parameters.Add("@pk_film_id", SqlDbType.Int).Value = x;
                string old_img = hf_billede.Value;
                if (File.Exists(Server.MapPath("~/Images/Users/") + old_img))
                {
                    File.Delete(Server.MapPath("~/Images/Users/") + old_img);
                }
                if (File.Exists(Server.MapPath("~/Images/Users/Scaled/") + old_img))
                {
                    File.Delete(Server.MapPath("~/Images/Users/Scaled/") + old_img);
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

            cmd.CommandText = @" UPDATE users SET userName = @name, userDescription = @descri, userImg = @img, userEmail = @email
                                            WHERE userId = @userId";


            cmd.Parameters.AddWithValue("@userid", Session["userId"]);
            cmd.Parameters.AddWithValue("@name", tb_name.Text);
            cmd.Parameters.AddWithValue("@descri", tb_beskri.Text);
            cmd.Parameters.AddWithValue("@email", tb_email.Text);
            cmd.Parameters.AddWithValue("@img", img_path);

            if (tb_pass.Text != "")
            {
                cmd.CommandText = @"UPDATE users
                                            SET userName = @name, userDescription = @descri, userImg = @img, userEmail = @email, userPassword = @password
                                            WHERE userId = @userId";
                cmd.Parameters.AddWithValue("@password", tb_pass.Text);
            }






            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect(Request.RawUrl);
        }
    }

}