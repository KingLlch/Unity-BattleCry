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