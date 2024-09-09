using System.Collections.Generic;
using UnityEngine;

public class Base
{
    public string Name;
    public string Description;

    public ItemType Type;
    public Rare Rare;
    public Sprite Sprite;

    public int Points;
    public int Health;

    public int Value;

    public Base Copy()
    {
        Base copy = (Base)this.MemberwiseClone();
        return copy;
    }
}

public class Weapon
{
    public float AttackTime;
    public int AttackRange;
    public bool IsMeleeAttack;

    public Weapon Copy()
    {
        Weapon copy = (Weapon)this.MemberwiseClone();
        return copy;
    }
}

public class Damages
{
    public int PierceDamage;
    public int SlashDamage;
    public int BluntDamage;
    public int FireDamage;
    public int IceDamage;
    public int EarthDamage;
    public int PoisonDamage;
    public int WaterDamage;
    public int LightDamage;
    public int DarknessDamage;

    public Damages Copy()
    {
        Damages copy = (Damages)this.MemberwiseClone();
        return copy;
    }
}

public class Resists
{
    public int PierceResist;
    public int SlashResist;
    public int BluntResist;
    public int FireResist;
    public int IceResist;
    public int EarthResist;
    public int PoisonResist;
    public int WaterResist;
    public int LightResist;
    public int DarknessResist;

    public Resists Copy()
    {
        Resists copy = (Resists)this.MemberwiseClone();
        return copy;
    }
}

public class Item
{
    public Base Base;
    public Weapon Weapon;
    public Resists Resists;
    public Damages Damages;

    public Item(string name, ItemType type, Rare rare, int points, int health, string spritePath, string description = "desc",
            float attackTime = 1, int attackRange = 1, bool isMeleeAttack = true,
            int pierceDamage = 0, int slashDamage = 0, int bluntDamage = 0, int fireDamage = 0, int iceDamage = 0, int earthDamage = 0, int poisonDamage = 0, int waterDamage = 0, int lightDamage = 0, int darknessDamage = 0,
            int pierceResist = 0, int slashResist = 0, int bluntResist = 0, int fireResist = 0, int iceResist = 0, int earthResist = 0, int poisonResist = 0, int waterResist = 0, int lightResist = 0, int darknessResist = 0)
    {
        Base = new Base
        {
            Name = name,
            Description = description,
            Type = type,
            Rare = rare,
            Points = points,
            Health = health,
            Sprite = Resources.Load<Sprite>(spritePath),
            Value = 0
        };

        Weapon = new Weapon
        {
            AttackRange = attackRange,
            AttackTime = attackTime,
            IsMeleeAttack = isMeleeAttack
        };

        Damages = new Damages
        {
            PierceDamage = pierceDamage,
            SlashDamage = slashDamage,
            BluntDamage = bluntDamage,
            FireDamage = fireDamage,
            IceDamage = iceDamage,
            EarthDamage = earthDamage,
            PoisonDamage = poisonDamage,
            WaterDamage = waterDamage,
            LightDamage = lightDamage,
            DarknessDamage = darknessDamage
        };

        Resists = new Resists
        {
            PierceResist = pierceResist,
            SlashResist = slashResist,
            BluntResist = bluntResist,
            FireResist = fireResist,
            IceResist = iceResist,
            EarthResist = earthResist,
            PoisonResist = poisonResist,
            WaterResist = waterResist,
            LightResist = lightResist,
            DarknessResist = darknessResist
        };
    }

    public Item Copy()
    {
        Item copy = (Item)this.MemberwiseClone();
        copy.Base = this.Base.Copy();
        copy.Weapon = this.Weapon.Copy();
        copy.Damages = this.Damages.Copy();
        copy.Resists = this.Resists.Copy();

        return copy;
    }
}

public static class ItemsList
{
    public static List<Item> AllItems = new List<Item>();
    public static List<Item> AllCommonItem = new List<Item>();
    public static List<Item> AllUncommonItem = new List<Item>();
    public static List<Item> AllRareItem = new List<Item>();
    public static List<Item> AllEpicItem = new List<Item>();
    public static List<Item> AllLegendaryItem = new List<Item>();
    public static List<Item> AllMythicalItem = new List<Item>();

