using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public bool IsInArmy = false;
    public Unit MainUnitLink;

    public UnitCharacteristics unitCharacteristics = new();

    public TextMeshProUGUI Value;
    public Image UnitImage;
    public Image UnitImageEdge;
}

public class UnitCharacteristics
{
    public int Value = 1;

    public string Name = "N Unit";
    public int Points;

    public string RaceName = " ";
    public string WeaponName = " ";
    public string ArmorName = " ";
    public string ShieldName = " ";
    public string SpecialName = "  ";

    public Item Race;
    public Item Weapon;
    public Item Armor;
    public Item Shield;
    public Item Special;

    public ItemInfo RaceLink;
    public ItemInfo WeaponLink;
    public ItemInfo ArmorLink;
    public ItemInfo ShieldLink;
    public ItemInfo SpecialLink;

    public int MaxHealth;
    public int Health;

    public Damages Damages = new();

    public Resists Resists = new();

    public float AttackTime;
    public int AttackRange;
    public bool IsMeleeAttack;

    public UnitCharacteristics Copy()
    {
        UnitCharacteristics copy = (UnitCharacteristics)MemberwiseClone();

        if (Race != null)
            copy.Race = Race.Copy();
        if (Weapon != null)
            copy.Weapon = Weapon.Copy();
        if (Armor != null)
            copy.Armor = Armor.Copy();
        if (Shield != null)
            copy.Shield = Shield.Copy();
        if (Special != null)
            copy.Special = Special.Copy();

        copy.Damages = Damages.Copy();
        copy.Resists = Resists.Copy();

        return copy;
    }
}