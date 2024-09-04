using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitCharacteristic unit = new UnitCharacteristic();

    public Sprite UnitSprite;
}

public class UnitCharacteristic
{
    public int Points;
    public string Name;

    public string Race;
    public string Weapon;
    public string Armor;
    public string Shield;
    public string Special;

    public int MaxHealth;
    public int Health;

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

    public float AttackTime;
    public int AttackRange;
    public bool IsMeleeAttack;
}