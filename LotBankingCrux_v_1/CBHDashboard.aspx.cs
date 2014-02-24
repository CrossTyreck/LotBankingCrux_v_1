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
    
    public partial class CBHDashboard : System.Web.UI.Page
    {
        CruxDB dbObject = new CruxDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ddlBuilders.Visible = false;
            //ddlNewProjects.Visible = false;
            //ddlBuilders.Items.Add("Select a Builder");
            //ddlNewProjects.Items.Add("Select a Project");

            //DataTable dtNames = new DataTable();
            //dtNames.Clear();
            //ddlBuilders.Items.Clear();

            //dtNames = dbObject.getBuilderNames();


            //if (dtNames.Columns.Count > 0)
            //{

            //    ddlBuilders.Visible = true;
            //    foreach (DataRow dr in dtNames.Rows)
            //    {
            //        foreach (DataColumn dc in dtNames.Columns)
            //        {
            //            ddlBuilders.Items.Add(dr[dc].ToString());
            //        }
            //    }
            //    ddlBuilders.DataBind();
            //}
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

        public void SelectBuilder_OnClick(object sender, EventArgs e)
        {

            Response.Redirect("ViewBuilderInfo.aspx");
        }


        /// <summary>
        /// Populates the Builders dropdown with a list of all builders
        /// So that the CBH Associate can select the correct builder
        /// Then a builder project and go to that specific project dashboard. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Obsolete("We no longer populate a dropdown list but display the projects by builder in a ProjectRowPanel, a custom control")]
        public void DDLBuilders_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DataTable dtProjects = dbObject.getProjects(dbObject.getBuilderId(ddlBuilders.SelectedValue.ToString()), 0);

            if (dtProjects.Columns.Count > 0)
            {
                ddlNewProjects.Visible = true;
                
                foreach (DataRow dr in dtProjects.Rows)
                {
                    foreach (DataColumn dc in dtProjects.Columns)
                    {
                        ddlNewProjects.Items.Add(dr[dc].ToString());
                    }
                }
                ddlNewProjects.DataBind();
            }
        }

        /// <summary>
        /// Once the Associate selects a specific builder they then can select a 
        /// specific project from the dropdown and this will take them to that specific
        /// project dashbored.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Obsolete("We no longer populate a dropdown list but display the projects by builder in a ProjectRowPanel, a custom control")]
        public void DDLNewProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ProjectDashboard.aspx");
            
        }

        /// <summary>
        /// Shows a list of existing builder project proposals in the MultiView Panel. 
        /// The current design should have an object that displays the current builder
        /// then list out the proposals tied to that builder in a custom control, the 
        /// ProjectRowPanel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ProjectProposals_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 0;

            List<int> lintBuilderIDs = dbObject.getBuilderId();
            
            foreach(int bID in lintBuilderIDs)
            {
                Project[] aBIDProjects = dbObject.getProjects(bID);
                foreach(Project project in aBIDProjects){
                    ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(project.getProjectName(), "ProjectProposal.aspx", project.getLastModified()));
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
        protected void ExistingProjects_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 1;

            List<int> lintBuilderIDs = dbObject.getBuilderId();
            foreach (int bID in lintBuilderIDs)
            {
                Project[] aBIDProjects = dbObject.getProjects(bID);
                foreach (Project project in aBIDProjects)
                {
                    ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(project.getProjectName(), "ProjectDashboard.aspx", project.getLastModified()));
                }
            }
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

            List<int> lintBuilderIDs = dbObject.getBuilderId();
            foreach (int bID in lintBuilderIDs)
            {
               BuilderDocumentData[] aBIDDocuments = dbObject.getBuilderDocumentData(bID);
                foreach (BuilderDocumentData doc in aBIDDocuments)
                {
                    ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(doc.getDocumentName(), "ProjectProposal.aspx", doc.getLastRequestedTime()));
                }
            }
        }

      
        protected void DashboardView_ActiveViewChanged(object sender, EventArgs e)
        {
           
        }
    }
}