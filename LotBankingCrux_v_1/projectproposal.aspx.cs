using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using LotBankingCrux_v_1.Crux;
using MySql.Data.MySqlClient;

namespace LotBankingCrux_v_1
{
    public partial class projectproposal : System.Web.UI.Page
    {
        protected void resetControls()
        {
            //tbProjectName.Text = DataBucket.userName;
            tbProjectName.Text = "";
            FirstStreet.Text = "";
            SecondStreet.Text = "";
            Cardinal.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownList1.SelectedIndex = -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //tbProjectName.Text = DataBucket.userName;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CBHHome.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DataInserted.ForeColor = System.Drawing.Color.Green;
            DataInserted.Text = "Data Inserted";
            LotBankingCrux_v_1.Crux.CruxDB DBObject = new LotBankingCrux_v_1.Crux.CruxDB();

            int numberLots = DropDownList1.SelectedIndex;

            string locationNotes = "";

            decimal acquisitionPrice;

            decimal improvementCost;

            decimal.TryParse(TextBox4.Text, NumberStyles.Currency, NumberFormatInfo.InvariantInfo, out acquisitionPrice);
            decimal.TryParse(TextBox5.Text, NumberStyles.Currency, NumberFormatInfo.InvariantInfo, out improvementCost);

            try
            {
                if (DataBucket.userID > 0)
                    //We need to add validation here, currently a user can enter an empty project
                    DBObject.insertPoject(LotBankingCrux_v_1.Crux.CruxDB.dbID, tbProjectName.Text, FirstStreet.Text, SecondStreet.Text, Cardinal.Text, locationNotes, acquisitionPrice, improvementCost, numberLots);
                else
                    Response.Redirect("Login.aspx");

                DataInserted.Visible = true;
                resetControls();
            }
            catch (MySqlException ex)
            {
                DataInserted.Text = ex.Message;

            }
            //else
            //{
            //    DataInserted.ForeColor = System.Drawing.Color.Red;
            //    DataInserted.Text = "Error!";
            //    DataInserted.Visible = true;
            //}
        }

        public void Welcome_OnClick(object sender, EventArgs e)
        {

            String route = "";

            if (DataBucket.userID > 0)
            {
                switch (DataBucket.userType)
                {
                    case 1:
                        route = "CBHDashboard";
                        DataBucket.userName = "Emily Leppert";
                        break;
                    case 2:
                        route = "Builder";
                        DataBucket.userName = "Fulton Homes";
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
                Response.Redirect("Login.aspx");
            }




        }
    }
}
