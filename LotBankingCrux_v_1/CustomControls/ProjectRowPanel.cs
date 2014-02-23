using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace LotBankingCrux_v_1.CustomControls
{
    public class ProjectRowPanel : Panel
    {
        public LinkButton Name { get; set; }
        public Label ModifiedDate { get; set; }

        public ProjectRowPanel(string name, string url, DateTime date)
        {
            Name = new LinkButton();
            Name.Text = name;
            Name.PostBackUrl = url;

            ModifiedDate = new Label();
            ModifiedDate.Text = date.ToShortDateString();

            Controls.Add(Name);
            Controls.Add(ModifiedDate);
        }
    }
}