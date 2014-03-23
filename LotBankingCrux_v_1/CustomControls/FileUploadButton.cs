using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LotBankingCrux_v_1.CustomControls
{

    public class FileUploadButton : Panel
    {

        private string contentLabel = String.Empty;
        public Label Content { get; set; }
        public FileUpload BrowseButton { get; set; }
        public Button DownloadButton { get; set; }
        public int DocClassId { get; set; }
        

        public FileUploadButton(string content, int id = 0)
        {
            contentLabel = content;
            DocClassId = id;
        }

        /// <summary>
        /// Used for uploading documents in Due Diligence. 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="browseButton"></param>
        /// <param name="submitFile"></param>
        /// 
        protected override void CreateChildControls()
        {

            Content = new Label();
            Content.Text = contentLabel;

            BrowseButton = new FileUpload();

            DownloadButton = new Button();
            DownloadButton.Text = "Download";

            Controls.Add(Content);
            Controls.Add(BrowseButton);
            Controls.Add(DownloadButton);

        }

    }

}