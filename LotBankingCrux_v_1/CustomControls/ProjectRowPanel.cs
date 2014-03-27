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
        public LinkButton Name { get; set; }
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
            Name = new LinkButton();
            Name.Text = name;
            Name.PostBackUrl = url + "?projectid=" + projid.ToString() + "&" + "builderid=" + builderid.ToString();


            // Name.BorderColor = Color.Aqua;
            // Name.BorderStyle = BorderStyle.Solid;

            ModifiedDate = new Label();
            ModifiedDate.Text = date;

            Controls.Add(Name);
            Controls.Add(ModifiedDate);
        }

        public void ProposalRowPanel(string name, string builder, DateTime requestedTime, DateTime submittedTime, string cssClass)
        {
            this.CssClass = cssClass;
        }


    }
}