using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

namespace LotBankingCrux_v_1.CustomControls
{
    public class ProjectRowPanel : Panel
    {
        public LinkButton Name { get; set; }
        public Label ModifiedDate { get; set; }

        public ProjectRowPanel(string name, string url, String date)
        {
            this.CssClass = "projectrowpanel";
            Name = new LinkButton();
            Name.Text = name;
            Name.PostBackUrl = url;
           // Name.CssClass = ".Linkclass";
           // Name.BorderColor = Color.Aqua;
           // Name.BorderStyle = BorderStyle.Solid;

            ModifiedDate = new Label();
            ModifiedDate.Text = date;

            Controls.Add(Name);
            Controls.Add(ModifiedDate);
        }

        public void ProposalRowPanel(string name, string requestedTime)
        {
            
            

        }
    }
}