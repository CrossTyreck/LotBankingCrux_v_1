﻿using System;
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
        public CruxDB dbObject = new CruxDB();
        public DataBucket DBucket = new DataBucket();
        public CruxFileStream cfsFileStream = new CruxFileStream();
        List<object> files = new List<object>();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateBuilderResumeView();
            CreateMarketDueDiligenceView();
            CreateTransactionDocumentationView();

            ClientScript.RegisterArrayDeclaration("documents", "");
            this.ClientScript.GetPostBackEventReference(this, string.Empty);
            
            if (IsPostBack)
            {
                string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
                string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

                if (eventTarget == "btnSubmitFiles")
                {
                    Dictionary<int, string> documents = new Dictionary<int, string>();
                    string[] values = eventArgument.Split(new char[] { '|' }, eventArgument.Count<char>(t => t == '|'));
                    for (int i = 0; i < values.Length; i += 2)
                    {
                        documents.Add(Int32.Parse(values[i].Substring(eventArgument.LastIndexOf(' '))), values[i + 1]);
                    }
                }
                if (eventTarget == "DocClassID" && eventArgument.Contains("drop_zone"))
                {
                    ((DataBucket)Session["UserData"])._docClassId = Int32.Parse(eventArgument.Substring(eventArgument.LastIndexOf(' ')));
                    UploadFile_Click(sender, e);
                }
            }
            else if (Request.HttpMethod.Equals("POST"))
            {
                Console.Write("text");
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

        /// <summary>
        /// Creates the components for this view. Needs to be extended for each view. 
        /// </summary>
        private void CreateTransactionDocumentationView()
        {
            Label header = new Label();
            Panel TransactionViewDocumentation = new Panel();
            TransactionViewDocumentation.CssClass = "DD-uploadcontainer";
            TransactionViewDocumentation.ID = "pnlTransactionDocumentationView";
            TreeNode node;
            UploadContainer fileUpload;

            header.Text = "Transaction Documents";

            TransactionViewDocumentation.Controls.Add(header);

            Dictionary<int, string> dictDocClassIDName = dbObject.SelectIDName("id", "document_class_name", "Project_Document_Class");

            foreach (KeyValuePair<int, string> pair in dictDocClassIDName)
            {
               fileUpload = new UploadContainer(pair.Key + ". " + pair.Value, pair.Key);

                fileUpload.DownloadButton.Click += new ImageClickEventHandler(DownloadFile_Click);

                TransactionViewDocumentation.Controls.Add(fileUpload);
                node = new TreeNode(pair.Key + ". " + pair.Value);
                // TreeView1.Nodes.Add(node);
            }
            mviwDueDiligence.Views[2].Controls.Add(TransactionViewDocumentation);

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
            cfsFileStream.UploadFile(dbObject, (DataBucket)Session["UserData"], Request, Context, ((DataBucket)Session["UserData"])._docClassId);
        }

        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            cfsFileStream.DownloadFile(dbObject, (DataBucket)Session["UserData"], Int32.Parse((sender as WebControl).Attributes["chris"]));
        }
    }
}
