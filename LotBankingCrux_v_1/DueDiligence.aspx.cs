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
        List<object> files = new List<object>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddFileForUpload(sender, e);
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
            CreateBuilderResumeView();
        }

        protected void lnkbtnMarketDueDiligence_Click(object sender, EventArgs e)
        {
            mviwDueDiligence.ActiveViewIndex = 1;
            CreateMarketDueDiligenceView();
        }

        protected void lnkbtnTransactionDocumentation_Click(object sender, EventArgs e)
        {
            mviwDueDiligence.ActiveViewIndex = 2;
            CreateTransactionDocumentationView();
        }

        /// <summary>
        /// Creates the components for this view. Needs to be extended for each view. 
        /// </summary>
        private void CreateTransactionDocumentationView()
        {

            Panel panel = new Panel();
            panel.CssClass = "DD-uploadcontainer";
            Label header = new Label();
            TreeNode node;
            UploadContainer fileUpload;
            header.Text = "Transaction Documents";
            panel.Controls.Add(header);
            Panel contentPanel1 = null;

            Dictionary<int, string> dictDocClassIDName = dbObject.SelectIDName("id", "document_class_name", "Project_Document_Class");

            foreach (KeyValuePair<int, string> pair in dictDocClassIDName)
            {
                contentPanel1 = new Panel();
                contentPanel1.Controls.Add(fileUpload = new UploadContainer(pair.Key + ". " + pair.Value, pair.Key));

                fileUpload.SubmitDocs.Click += UploadFile_Click;

                panel.Controls.Add(fileUpload);
                node = new TreeNode(pair.Key + ". " + pair.Value);
                TreeView1.Nodes.Add(node);
            }

            mviwDueDiligence.Views[2].Controls.Add(panel);

            //What was I doing here?
            //if ((((DataBucket)Session["UserData"])._docClassId = dbObject.GetDocClassId(fileUpload.Content.Text.Substring(3, fileUpload.Content.Text.Length - 3))) <= 0)
            //{
            //    ((DataBucket)Session["UserData"])._docClassId = 0;
            //}

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
            Dictionary<int, string> files = new Dictionary<int,string>();
            for (int i = 0; i < viwTransactionDocumentation.Controls.Count; i++)
            {
                
                UploadContainer panel = viwTransactionDocumentation.FindControl(i.ToString()) as UploadContainer;
                if (panel != null)
                    files[i] = (panel.DragNDrop.Controls[0] as Label).Text;
            }
            //cfsFileStream.UploadFile((sender as FileUpload).PostedFile.FileName, sender as FileUpload, DBObject, (DataBucket)Session["UserData"], Request, Context);
            cfsFileStream.UploadFile(dbObject, (DataBucket)Session["UserData"], Request, Context, ((DataBucket)Session["UserData"])._docClassId);
        }

        protected void AddFileForUpload(object sender, EventArgs e)
        {



        }

 

    }
}