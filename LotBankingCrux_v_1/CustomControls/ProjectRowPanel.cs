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
        public Color LinkNameColor { get; set; }

        public ProjectRowPanel(int id, string name, string url, string date)
        {
            ProjectID = id;
            Name = new LinkButton();
            Name.Text = name;
            Name.PostBackUrl = url + "?projectid=" + id.ToString();


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