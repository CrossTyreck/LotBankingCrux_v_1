using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using LotBankingCrux_v_1.Crux;

namespace LotBankingCrux_v_1.CustomControls
{
    public class ProjectRowPanel : Panel
    {
        public Button RowButton { get; set; }
        public Label Builder { get; set; }
        public Label ModifiedDate { get; set; }
        public Label CreatedDate { get; set; }
        public int ProjectID { get; set; }
        public int BuilderID { get; set; }
        public Color LinkNameColor { get; set; }

        public ProjectRowPanel(int projid, string name, string url, string date, int builderid = 0)
        {
            ProjectID = projid;
            BuilderID = builderid;
            RowButton = new Button();
            RowButton.CssClass = "projectRowButton";
            RowButton.Text = "Project: " + name + "Date: " + date;
            RowButton.PostBackUrl = url + "?projectid=" + projid.ToString() + "&" + "builderid=" + builderid.ToString();

            Controls.Add(RowButton);

        }

        public void ProposalRowPanel(string name, string builder, DateTime requestedTime, DateTime submittedTime, string cssClass)
        {
            this.CssClass = cssClass;
        }


    }
}