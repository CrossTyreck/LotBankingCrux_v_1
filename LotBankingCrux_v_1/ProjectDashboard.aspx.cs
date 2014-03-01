using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.Crux;
using LotBankingCrux_v_1.CustomControls;
using System.Data;

namespace LotBankingCrux_v_1
{
    public partial class ProjectDashboard : System.Web.UI.Page
    {
        CruxDB dbObject = new CruxDB();


        protected void Page_Load(object sender, EventArgs e)
        {
            List<String> aBIDDocuments = dbObject.getProjectDocuments(((DataBucket)Session["UserData"])._userID);
            foreach (String doc in aBIDDocuments)
            {
                pnlProjectDocumentsTest.Controls.Add(new ProjectRowPanel(doc, "ProjectDashboard.aspx", DateTime.Now));
            }
        }

        protected void LotTakeDown_OnClick(object sender, EventArgs e)
        {
            //Link to the takedown page based on the project we are on
            Response.Redirect("");
        }

        //This method should be used to download or view documents that are selected
        protected void DDLDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void DueDiligence_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("DueDiligence.aspx");

        }
    }
}