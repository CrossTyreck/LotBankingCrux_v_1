using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.Crux;

namespace LotBankingCrux_v_1.Account
{


    public partial class Login : Page
    {
        CruxDB dbObject = new CruxDB();
        DataBucket userData = new DataBucket();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginForm.LoginButtonStyle.CssClass = "loginbutton";
        }

        protected void Login_Click(object sender, EventArgs e)
        {

            string userName = ((TextBox)LoginForm.FindControl("UserName")).Text;

            string passWord = ((TextBox)LoginForm.FindControl("Password")).Text;

            string route = "";

            int loginID = dbObject.login(userName, passWord);

            if (loginID > 0)
            {
                userData._userID = loginID;
                userData._userType = dbObject.getUserClassId(userData._userID);
                Session["UserData"] = userData;

                switch (((DataBucket)Session["UserData"])._userType)
                {
                    case 1:
                        route = "CBHDashboard";
                        Session["UserName"] = "Emily Leppert";
                        break;
                    case 2:
                        route = "Builder";
                        ((DataBucket)Session["UserData"])._userName = dbObject.getBuilderName(loginID);

                        break;
                    case 3:
                        route = "Investor";
                        Session["UserName"] = "Scrooge McDuck";
                        break;
                    default:
                        break;

                }
                //Assemble URL string here for proper redirect
                Response.Redirect(route + ".aspx");
            }
        }

    }
}