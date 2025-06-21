using System;

namespace Custom.ColorTable
{
    public class MyColorTable : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.FromArgb(100, 220, 220, 220);
            }
        }
        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.FromArgb(100, 220, 220, 220);
            }
        }
        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.FromArgb(100, 220, 220, 220);
            }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(100, 220, 220, 220);
            }
        }
        public override Color MenuBorder
        {
            get
            {
                return Color.WhiteSmoke;
            }
        }
        public override Color MenuItemBorder
        {
            get
            {
                return Color.WhiteSmoke;
            }
        }
        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(100, 220, 220, 220);
            }
        }
        public override Color MenuStripGradientBegin
        {
            get
            {
                return Color.FromArgb(100, 220, 220, 220);
            }
        }
        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.FromArgb(100, 220, 220, 220);
            }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(100, 80, 80, 80);
            }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(100, 80, 80, 80);
            }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(100, 220, 220, 220);
            }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(100, 220, 220, 220);
            }
        }
    }
}