    public static List<Item> AllRace = new List<Item>();
    public static List<Item> AllEquipmentItems = new List<Item>();
}

public class ItemManager : MonoBehaviour
{
    private void Awake()
    {
        AddItems();
        SortingItems();
    }

    private void AddItems()
    {
        //Races
        ItemsList.AllItems.Add(new Item("Human", ItemType.Race, Rare.Common, 7, 5, "Sprites/Items/Human", bluntDamage: 1, slashResist: 1));

        ItemsList.AllItems.Add(new Item("Goblin", ItemType.Race, Rare.Common, 3, 3, "Sprites/Items/Goblin", slashDamage: 1, bluntResist: -1));
        ItemsList.AllItems.Add(new Item("Orc", ItemType.Race, Rare.Common, 10, 8, "Sprites/Items/Orc", bluntDamage: 2, bluntResist: 1, slashResist: -1));
        ItemsList.AllItems.Add(new Item("RedOrc", ItemType.Race, Rare.Common, 17, 12, "Sprites/Items/RedOrc", bluntDamage: 3, bluntResist: 2));
        ItemsList.AllItems.Add(new Item("Troll", ItemType.Race, Rare.Common, 20, 15, "Sprites/Items/Troll", bluntDamage: 4, earthDamage: 2, slashResist: 2, earthResist: 2, poisonResist: 3, fireResist: -5, iceResist: -3));
        ItemsList.AllItems.Add(new Item("Ogre", ItemType.Race, Rare.Common, 50, 30, "Sprites/Items/Ogre", bluntDamage: 7, slashResist: 5, fireResist: -5, waterResist: -3));
        ItemsList.AllItems.Add(new Item("Centaur", ItemType.Race, Rare.Common, 30, 15, "Sprites/Items/Centaur", pierceDamage: 4, slashResist: 3, bluntResist: 3, pierceResist: -4));

        ItemsList.AllItems.Add(new Item("HighElf", ItemType.Race, Rare.Common, 7, 5, "Sprites/Items/HighElf", slashDamage: 2, bluntResist: -1, darknessResist: -1, lightResist: 2));
        ItemsList.AllItems.Add(new Item("DarkElf", ItemType.Race, Rare.Common, 15, 10, "Sprites/Items/DarkElf", pierceDamage: 4, bluntResist: -3, poisonResist: -3, darknessResist: 2, lightResist: -1));
        ItemsList.AllItems.Add(new Item("ForestElf", ItemType.Race, Rare.Common, 10, 7, "Sprites/Items/ForestElf", poisonDamage: 3, poisonResist: 2, bluntResist: -2));

        ItemsList.AllItems.Add(new Item("Skaven", ItemType.Race, Rare.Common, 2, 2, "Sprites/Items/Skaven", slashDamage: 1, bluntResist: -1, pierceResist: -1, earthResist: 1));
        ItemsList.AllItems.Add(new Item("Black Skaven", ItemType.Race, Rare.Common, 12, 7, "Sprites/Items/Black Skaven", slashDamage: 3, bluntDamage: 2, bluntResist: -1, pierceResist: -1, earthResist: 3));

        ItemsList.AllItems.Add(new Item("CopperDwarf", ItemType.Race, Rare.Common, 9, 7, "Sprites/Items/CopperDwarf", bluntDamage: 1, bluntResist: 1));
        ItemsList.AllItems.Add(new Item("IronDwarf", ItemType.Race, Rare.Common, 12, 10, "Sprites/Items/IronDwarf", bluntDamage: 2, bluntResist: 2));
        ItemsList.AllItems.Add(new Item("GoldDwarf", ItemType.Race, Rare.Common, 21, 15, "Sprites/Items/GoldDwarf", bluntDamage: 3, bluntResist: 3));

        ItemsList.AllItems.Add(new Item("Driad", ItemType.Race, Rare.Common, 5, 5, "Sprites/Items/Driad", earthDamage: 1, poisonResist: 2));
        ItemsList.AllItems.Add(new Item("Ent", ItemType.Race, Rare.Common, 20, 15, "Sprites/Items/Ent", bluntDamage: 2, earthResist: 3, fireResist: -5));
        ItemsList.AllItems.Add(new Item("DarkEnt", ItemType.Race, Rare.Common, 25, 18, "Sprites/Items/DarkEnt", bluntDamage: 3, poisonResist: 2, fireResist: -6));

        ItemsList.AllItems.Add(new Item("Naga", ItemType.Race, Rare.Common, 15, 10, "Sprites/Items/Naga", pierceDamage: 2, poisonResist: 2, fireResist: -2));
        ItemsList.AllItems.Add(new Item("Medusa", ItemType.Race, Rare.Common, 20, 15, "Sprites/Items/Medusa", pierceDamage: 3, poisonDamage: 1, bluntResist: -1));

        ItemsList.AllItems.Add(new Item("RedDragon", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/RedDragon", fireDamage: 5, fireResist: 5, iceResist: -3));
        ItemsList.AllItems.Add(new Item("BlueDragon", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/BlueDragon", waterDamage: 5, waterResist: 5, lightResist: -2));
        ItemsList.AllItems.Add(new Item("YellowDragon", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/YellowDragon", lightDamage: 5, lightResist: 5, earthResist: -2));
        ItemsList.AllItems.Add(new Item("GreenDragon", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/GreenDragon", poisonDamage: 4, poisonResist: 4, fireResist: -2));
        ItemsList.AllItems.Add(new Item("BrownDragon", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/BrownDragon", earthDamage: 4, earthResist: 5, lightResist: -2));
        ItemsList.AllItems.Add(new Item("GreyDragon", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/GreyDragon", bluntDamage: 4, slashResist: 4, pierceResist: 3));
        ItemsList.AllItems.Add(new Item("PurpleDragon", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/PurpleDragon", darknessDamage: 5, darknessResist: 5, lightResist: -4));
        ItemsList.AllItems.Add(new Item("WhiteDragon", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/WhiteDragon", iceDamage: 5, iceResist: 5, fireResist: -3));
        ItemsList.AllItems.Add(new Item("BlackDragon", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/BlackDragon", darknessDamage: 5, poisonResist: 3, lightResist: -5));

        ItemsList.AllItems.Add(new Item("Angel", ItemType.Race, Rare.Common, 40, 35, "Sprites/Items/Angel", lightDamage: 5, lightResist: 5, darknessResist: -3));
        ItemsList.AllItems.Add(new Item("Demon", ItemType.Race, Rare.Common, 40, 35, "Sprites/Items/Demon", darknessDamage: 5, darknessResist: 5, lightResist: -3));
        ItemsList.AllItems.Add(new Item("Imp", ItemType.Race, Rare.Common, 10, 8, "Sprites/Items/Imp", fireDamage: 1, fireResist: 2));

        ItemsList.AllItems.Add(new Item("RobotMK1", ItemType.Race, Rare.Common, 20, 15, "Sprites/Items/RobotMK1", bluntDamage: 2, pierceResist: 1));
        ItemsList.AllItems.Add(new Item("RobotMK10", ItemType.Race, Rare.Common, 30, 20, "Sprites/Items/RobotMK10", bluntDamage: 3, slashResist: 2));
        ItemsList.AllItems.Add(new Item("RobotMK200", ItemType.Race, Rare.Common, 40, 30, "Sprites/Items/RobotMK200", bluntDamage: 4, fireResist: 3));
        ItemsList.AllItems.Add(new Item("RobotMK400", ItemType.Race, Rare.Common, 50, 40, "Sprites/Items/RobotMK400", bluntDamage: 5, iceResist: 2));
        ItemsList.AllItems.Add(new Item("RobotMK1000", ItemType.Race, Rare.Common, 100, 80, "Sprites/Items/RobotMK1000", bluntDamage: 10, fireResist: 5, lightResist: 5));

        ItemsList.AllItems.Add(new Item("Fire Elemental", ItemType.Race, Rare.Common, 30, 25, "Sprites/Items/FireElemental", fireDamage: 5, fireResist: 5, waterResist: -5));
        ItemsList.AllItems.Add(new Item("Water Elemental", ItemType.Race, Rare.Common, 30, 25, "Sprites/Items/WaterElemental", waterDamage: 5, waterResist: 5, fireResist: -5));
        ItemsList.AllItems.Add(new Item("Earth Elemental", ItemType.Race, Rare.Common, 30, 25, "Sprites/Items/EarthElemental", earthDamage: 5, earthResist: 5, lightResist: -3));
        ItemsList.AllItems.Add(new Item("Ice Elemental", ItemType.Race, Rare.Common, 30, 25, "Sprites/Items/IceElemental", iceDamage: 5, iceResist: 5, fireResist: -5));
        ItemsList.AllItems.Add(new Item("Poison Elemental", ItemType.Race, Rare.Common, 30, 25, "Sprites/Items/PoisonElemental", poisonDamage: 5, poisonResist: 5, lightResist: -2));
        ItemsList.AllItems.Add(new Item("Light Elemental", ItemType.Race, Rare.Common, 30, 25, "Sprites/Items/LightElemental", lightDamage: 5, lightResist: 5, darknessResist: -3));
        ItemsList.AllItems.Add(new Item("Darkness Elemental", ItemType.Race, Rare.Common, 30, 25, "Sprites/Items/DarknessElemental", darknessDamage: 5, darknessResist: 5, lightResist: -3));

        ItemsList.AllItems.Add(new Item("ZombieHuman", ItemType.Race, Rare.Common, 2, 3, "Sprites/Items/Skeleton", slashDamage: 1, bluntResist: -1));
        ItemsList.AllItems.Add(new Item("ZombieOrc", ItemType.Race, Rare.Common, 3, 4, "Sprites/Items/Skeleton", slashDamage: 2, bluntResist: -2));
        ItemsList.AllItems.Add(new Item("SkeletonHuman", ItemType.Race, Rare.Common, 2, 3, "Sprites/Items/Skeleton", pierceDamage: 1, bluntResist: -1));
        ItemsList.AllItems.Add(new Item("SkeletonOrc", ItemType.Race, Rare.Common, 3, 4, "Sprites/Items/Skeleton", pierceDamage: 2, bluntResist: -2));
        ItemsList.AllItems.Add(new Item("Vampire", ItemType.Race, Rare.Common, 5, 5, "Sprites/Items/Vampire", pierceDamage: 3, darknessResist: 3));
        ItemsList.AllItems.Add(new Item("Spirit", ItemType.Race, Rare.Common, 5, 5, "Sprites/Items/Spirit", darknessDamage: 2, lightResist: 2));


        //Weapon
        ItemsList.AllItems.Add(new Item("Weapon", ItemType.Weapon, Rare.Common, 5, 2, "Sprites/Items/Weapon"));

        //Armor
        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, Rare.Common, 5, 2, "Sprites/Items/Armor"));

        //Shield
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Sprites/Items/Shield"));

        //Special
        ItemsList.AllItems.Add(new Item("Special", ItemType.Special, Rare.Common, 5, 2, "Sprites/Items/Special"));
    }

    private void SortingItems()
    {
        foreach (Item item in ItemsList.AllItems)
        {
            if (item.Base.Type == ItemType.Race)
            {
                ItemsList.AllRace.Add(item);
            }
            else
            {
                ItemsList.AllEquipmentItems.Add(item);
            }

            switch (item.Base.Rare)
            {
                case (Rare.Common):
                    ItemsList.AllCommonItem.Add(item);
                    break;

                case (Rare.Uncommon):
                    ItemsList.AllUncommonItem.Add(item);
                    break;

                case (Rare.Rare):
                    ItemsList.AllRareItem.Add(item);
                    break;

                case (Rare.Epic):
                    ItemsList.AllEpicItem.Add(item);
                    break;

                case (Rare.Legendary):
                    ItemsList.AllLegendaryItem.Add(item);
                    break;

                case (Rare.Mythical):
                    ItemsList.AllMythicalItem.Add(item);
                    break;
            }
        }
    }
}

public enum ItemType
{
    Race = 0,
    Weapon = 1,
    Armor = 2,
    Shield = 3,
    Special = 4
} 

public enum Rare 
{
    Common = 0,
    Uncommon = 1,
    Rare = 2,
    Epic = 3,
    Legendary = 4,
    Mythical = 5
}

