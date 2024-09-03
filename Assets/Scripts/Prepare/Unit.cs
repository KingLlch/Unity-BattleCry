using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [HideInInspector] public int Points;
    [HideInInspector] public string Name;

    [HideInInspector] public string Race;
    [HideInInspector] public string Weapon;
    [HideInInspector] public string Armor;
    [HideInInspector] public string Shield;
    [HideInInspector] public string Special;

    [HideInInspector] public int MaxHealth;
    [HideInInspector] public int Health;

    [HideInInspector] public int PierceDamage;
    [HideInInspector] public int SlashDamage;
    [HideInInspector] public int BluntDamage;
    [HideInInspector] public int FireDamage;
    [HideInInspector] public int IceDamage;
    [HideInInspector] public int EarthDamage;
    [HideInInspector] public int WaterDamage;
    [HideInInspector] public int LightDamage;
    [HideInInspector] public int DarknessDamage;

    [HideInInspector] public int PierceResist;
    [HideInInspector] public int SlashResist;
    [HideInInspector] public int BluntResist;
    [HideInInspector] public int FireResist;
    [HideInInspector] public int IceResist;
    [HideInInspector] public int EarthResist;
    [HideInInspector] public int WaterResist;
    [HideInInspector] public int LightResist;
    [HideInInspector] public int DarknessResist;
}