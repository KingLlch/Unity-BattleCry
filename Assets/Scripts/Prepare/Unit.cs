using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool IsInArmy = false;

    public UnitCharacteristics unitCharacteristics = new UnitCharacteristics();

    public Sprite UnitSprite;
}

public class UnitCharacteristics
{
    public int Points;
    public string Name;

    public string RaceName;
    public string WeaponName;
    public string ArmorName;
    public string ShieldName;
    public string SpecialName;

    public Item Race;
    public Item Weapon;
    public Item Armor;
    public Item Shield;
    public Item Special;

    public int MaxHealth;
    public int Health;

    public Damages Damages = new Damages();

    public Resists Resists = new Resists();

    public float AttackTime;
    public int AttackRange;
    public bool IsMeleeAttack;
}