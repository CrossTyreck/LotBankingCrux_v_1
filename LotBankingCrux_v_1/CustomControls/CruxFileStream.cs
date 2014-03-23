using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LotBankingCrux_v_1.Crux;
using System.Net;

namespace LotBankingCrux_v_1.CustomControls
{
    public class CruxFileStream
    {

        public void DownloadFile(HttpContext Context, string fileName, object sender, EventArgs e)
        {
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create("http://www.lotbanking.com/Downloads/" + fileName);
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            int bufferSize = 1;
            Context.Response.Clear();
            Context.Response.ClearHeaders();
            Context.Response.ClearContent();
            Context.Response.AppendHeader("Content-Disposition:", "attachment; filename=Sample.zip");
            Context.Response.AppendHeader("Content-Length", objResponse.ContentLength.ToString());
            Context.Response.ContentType = "application/download";
            byte[] byteBuffer = new byte[bufferSize + 1];
            MemoryStream memStrm = new MemoryStream(byteBuffer, true);
            Stream strm = objRequest.GetResponse().GetResponseStream();
            byte[] bytes = new byte[bufferSize + 1];
            while (strm.Read(byteBuffer, 0, byteBuffer.Length) > 0)
            {
                Context.Response.BinaryWrite(memStrm.ToArray());
                Context.Response.Flush();
            }
            Context.Response.Close();
            Context.Response.End();
            memStrm.Close();
            memStrm.Dispose();
            strm.Dispose();
        }


        /// <summary>
        /// Upload a file to the server. The intent is that a user will click a submit button 
        /// on the Due Diligence page. This will bring up a list of all the documents they have
        /// selected for upload for them to review. If they want to upload that list then they
        /// click another button. That button will call this function.
        /// </summary>
        /// <param name="pathName">Current location of the file you wish to upload</param>
        /// <param name="fs">File stream in which the file is located for uploading. example: FileUpload1.PostedFiles.InputStream</param>
        /// <param name="dbObject">Used to access the database</param>
        /// <param name="sesBucket">Current DataBucket that is in the Session variable</param>
        public Label UploadFile(CruxDB dbObject, DataBucket sesBucket, HttpRequest Request, HttpContext Context)
        {

            Label lblFileUploadStatus = new Label();
            HttpFileCollection multipleFiles = Request.Files;
            for (int fileCount = 0; fileCount < multipleFiles.Count; fileCount++)
            {
                string fileName = Path.GetFileName(multipleFiles[fileCount].FileName);
                string ext = Path.GetExtension(fileName);
                string contenttype = String.Empty;
             
                switch (ext)
                {
                    case ".doc":
                        contenttype = "application/vnd.ms-word";
                        break;
                    case ".docx":
                        contenttype = "application/vnd.ms-word";
                        break;
                    case ".xls":
                        contenttype = "application/vnd.ms-excel";
                        break;
                    case ".xlsx":
                        contenttype = "application/vnd.ms-excel";
                        break;
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".JPG":
                        contenttype = "image/JPG";
                        break;
                    case ".jpeg":
                        contenttype = "image/jpeg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                    case ".gif":
                        contenttype = "image/gif";
                        break;
                    case ".pdf":
                        contenttype = "application/pdf";
                        break;
                }
                if (contenttype != String.Empty)
                {
                    HttpPostedFile uploadedFile = multipleFiles[fileCount];

                    if (uploadedFile.ContentLength > 0)
                    {
                        Stream fs = uploadedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        // Might need to append file extension later (not sure)
                        dbObject.insertProjectDocument(sesBucket._userID, fileName, bytes);
                        //uploadedFile.SaveAs(Context.Server.MapPath("~/Files/") + fileName);
                        lblFileUploadStatus.Text += fileName + "Saved <BR>";
                    }
                }
            }

            return lblFileUploadStatus;
        }
    }
}