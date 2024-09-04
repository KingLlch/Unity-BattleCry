using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Base
{
    public string Name;

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

    public Item(string name, ItemType type, int points, int health, string spritePath,
            float attackTime, int attackRange, bool isMeleeAttack,
            int pierceDamage = 0, int slashDamage = 0, int bluntDamage = 0, int fireDamage = 0, int iceDamage = 0, int earthDamage = 0, int poisonDamage = 0, int waterDamage = 0, int lightDamage = 0, int darknessDamage = 0,
            int pierceResist = 0, int slashResist = 0, int bluntResist = 0, int fireResist = 0, int iceResist = 0, int earthResist = 0, int poisonResist = 0, int waterResist = 0, int lightResist = 0, int darknessResist = 0)
    {
        Base = new Base
        {
            Name = name,
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
    public static List<Item> AllItems = new List<Item>();
}

public class ItemManager: MonoBehaviour
{
    private void Awake()
    {
        ItemsList.AllItems.Add(new Item("g",ItemType.Race,0,0,"Sprites/Items/name1",0,0,true));

        ItemsList.AllItems.Add(new Item("t", ItemType.Weapon, 0, 0, "Sprites/Items/name2", 0, 0, true));

        ItemsList.AllItems.Add(new Item("r", ItemType.Shield, 0, 0, "Sprites/Items/name3", 0, 0, true));
    }
}
