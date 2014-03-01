using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace LotBankingCrux_v_1.CustomControls
{
    public class Meter
    {

        public float Value { get; set; }
        public Color valueColor { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public Color MinMaxColor { get; set; }
        public string title { get; set; }
        public Color titleColor { get; set; }
        public string Label { get; set; }
        public Color LabelColor { get; set; }
        public float GaugeWidthScale { get; set; }
        public Color GaugeBorderColor { get; set; }
        public float GaugeBorderWidth { get; set; }
        public Color GaugeShadowColor { get; set; }
        public float GaugeShadowScale { get; set; }
        public Color CanvasBackColor { get; set; }
        public Color GaugeBackColor { get; set; }
        public Color NeedleColor { get; set; }
        public int LowerActionLimit { get; set; }
        public int LowerWarningLimit { get; set; }
        public int UpperWarningLimit { get; set; }
        public int UpperActionLimit { get; set; }
        public Color OptimumRangeColor {get; set;}
        public Color WarningRangeColor {get; set;}
        public Color ActionRangeColor {get; set;}

        public String GenerateMeterScriptValues(string id, string name)
        {
            return
            " var " + name + " = new GaugeSVG({id: \"" + id +
            "\", value: " + Value +
            ", min: " + Min +
            ", max: " + Max +
            ", optimumRangeColor: \"#" + OptimumRangeColor.R.ToString("X2") + OptimumRangeColor.G.ToString("X2") + OptimumRangeColor.B.ToString("X2") + 
            "\", warningRangeColor: \"#" + WarningRangeColor.R.ToString("X2") + WarningRangeColor.G.ToString("X2") + WarningRangeColor.B.ToString("X2") +
            "\", actionRangeColor: \"#" + ActionRangeColor.R.ToString("X2") + ActionRangeColor.G.ToString("X2") + ActionRangeColor.B.ToString("X2") +
            "\", gaugeBorderColor: \"#" + GaugeBorderColor.R.ToString("X2") + GaugeBorderColor.G.ToString("X2") + GaugeBorderColor.B.ToString("X2") + 
            "\"});";

        }
    }
}