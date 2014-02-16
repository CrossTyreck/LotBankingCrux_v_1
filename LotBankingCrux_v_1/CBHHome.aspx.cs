using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotBankingCrux_v_1
{
    public partial class CBHHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        protected void DueDiligence_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("DueDiligence.aspx");
        }
        protected void NewBuilderProposal_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ProjectProposal.aspx");
        }

        protected void ProjectDashboard_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ProjectDashboard.aspx");
        }

    }
}