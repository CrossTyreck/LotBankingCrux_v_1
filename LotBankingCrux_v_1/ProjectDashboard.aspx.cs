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
            Dictionary<int, String[]> aBIDDocuments = dbObject.getProjectDocumentNames(int.Parse(Request.QueryString["projectid"]));
            foreach (KeyValuePair<int, String[]> doc in aBIDDocuments)
            {
                pnlProjectDocumentsTest.Controls.Add(new ProjectRowPanel(doc.Key, doc.Value[0], "ProjectDashboard.aspx", doc.Value[1]));
            }

            if (!this.IsPostBack)
            {
                if ((txtbxAccessToLiquidity.Text = dbObject.GetProjectValue(int.Parse(Request.QueryString["builderid"]))) == "")
                {
                    txtbxAccessToLiquidity.Text = "Insert Access to Liquidity data here and click submit.";
                }
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

        protected void btnSaveChng_Click(object sender, EventArgs e)
        {
            dbObject.SetProjectAccessLiquidity(txtbxAccessToLiquidity.Text, int.Parse(Request.QueryString["builderid"]));
        }
    }
}