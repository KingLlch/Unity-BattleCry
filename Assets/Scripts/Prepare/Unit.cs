using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public bool IsInArmy = false;

    public UnitCharacteristics unitCharacteristics = new UnitCharacteristics();

    public TextMeshProUGUI Value;
    public Image UnitImage;
}

public class UnitCharacteristics
{
    public int Value = 1;

    public string Name = "NUnit";
    public int Points;

    public string RaceName = "RaceName";
    public string WeaponName = "WeaponName";
    public string ArmorName = "ArmorName";
    public string ShieldName = "ShieldName";
    public string SpecialName = "SpecialName";

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