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
            TextBox txtUser = LoginForm.FindControl("UserName") as TextBox;
            if (!IsPostBack)
            {
                if (Request.Cookies["myCookie"] != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("myCookie");
                    LoginForm.UserName = cookie.Values["username"].ToString();
                    this.LoginForm.RememberMeSet = !(String.IsNullOrEmpty(LoginForm.UserName));
                    this.SetFocus(LoginForm.FindControl("Password"));
             
                }
                else
                {
                    this.SetFocus(txtUser);
                }
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {

            string userName = this.LoginForm.UserName.ToString();

            string passWord = this.LoginForm.Password.ToString();

            string route = "";

            int loginID = dbObject.login(userName, passWord);

            if (loginID > 0)
            {
                userData._userID = loginID;
                userData._userType = dbObject.getUserClassId(userData._userID);
                Session["UserData"] = userData;

                //Setup Remember me functionality
                ctlLogin_LoggedIN(sender, e);
                switch (((DataBucket)Session["UserData"])._userType)
                {
                    case 1:
                        route = "CBHDashboard";
                        Session["UserName"] = "Emily Leppert";
                        break;
                    case 2:
                        route = "Builder";
                        ((DataBucket)Session["UserData"])._userName = dbObject.getBuilderName(loginID);
                        ((DataBucket)Session["UserData"])._builderID = ((DataBucket)Session["UserData"])._userID;
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

        protected void ctlLogin_LoggedIN(object sender, EventArgs e)
        {
            CheckBox rm = (CheckBox)LoginForm.FindControl("RememberMe");
            if (rm.Checked)
            {
                HttpCookie myCookie = new HttpCookie("myCookie");
                Response.Cookies.Remove("myCookie");
                Response.Cookies.Add(myCookie);
                myCookie.Values.Add("username", this.LoginForm.UserName.ToString());
                DateTime dtExpiry = DateTime.Now.AddDays(15); //you can add years and months too here
                Response.Cookies["myCookie"].Expires = dtExpiry;
            }
            else
            {
                HttpCookie myCookie = new HttpCookie("myCookie");
                Response.Cookies.Remove("myCookie");
                Response.Cookies.Add(myCookie);
                myCookie.Values.Add("username", this.LoginForm.UserName.ToString());
                DateTime dtExpiry = DateTime.Now.AddSeconds(1); //you can add years and months too here
                Response.Cookies["myCookie"].Expires = dtExpiry;
            }
        }
    }
}