using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExternalStartingItemsGUI
{
    public partial class modded : UserControl
    {
        public modded()
        {
            InitializeComponent();
        }

        private static Dictionary<String, List<ItemData>> items = new Dictionary<string, List<ItemData>>();
        private static HashSet<string> prohibited = new HashSet<string> { "BFG", "Blackhole", "BossHunter", "BossHunterConsumed", "BurnNearby", "Cleanse", "CommandMissile", "CrippleWard", "CritOnUse", "DeathProjectile", "DroneBackup", "EliteFireEquipment", "EliteHauntedEquipment", "EliteIceEquipment", "EliteLightningEquipment", "EliteLunarEquipment", "Enigma", "FireBallDash", "Fruit", "GainArmor", "Gateway", "GoldGat", "GummyClone", "Jetpack", "LifestealOnHit", "Lightning", "Meteor", "Molotov", "MultiShopCard", "OrbOnUse", "PassiveHealing", "QuestVolatileBattery", "Recycle", "Saw", "Scanner", "TeamWarCry", "Tonic", "VendingMachine", "AdaptiveArmor", "AlienHead", "ArmorPlate", "ArmorReductionOnHit", "ArtifactKey", "AttackSpeedAndMoveSpeed", "AttackSpeedOnCrit", "AutoCastEquipment", "Bandolier", "BarrierOnKill", "BarrierOnOverHeal", "Bear", "BearVoid", "BeetleGland", "Behemoth", "BleedOnHit", "BleedOnHitAndExplode", "BleedOnHitVoid", "BonusGoldPackOnKill", "BoostAttackSpeed", "BoostEquipmentRecharge", "BossDamageBonus", "BounceNearby", "CaptainDefenseMatrix", "ChainLightning", "ChainLightningVoid", "Clover", "CloverVoid", "ConvertCritChanceToCritDamage", "CritDamage", "CritGlasses", "CritGlassesVoid", "Crowbar", "CutHp", "Dagger", "DeathMark", "DroneWeapons", "DroneWeaponsBoost", "DroneWeaponsDisplay1", "DroneWeaponsDisplay2", "ElementalRingVoid", "EnergizedOnEquipmentUse", "EquipmentMagazine", "EquipmentMagazineVoid", "ExecuteLowHealthElite", "ExplodeOnDeath", "ExplodeOnDeathVoid", "ExtraLife", "ExtraLifeConsumed", "ExtraLifeVoid", "ExtraLifeVoidConsumed", "FallBoots", "Feather", "FireRing", "FireballsOnHit", "Firework", "FlatHealth", "FocusConvergence", "FragileDamageBonus", "FragileDamageBonusConsumed", "FreeChest", "GhostOnKill", "GoldOnHit", "GoldOnHurt", "GummyCloneIdentifier", "HalfAttackSpeedHalfCooldowns", "HalfSpeedDoubleHealth", "HeadHunter", "HealOnCrit", "HealWhileSafe", "HealingPotion", "HealingPotionConsumed", "Hoof", "IceRing", "Icicle", "IgniteOnKill", "ImmuneToDebuff", "IncreaseHealing", "Infusion", "InvadingDoppelganger", "JumpBoost", "KillEliteFrenzy", "Knurl", "LaserTurbine", "LightningStrikeOnHit", "LunarBadLuck", "LunarDagger", "LunarPrimaryReplacement", "LunarSecondaryReplacement", "LunarSpecialReplacement", "LunarSun", "LunarTrinket", "LunarUtilityReplacement", "Medkit", "MinionLeash", "MinorConstructOnKill", "Missile", "MissileVoid", "MonstersOnShrineUse", "MoreMissile", "MoveSpeedOnKill", "Mushroom", "MushroomVoid", "NearbyDamageBonus", "NovaOnHeal", "NovaOnLowHealth", "OutOfCombatArmor", "ParentEgg", "Pearl", "PermanentDebuffOnHit", "PersonalShield", "Phasing", "Plant", "PrimarySkillShuriken", "RandomDamageZone", "RandomEquipmentTrigger", "RandomlyLunar", "RegeneratingScrap", "RegeneratingScrapConsumed", "RepeatHeal", "RoboBallBuddy", "ScrapGreen", "ScrapRed", "ScrapWhite", "ScrapYellow", "SecondarySkillMagazine", "Seed", "ShieldOnly", "ShinyPearl", "ShockNearby", "SiphonOnLowHealth", "SlowOnHit", "SlowOnHitVoid", "SprintArmor", "SprintBonus", "SprintOutOfCombat", "SprintWisp", "Squid", "StickyBomb", "StrengthenBurn", "StunChanceOnHit", "Syringe", "TPHealingNova", "Talisman", "Thorns", "TitanGoldDuringTP", "TonicAffliction", "Tooth", "TreasureCache", "TreasureCacheVoid", "UtilitySkillMagazine", "VoidMegaCrabItem", "WarCryOnMultiKill", "WardOnLevel" };

        private ItemData lookupItem(string name, string mod)
        {
            foreach (ItemData item in items[modList.SelectedItem.ToString()])
            {
                if (item.name == name && item.mod == mod) return item;
            }
            return new ItemData("Incorrect", "Incorrect", -1, false);
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            ModData moddata = ModData.readModData();
            HashSet<string> mods = new HashSet<string>();
            foreach (ItemData item in moddata.itemList)
            {
                if (!mods.Contains(item.mod))
                {
                    mods.Add(item.mod);
                }
                if (items.ContainsKey(item.mod))
                {
                    items[item.mod].Add(item);
                }
                else
                {
                    items.Add(item.mod, new List<ItemData>());
                    items[item.mod].Add(item);
                }
                
            }
            itemlist.Items.Clear();
            modList.Items.Clear();
            foreach (String mod in mods)
            {
                modList.Items.Add(mod);
            }
        }

        private void modList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            itemlist.Items.Clear();
            foreach (ItemData i in items[modList.GetItemText(modList.SelectedItem)])
            {
                if (!prohibited.Contains(i.name) && !itemlist.Items.ContainsKey(i.name))
                {
                    itemlist.Items.Add(i.name);
                }
            }
            nameLabel.Text = "None";
            number.Text = "0";
        }

        private void add_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            if (itemlist.SelectedItems.Count != 0)
            {
                string name = itemlist.SelectedItems[0].Text;
                ItemData itemdata = lookupItem(name, modList.SelectedItem.ToString());
                Item item = file.getItemByID(itemdata.name, itemdata.isActive, itemdata.mod);
                int numberItem = item.number;

                numberItem += GUI.parseQuantity();

                file.changeNumber(itemdata.name, itemdata.mod, numberItem);
                number.Text = file.getItemNumber(name, modList.SelectedItem.ToString()).ToString();
                file.writeFile();

            }
            else
            {
                DialogResult nope = MessageBox.Show("Please select an item.", "An item must be selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void itemlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SaveFile file = SaveFile.readFile();
                if (itemlist.SelectedItems.Count != 0)
                {
                    string name = itemlist.SelectedItems[0].Text;
                    nameLabel.Text = name;
                    number.Text = file.getItemNumber(name, modList.SelectedItem.ToString()).ToString();
                }
            }
            catch (Exception)
            {
                ;
            }
            }

        private void remove_Click(object sender, EventArgs e)
        {
            SaveFile file = SaveFile.readFile();
            if (itemlist.SelectedItems.Count != 0)
            {
                string name = itemlist.SelectedItems[0].Text;
                ItemData itemdata = lookupItem(name, modList.SelectedItem.ToString());
                Item item = file.getItemByID(itemdata.name, itemdata.isActive, itemdata.mod);
                int numberItem = item.number;

                numberItem -= GUI.parseQuantity();

                file.changeNumber(itemdata.name, itemdata.mod, numberItem);
                number.Text = file.getItemNumber(name, modList.SelectedItem.ToString()).ToString();
                file.writeFile();

            }
            else
            {
                DialogResult nope = MessageBox.Show("Please select an item.", "An item must be selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modded_Load(object sender, EventArgs e)
        {
            ModData moddata = ModData.readModData();
            HashSet<string> mods = new HashSet<string>();
            foreach (ItemData item in moddata.itemList)
            {
                if (!mods.Contains(item.mod))
                {
                    mods.Add(item.mod);
                }
                if (items.ContainsKey(item.mod))
                {
                    items[item.mod].Add(item);
                }
                else
                {
                    items.Add(item.mod, new List<ItemData>());
                    items[item.mod].Add(item);
                }

            }
            itemlist.Items.Clear();
            modList.Items.Clear();
            foreach (String mod in mods)
            {
                modList.Items.Add(mod);
            }
        }
    }
}
