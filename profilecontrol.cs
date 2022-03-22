using System;
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
            }
            GUI.updateProfile();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            if (file.ProfileList.Count > 0)
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
                DialogResult nope = MessageBox.Show("You cannot delete your only profile.", "There must be at least one profile.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            file.writeFile();
        }
    }
}
