using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

namespace CustomFileDownloader
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    string pw = "ogre";
                    string dlPath = "down";
                    string appPath = "cdl";
                    string url = string.Format("http://www.13x17.com/{0}/{1}/", appPath, dlPath);

                    if (pw == TextBox3.Text)
                    {
                        string path = Server.MapPath("~");
                        path += path.EndsWith(Path.DirectorySeparatorChar.ToString()) ? string.Empty : Path.DirectorySeparatorChar.ToString();
                        path += dlPath + Path.DirectorySeparatorChar.ToString();

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        WebClient client = new WebClient();
                        client.DownloadFile(TextBox1.Text, path + TextBox2.Text);
                        client.Dispose();

                        Response.Write("your url is: " + url + TextBox2.Text);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message.ToString());
                }
                finally
                {
                }
            }
        }
    }
}
