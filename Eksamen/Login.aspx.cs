using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        cmd.CommandText = @"SELECT * FROM users WHERE
                            userEmail = @email
                            AND userPassword = @password";
        cmd.Parameters.AddWithValue("@email", tb_email.Text);
        cmd.Parameters.AddWithValue("@password", tb_password.Text);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Session["userId"] = reader["userId"];
            Session["roleId"] = reader["fk_roleId"];
           
            Response.Redirect("Default.aspx");

        }
        conn.Close();
    }

    protected void btn_opret_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        cmd.CommandText = @"INSERT INTO users (userName, userDescription, userImg, userEmail, userPassword) 
                                        VALUES (@name, @descri, @img, @email, @pass)";

        cmd.Parameters.AddWithValue("@name", tb_OPname.Text);
        cmd.Parameters.AddWithValue("@descri", tb_OPbeskri.Text);
        cmd.Parameters.AddWithValue("@email", tb_OPemail.Text);
        cmd.Parameters.AddWithValue("@pass", tb_OPpass.Text);
        
        string img_path = "intetbillede.jpg";

        //Hvis der er en fil i FilUploaden

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


            //Udfør selve skaleringen
            //ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe + Filnavn, BilledeSkalering);

        }
        // Tildel parameter-værdierne, fra input felterne.
        cmd.Parameters.AddWithValue("@img", img_path);



        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        Response.Redirect("Login.aspx");
    }

    protected void btn_visopret_Click(object sender, EventArgs e)
    {
        panel_opret.Visible = true;
    }
}