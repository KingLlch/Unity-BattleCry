using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public CellUI cell;

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

    public Damages Damages = new Damages();

    public Resists Resists = new Resists();

    public float AttackTime;
    public int AttackRange;
    public bool IsMeleeAttack;
}