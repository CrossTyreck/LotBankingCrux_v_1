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

        }

        protected void butInsertLogin_Click(object sender, EventArgs e)
        {

            dbOjbect.insertBuilder(dbOjbect.insertLogin(tbUserName.Text, tbPassword.Text, Convert.ToInt32(DDLUserType.SelectedItem.Value), Convert.ToInt32(tbOptionMask.Text)), tbBuilderName.Text);

        }

        protected void DLLUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}