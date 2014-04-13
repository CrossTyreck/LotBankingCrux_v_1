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
        public Panel DragNDrop { get; set; }

        public UploadContainer(string content, int id = 0)
        {
            Panel pnlLabel = new Panel();
            Panel wrapPanel = new Panel();
            Panel pnlObject = new Panel();
            Label lblDropHere = new Label();
     
            DragNDrop = new Panel();

            lblDropHere.Text = "Drop Here OR Click Below";
            DragNDrop.CssClass = "drop_zone";
            DragNDrop.ID = "drop_zone "+ id.ToString();
            DragNDrop.Controls.Add(lblDropHere);
            DragNDrop.Attributes.Add("ondragover", "handleDragOver(event)");
            DragNDrop.Attributes.Add("ondrop", "handleDnDFileSelect(event)");

            pnlLabel.CssClass = "DD-label";
            pnlObject.CssClass = "DD-buttons";

            contentLabel = content;
            DocClassId = id;

            Content = new Label();
            Content.Text = contentLabel;

            wrapPanel.CssClass = "wrapPanel";

            BrowseButton = new FileUpload();
            BrowseButton.Attributes["style"] = "padding: 20px; opacity: 0.0; z-index: 1;";
            BrowseButton.Attributes["title"] = "Click to add file";

            BrowseImage = new Image();
            BrowseImage.ImageUrl = @"Images\DueDiligence\browse.png";
            BrowseImage.Attributes["style"] = "z-index: 0; height: 80px; margin-top: -67px;";

            SubmitDocs = new ImageButton();
            SubmitDocs.ImageUrl = @"Images\DueDiligence\successful_submit.png";

            DownloadButton = new ImageButton();
            DownloadButton.Attributes.Add("chris", DocClassId.ToString());
            DownloadButton.ImageUrl = @"Images\DueDiligence\download.png";


            pnlLabel.Controls.Add(Content);
           
            wrapPanel.Controls.Add(BrowseButton);
            wrapPanel.Controls.Add(BrowseImage);
            DragNDrop.Controls.Add(wrapPanel);
            pnlObject.Controls.Add(SubmitDocs);
            pnlObject.Controls.Add(DownloadButton);
        
            this.ID = id.ToString();
            Controls.Add(pnlLabel);
            Controls.Add(pnlObject);
            Controls.Add(DragNDrop);
           
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