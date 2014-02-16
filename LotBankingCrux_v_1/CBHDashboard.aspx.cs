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
    
    public partial class CBHDashboard : System.Web.UI.Page
    {
        CruxDB dbObject = new CruxDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlBuilders.Visible = false;
            ddlNewProjects.Visible = false;

            //ddlBuilders.Items.Clear();
            //ddlNewProjects.Items.Clear();
            ddlBuilders.Items.Add("Select a Builder");
            ddlNewProjects.Items.Add("Select a Project");
            DataTable dtNames = new DataTable();
            dtNames.Clear(); 
            
            dtNames = dbObject.getBuilderNames();
         
            if (dtNames.Columns.Count > 0)
            {

                ddlBuilders.Visible = true;
                foreach (DataRow dr in dtNames.Rows)
                {
                    foreach (DataColumn dc in dtNames.Columns)
                    {
                        ddlBuilders.Items.Add(dr[dc].ToString());
                    }
                }
                ddlBuilders.DataBind();
            }
            
        }

        public void AddUser_OnClick(object sender, EventArgs e)
        {

            Response.Redirect("CreateUserLogin.aspx");

        }

        public void SelectBuilder_OnClick(object sender, EventArgs e)
        {

            Response.Redirect("ViewBuilderInfo.aspx");
        }

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

        public void DDLNewProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ProjectDashboard.aspx");

        }
    }
}