using System.Collections.Generic;
using UnityEngine;

public struct Base
{
    public string Name;
    public string Description;

    public ItemType Type;
    public Sprite Sprite;

    public int Points;
    public int Health;
}

public struct Weapon
{
    public float AttackTime;
    public int AttackRange;
    public bool IsMeleeAttack;
}

public struct Damages
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
}

public struct Resists
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
}

public struct Item
{
    public Base Base;
    public Weapon Weapon;
    public Resists Resists;
    public Damages Damages;

    public Item(string name, ItemType type, int points, int health, string spritePath, string description = "desc",
            float attackTime = 1, int attackRange = 1, bool isMeleeAttack = true,
            int pierceDamage = 0, int slashDamage = 0, int bluntDamage = 0, int fireDamage = 0, int iceDamage = 0, int earthDamage = 0, int poisonDamage = 0, int waterDamage = 0, int lightDamage = 0, int darknessDamage = 0,
            int pierceResist = 0, int slashResist = 0, int bluntResist = 0, int fireResist = 0, int iceResist = 0, int earthResist = 0, int poisonResist = 0, int waterResist = 0, int lightResist = 0, int darknessResist = 0)
    {
        Base = new Base
        {
            Name = name,
            Description = description,
            Type = type,
            Points = points,
            Health = health,
            Sprite = Resources.Load<Sprite>(spritePath)
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
}

public static class ItemsList
{
    public static List<Item> AllRace = new List<Item>();

    public static List<Item> AllItems = new List<Item>();
}

public class ItemManager: MonoBehaviour
{
    private void Awake()
    {
        ItemsList.AllRace.Add(new Item("Human",ItemType.Race, 5, 5,"Sprites/Items/Human", bluntDamage:1, bluntResist:1));

        ItemsList.AllRace.Add(new Item("Skeleton", ItemType.Race, 2, 3, "Sprites/Items/Skeleton", slashDamage: 1, bluntResist: -1));

        ItemsList.AllItems.Add(new Item("Armor", ItemType.Armor, 5, 2, "Sprites/Items/Human", poisonResist:3));
    }
}
