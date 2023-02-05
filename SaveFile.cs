using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ExternalStartingItemsGUI
{
    [Serializable]
    public class Item
    {
        public string name;
        public int number;
        public bool isActive;
        public String mod;

        public Item(string name)
        {
            this.name = name;
            this.number = 1;
            this.isActive = false;
            this.mod = "ITEM";
        }

        public Item(string name, int number)
        {
            this.name = name;
            this.number = number;
            this.isActive = false;
            this.mod = "ITEM";
        }

        public Item(string name, int number, bool isActive)
        {
            this.name = name;
            this.number = number;
            this.isActive = isActive;
            this.mod = "ITEM";
        }
        public Item(string name, int number, bool isActive, String mod)
        {
            this.name = name;
            this.number = number;
            this.isActive = isActive;
            this.mod = mod;
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
        public bool changeNumberNotVoid(int number)
        {
            this.number = number;
            if (number < 0)
            {
                this.number = 0;
                return false;
            }
            return true;
        }
    }

    [Serializable]
    public class ActiveProfile {
        public string name;
        public List<Item> items;
        public bool truerougelike;
        public bool spawnsEnabled;

        public int regularCredits;

        public int redCredits;
        public int yellowCredits;
        public int blueCredits;
        public int orangeCredits;
        public int purpleCredits;
        public int blackCredits;
        public int totalCreditsGained;
        public int totalItemsBought;
        public int totalStagesCompleted;
        public int creditsPerStage;
        public int creditIncreaseEveryNStages;
        public int bonusPerLoop;
        public int instantTeleportStartingOnStage;
        public bool voidFieldsCompleted;
        public int bonusCreditEveryNToms;
        public int totalCreditsSaved;
        public int totalSpecialCreditsGained;

        public ActiveProfile(string name) {
            this.name = name;
            this.items = new List<Item>();
            this.truerougelike = false;
            this.spawnsEnabled = true;

            this.regularCredits = 0;
            this.redCredits = 0;
            this.yellowCredits = 0;
            this.blueCredits = 0;
            this.orangeCredits = 0;
            this.purpleCredits = 0;
            this.blackCredits = 0;
            this.totalCreditsGained = 0;
            this.totalItemsBought = 0;
            this.totalStagesCompleted = 0;
            this.creditsPerStage = 5;
            this.creditIncreaseEveryNStages = 50;
            this.bonusPerLoop = 2;
            this.instantTeleportStartingOnStage = 50;
            this.bonusCreditEveryNToms = 75;
            this.totalCreditsSaved = 0;
            this.totalSpecialCreditsGained = 0;
            this.voidFieldsCompleted = false;
        }

        public ActiveProfile() { }
    }

    [Serializable]
    public class SaveFile
    {
        public ActiveProfile activeProfile;
        public List<ActiveProfile> ProfileList;
        public int version;

        public SaveFile() 
        {
            this.ProfileList = new List<ActiveProfile>();
            this.version = 2;
        }

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
        public bool hasCard()
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == "MultiShopCard" && item.number != 0)
                {
                    return true;
                }
            }
            return false;
        }
        public string createToolTip(string ID, bool priced)
        {
            if (priced)
            {
                string tooltip = "Amount: ";
                List<int> priceList = new List<int>();
                bool found = false;
                foreach (Item item in this.activeProfile.items)
                {
                    if (item.name == ID)
                    {
                        tooltip += item.number.ToString();
                        priceList.Add(SaveFile.calculateCurrentPrice(ID, item.number));
                        found = true;
                    }
                }
                if (!found)
                {
                    tooltip += 0.ToString();
                    priceList.Add(SaveFile.calculateCurrentPrice(ID, 0));
                }
                tooltip += "\n";
                tooltip += "Price:\n";
                priceList.Add(GUI.getPrice(ID, PriceTypes.Red));
                priceList.Add(GUI.getPrice(ID, PriceTypes.Yellow));
                priceList.Add(GUI.getPrice(ID, PriceTypes.Blue));
                priceList.Add(GUI.getPrice(ID, PriceTypes.Orange));
                priceList.Add(GUI.getPrice(ID, PriceTypes.Purple));
                priceList.Add(GUI.getPrice(ID, PriceTypes.Black));
                for (int i = 0; i < priceList.Count; i++)
                {
                    if (priceList[i] != 0)
                    {
                        tooltip += "  ";
                        tooltip = tooltip + Enum.GetName(typeof(PriceTypes), i) + ": " + priceList[i].ToString();
                        tooltip += "\n";
                    }
                }
                tooltip = tooltip + "Price Change: " + GUI.getPriceChange(ID).ToString() + "\n";
                tooltip = tooltip + "Min/Max Price: " + GUI.getMaxPriceChange(ID).ToString() + "\n";
                return tooltip;
            }
            else
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
        }
        public static void changeNumberPriced(string ID, Dictionary<PriceTypes, int> price, SaveFile save)
        {
            ActiveProfile profile = save.activeProfile;
            if (save.getItemNumber(ID) == 0)
            {
                save.addItem(ID, GUI.parseIsActive());
            }
            foreach (Item item in save.activeProfile.items)
            {
                if (item.name == ID)
                {
                    if (profile.regularCredits >= price[PriceTypes.Regular] && profile.redCredits >= price[PriceTypes.Red] && profile.yellowCredits >= price[PriceTypes.Yellow] && profile.blueCredits >= price[PriceTypes.Blue] && profile.orangeCredits >= price[PriceTypes.Orange] && profile.purpleCredits >= price[PriceTypes.Purple] && profile.blackCredits >= price[PriceTypes.Black])
                    {
                        profile.regularCredits -= price[PriceTypes.Regular];
                        profile.redCredits -= price[PriceTypes.Red];
                        profile.yellowCredits -= price[PriceTypes.Yellow];
                        profile.blueCredits -= price[PriceTypes.Blue];
                        profile.orangeCredits -= price[PriceTypes.Orange];
                        profile.purpleCredits -= price[PriceTypes.Purple];
                        profile.blackCredits -= price[PriceTypes.Black];
                        item.changeNumber(item.number + 1);
                        profile.totalItemsBought++;
                        if (save.hasCard())
                        {
                            if (price[PriceTypes.Regular] / 10 == 0 && price[PriceTypes.Regular] != 0)
                            {
                                profile.regularCredits++;
                                profile.totalCreditsSaved++;
                            }
                            else
                            {
                                profile.regularCredits += price[PriceTypes.Regular] / 10;
                                profile.totalCreditsSaved += price[PriceTypes.Regular] / 10;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not enough credits.", "No credits?", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            save.writeFile();
        }

        public static void changeNumberPriced(string ID, int previousPrice, SaveFile save)
        {
            if (save.getItemNumber(ID) == 0)
            {
                MessageBox.Show("No items to sell.", "No items?", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                foreach (Item item in save.activeProfile.items)
                {
                    if (item.name == ID)
                    {
                        if (!item.changeNumberNotVoid(item.number - 1))
                        {
                            MessageBox.Show("No items to sell.", "No items?", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            save.activeProfile.regularCredits += previousPrice / 2;
                        }
                    }
                }
            }
            save.writeFile();
        }
        public static int calculateCurrentPrice(string ID, int currentAmount)
        {
            int startingPrice = GUI.getPrice(ID, PriceTypes.Regular);
            int priceChange = GUI.getPriceChange(ID);
            int maxPriceChange = GUI.getMaxPriceChange(ID);
            int amount = 0;
            if (priceChange != 0)
            {
                if (priceChange > 0)
                {
                    while (startingPrice < maxPriceChange)
                    {
                        if (amount >= currentAmount)
                        {
                            break;
                        }
                        startingPrice += priceChange;
                        amount++;
                    }
                }
                else
                {
                    while (startingPrice > maxPriceChange && amount < currentAmount)
                    {
                        startingPrice += priceChange;
                        amount++;
                    }
                }
            }
            return startingPrice;
        }
        public static int calculatePreviousPrice(string ID, int currentAmount)
        {
            int startingPrice = GUI.getPrice(ID, PriceTypes.Regular);
            int priceChange = GUI.getPriceChange(ID);
            int maxPriceChange = GUI.getMaxPriceChange(ID);
            int amount = 0;
            if (priceChange != 0)
            {
                if (priceChange > 0)
                {
                    while (startingPrice < maxPriceChange)
                    {
                        if (amount >= currentAmount - 1)
                        {
                            break;
                        }
                        startingPrice += priceChange;
                        amount++;
                    }
                }
                else
                {
                    while (startingPrice > maxPriceChange && amount < currentAmount - 1)
                    {
                        startingPrice += priceChange;
                        amount++;
                    }
                }
            }
            return startingPrice;
        }

        public Item getItemByID(string ID, bool isActive)
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID && item.mod == "ITEM")
                {
                    return item;
                }
            }
            return addItem(ID, isActive);
        }
        public Item getItemByID(string ID, bool isActive, string mod)
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID && item.mod == mod)
                {
                    return item;
                }
            }
            return addItem(ID, isActive, mod);
        }

        public Item addItem(string ID, bool isActive)
        {
            Item item = new Item(ID, 0, isActive);
            this.activeProfile.items.Add(item);
            return item;
        }

        public Item addItem(string ID, bool isActive, string mod)
        {
            Item item = new Item(ID, 0, isActive, mod);
            this.activeProfile.items.Add(item);
            return item;
        }

        public void changeNumber(string ID, int number)
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID && item.mod == "ITEM")
                {
                    item.changeNumber(number);
                }
            }
        }
        public void changeNumber(string ID, string mod, int number)
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID && item.mod == mod)
                {
                    item.changeNumber(number);
                }
            }
        }

        public int getItemNumber(string ID)
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID && item.mod == "ITEM")
                {
                    return item.number;
                }
            }
            return 0;
        }
        public int getItemNumber(string ID, string mod)
        {
            foreach (Item item in this.activeProfile.items)
            {
                if (item.name == ID && item.mod == mod)
                {
                    return item.number;
                }
            }
            return 0;
        }
    }
    [Serializable]
    public class ItemData
    {
        public string name;
        public string mod;
        public int id;
        public bool isActive;

        public ItemData(string name, string mod, int id, bool isActive)
        {
            this.name = name;
            this.mod = mod;
            this.id = id;
            this.isActive = isActive;
        }

        public ItemData() { }

        public string toString()
        {
            return name + ", " + mod + ", " + id.ToString() + ", " + isActive.ToString(); 
        }
    }

    [Serializable]
    public class ModData
    {
        public List<ItemData> itemList = new List<ItemData>();
        
        public ModData() { }

        public void writeModData()
        {
            XmlSerializer xml = new XmlSerializer(typeof(ModData));

            string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "externalitems");
            string filename = Path.Combine(specificFolder, "moddata.xml");

            Directory.CreateDirectory(specificFolder);

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                xml.Serialize(fs, this);
            }
        }

        public static ModData readModData()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(ModData));

                string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "externalitems");
                string filename = Path.Combine(specificFolder, "moddata.xml");

                Directory.CreateDirectory(specificFolder);

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    return (ModData)xml.Deserialize(fs);
                }
            }
            catch (InvalidOperationException)
            {
                ModData modData = new ModData();
                modData.writeModData();
                return modData;
            }
        }
    }
}
