﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.Crux;
using LotBankingCrux_v_1.CustomControls;

namespace LotBankingCrux_v_1
{
    public partial class Builder : System.Web.UI.Page
    {

        CruxDB dbObject = new CruxDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ProjectDashboard.Visible = false;
            /*Dynamically set builder image:
             * Get builder name by id, query server for builder image URL
             * add that URL to the ImageURL below. 
            imgBuilderLogo.ImageUrl = "~/Images/heroAccent.png"; */

            //Project[] aBIDProjects = dbObject.getProjects(((DataBucket)Session["UserData"])._userID);
            //foreach (Project project in aBIDProjects)
            //{
            //    pnlProjects.Controls.Add(new ProjectRowPanel(project.getProjectName(), "ProjectDashboard.aspx", project.getLastModified()));
            //}

            if (lnkbtnContactName.Text.Equals(""))
            {
                lnkbtnContactName.Text = "Click Here to Update";
            }

            if (lnkbtnContactNumber.Text.Equals(""))
            {
                lnkbtnContactNumber.Text = "Click Here to Update";
            }
        }


        protected void BuilderProposal_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ProjectProposal.aspx");

        }

        ////What project are we accessing
        //protected void BuilderProposal_SelectedIndex(object sender, EventArgs e)
        //{
        //    //create the link to the right project
        //    ProjectDashboard.Visible = true;
        //    ProjectDashboard.Text = BuilderProposal.Text;
        //}

        //redirect to the right project
        protected void ProjectDashboard_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(BuilderProposal.Text + ".aspx");
        }

        protected void DashboardView_ActiveViewChanged(object sender, EventArgs e)
        {

        }

        protected void lnkbtnProposals_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 0;


            Dictionary<int, String[]> aBIDProjects = dbObject.getProposalsByBID(((DataBucket)Session["UserData"])._builderID, "", false);
            foreach (KeyValuePair<int, String[]> project in aBIDProjects)
            {
                ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(project.Value[0], "ProjectProposal.aspx", project.Value[1]));
            }
         }

        protected void lnkbtnProjects_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 1;

            Dictionary<int, String[]> aBIDProjects = dbObject.getProjectsByBID(((DataBucket)Session["UserData"])._builderID, "", true);
            foreach (KeyValuePair<int, String[]> project in aBIDProjects)
            {
                ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(project.Value[0], "ProjectDashboard.aspx", project.Value[1]));
            }
        }

        protected void lnkbtnBuilderDocuments_Click(object sender, EventArgs e)
        {
            DashboardView.ActiveViewIndex = 2;


            Dictionary<int, String[]> aBIDDocuments = dbObject.getBuilderDocumentsByBID(((DataBucket)Session["UserData"])._builderID, "");
            foreach (KeyValuePair<int, String[]> doc in aBIDDocuments)
            {
                ProjectProposalsPanel.Controls.Add(new ProjectRowPanel(doc.Value[0], "ProjectProposal.aspx", doc.Value[1]));
            }
        }

        protected void lnkbtnContactName_Click(object sender, EventArgs e)
        {
            txtAddContactName.Visible = true;
            btnSubmitContact.Visible = true;
        }

        protected void lnkbtnContactNumber_Click(object sender, EventArgs e)
        {
            txtAddContactName.Visible = true;
            btnSubmitContact.Visible = true;
        }

        protected void btnSubmitContact_Click(object sender, EventArgs e)
        {
            //Add in the database connection that stores contact information here.
            txtAddContactName.Visible = false;
            txtAddContactName.Visible = false;
            btnSubmitContact.Visible = false;
        }
    }
}