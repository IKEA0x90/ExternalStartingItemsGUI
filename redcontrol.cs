using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExternalStartingItemsGUI
{
    public partial class redcontrol : UserControl
    {
        public redcontrol()
        {
            InitializeComponent();
        }
        private void click_MouseClick(object sender, MouseEventArgs e)
        {
            string tooltip = GUI.ItemClick_MouseClick(sender, e);
            toolTip.SetToolTip(sender as Control, tooltip);
        }

        private void redcontrol_Load(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(PictureBox))
                {
                    toolTip.SetToolTip(control, file.createToolTip(control.Tag.ToString()));
                }
            }
        }
        private void tooltip_MouseEnter(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            PictureBox item = sender as PictureBox;
            toolTip.SetToolTip(item, file.createToolTip(item.Tag.ToString()));
        }
    }
}
