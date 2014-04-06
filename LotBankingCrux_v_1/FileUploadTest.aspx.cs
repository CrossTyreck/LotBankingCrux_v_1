using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotBankingCrux_v_1
{
    public partial class FileUploadTest : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.Equals("POST"))
            {
                UploadFile(sender, e);
            }
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            HttpFileCollection fileCollection = Request.Files;
            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile upload = fileCollection[i];
                string filename = "c:\\Test\\" + Path.GetFileName(upload.FileName);
                upload.SaveAs(filename);
            }
        }
    }
}