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