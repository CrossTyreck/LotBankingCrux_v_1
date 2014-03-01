using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LotBankingCrux_v_1.CustomControls
{

    public class FileUploadButton : Panel
    {

        public Label Content { get; set; }
        public FileUpload BrowseButton { get; set; }
        public Button SubmitFile { get; set; }

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
            Content.Text = "Content to upload";

            BrowseButton = new FileUpload();

            SubmitFile = new Button();
            SubmitFile.Text = "Upload";

            Controls.Add(Content);
            Controls.Add(BrowseButton);
            Controls.Add(SubmitFile);

        }


    }
}