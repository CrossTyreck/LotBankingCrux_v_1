using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.Crux;
using System.Data;

namespace LotBankingCrux_v_1
{
    public partial class ProjectDashboard : System.Web.UI.Page
    {
        CruxDB dbObject = new CruxDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlDocuments.Items.Add("Select Document");
            //load the list of documents that are available to the drop down list
            DataTable dtProjects = dbObject.getBuilderDocuments(6);
            if (dtProjects.Columns.Count > 0)
            {
                ddlDocuments.Visible = true;

                foreach (DataRow dr in dtProjects.Rows)
                {
                    foreach (DataColumn dc in dtProjects.Columns)
                    {
                        ddlDocuments.Items.Add(dr[dc].ToString());
                    }
                }
                ddlDocuments.DataBind();
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
    }
}