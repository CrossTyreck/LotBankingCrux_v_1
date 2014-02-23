using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.Crux;

namespace LotBankingCrux_v_1
{

    public partial class Restricted : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        //This is the only function that was changed from SiteMaster to Restricted
        protected virtual void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserData"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            
        }

        public void Welcome_OnClick(object sender, EventArgs e)
        {

            String route = "";

            if (((DataBucket)Session["UserData"])._userID > 0)
            {
                switch (((DataBucket)Session["UserData"])._userType)
                {
                    case 1:
                        route = "CBHDashboard";
                        ((DataBucket)Session["UserData"])._userName = "Emily Leppert";
                        break;
                    case 2:
                        route = "Builder";
                        ((DataBucket)Session["UserData"])._userName = "Fulton Homes";
                        break;
                    case 3:
                        route = "Investor";
                        ((DataBucket)Session["UserData"])._userName = "Scrooge McDuck";
                        break;
                    default:
                        break;

                }
                //Assemble URL string here for proper redirect
                Response.Redirect(route + ".aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
           



        }

        public void Logout_OnClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}