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
       
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Login_Click(object sender, EventArgs e)
        {
        
            string userName = ((TextBox)LoginForm.FindControl("UserName")).Text;

            string passWord = ((TextBox)LoginForm.FindControl("Password")).Text;

            string route = "";

            int loginID = dbObject.login(userName, passWord);

            if (loginID > 0)
            {
                DataBucket.userID = loginID;
                DataBucket.userType = dbObject.getUserClassId(DataBucket.userID);
                
                switch (DataBucket.userType)
                {
                    case 1:
                        route = "CBHDashboard";
                        DataBucket.userName = "Emily Leppert";
                        break;
                    case 2:
                        route = "BuilderDashboard";
                        DataBucket.userName = dbObject.getBuilderName(DataBucket.userID);
                        break;
                    case 3:
                        route = "Investor";
                        DataBucket.userName = "Scrooge McDuck";
                        break;
                    default:
                        break;

                }
                //Assemble URL string here for proper redirect
                Response.Redirect(route + ".aspx");
            }
            else
            {
                LoginForm.FindControl("LoginErrorLabel").Visible = true;
            }


        }
    }
}