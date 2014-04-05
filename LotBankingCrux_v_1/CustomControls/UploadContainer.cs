using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.CustomControls;
using LotBankingCrux_v_1.Crux;

namespace LotBankingCrux_v_1.CustomControls
{

    public class UploadContainer : Panel
    {

        private string contentLabel = String.Empty;
        public Label Content { get; set; }
        public FileUpload BrowseButton { get; set; }
        public Button DownloadButton { get; set; }
        public Button SubmitDocs { get; set; }
        public int DocClassId { get; set; }
        public CruxFileStream cfsFileStream { get; set; }
        public CruxDB DBObject { get; set; }

        public UploadContainer(string content, int id = 0)
        {
            Panel pnLabel = new Panel();
            Panel pnObject = new Panel();
            
            contentLabel = content;
            DocClassId = id;

            Content = new Label();
            Content.Text = contentLabel;

            BrowseButton = new FileUpload();

            SubmitDocs = new Button();
            SubmitDocs.Text = "Submit Documents";

            DownloadButton = new Button();
            DownloadButton.Text = "Download";

            pnLabel.Controls.Add(Content);

            pnObject.Controls.Add(BrowseButton);
            pnObject.Controls.Add(SubmitDocs);
            pnObject.Controls.Add(DownloadButton);
            
            Controls.Add(pnLabel);
            Controls.Add(pnObject);
        }

        /// <summary>
        /// Used for uploading documents in Due Diligence. 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="browseButton"></param>
        /// <param name="submitFile"></param>
        /// 
        /*protected override void CreateChildControls()
        {

            Content = new Label();
            Content.Text = contentLabel;

            BrowseButton = new FileUpload();

            SubmitDocs = new Button();
            SubmitDocs.Text = "Submit Documents";
            

           
            DownloadButton = new Button();
            DownloadButton.Text = "Download";

            Controls.Add(Content);
            Controls.Add(BrowseButton);
            Controls.Add(SubmitDocs);
            Controls.Add(DownloadButton);

        }*/

        //protected void UploadFile_Click(object sender, EventArgs e)
        //{
        //    //cfsFileStream.UploadFile((sender as FileUpload).PostedFile.FileName, sender as FileUpload, DBObject, (DataBucket)Session["UserData"], Request, Context);
        //    cfsFileStream.UploadFile(DBObject, (DataBucket)Session["UserData"], Request, Context);
        //}

    }

}