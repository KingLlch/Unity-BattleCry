using System.Collections.Generic;
using UnityEngine;

public class Value
{
    public int ItemValue;
}

public class Base
{
    public string Name;
    public string Description;

    public ItemType Type;
    public Rare Rare;

    public Sprite MainUnitSprite;

    public Sprite ItemSprite;
    public Sprite ItemUISprite;

    public int Points;
    public int Health;

    public Base Copy()
    {
        Base copy = (Base)this.MemberwiseClone();
        return copy;
    }
}

public class Weapon
{
    public bool IsWeapon;

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
    public Value Value;
    public Base Base;
    public Weapon Weapon;
    public Resists Resists;
    public Damages Damages;

    public Item(string name, ItemType type, Rare rare, int points, int health, string spritePath, string spriteUnitColorPath = "White", string description = "desc",
            float attackTime = 1, int attackRange = 1, bool isMeleeAttack = true,
            int pierceDamage = 0, int slashDamage = 0, int bluntDamage = 0, int fireDamage = 0, int iceDamage = 0, int earthDamage = 0, int poisonDamage = 0, int waterDamage = 0, int lightDamage = 0, int darknessDamage = 0,
            int pierceResist = 0, int slashResist = 0, int bluntResist = 0, int fireResist = 0, int iceResist = 0, int earthResist = 0, int poisonResist = 0, int waterResist = 0, int lightResist = 0, int darknessResist = 0,
            bool isWeapon = false)
    {
        Base = new Base
        {
            Name = name,
            Description = description,
            Type = type,
            Rare = rare,
            Points = points,
            Health = health,
            ItemUISprite = Resources.Load<Sprite>("Sprites/ItemsUI/" + spritePath),
            ItemSprite = Resources.Load<Sprite>("Sprites/Items/" + spritePath),
            MainUnitSprite = Resources.Load<Sprite>("Sprites/Items/Main/" + spriteUnitColorPath)
        };

        Value = new Value
        {
            ItemValue = 10
        };

        Weapon = new Weapon
        {
            IsWeapon = isWeapon,
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
    public static bool IsItemsAdded;

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

    }

    private void Start()
    {
        if (!ItemsList.IsItemsAdded)
        {
            AddItems();
            ItemsList.IsItemsAdded = true;
        }

        SortingItems();     
    }

    private void AddItems()
    {
        //Races
        ItemsList.AllItems.Add(new Item("Human", ItemType.Race, Rare.Common, 7, 5, "Races/Human", "White", bluntDamage: 1, slashResist: 1));

        ItemsList.AllItems.Add(new Item("Goblin", ItemType.Race, Rare.Common, 3, 3, "Races/Goblin", "Green", slashDamage: 1, bluntResist: -1));
        ItemsList.AllItems.Add(new Item("Orc", ItemType.Race, Rare.Common, 10, 8, "Races/Orc", "DarkGreen", bluntDamage: 2, bluntResist: 1, slashResist: -1));
        ItemsList.AllItems.Add(new Item("RedOrc", ItemType.Race, Rare.Rare, 17, 12, "Races/RedOrc", "Red", bluntDamage: 3, bluntResist: 2));
        ItemsList.AllItems.Add(new Item("Troll", ItemType.Race, Rare.Epic, 20, 15, "Races/Troll", "DarkGreen", bluntDamage: 4, earthDamage: 2, slashResist: 2, earthResist: 2, poisonResist: 3, fireResist: -5, iceResist: -3));
        ItemsList.AllItems.Add(new Item("Stone Troll", ItemType.Race, Rare.Epic, 20, 15, "Races/StoneTroll", "Grey", bluntDamage: 4, earthDamage: 2, slashResist: 2, earthResist: 2, poisonResist: 3, fireResist: -5, iceResist: -3));
        ItemsList.AllItems.Add(new Item("Ogre", ItemType.Race, Rare.Legendary, 50, 30, "Races/Ogre", "DarkYellow", bluntDamage: 7, slashResist: 5, fireResist: -5, waterResist: -3));
        //ItemsList.AllItems.Add(new Item("Centaur", ItemType.Race, Rare.Epic, 30, 15, "Races/Centaur","White", pierceDamage: 4, slashResist: 3, bluntResist: 3, pierceResist: -4));

        ItemsList.AllItems.Add(new Item("HighElf", ItemType.Race, Rare.Uncommon, 7, 5, "Races/HighElf", "SnowWhite", slashDamage: 2, bluntResist: -1, darknessResist: -1, lightResist: 2));
        ItemsList.AllItems.Add(new Item("DarkElf", ItemType.Race, Rare.Epic, 15, 10, "Races/DarkElf",  "Purple", pierceDamage: 4, bluntResist: -3, poisonResist: -3, darknessResist: 2, lightResist: -1));
        ItemsList.AllItems.Add(new Item("ForestElf", ItemType.Race, Rare.Rare, 10, 7, "Races/ForestElf",  "Green", poisonDamage: 3, poisonResist: 2, bluntResist: -2));

        ItemsList.AllItems.Add(new Item("Skaven", ItemType.Race, Rare.Common, 2, 2, "Races/Skaven", "Grey", slashDamage: 1, bluntResist: -1, pierceResist: -1, earthResist: 1));
        ItemsList.AllItems.Add(new Item("Black Skaven", ItemType.Race, Rare.Epic, 12, 7, "Races/BlackSkaven", "Black", slashDamage: 3, bluntDamage: 2, bluntResist: -1, pierceResist: -1));
        ItemsList.AllItems.Add(new Item("White Skaven", ItemType.Race, Rare.Mythical, 12, 7, "Races/WhiteSkaven", "SnowWhite", slashDamage: 3, bluntDamage: 2, bluntResist: -1, pierceResist: -1));

        ItemsList.AllItems.Add(new Item("CopperDwarf", ItemType.Race, Rare.Uncommon, 9, 7, "Races/CopperDwarf",  "Brown", bluntDamage: 1, bluntResist: 1));
        ItemsList.AllItems.Add(new Item("IronDwarf", ItemType.Race, Rare.Rare, 12, 10, "Races/IronDwarf",  "Grey", bluntDamage: 2, bluntResist: 2));
        ItemsList.AllItems.Add(new Item("GoldDwarf", ItemType.Race, Rare.Legendary, 21, 15, "Races/GoldDwarf",  "DarkYellow", bluntDamage: 3, bluntResist: 3));

        ItemsList.AllItems.Add(new Item("Dryad", ItemType.Race, Rare.Uncommon, 5, 5, "Races/Dryad",  "Brown", earthDamage: 1, poisonResist: 2));
        ItemsList.AllItems.Add(new Item("Ent", ItemType.Race, Rare.Rare, 20, 15, "Races/Ent", "Brown", bluntDamage: 2, earthResist: 3, fireResist: -5));
        ItemsList.AllItems.Add(new Item("DarkEnt", ItemType.Race, Rare.Epic, 25, 18, "Races/DarkEnt",  "Purple", bluntDamage: 3, poisonResist: 2, fireResist: -6));

        ItemsList.AllItems.Add(new Item("Naga", ItemType.Race, Rare.Mythical, 15, 10, "Races/Naga",  "Blue", pierceDamage: 2, poisonResist: 2, fireResist: -2));
        //ItemsList.AllItems.Add(new Item("Medusa", ItemType.Race, Rare.Rare, 20, 15, "Races/Medusa","White", pierceDamage: 3, poisonDamage: 1, bluntResist: -1));

        ItemsList.AllItems.Add(new Item("RedDragon", ItemType.Race, Rare.Mythical, 50, 40, "Races/RedDragon",  "Red", fireDamage: 5, fireResist: 5, iceResist: -3));
        ItemsList.AllItems.Add(new Item("BlueDragon", ItemType.Race, Rare.Mythical, 50, 40, "Races/BlueDragon",  "Blue", waterDamage: 5, waterResist: 5, lightResist: -2));
        ItemsList.AllItems.Add(new Item("YellowDragon", ItemType.Race, Rare.Mythical, 50, 40, "Races/YellowDragon",  "Yellow", lightDamage: 5, lightResist: 5, earthResist: -2));
        ItemsList.AllItems.Add(new Item("GreenDragon", ItemType.Race, Rare.Mythical, 50, 40, "Races/GreenDragon",  "Green", poisonDamage: 4, poisonResist: 4, fireResist: -2));
        ItemsList.AllItems.Add(new Item("BrownDragon", ItemType.Race, Rare.Mythical, 50, 40, "Races/BrownDragon",  "Brown", earthDamage: 4, earthResist: 5, lightResist: -2));
        ItemsList.AllItems.Add(new Item("GreyDragon", ItemType.Race, Rare.Mythical, 50, 40, "Races/GreyDragon",  "Grey", bluntDamage: 4, slashResist: 4, pierceResist: 3));
        ItemsList.AllItems.Add(new Item("PurpleDragon", ItemType.Race, Rare.Mythical, 50, 40, "Races/PurpleDragon",  "Purple", darknessDamage: 5, darknessResist: 5, lightResist: -4));
        ItemsList.AllItems.Add(new Item("WhiteDragon", ItemType.Race, Rare.Mythical, 50, 40, "Races/WhiteDragon", "SnowWhite", iceDamage: 5, iceResist: 5, fireResist: -3));
        ItemsList.AllItems.Add(new Item("BlackDragon", ItemType.Race, Rare.Mythical, 50, 40, "Races/BlackDragon",  "Black", darknessDamage: 5, poisonResist: 3, lightResist: -5));

        ItemsList.AllItems.Add(new Item("Angel", ItemType.Race, Rare.Common, 40, 35, "Races/Angel",  "White", lightDamage: 5, lightResist: 5, darknessResist: -3));
        ItemsList.AllItems.Add(new Item("Demon", ItemType.Race, Rare.Common, 40, 35, "Races/Demon",  "Red", darknessDamage: 5, darknessResist: 5, lightResist: -3));
        ItemsList.AllItems.Add(new Item("Imp", ItemType.Race, Rare.Common, 10, 8, "Races/Imp",  "Red", fireDamage: 1, fireResist: 2));

        ItemsList.AllItems.Add(new Item("RobotMK1", ItemType.Race, Rare.Common, 20, 15, "Races/Robot1",  "Grey", bluntDamage: 2, pierceResist: 1));
        ItemsList.AllItems.Add(new Item("RobotMK10", ItemType.Race, Rare.Uncommon, 30, 20, "Races/Robot2", "Grey", bluntDamage: 3, slashResist: 2));
        ItemsList.AllItems.Add(new Item("RobotMK200", ItemType.Race, Rare.Rare, 40, 30, "Races/Robot3", "Grey", bluntDamage: 4, fireResist: 3));
        ItemsList.AllItems.Add(new Item("RobotMK400", ItemType.Race, Rare.Epic, 50, 40, "Races/Robot4", "Grey", bluntDamage: 5, iceResist: 2));
        ItemsList.AllItems.Add(new Item("RobotMK2000", ItemType.Race, Rare.Legendary, 70, 70, "Races/Robot5", "Grey", bluntDamage: 5, iceResist: 2));
        ItemsList.AllItems.Add(new Item("RobotMK10000", ItemType.Race, Rare.Mythical, 100, 80, "Races/Robot6", "Grey", bluntDamage: 10, fireResist: 5, lightResist: 5));

        ItemsList.AllItems.Add(new Item("Fire Elemental", ItemType.Race, Rare.Rare, 30, 25, "Races/FireElemental",  "Red", fireDamage: 5, fireResist: 5, waterResist: -5));
        ItemsList.AllItems.Add(new Item("Water Elemental", ItemType.Race, Rare.Rare, 30, 25, "Races/WaterElemental",  "Blue", waterDamage: 5, waterResist: 5, fireResist: -5));
        ItemsList.AllItems.Add(new Item("Earth Elemental", ItemType.Race, Rare.Rare, 30, 25, "Races/EarthElemental",  "Brown", earthDamage: 5, earthResist: 5, lightResist: -3));
        ItemsList.AllItems.Add(new Item("Ice Elemental", ItemType.Race, Rare.Rare, 30, 25, "Races/IceElemental",  "SnowWhite", iceDamage: 5, iceResist: 5, fireResist: -5));
        ItemsList.AllItems.Add(new Item("Poison Elemental", ItemType.Race, Rare.Rare, 30, 25, "Races/PoisonElemental",  "Green", poisonDamage: 5, poisonResist: 5, lightResist: -2));
        ItemsList.AllItems.Add(new Item("Light Elemental", ItemType.Race, Rare.Rare, 30, 25, "Races/LightElemental",  "Yellow", lightDamage: 5, lightResist: 5, darknessResist: -3));
        ItemsList.AllItems.Add(new Item("Darkness Elemental", ItemType.Race, Rare.Rare, 30, 25, "Races/DarknessElemental",  "Purple", darknessDamage: 5, darknessResist: 5, lightResist: -3));

        ItemsList.AllItems.Add(new Item("ZombieHuman", ItemType.Race, Rare.Common, 2, 3, "Races/Zombie",  "Green", slashDamage: 1, bluntResist: -1));
        ItemsList.AllItems.Add(new Item("ZombieOrc", ItemType.Race, Rare.Common, 3, 4, "Races/OrcZombie",  "DarkGreen", slashDamage: 2, bluntResist: -2));
        ItemsList.AllItems.Add(new Item("SkeletonHuman", ItemType.Race, Rare.Common, 2, 3, "Races/Skeleton", "SnowWhite", pierceDamage: 1, bluntResist: -1));
        ItemsList.AllItems.Add(new Item("SkeletonOrc", ItemType.Race, Rare.Common, 3, 4, "Races/OrcSkeleton", "SnowWhite", pierceDamage: 2, bluntResist: -2));
        ItemsList.AllItems.Add(new Item("Vampire", ItemType.Race, Rare.Legendary, 5, 5, "Races/Vampire",  "SnowWhite", pierceDamage: 3, darknessResist: 3));
        ItemsList.AllItems.Add(new Item("AlphaVampire", ItemType.Race, Rare.Mythical, 5, 5, "Races/AlphaVampire", "SnowWhite", pierceDamage: 3, darknessResist: 3));
        ItemsList.AllItems.Add(new Item("Spirit", ItemType.Race, Rare.Epic, 5, 5, "Races/Spirit",  "Blue", darknessDamage: 2, lightResist: 2));


        //Weapon
        ItemsList.AllItems.Add(new Item("Iron Sword", ItemType.Weapon, Rare.Common, 5, 2, "Weapons/Sword",  attackRange: 1, slashDamage: 1));
        ItemsList.AllItems.Add(new Item("Iron Spear", ItemType.Weapon, Rare.Common, 5, 2, "Weapons/Spear",  attackRange: 2, pierceDamage: 1));
        ItemsList.AllItems.Add(new Item("Iron Mace", ItemType.Weapon, Rare.Common, 5, 2, "Weapons/Mace",  attackRange: 1, bluntDamage: 1));

        //Armor
        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, Rare.Common, 5, 2, "Armors/WhiteArmor"));
        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, Rare.Common, 5, 2, "Armors/YellowArmor"));
        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, Rare.Common, 5, 2, "Armors/PurpleArmor"));
        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, Rare.Common, 5, 2, "Armors/RedArmor"));
        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, Rare.Common, 5, 2, "Armors/GreenArmor"));
        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, Rare.Common, 5, 2, "Armors/GreyArmor"));
        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, Rare.Common, 5, 2, "Armors/BlueArmor"));
        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, Rare.Common, 5, 2, "Armors/BrownArmor"));

        //Shield
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Shields/WhiteShield"));
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Shields/YellowShield"));
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Shields/PurpleShield"));
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Shields/RedShield"));
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Shields/GreenShield"));
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Shields/BlueShield"));
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Shields/DarkBlueShield"));
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Shields/GreyShield"));
        ItemsList.AllItems.Add(new Item("Shield", ItemType.Shield, Rare.Common, 5, 2, "Shields/BrownShield"));

        //Special
        ItemsList.AllItems.Add(new Item("Special", ItemType.Special, Rare.Common, 5, 2, "Specials/Special"));
    }

    public void SortingItems()
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

