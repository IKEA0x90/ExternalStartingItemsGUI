using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
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

        public static Dictionary<string, string> prices;

        public static int getPrice(string ID, PriceTypes priceType)
        {
            return int.Parse(GUI.prices[ID].Split(';')[0].Split(',')[(int)priceType]);
        }

        public static int getPriceChange(string ID)
        {
            return int.Parse(GUI.prices[ID].Split(';')[1]);
        }

        public static int getMaxPriceChange(string ID)
        {
            return int.Parse(GUI.prices[ID].Split(';')[2]);
        }

        public static bool parseIsActive()
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

        private class ControlClass
        {
            private static UserControl[] controlarray = new UserControl[9];
           
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
                controlarray[8] = new modded();
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
                    case "modded": return controlarray[8];
                    default: return controlarray[0];
                }
            }
        }

        public static string ItemClick_MouseClick(object sender, MouseEventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            if (file.activeProfile.truerougelike)
            {
                PictureBox itemB = sender as PictureBox;
                string ID = itemB.Tag.ToString();
                Form form = GUI.ActiveForm;

                Dictionary<PriceTypes, int> price = new Dictionary<PriceTypes, int>();
                price[PriceTypes.Regular] = SaveFile.calculateCurrentPrice(ID, file.getItemNumber(ID));
                price[PriceTypes.Red] = getPrice(ID, PriceTypes.Red);
                price[PriceTypes.Yellow] = getPrice(ID, PriceTypes.Yellow);
                price[PriceTypes.Blue] = getPrice(ID, PriceTypes.Blue);
                price[PriceTypes.Orange] = getPrice(ID, PriceTypes.Orange);
                price[PriceTypes.Purple] = getPrice(ID, PriceTypes.Purple);
                price[PriceTypes.Black] = getPrice(ID, PriceTypes.Black);

                if (e.Button == MouseButtons.Left)
                {
                    SaveFile.changeNumberPriced(ID, price, file);
                }
                else if ((e.Button == MouseButtons.Right))
                {
                    SaveFile.changeNumberPriced(ID, SaveFile.calculatePreviousPrice(ID, file.getItemNumber(ID)), file);
                }

                file.writeFile();

                foreach (Control control in form.Controls)
                {
                    if (control.GetType() == typeof(Label))
                    {
                        Label label = control as Label;

                        switch (label.Name)
                        {
                            case "RegularCredits":
                                label.Text = file.activeProfile.regularCredits.ToString();
                                break;
                            case "RedCredits":
                                label.Text = file.activeProfile.redCredits.ToString();
                                break;
                            case "YellowCredits":
                                label.Text = file.activeProfile.yellowCredits.ToString();
                                break;
                            case "BlueCredits":
                                label.Text = file.activeProfile.blueCredits.ToString();
                                break;
                            case "OrangeCredits":
                                label.Text = file.activeProfile.orangeCredits.ToString();
                                break;
                            case "PurpleCredits":
                                label.Text = file.activeProfile.purpleCredits.ToString();
                                break;
                            case "BlackCredits":
                                label.Text = file.activeProfile.blackCredits.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                }

                return file.createToolTip(ID, true);
            }
            else
            {

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
            file.version = 2.01f; //UPDATE ON EACH REVISION

            if (file.activeProfile.truerougelike)
            {
                GUI.prices = new Dictionary<string, string>();
                try
                {
                    using (var client = new WebClient())
                    {
                        string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "externalitems");
                        string filename = Path.Combine(specificFolder, "prices.txt");

                        Directory.CreateDirectory(specificFolder);
                        client.DownloadFile("http://cinnamonbun.ru/prices.txt", filename);
                    }
                }
                catch (Exception)
                {
                    ;
                }

                if (File.Exists(Path.Combine(Path.GetTempPath(), "prices.txt")))
                {
                    StreamReader reader = new StreamReader(Path.Combine(Path.GetTempPath(), "prices.txt"));

                    string input = reader.ReadLine();

                    for (; ; )
                    {
                        input = reader.ReadLine();
                        string ID;
                        string price;

                        if (input != "#End")
                        {
                            ID = input.Split(';')[0];
                            price = input.Split(';')[1] + ";" + input.Split(';')[2] + ";" + input.Split(';')[3];
                            GUI.prices.Add(ID, price);
                        }
                        else break;
                    }
                    reader.Close();
                }
                else
                {
                    DialogResult noPrices = MessageBox.Show("Could not find a file with prices. Switching to default profile.", "No prices?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file.setActive("Default");
                }
                ActiveProfile profile = file.activeProfile;
                foreach (Control control in this.Controls)
                {
                    if ((string)control.Tag == "SPECIAL")
                    {
                        control.Visible = profile.truerougelike;
                    }
                }
                moddedButton.Visible = !profile.truerougelike;
                quantity.Visible = !profile.truerougelike;

                RegularCredits.Text = profile.regularCredits.ToString();
                RedCredits.Text = profile.redCredits.ToString();
                YellowCredits.Text = profile.yellowCredits.ToString();
                BlueCredits.Text = profile.blueCredits.ToString();
                OrangeCredits.Text = profile.orangeCredits.ToString();
                PurpleCredits.Text = profile.purpleCredits.ToString();
                BlackCredits.Text = profile.blackCredits.ToString();
            }
            file.writeFile();
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
        public static int parseQuantity()
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

        public void updateCredits()
        {
            ActiveProfile profile = SaveFile.readFile().activeProfile;
            RegularCredits.Text = profile.regularCredits.ToString();
            RedCredits.Text = profile.redCredits.ToString();
            YellowCredits.Text = profile.yellowCredits.ToString();
            BlueCredits.Text = profile.blueCredits.ToString();
            OrangeCredits.Text = profile.orangeCredits.ToString();
            PurpleCredits.Text = profile.purpleCredits.ToString();
            BlackCredits.Text = profile.blackCredits.ToString();
        }

        public static void updateCreditsStatic()
        {
            SaveFile file = SaveFile.readFile();
            Form form = GUI.ActiveForm;

            foreach (Control control in form.Controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    Label label = control as Label;

                    switch (label.Name)
                    {
                        case "RegularCredits":
                            label.Text = file.activeProfile.regularCredits.ToString();
                            break;
                        case "RedCredits":
                            label.Text = file.activeProfile.redCredits.ToString();
                            break;
                        case "YellowCredits":
                            label.Text = file.activeProfile.yellowCredits.ToString();
                            break;
                        case "BlueCredits":
                            label.Text = file.activeProfile.blueCredits.ToString();
                            break;
                        case "OrangeCredits":
                            label.Text = file.activeProfile.orangeCredits.ToString();
                            break;
                        case "PurpleCredits":
                            label.Text = file.activeProfile.purpleCredits.ToString();
                            break;
                        case "BlackCredits":
                            label.Text = file.activeProfile.blackCredits.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }

        }
        public static void creditLabelVisible(bool visible)
        {
            SaveFile file = SaveFile.readFile();
            Form form = GUI.ActiveForm;

            foreach (Control control in form.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button button = control as Button;
                    if ((string)button.Tag == "SPECIAL" || (string)button.Tag == "modded") 
                    {
                        button.Visible = !visible;
                    }
                }

                if (control.GetType() == typeof(Label))
                {
                    Label label = control as Label;

                    if ((string)label.Tag == "SPECIAL")
                    {
                        label.Visible = visible;
                    }
                }
            }
        }

        private void GUI_Activated(object sender, EventArgs e)
        {
            updateCredits();
            try
            {
                using (var client = new WebClient())
                {
                    string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "externalitems");
                    string filename = Path.Combine(specificFolder, "prices.txt");

                    Directory.CreateDirectory(specificFolder);
                    client.DownloadFile("http://cinnamonbun.ru/prices.txt", filename);
                }
            }
            catch (Exception)
            {
                ;
            }
        }
    }
}
