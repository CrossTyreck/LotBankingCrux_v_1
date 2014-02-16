using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotBankingCrux_v_1
{
    public partial class Builder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectDashboard.Visible = false;
            /*Dynamically set builder image:
             * Get builder name by id, query server for builder image URL
             * add that URL to the ImageURL below. 
            imgBuilderLogo.ImageUrl = "~/Images/heroAccent.png"; */
           
        }

        protected void BuilderProposal_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ProjectProposal.aspx");

        }

        //What project are we accessing
        protected void BuilderProposal_SelectedIndex(object sender, EventArgs e)
        {
            //create the link to the right project
            ProjectDashboard.Visible = true;
            ProjectDashboard.Text = BuilderProposal.Text;
        }

        //redirect to the right project
        protected void ProjectDashboard_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(BuilderProposal.Text + ".aspx");
        }
    }

}