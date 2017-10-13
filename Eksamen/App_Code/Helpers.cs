using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

/// <summary>
/// Samling af små hjælpe funktioner
/// </summary>
public class Helpers
{
    /// <summary>
    /// Her sættes den "globale" connection string
    /// </summary>
    public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    /// <summary>
    /// Trim en string ned til en bestemt maksimum længde
    /// </summary>
    /// <param name="FullText">Den fulde tekst der skal klippes af</param>
    /// <param name="MaxLength">Antallet af tegn der skal trimmes ned til</param>
    /// <returns></returns>
    public static string EvalTrimmed(string FullText, int MaxLength)
    {
        // Teksten kan indeholde HTML tags, som ikke bør blive klippet over,
        // derfor fjernes alt der ligger imellem to <>
        FullText = Regex.Replace(FullText, "<.*?>", string.Empty);
        // hvis teksten stadig er længere end MaxLength
        if (FullText.Length > MaxLength)
        {
            // så returneres det ønskede antal tegn, plus tre ...
            return FullText.Substring(0, MaxLength - 3) + "..."; ;
        }
        // hvis teksten ikke er længere end MaxLength, returneres den den HTML frie tekst
        return FullText;
    }
    public static void RefreshRSSFeed(int category_id)
    {
        XmlDocument dom = new XmlDocument();
        string KanalNavn = "default_rssfeed.xml";
        XmlProcessingInstruction xpi = dom.CreateProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-9\"");
        dom.AppendChild(xpi);

        XmlElement rod = dom.CreateElement("rss");

        XmlElement channel = dom.CreateElement("channel");

        SqlConnection conn = new SqlConnection(Helpers.ConnectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM categories WHERE catId = @id", conn);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = category_id;
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            XmlElement channel_title = dom.CreateElement("title");
            channel_title.AppendChild(dom.CreateTextNode(reader["catName"].ToString()));
            channel.AppendChild(channel_title);

            KanalNavn = reader["catName"].ToString();

            XmlElement channel_link = dom.CreateElement("link");
            channel_link.AppendChild(dom.CreateTextNode("http://localhost:37412/Albums.aspx?category_id=" + reader["catId"].ToString()));
            channel.AppendChild(channel_link);
        }
        conn.Close();
        SqlCommand cmd_article = new SqlCommand("SELECT * FROM albums WHERE fk_catId = @id ORDER BY albumDate DESC", conn);
        cmd_article.Parameters.Add("@id", SqlDbType.Int).Value = category_id;
        conn.Open();
        SqlDataReader reader_article = cmd_article.ExecuteReader();
        while (reader_article.Read())
        {
            XmlElement items = dom.CreateElement("items");

            XmlElement article_title = dom.CreateElement("title");
            article_title.AppendChild(dom.CreateTextNode(reader_article["albumTitle"].ToString()));
            items.AppendChild(article_title);

            XmlElement article_description = dom.CreateElement("description");
            article_description.AppendChild(dom.CreateTextNode(reader_article["albumArtist"].ToString()));
            items.AppendChild(article_description);

            XmlElement item_link = dom.CreateElement("link"); 
            item_link.AppendChild(dom.CreateTextNode("http://localhost:37412/Albums.aspx?category_id=" + reader_article["fk_catId"].ToString() + "&albumId=" + reader_article["albumId"].ToString()));
            items.AppendChild(item_link);

            channel.AppendChild(items);
        }
        conn.Close();
        rod.AppendChild(channel);
        dom.AppendChild(rod);
        dom.Save(HttpContext.Current.Server.MapPath("~/rss/" + KanalNavn + ".xml"));
    }
}