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
using System.Web.UI.DataVisualization.Charting;


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
                PopulateBuilderDropdown();
                CreateDataView();
                CreateBuilderDocumentsView();
                CreateProposalsView();
                CreateProjectsView();
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
        private void CreateBuilderDocumentsView()
        {
            ddlOrderBy.Items.Add("Builder");
            ddlOrderBy.Items.Add("Document Name");
            ddlOrderBy.Items.Add("Submission Date");
            ddlOrderBy.Items.Add("Approval Date");
            ddlOrderBy.Items.Add("Last Requested Date");

            Dictionary<int, String> lintBuilderIDs = dbObject.getBuilderIds();
            foreach (KeyValuePair<int, String> bID in lintBuilderIDs)
            {
                Dictionary<int, String[]> aBIDDocuments = dbObject.getBuilderDocumentsByBID(bID.Key, ddlOrderBy.SelectedValue.ToString());
            }
        }

        /// <summary>
        /// Bind data to Chart controls in Data view
        /// </summary>
        private void CreateDataView()
        {
            //Hard coding meter values, should use DB info
            meter1.Min = -10;
            meter1.Max = 150;
            meter1.Value = dbObject.RateOfReturn();
            meter1.OptimumRangeColor = Color.Red;
            meter1.WarningRangeColor = Color.Red;
            meter1.ActionRangeColor = Color.Red;
            meter1.Title = "Rate of Return";

            int sumcount;
            int totalcount;

            dbObject.LotsSoldOverTotal(out sumcount, out totalcount);

            meter2.Min = 0;
            meter2.Max = totalcount;
            meter2.Value = sumcount;
            meter2.OptimumRangeColor = Color.Blue;
            meter2.WarningRangeColor = Color.Blue;
            meter2.ActionRangeColor = Color.Blue;
            meter2.Title = "Lots Sold VS Total Lots";

            string[] xValues;
            double[] yValues;

            dbObject.BuilderProfitability(out xValues, out yValues);

            // Populate series data
            Chart1.Series["Default"]["PieLabelStyle"] = "Outside";
            Chart1.Series[0]["PieDrawingStyle"] = "Concave";
            Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
        }

        /// <summary>
        /// Shows a list of existing builder project proposals in the MultiView Panel. 
        /// The current design should have an object that displays the current builder
        /// then list out the proposals tied to that builder in a custom control, the 
        /// ProjectRowPanel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateProposalsView()
        {
            ddlOrderBy.Items.Add("Builder");
            ddlOrderBy.Items.Add("Document Name");
            ddlOrderBy.Items.Add("Submission Date");
            ddlOrderBy.Items.Add("Approval Date");
            ddlOrderBy.Items.Add("Last Requested Date");

            lstbxBuilders.DataSource = dbObject.getBuilderNameID();
            lstbxBuilders.DataTextField = "Builder Name";
            lstbxBuilders.DataValueField = "Builder Id";
            lstbxBuilders.DataBind();

            Dictionary<int, String> lintBuilderIDs = dbObject.getBuilderIds();
            foreach (KeyValuePair<int, String> bID in lintBuilderIDs)
            {
                Dictionary<int, String[]> aBIDProjects = dbObject.getProjectsByBID(bID.Key, ddlOrderBy.SelectedValue.ToString(), true, true);
                foreach (KeyValuePair<int, String[]> project in aBIDProjects)
                {
                    ProjectsPanel.Controls.Add(new ProjectRowPanel(project.Key, project.Value[0], "ProjectDashboard.aspx", project.Value[1], bID.Key));
                }
            }
        }

        /// <summary>
        /// Shows a list of existing builder projects in the MultiView Panel. 
        /// The current design should have an object that displays the current builder
        /// then list out the projects tied to that builder in a custom control, the 
        /// ProjectRowPanel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateProjectsView()
        {
            ddlOrderBy.Items.Add("Builder");
            ddlOrderBy.Items.Add("Project Name");
            ddlOrderBy.Items.Add("Submission Date");
            ddlOrderBy.Items.Add("Approval Date");
            ddlOrderBy.Items.Add("Last Requested Date");

            ProjectsPanel.Controls.Clear();

            Dictionary<int, String> lintBuilderIDs = dbObject.getBuilderIds();
            foreach (KeyValuePair<int, String> bID in lintBuilderIDs)
            {
                Dictionary<int, String[]> aBIDProjects = dbObject.getProjectsByBID(bID.Key, ddlOrderBy.SelectedValue.ToString(), true);
                foreach (KeyValuePair<int, String[]> project in aBIDProjects)
                {
                    ProjectsPanel.Controls.Add(new ProjectRowPanel(project.Key, project.Value[0], "ProjectDashboard.aspx", project.Value[1], bID.Key));
                }
            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        protected void PopulateBuilderDropdown()
        {
            if (ddlBuilders.Items.Count > 0)
            {
                ddlBuilders.Items.Clear();
            }

            Dictionary<int, string> bldrNames = dbObject.getBuilderIds();

            foreach (string bldrName in bldrNames.Values)
            {
                ddlBuilders.Items.Add(bldrName);
            }

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
       
        protected void Projects_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 1;
        }
        
        protected void Proposals_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 0;
        }
        
        protected void BuilderDocuments_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 2;
        }

        protected void Data_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 3;
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
                ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(project.Key, project.Value[1], "ProjectProposal.aspx", project.Value[2], int.Parse(project.Value[0])));
            }
        }

        protected void GoToBuilder(object sender, EventArgs e)
        {
            Response.Redirect("Builder.aspx?builderid=" + dbObject.getBuilderId(ddlBuilders.SelectedValue.ToString()));
        }
    }
}
