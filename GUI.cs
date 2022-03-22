using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExternalStartingItemsGUI
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private class ControlClass
        {
            private static UserControl[] controlarray = new UserControl[8];
           
            public static void setArray()
            {
                controlarray[0] = new profilecontrol();
                controlarray[1] = new whitecontrol();
                controlarray[2] = new greencontrol();
                controlarray[3] = new redcontrol();
                controlarray[4] = new yellowcontrol();
                controlarray[5] = new purplecontrol();
                controlarray[6] = new bluecontrol();
                controlarray[7] = new orangecontrol();
            }

            public static UserControl getcontrol(string color)
            {
                switch (color)
                {
                    case "profile": return controlarray[0];
                    case "white": return controlarray[1];
                    case "green": return controlarray[2];
                    case "red": return controlarray[3];
                    case "yellow": return controlarray[4];
                    case "purple": return controlarray[5];
                    case "blue": return controlarray[6];
                    case "orange": return controlarray[7];
                    default: return controlarray[0];
                }
            }
        }

        public static string ItemClick_MouseClick(object sender, MouseEventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            PictureBox itemB = sender as PictureBox;
            string ID = itemB.Tag.ToString();
            bool isActive = parseIsActive();
            Item item = file.getItemByID(ID, isActive);
            int number = item.number;

            if (e.Button == MouseButtons.Left)
            {
                number += parseQuantity();
            }
            else if ((e.Button == MouseButtons.Right))
            {
                number -= parseQuantity();
            }

            file.changeNumber(ID, number);
            file.writeFile();

            return file.createToolTip(ID);
        }

        private void stickyButton_MouseClick(object sender, System.EventArgs e)
        {
            panelpanel.Controls.Clear();
            Button button = sender as Button;
            Button oldButton = this.Controls.Find(colorbutton.Tag.ToString(), false)[0] as Button;
            if (button.Name != "apply" && button.Name != "quantity")
            {
                if (oldButton.Enabled == false)
                {
                    oldButton.BackColor = colorbutton.BackColor;
                    oldButton.Enabled = true;
                }

                UserControl control = ControlClass.getcontrol(button.Tag.ToString());
                panelpanel.Controls.Add(control);
                colorbutton.BackColor = button.BackColor;
                colorbutton.Tag = button.Name;
                button.BackColor = button.FlatAppearance.MouseDownBackColor;
                button.Enabled = false;
            }
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            ControlClass.setArray();
            SaveFile file = SaveFile.readFile();
            Button button;
            foreach (Control b in this.Controls)
            {
                if (b.GetType() == typeof(Button) && b.Name != "apply" && b.Name != "quantity")
                {
                    button = b as Button;
                    button.Click += stickyButton_MouseClick;
                }
            }
            profileLabel.Text = file.activeProfile.name;
        }

        private void quantity_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button== MouseButtons.Right)
            {
                string text = quantity.Text.Remove(0, 1);
                int amount = int.Parse(text);
                if (amount > 1)
                {
                    amount /= 10;
                }
                else amount = 1000;
                quantity.Text = "x" + amount.ToString();
            }
            else
            {
                string text = quantity.Text.Remove(0, 1);
                int amount = int.Parse(text);
                if (amount < 1000)
                {
                    amount *= 10;
                }
                else amount = 1;
                quantity.Text = "x" + amount.ToString();
            }
        }
        private static int parseQuantity()
        {
            Form form = GUI.ActiveForm;
            foreach (Control control in form.Controls) 
            {
                if (control.Name == "quantity")
                {
                    return int.Parse(control.Text.Remove(0, 1));
                }
            }
            return 1;
            
        }

        private static bool parseIsActive()
        {
            Form form = GUI.ActiveForm;
            foreach (Control control in form.Controls)
            {
                if (control.Name == "orangebutton")
                {
                    return !control.Enabled;
                }
            }
            return false;
        }

        public static void updateProfile()
        {
            SaveFile file = SaveFile.readFile();
            Form form = GUI.ActiveForm;
            foreach (Control control in form.Controls)
            {
                if (control.Name == "profileLabel")
                {
                    control.Text = file.activeProfile.name;
                }
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            file.writeFile();
        }
    }
}
