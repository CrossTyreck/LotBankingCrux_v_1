using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.Crux;
using LotBankingCrux_v_1.CustomControls;
using System.Data;
using System.Drawing;


namespace LotBankingCrux_v_1
{

    public partial class CBHDashboard : System.Web.UI.Page
    {
        CruxDB dbObject = new CruxDB();
        public Meter meter1 = new Meter();
        public Meter meter2 = new Meter();
        public Meter meter3 = new Meter();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Hard coding meter values, should use DB info
            meter1.Min = 0;
            meter1.Max = 10000;
            meter1.Value = 7500;
            meter1.OptimumRangeColor = Color.Red;
            meter1.WarningRangeColor = Color.Red;
            meter1.ActionRangeColor = Color.Red;

            meter2.Min = 0;
            meter2.Max = 3252;
            meter2.Value = 820;
            meter2.OptimumRangeColor = Color.Blue;
            meter2.WarningRangeColor = Color.Blue;
            meter2.ActionRangeColor = Color.Blue;

            meter3.Min = 0;
            meter3.Max = 500;
            meter3.Value = 450;
            meter3.OptimumRangeColor = Color.Green;
            meter3.WarningRangeColor = Color.Green;
            meter3.ActionRangeColor = Color.Green;
            ddlOrderBy.Items.Clear();
        }

        /// <summary>
        /// This allows the Associate to add a user to the website. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddUser_OnClick(object sender, EventArgs e)
        {

            Response.Redirect("CreateUserLogin.aspx");

        }

        /// <summary>
        /// Shows a list of existing builder projects in the MultiView Panel. 
        /// The current design should have an object that displays the current builder
        /// then list out the projects tied to that builder in a custom control, the 
        /// ProjectRowPanel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Projects_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 1;

            ddlOrderBy.Items.Add("Builder");
            ddlOrderBy.Items.Add("Project Name");
            ddlOrderBy.Items.Add("Submission Date");
            ddlOrderBy.Items.Add("Approval Date");
            ddlOrderBy.Items.Add("Last Requested Date");

            Dictionary<int, String> lintBuilderIDs = dbObject.getBuilderIds();
            foreach (KeyValuePair<int, String> bID in lintBuilderIDs)
            {
                Dictionary<int, String[]> aBIDProjects = dbObject.getProjectsByBID(bID.Key, ddlOrderBy.SelectedValue.ToString(), true);
                foreach (KeyValuePair<int, String[]> project in aBIDProjects)
                {
                    ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(project.Key, project.Value[0], "ProjectDashboard.aspx", project.Value[1]));
                }
            }
        }

        /// <summary>
        /// Shows a list of existing builder project proposals in the MultiView Panel. 
        /// The current design should have an object that displays the current builder
        /// then list out the proposals tied to that builder in a custom control, the 
        /// ProjectRowPanel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Proposals_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 0;

            ddlOrderBy.Items.Add("Builder");
            ddlOrderBy.Items.Add("Document Name");
            ddlOrderBy.Items.Add("Submission Date");
            ddlOrderBy.Items.Add("Approval Date");
            ddlOrderBy.Items.Add("Last Requested Date");

            lstbxBuilders.DataSource = dbObject.getBuilderNameID();
            lstbxBuilders.DataTextField = "Builder Name";
            lstbxBuilders.DataValueField = "Builder Id";
            lstbxBuilders.DataBind();
        }

        /// <summary>
        /// Shows a list of existing builder documents in the MultiView Panel. 
        /// The current design should have an object that displays the current builder
        /// then list out the documents tied to that builder in a custom control, the 
        /// ProjectRowPanel. These are not project documents but rather documents that
        /// CBH specifically requests after a builder is registered in the system. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BuilderDocuments_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 2;

            ddlOrderBy.Items.Add("Builder");
            ddlOrderBy.Items.Add("Document Name");
            ddlOrderBy.Items.Add("Submission Date");
            ddlOrderBy.Items.Add("Approval Date");
            ddlOrderBy.Items.Add("Last Requested Date");

            Dictionary<int, String> lintBuilderIDs = dbObject.getBuilderIds();
            foreach (KeyValuePair<int, String> bID in lintBuilderIDs)
            {

                Dictionary<int, String[]> aBIDDocuments = dbObject.getBuilderDocumentsByBID(bID.Key, ddlOrderBy.SelectedValue.ToString());

                //foreach (Dictionary<int, string[]> doc in aBIDDocuments)
                //{
                //    ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(doc.getDocumentName(), "ProjectProposal.aspx", doc.getLastRequestedTime()));
                //}
            }
        }

        protected void DashboardView_ActiveViewChanged(object sender, EventArgs e)
        {

        }

        public int GetMeterValue()
        {
            return 50;

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {

            List<int> lintBuilderIDs = new List<int>();
            foreach (int item in lstbxBuilders.GetSelectedIndices())
            {
                lintBuilderIDs.Add(Int32.Parse(lstbxBuilders.Items[item].Value));
            }

            Dictionary<int, String[]> aBIDProjects = dbObject.getBuilderProjects(lintBuilderIDs, chkAwaitingApproval.Checked, chkAwaitingBuilderInfo.Checked, chkDeclined.Checked);
            foreach (KeyValuePair<int, String[]> project in aBIDProjects)
            {
                ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(project.Key, project.Value[0], "ProjectProposal.aspx", project.Value[1]));
            }

        }



    }
}
//protected void lnkbtnProposals_Click(object sender, EventArgs e)
//{
//    DashboardView.ActiveViewIndex = 0;


//    Dictionary<int, String[]> aBIDProjects = dbObject.getProposalsByBID(((DataBucket)Session["UserData"])._builderID, "", false);
//    foreach (KeyValuePair<int, String[]> project in aBIDProjects)
//    {
//        ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(project.Key, project.Value[0], "ProjectProposal.aspx", project.Value[1]));
//    }
//}

//protected void lnkbtnProjects_Click(object sender, EventArgs e)
//{
//    DashboardView.ActiveViewIndex = 1;

//    Dictionary<int, String[]> aBIDProjects = dbObject.getProjectsByBID(((DataBucket)Session["UserData"])._builderID, "", true);
//    foreach (KeyValuePair<int, String[]> project in aBIDProjects)
//    {
//        ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(project.Key, project.Value[0], "ProjectDashboard.aspx", project.Value[1]));
//    }
//}

//protected void lnkbtnBuilderDocuments_Click(object sender, EventArgs e)
//{
//    DashboardView.ActiveViewIndex = 2;


//    Dictionary<int, String[]> aBIDDocuments = dbObject.getBuilderDocumentsByBID(((DataBucket)Session["UserData"])._builderID, "");
//    foreach (KeyValuePair<int, String[]> doc in aBIDDocuments)
//    {
//        ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(doc.Key, doc.Value[0], "ProjectProposal.aspx", doc.Value[1]));
//    }
//}