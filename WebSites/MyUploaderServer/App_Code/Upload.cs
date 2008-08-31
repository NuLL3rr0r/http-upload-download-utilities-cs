using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.IO;

/// <summary>
/// Summary description for Upload
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Upload : System.Web.Services.WebService {

    #region Global Variables

    private string path;

    #endregion

    public Upload () {
        Server.ScriptTimeout = 2147483647;

        path = Server.MapPath("~");
        //path += path.EndsWith(Path.DirectorySeparatorChar.ToString()) ? string.Empty : Path.DirectorySeparatorChar.ToString();

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region Upload

    [WebMethod]
    public string UploadChunk(string fileName, string upPath, byte[] buffer, long offset, bool forceMode, string login) {
        if (login != "HiLouis!")
            return "Illegal Access...";

        string res = string.Empty;

        try
        {
            string filePath = Path.Combine(path, upPath);
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            filePath = Path.Combine(filePath, fileName);

            if (offset == 0)
            {
                if (forceMode)
                    if (File.Exists(filePath))
                        File.Delete(filePath);

                if (File.Exists(filePath))
                {
                    FileInfo fi = new FileInfo(filePath);
                    return "{offset:" + fi.Length +"}";
                }

                File.Create(filePath).Close();
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                fs.Seek(offset, SeekOrigin.Begin);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }

            res = "OK!";
        }
        catch (Exception ex)
        {
            res = ex.Message;
        }

        return res;
    }

    #endregion
}

