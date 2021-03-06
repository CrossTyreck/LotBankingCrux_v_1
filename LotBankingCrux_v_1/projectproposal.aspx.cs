﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotBankingCrux_v_1.Crux;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace LotBankingCrux_v_1
{
    public partial class ProjectProposal : System.Web.UI.Page
    {

        CruxDB dbObject = new CruxDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnAccept.Visible = false;
            btnDecline.Visible = false;
            InitControls(((DataBucket)Session["UserData"])._userType);
            UpdateMap();
        }

        protected void resetControls()
        {
            txtCardinal.Text = "";
            txtFirstStreet.Text = "";
            txtImprovementCosts.Text = "";
            txtNumberOfLots.Text = "";
            txtProjectName.Text = "";
            txtSecondStreet.Text = "";
            txtAcquisitionPrice.Text = "";
            lblRollPrice.Visible = false;
            txtbxRollPrice.Visible = false;

        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("CBHHome.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            CruxDB DBObject = new CruxDB();

            int numberLots = 0;// = Int32.Parse(txtNumberOfLots.Text);
            if (txtNumberOfLots.Text == "")
            {
            }
            else
            {
                numberLots = Int32.Parse(txtNumberOfLots.Text);
            }

            string locationNotes = "";

            decimal acquisitionPrice;

            decimal improvementCost;

            decimal.TryParse(txtAcquisitionPrice.Text, NumberStyles.Currency, NumberFormatInfo.InvariantInfo, out acquisitionPrice);
            decimal.TryParse(txtImprovementCosts.Text, NumberStyles.Currency, NumberFormatInfo.InvariantInfo, out improvementCost);

            try
            {
                if (((DataBucket)Session["UserData"])._userID > 0)
                {
                    //We need to add validation here, currently a user can enter an empty project
                    if (txtProjectName.Text == "" || txtFirstStreet.Text == "" || txtSecondStreet.Text == "" || txtCity.Text == "" || txtState.Text == "" || txtCardinal.Text == "" || txtAcquisitionPrice.Text == "" || txtImprovementCosts.Text == "")
                    {
                        lblDataInserted.Visible = true;
                        lblDataInserted.ForeColor = System.Drawing.Color.Red;
                        lblDataInserted.Text = "Please fill in all fields";
                    }
                    else
                    {
                        DBObject.insertProject(LotBankingCrux_v_1.Crux.CruxDB.dbID, txtProjectName.Text, txtFirstStreet.Text, txtSecondStreet.Text, txtCity.Text, txtState.Text, txtCardinal.Text, locationNotes, acquisitionPrice, improvementCost, numberLots);
                        lblDataInserted.Visible = true;
                        lblDataInserted.ForeColor = System.Drawing.Color.Green;
                        lblDataInserted.Text = "Data Inserted";
                    }                
                    }
                else
                    Response.Redirect("Login.aspx");

                

                if (dbObject.GetReqFinInfoChecked(((DataBucket)Session["UserData"])._userID) > 0)
                {
                    lblAddInfoReq.Visible = true;
                }

                resetControls();
            }
            catch (MySqlException ex)
            {
                lblDataInserted.Text = ex.Message;
            }
            //else
            //{
            //    DataInserted.ForeColor = System.Drawing.Color.Red;
            //    DataInserted.Text = "Error!";
            //    DataInserted.Visible = true;
            //}
        }

        void InitControls(int userType)
        {
            switch (userType)
            {
                case 1:
                    SetAssociatePage();
                    break;
                case 2:
                    SetBuilderPage();
                    break;
                default:
                    SetDefaultPage();
                    break;
            }
        }

        /// <summary>
        /// Initialize controls for the builder so they can submit proposals
        /// </summary>
        void SetBuilderPage()
        {
            Project proposal;

            if ((Request.QueryString["projectid"] != null) && ((proposal = dbObject.getProposal(Int32.Parse(Request.QueryString["projectid"].ToString()))) != null))
            {
                txtProjectName.Text = proposal.getProjectName();
                txtFirstStreet.Text = proposal.getFirstCrossStreet();
                txtSecondStreet.Text = proposal.getSecondCrossStreet();
                txtCity.Text = proposal.getCity();
                txtState.Text = proposal.getState();
                txtCardinal.Text = proposal.getCardinal();
                //txtNumberOfLots.Text = proposal.get
                txtImprovementCosts.Text = proposal.getImprovementCost().ToString();
                txtAcquisitionPrice.Text = proposal.getAquisitionPrice().ToString();
            }
        }

        /// <summary>
        /// Initialize controls for the associate to be able to view proposal and 
        /// approve, request additional requirement, reject proposal
        /// </summary>
        void SetAssociatePage()
        {
            Project proposal;

            if ((Request.QueryString["projectid"] != null) && ((proposal = dbObject.getProposal(Int32.Parse(Request.QueryString["projectid"].ToString()))) != null))
            {
                txtProjectName.Text = proposal.getProjectName();
                txtFirstStreet.Text = proposal.getFirstCrossStreet();
                txtSecondStreet.Text = proposal.getSecondCrossStreet();
                txtCity.Text = proposal.getCity();
                txtState.Text = proposal.getState();
                txtCardinal.Text = proposal.getCardinal();
                //txtNumberOfLots.Text = proposal.get
                txtImprovementCosts.Text = proposal.getImprovementCost().ToString();
                txtAcquisitionPrice.Text = proposal.getAquisitionPrice().ToString();
                btnAccept.Visible = true;
                btnDecline.Visible = true;
                btnSubmit.Visible = false;
                lblRollPrice.Visible = true;
                txtbxRollPrice.Visible = true;

            }
        }

        /// <summary>
        /// User has no id so route them to Login
        /// </summary>
        void SetDefaultPage()
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnCheckLocation_Click(object sender, EventArgs e)
        {
            UpdateMap();

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            dbObject.acceptProposal(Int32.Parse(Request.QueryString["projectid"].ToString()), ((DataBucket)Session["UserData"])._userID, int.Parse(txtbxRollPrice.Text));
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            dbObject.declineProposal(Int32.Parse(Request.QueryString["projectid"].ToString()), ((DataBucket)Session["UserData"])._userID);
        }

        private void UpdateMap()
        {
            string firstStreet = "";
            string secondStreet = "";

            if (txtFirstStreetSuffix.SelectedItem.Text != "Select")
                firstStreet = txtFirstStreet.Text + " " + txtFirstStreetSuffix.SelectedItem.Text;
            else
                firstStreet = txtFirstStreet.Text;

            if (txtSecondStreetSuffix.SelectedItem.Text != "Select")
                secondStreet = txtSecondStreet.Text + " " + txtSecondStreetSuffix.SelectedItem.Text;
            else
                secondStreet = txtSecondStreet.Text;

            string cityLocation = txtCity.Text;
            string stateLocation = txtState.Text;

            mapImage.Attributes["src"] = ResolveUrl("http://maps.googleapis.com/maps/api/staticmap?center=" + firstStreet + "%26" + secondStreet + "," + cityLocation + "," + stateLocation + "&zoom=16&size=600x600&maptype=roadmap&markers=color:blue%7C" + firstStreet + "%26" + secondStreet + "," + cityLocation + "," + stateLocation + "&sensor=false");
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Globalization;
//using LotBankingCrux_v_1.Crux;
//using MySql.Data.MySqlClient;

//namespace LotBankingCrux_v_1
//{
//    public partial class projectproposal : System.Web.UI.Page
//    {
//  

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            //tbProjectName.Text = DataBucket.userName;
//        }

//        protected void Button2_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("CBHHome.aspx");
//        }

//        protected void Button1_Click(object sender, EventArgs e)
//        {

//            DataInserted.ForeColor = System.Drawing.Color.Green;
//            DataInserted.Text = "Data Inserted";
//            LotBankingCrux_v_1.Crux.CruxDB DBObject = new LotBankingCrux_v_1.Crux.CruxDB();

//            int numberLots = DropDownList1.SelectedIndex;

//            string locationNotes = "";

//            decimal acquisitionPrice;

//            decimal improvementCost;

//            decimal.TryParse(TextBox4.Text, NumberStyles.Currency, NumberFormatInfo.InvariantInfo, out acquisitionPrice);
//            decimal.TryParse(TextBox5.Text, NumberStyles.Currency, NumberFormatInfo.InvariantInfo, out improvementCost);

//            try
//            {
//                if (DataBucket.userID > 0)
//                    //We need to add validation here, currently a user can enter an empty project
//                    DBObject.insertPoject(LotBankingCrux_v_1.Crux.CruxDB.dbID, tbProjectName.Text, FirstStreet.Text, SecondStreet.Text, Cardinal.Text, locationNotes, acquisitionPrice, improvementCost, numberLots);
//                else
//                    Response.Redirect("Login.aspx");

//                DataInserted.Visible = true;
//                resetControls();
//            }
//            catch (MySqlException ex)
//            {
//                DataInserted.Text = ex.Message;

//            }
//            //else
//            //{
//            //    DataInserted.ForeColor = System.Drawing.Color.Red;
//            //    DataInserted.Text = "Error!";
//            //    DataInserted.Visible = true;
//            //}
//        }

//        public void Welcome_OnClick(object sender, EventArgs e)
//        {

//            String route = "";

//            if (DataBucket.userID > 0)
//            {
//                switch (DataBucket.userType)
//                {
//                    case 1:
//                        route = "CBHDashboard";
//                        DataBucket.userName = "Emily Leppert";
//                        break;
//                    case 2:
//                        route = "Builder";
//                        DataBucket.userName = "Fulton Homes";
//                        break;
//                    case 3:
//                        route = "Investor";
//                        DataBucket.userName = "Scrooge McDuck";
//                        break;
//                    default:
//                        break;

//                }
//                //Assemble URL string here for proper redirect
//                Response.Redirect(route + ".aspx");
//            }
//            else
//            {
//                Response.Redirect("Login.aspx");
//            }




//        }
//    }
//}
