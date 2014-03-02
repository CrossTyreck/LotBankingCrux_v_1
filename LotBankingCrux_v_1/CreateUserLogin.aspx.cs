using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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

            lblUserAdded.Visible = true;

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

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            MailMessage mailObj = new MailMessage(
             txtEmailOrigin.Text, txtEmailDestination.Text, txtEmailSubject.Text, txtEmailContent.Text);
            SmtpClient SMTPServer = new SmtpClient("www.lotbanking.com");
            try
            {
                SMTPServer.Send(mailObj);
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
            }
        }

    }
}