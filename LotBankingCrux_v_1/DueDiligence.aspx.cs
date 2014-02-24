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
        CruxDB DBObject = new CruxDB();
        DataBucket DBucket = new DataBucket();
        CruxFileStream cfsFileStream = new CruxFileStream();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Button1.Attributes.Add("onclick", "window.open('DueDiligence.aspx'),'', 'height=300,width=300);return false");
        }


        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {

        }

        protected void uploadButton1_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload1.PostedFile.FileName;
            cfsFileStream.UploadFile(filePath, FileUpload1, DBObject, Session["UserData"] as DataBucket, Request, Context);
            //documentSubmit(filePath);
        }

        protected void uploadButton2_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload2.PostedFile.FileName;
            documentSubmit(filePath);
        }
        protected void uploadButton3_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload3.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton4_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload4.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton5_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload5.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton6_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload6.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton7_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload7.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton8_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload8.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton9_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload9.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton10_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload10.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton11_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload11.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton12_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload12.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton13_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload13.PostedFile.FileName;
            documentSubmit(filePath);
        }
        protected void uploadButton14_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload14.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton15_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload15.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton16_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload16.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton17_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload17.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton18_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload18.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton19_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload19.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton20_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload20.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton21_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload21.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton22_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload22.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton23_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload23.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton24_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload24.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton25_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload25.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton26_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload26.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton27_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload27.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton28_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload28.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton29_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload29.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton30_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload30.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton31_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload31.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton32_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload32.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton33_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload33.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton34_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload34.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton35_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload35.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton36_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload36.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton37_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload37.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton38_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload38.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton39_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload39.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton40_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload40.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton41_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload41.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton42_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload42.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton43_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload43.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton44_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload44.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton45_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload45.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton46_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload46.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton47_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload47.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton48_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload48.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton49_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload49.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton50_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload50.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton51_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload51.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton52_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload52.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton53_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload53.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton54_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload54.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton55_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload55.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton56_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload56.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void uploadButton57_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload57.PostedFile.FileName;
            documentSubmit(filePath);
        }

        protected void documentSubmit(string pathName)
        {
            string filename = Path.GetFileName(pathName);
            string ext = Path.GetExtension(filename);
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
                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                // Might need to append file extension later (not sure)
                DBObject.insertProjectDocument(((DataBucket)Session["UserData"])._userID, filename, bytes);


            }
        }


        /// <summary>
        /// Currently a test button for submitting documents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void testRemove_Click(object sender, EventArgs e)
        {


        }


    }
}