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
        public Image BrowseImage { get; set; }
        public ImageButton DownloadButton { get; set; }
        public ImageButton SubmitDocs { get; set; }
        public int DocClassId { get; set; }
        public CruxFileStream cfsFileStream { get; set; }
        public CruxDB DBObject { get; set; }

        public UploadContainer(string content, int id = 0)
        {
            Panel pnLabel = new Panel();
            Panel pnObject = new Panel();
            pnLabel.CssClass = "DD-label";
            pnObject.CssClass = "DD-buttons";
            
            contentLabel = content;
            DocClassId = id;

            Content = new Label();
            Content.Text = contentLabel;

            BrowseButton = new FileUpload();
            BrowseButton.Attributes["style"] = "opacity: 0.0; z-index: 0";

            BrowseImage = new Image();
            BrowseImage.ImageUrl = @"Images\DueDiligence\browse.png";
            BrowseImage.Attributes["style"] = "z-index: 1; border: none; padding: 0; background: none; display:block; background-color: #FF8000; padding: 10px; width: 70%; margin:10px auto; z-index:10; position:relative;";

            SubmitDocs = new ImageButton();
            SubmitDocs.ImageUrl = @"Images\DueDiligence\successful_submit.png";

            DownloadButton = new ImageButton();
            DownloadButton.ImageUrl = @"Images\DueDiligence\download.png";

            pnLabel.Controls.Add(Content);

            pnObject.Controls.Add(BrowseButton);
            pnObject.Controls.Add(BrowseImage);
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