using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ExternalStartingItemsGUI
{
    [Serializable]
    public class Item
    {
        public string name;
        public int number;
        public bool isActive;

        public Item(string name)
        {
            this.name = name;
            this.number = 1;
            this.isActive = false;
        }

        public Item(string name, int number)
        {
            this.name = name;
            this.number = number;
            this.isActive = false;
        }

        public Item(string name, int number, bool isActive)
        {
            this.name = name;
            this.number = number;
            this.isActive = isActive;
        }

        public Item() { }

        public void changeNumber(int number)
        {
            this.number = number;
            if (number < 0)
            {
                this.number = 0;
            }
        }
    }

    [Serializable]
    public class ActiveProfile {
        public string name;
        public List<Item> items;

        public ActiveProfile(string name) {
            this.name = name;
            this.items = new List<Item>();
        }

        public ActiveProfile() { }
    }

    [Serializable]
    public class SaveFile
    {
        public ActiveProfile activeProfile;
        public List<ActiveProfile> ProfileList = new List<ActiveProfile>();

        public SaveFile() { }

        public static SaveFile readFile()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(SaveFile));

                string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "externalitems");
                string filename = Path.Combine(specificFolder, "profiles.xml");

                Directory.CreateDirectory(specificFolder);

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    return (SaveFile)xml.Deserialize(fs);
                }
            }
            catch (InvalidOperationException)
            {
                SaveFile saveFile = new SaveFile();
                saveFile.activeProfile = new ActiveProfile("Default");
                saveFile.writeFile();
                return saveFile;
            }
        }

        public void writeFile()
        {
            XmlSerializer xml = new XmlSerializer(typeof(SaveFile));

            string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "externalitems");
            string filename = Path.Combine(specificFolder, "profiles.xml");

            Directory.CreateDirectory(specificFolder);
            clearItems();

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                xml.Serialize(fs, this);
            }

        }

        public void addProfile(string name)
        {
            this.ProfileList.Add(new ActiveProfile(name));
        }

        public bool setActive(string name)
        {
            foreach (ActiveProfile profile in this.ProfileList)
            {
                if (profile.name == name)
                {
                    this.ProfileList.Add(this.activeProfile);
                    this.activeProfile = profile;
                    this.ProfileList.Remove(profile);
                    return true;
                }
            }
            return false;
        }

        public void removeProfile()
        {
            this.activeProfile = this.ProfileList[0];
            this.ProfileList.Remove(this.activeProfile);
        }

        private void clearItems()
        {
            for (int i = 0; i < this.activeProfile.items.Count; i++)
            {
                if (this.activeProfile.items[i].number == 0) {
                    this.activeProfile.items.RemoveAt(i);
                }
            }
        }

        public string createToolTip(string ID)
        {
            string tooltip = "Amount: ";
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID)
                {
                    tooltip += item.number;
                    return tooltip;
                }
            }
            tooltip += "0";
            return tooltip;
        }

        public Item getItemByID(string ID, bool isActive)
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID)
                {
                    return item;
                }
            }
            return addItem(ID, isActive);
        }

        public Item addItem(string ID, bool isActive)
        {
            Item item = new Item(ID, 0, isActive);
            this.activeProfile.items.Add(item);
            return item;
        }

        public void changeNumber(string ID, int number)
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID)
                {
                    item.changeNumber(number);
                }
            }
        }

        public int getItemNumber(string ID)
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID)
                {
                    return item.number;
                }
            }
            return 0;
        }
    }
}
