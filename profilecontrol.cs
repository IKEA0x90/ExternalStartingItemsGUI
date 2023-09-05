using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExternalStartingItemsGUI
{
    public partial class profilecontrol : UserControl
    {
        public profilecontrol()
        {
            InitializeComponent();
        }

        private void newProfileNameText_TextChanged(object sender, EventArgs e)
        {
            var cursorPosition = newProfileNameText.SelectionStart;
            newProfileNameText.Text = Regex.Replace(newProfileNameText.Text, "[^0-9a-zA-Z]", "");
            newProfileNameText.SelectionStart = cursorPosition;
        }

        private void newProfileButton_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            string newName = newProfileNameText.Text;

            if (newName == "")
            {
                DialogResult emptyName = MessageBox.Show("Please enter a name for the new profile.", "Name field cannot be empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool cont = true;
                foreach (ActiveProfile item in file.ProfileList)
                {
                    if (item.name == newName)
                    {
                        DialogResult emptyName = MessageBox.Show("The name you entered is already used by another profile. Please enter a unique name.", "Name already in use!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cont = false;
                    }
                }

                if (file.activeProfile.name == newName)
                {
                    DialogResult emptyName = MessageBox.Show("The name you entered is already used by another profile. Please enter a unique name.", "Name already in use!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cont = false;
                }

                if (cont)
                {
                    int index0 = profilelist.FindItemWithText(file.activeProfile.name).Index;
                    file.addProfile(newName);
                    file.setActive(newName);
                    profilelist.Items.Add(newName);
                    int index = profilelist.FindItemWithText(newName).Index;
                    profilelist.Items[index].Selected = true;
                    profilelist.Items[index0].Selected = false;
                    newProfileNameText.Text = "";
                }

            file.writeFile();

            }
        }

        private void profilecontrol_Load(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            profilelist.Items.Add(file.activeProfile.name);
            if (file.ProfileList.Count > 0)
            {
                foreach (ActiveProfile item in file.ProfileList)
                {
                    profilelist.Items.Add(item.name);
                }
            }
            int index = profilelist.FindItemWithText(file.activeProfile.name).Index;
            profilelist.Items[index].Selected = true;
        }

        private void profilelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            if (profilelist.SelectedItems.Count > 0)
            {
                file.setActive(profilelist.SelectedItems[0].Text);
                ActiveProfile profile = file.activeProfile;
                string name = profile.name;
                nameLabel.Text = name;
                file.writeFile();

                if (profile.truerougelike)
                {
                    enablemode.Enabled = false;
                    disablespawns.Enabled = true;
                    mode.Enabled = true;
                    label5.Enabled = true;
                    getorange.Enabled = true;
                    getpurple.Enabled = true;
                    getyellow.Enabled = true;
                    purge.Enabled = false;
                    purge.Visible = false;
                    radioButton1.Checked = true;

                    enablemode.Visible = false;
                    disablespawns.Visible = true;
                    mode.Visible = true;
                    label5.Visible = true;
                    getorange.Visible = true;
                    getpurple.Visible = true;
                    getyellow.Visible = true;

                    GUI.creditLabelVisible(true);
                }
                else
                {
                    //enablemode.Enabled = true;
                    disablespawns.Enabled = false;
                    mode.Enabled = false;
                    label5.Enabled = false;
                    valuebox.Enabled = false;
                    getorange.Enabled = false;
                    getpurple.Enabled = false;
                    getyellow.Enabled = false;
                    purge.Enabled = true;
                    purge.Visible = true;
                    applyb.Visible = false;
                    resetb.Visible = false;
                    applyb.Enabled = false;
                    resetb.Enabled = false;

                    //enablemode.Visible = true;
                    disablespawns.Visible = false;
                    mode.Visible = false;
                    label5.Visible = false;
                    valuebox.Visible = false;
                    label4.Visible = false;
                    getorange.Visible = false;
                    getpurple.Visible = false;
                    getyellow.Visible = false;
                    GUI.creditLabelVisible(false);
                }
            }
            GUI.updateProfile();
            GUI.updateCreditsStatic();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            if (file.ProfileList.Count > 0 && file.activeProfile.name != "Default")
            {

                DialogResult areYouSure = MessageBox.Show("Are you sure you want to delete this profile? This cannot be undone.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (areYouSure == DialogResult.Yes)
                {
                    int index = profilelist.FindItemWithText(file.activeProfile.name).Index;
                    file.removeProfile();
                    profilelist.Items.RemoveAt(index);
                    profilelist.Items[0].Selected = true;
                }
            }
            else
            {
                DialogResult nope = MessageBox.Show("You cannot delete Default profile.", "Cannot delete Default.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            file.writeFile();
        }

        private void purge_Click(object sender, EventArgs e)
        {
            DialogResult areYouSure = MessageBox.Show("Are you sure you want to delete all of your items profile? This cannot be undone.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (areYouSure == DialogResult.Yes)
            {
                SaveFile file = SaveFile.readFile();
                ActiveProfile profile = file.activeProfile;
                profile.items.Clear();
                file.writeFile();
            }
        }

        private void fileb_Click(object sender, EventArgs e)
        {
            try
            {
                string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "externalitems");
                string filename = Path.Combine(specificFolder, "profiles.xml");
                System.Diagnostics.Process.Start(filename);
            }
            catch (Exception)
            {
                DialogResult nope = MessageBox.Show("The profile file is missing.", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enablemode_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            if (file.activeProfile.name != "Default")
            {
                DialogResult areYouSure = MessageBox.Show("Are you sure you want to enable TrueRougeLike mode? All of your items will be deleted. This cannot be undone.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (areYouSure == DialogResult.Yes)
                {
                    file.activeProfile.truerougelike = true;
                    disablespawns.Checked = true;
                    enablemode.Enabled = false;
                    disablespawns.Enabled = true;
                    mode.Enabled = true;
                    label5.Enabled = true;
                    getorange.Enabled = true;
                    getpurple.Enabled = true;
                    getyellow.Enabled = true;
                    purge.Enabled = false;
                    purge.Visible = false;

                    enablemode.Visible = false;
                    disablespawns.Visible = true;
                    mode.Visible = true;
                    label5.Visible = true;
                    getorange.Visible = true;
                    getpurple.Visible = true;
                    getyellow.Visible = true;
                    GUI.creditLabelVisible(true); 
                    file.activeProfile.items.Clear();
                    file.activeProfile.spawnsEnabled = false;
                    radioButton1.Checked = true;
                }
                file.writeFile();
            }
            else
            {
                DialogResult nope = MessageBox.Show("Cannot make Default profile TrueRougeLike. Please make a new profile and switch it.", "Cannot change Default profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getyellow_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            ActiveProfile profile = file.activeProfile;
            profile.yellowCredits += 1;
            file.writeFile();
            GUI.updateCreditsStatic();
        }

        private void getpurple_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            ActiveProfile profile = file.activeProfile;
            profile.purpleCredits += 1;
            file.writeFile();
            GUI.updateCreditsStatic();
        }

        private void getorange_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            ActiveProfile profile = file.activeProfile;
            profile.orangeCredits += 1;
            file.writeFile();
            GUI.updateCreditsStatic();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                deleteButton.Enabled = true;
                newProfileButton.Enabled = true;
                newProfileNameText.Enabled = true;
                newProfileNameText.Visible = true;
                deleteButton.Visible = true;
                deleteButton.Enabled = true;
                newProfileButton.Visible = true;
                valuebox.Enabled = false;
                valuebox.Visible = false;
                currentvalue.Visible = false;
                applyb.Enabled = false;
                applyb.Visible = false;
                label4.Visible = false;

                statview.Enabled = false;
                statview.Visible = false;
                statview.Clear();
                valuelist.Clear();
                valuelist.Enabled = false;
                valuelist.Visible = false;
                profilelist.Enabled = true;
                profilelist.Visible = true;

                resetb.Enabled = false;
                resetb.Visible = false;

                label2.Text = "Create new profile:";
            }
        }

        private void valuemode_CheckedChanged(object sender, EventArgs e)
        {
            if (valuemode.Checked)
            {
                deleteButton.Enabled = false;
                newProfileButton.Enabled = false;
                newProfileNameText.Enabled = false;
                valuebox.Enabled = true;
                valuebox.Visible = true;
                deleteButton.Visible = false;
                deleteButton.Enabled = false;
                currentvalue.Visible = true;
                label4.Visible = true;

                statview.Enabled = false;
                statview.Visible = false;
                statview.Clear();
                valuelist.Clear();
                valuelist.Enabled = true;
                valuelist.Visible = true;
                profilelist.Enabled = false;
                profilelist.Visible = false;
                applyb.Enabled = true;
                applyb.Visible = true;

                resetb.Enabled = true;
                resetb.Visible = true;

                label2.Text = "Enter Value:";
                values.Clear();

                ActiveProfile profile = SaveFile.readFile().activeProfile;

                valuelist.Items.Add("Credits Per Stage");
                valuelist.Items.Add("Bonus Credits Per Loop");
                valuelist.Items.Add("Bonus Income Per N Total Stages");
                valuelist.Items.Add("Bonus Income Per N Ghor's Toms");
                valuelist.Items.Add("Instant TP After N Total Stages");

                values.Add("creditsPerStage", profile.creditsPerStage);
                values.Add("bonusCreditEveryNToms", profile.bonusCreditEveryNToms);
                values.Add("creditIncreaseEveryNStages", profile.creditIncreaseEveryNStages);
                values.Add("bonusPerLoop", profile.bonusPerLoop);
                values.Add("instantTeleportStartingOnStage", profile.instantTeleportStartingOnStage);

            }
            else
            {
                valuebox.Minimum = 0;
                currentvalue.Text = "None";
                valuebox.Value = 0;
            }
        }

        private void statmode_CheckedChanged(object sender, EventArgs e)
        {
            if (statmode.Checked)
            {
                deleteButton.Enabled = false;
                deleteButton.Visible = false;
                newProfileButton.Visible = false;
                newProfileButton.Enabled = false;
                newProfileNameText.Enabled = false;
                newProfileNameText.Visible = false;
                deleteButton.Visible = false;
                deleteButton.Enabled = false;
                valuebox.Enabled = false;
                valuebox.Visible = false;
                currentvalue.Visible = false;
                applyb.Enabled = false;
                applyb.Visible = false;
                label4.Visible = false;

                statview.Enabled = true;
                statview.Visible = true;
                statview.Clear();
                valuelist.Clear();
                valuelist.Enabled = false;
                valuelist.Visible = false;
                profilelist.Enabled = false;
                profilelist.Visible = false;

                resetb.Enabled = false;
                resetb.Visible = false;

                label2.Text = "Warning!\nStats are not updated if you left this window active.\nPlease re-select to update.";

                ActiveProfile profile = SaveFile.readFile().activeProfile;

                statview.Items.Add("Total Credits Gained: " + profile.totalCreditsGained.ToString());
                statview.Items.Add("Total Items Bought: " + profile.totalItemsBought.ToString());
                statview.Items.Add("Total Stages Completed: " + profile.totalStagesCompleted.ToString());
                statview.Items.Add("Total Credits Saved: " + profile.totalCreditsSaved.ToString());
                statview.Items.Add("Total Special Credits Gained: " + profile.totalSpecialCreditsGained.ToString());
            }
        }

        private static Dictionary<string, int> values = new Dictionary<string, int>();
        private void applyb_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            ActiveProfile profile = file.activeProfile;

            profile.creditsPerStage = values["creditsPerStage"];
            profile.creditIncreaseEveryNStages = values["creditIncreaseEveryNStages"];
            profile.bonusPerLoop = values["bonusPerLoop"];
            profile.instantTeleportStartingOnStage = values["instantTeleportStartingOnStage"];
            profile.bonusCreditEveryNToms = values["bonusCreditEveryNToms"];

            file.writeFile();
        }

        private void resetb_Click(object sender, EventArgs e)
        {
            DialogResult areYouSure = MessageBox.Show("Are you sure you want to reset all the values to default? This cannot be undone.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (areYouSure == DialogResult.Yes)
            {
                SaveFile file = SaveFile.readFile();
                ActiveProfile profile = file.activeProfile;
                profile.creditsPerStage = 5;
                profile.creditIncreaseEveryNStages = 50;
                profile.bonusPerLoop = 2;
                profile.instantTeleportStartingOnStage = 50;
                profile.bonusCreditEveryNToms = 75;
                file.writeFile();

                valuemode.Checked = false;
                radioButton1.Checked = true;
            }
        }

        private void valuelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveProfile profile = SaveFile.readFile().activeProfile;
            if (valuelist.SelectedItems.Count > 0)
            {
                string selectedValueText = valuelist.SelectedItems[0].Text;
                currentvalue.Text = selectedValueText;
                int actualValue;

                switch (selectedValueText)
                {
                    case "Credits Per Stage":
                        actualValue = values["creditsPerStage"];
                        valuebox.Minimum = 0;
                        break;
                    case "Bonus Income Per N Total Stages":
                        actualValue = values["creditIncreaseEveryNStages"];
                        valuebox.Value = actualValue;
                        valuebox.Minimum = 1;
                        break;
                    case "Bonus Credits Per Loop":
                        actualValue = values["bonusPerLoop"];
                        valuebox.Minimum = 0;
                        break;
                    case "Instant TP After N Total Stages":
                        actualValue = values["instantTeleportStartingOnStage"];
                        valuebox.Minimum = -1;
                        break;
                    case "Bonus Income Per N Ghor's Toms":
                        actualValue = values["bonusCreditEveryNToms"];
                        valuebox.Value = actualValue;
                        valuebox.Minimum = 1;
                        break;
                    default:
                        valuebox.Minimum = 0;
                        actualValue = 0;
                        break;
                }

                valuebox.Value = actualValue;
            }
        }

        private void valuebox_ValueChanged(object sender, EventArgs e)
        {
            if (valuelist.SelectedItems.Count > 0)
            {
                string selectedValueText = valuelist.SelectedItems[0].Text;

                switch (selectedValueText)
                {
                    case "Credits Per Stage":
                        values["creditsPerStage"] = (int)valuebox.Value;
                        break;
                    case "Bonus Income Per N Total Stages":
                        values["creditIncreaseEveryNStages"] = (int)valuebox.Value;
                        break;
                    case "Bonus Credits Per Loop":
                        values["bonusPerLoop"] = (int)valuebox.Value;
                        break;
                    case "Instant TP After N Total Stages":
                        values["instantTeleportStartingOnStage"] = (int)valuebox.Value;
                        break;
                    case "Bonus Income Per N Ghor's Toms":
                        values["bonusCreditEveryNToms"] = (int)valuebox.Value;
                        break;
                    default:
                        break;
                }
            }
        }

        private void disablespawns_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult areYouSure = MessageBox.Show("Please restart the game to apply this change.", "Game restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SaveFile file = SaveFile.readFile();
            file.activeProfile.spawnsEnabled = !disablespawns.Checked;
            file.writeFile();
        }
    }
}
