using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotBankingCrux_v_1
{
    public partial class AcceptProposals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CBHDashboard_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/CBHDashboard.aspx");
        }
    }
}