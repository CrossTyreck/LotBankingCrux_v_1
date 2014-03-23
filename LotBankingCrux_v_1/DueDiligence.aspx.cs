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

        protected void UploadFile_Click(object sender, EventArgs e)
        {
            //cfsFileStream.UploadFile((sender as FileUpload).PostedFile.FileName, sender as FileUpload, DBObject, (DataBucket)Session["UserData"], Request, Context);
            cfsFileStream.UploadFile(DBObject, (DataBucket)Session["UserData"], Request, Context);
        }


    }
}