using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LotBankingCrux_v_1.Crux;
using LotBankingCrux_v_1.CustomControls;
using System.Text;

namespace LotBankingCrux_v_1
{
    public partial class DueDiligence : System.Web.UI.Page
    {
        CruxDB dbObject = new CruxDB();
        DataBucket DBucket = new DataBucket();
        CruxFileStream cfsFileStream = new CruxFileStream();

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateTransactionDocumentationView();
            CreateMarketDueDiligenceView();
            CreateBuilderResumeView();

        }

        protected void lnkbtnBuilderResume_Click(object sender, EventArgs e)
        {
            mviwDueDiligence.ActiveViewIndex = 0;
        }

        protected void lnkbtnMarketDueDiligence_Click(object sender, EventArgs e)
        {
            mviwDueDiligence.ActiveViewIndex = 1;
        }

        protected void lnkbtnTransactionDocumentation_Click(object sender, EventArgs e)
        {
            mviwDueDiligence.ActiveViewIndex = 2;
        }

        private void CreateTransactionDocumentationView()
        {
            Panel panel = new Panel();
            Label header = new Label();
            FileUploadButton fileUpload;
            header.Text = "Transaction Documents";
            panel.Controls.Add(header);
            Panel contentPanel = null;

            contentPanel = new Panel();
            contentPanel.Controls.Add(fileUpload = new FileUploadButton("1. Development Agreement"));
            fileUpload.SubmitDocs.Click += UploadFile_Click;
            panel.Controls.Add(contentPanel);

            contentPanel = new Panel();
            contentPanel.Controls.Add(new FileUploadButton("2. Entity Formation Documents"));
            panel.Controls.Add(contentPanel);

            //Add more Content Panels here

            if ((((DataBucket)Session["UserData"])._docClassId = dbObject.GetDocClassId(fileUpload.Content.Text.Substring(3, fileUpload.Content.Text.Length - 3))) <= 0)
            {
                ((DataBucket)Session["UserData"])._docClassId = 0;
            }



            mviwDueDiligence.Views[2].Controls.Add(panel);


        }

        private void CreateMarketDueDiligenceView()
        {
            Panel panel = new Panel();
            Label header = new Label();
            header.Text = "Market Due Diligence";
            panel.Controls.Add(header);
            mviwDueDiligence.Views[1].Controls.Add(panel);
        }

        private void CreateBuilderResumeView()
        {
            Panel panel = new Panel();
            Label header = new Label();
            header.Text = "Builder Resume";
            panel.Controls.Add(header);
            mviwDueDiligence.Views[0].Controls.Add(panel);
        }

        protected void UploadFile_Click(object sender, EventArgs e)
        {
            //cfsFileStream.UploadFile((sender as FileUpload).PostedFile.FileName, sender as FileUpload, DBObject, (DataBucket)Session["UserData"], Request, Context);
            cfsFileStream.UploadFile(dbObject, (DataBucket)Session["UserData"], Request, Context, ((DataBucket)Session["UserData"])._docClassId);
        }

    }
}