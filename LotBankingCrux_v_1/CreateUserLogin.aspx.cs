using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.Crux;

namespace LotBankingCrux_v_1
{
    public partial class CreateUserLogin : System.Web.UI.Page
    {
        CruxDB dbOjbect = new CruxDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBuilderName.Visible = false;
            tbBuilderName.Visible = false;
        }

        protected void butInsertLogin_Click(object sender, EventArgs e)
        {
            int id = dbOjbect.insertLogin(tbUserName.Text, tbPassword.Text, Convert.ToInt32(DDLUserType.SelectedItem.Value), Convert.ToInt32(tbOptionMask.Text));
            if(DDLUserType.SelectedItem.Value.Equals("2"))
            {
                dbOjbect.insertBuilder(id, tbBuilderName.Text);
            }

        }

        protected void DLLUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLUserType.Text.Equals("2"))
            {
                lblBuilderName.Visible = true;
                tbBuilderName.Visible = true;
            }
            else
            {
                lblBuilderName.Visible = false;
                tbBuilderName.Visible = false;
            }
            
        }

    }
}