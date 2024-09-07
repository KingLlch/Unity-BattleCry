using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public bool IsInArmy = false;

    public UnitCharacteristics unitCharacteristics = new UnitCharacteristics();

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

    public int MaxHealth;
    public int Health;

    public Damages Damages = new Damages();

    public Resists Resists = new Resists();

    public float AttackTime;
    public int AttackRange;
    public bool IsMeleeAttack;

    public UnitCharacteristics Copy()
    {
        UnitCharacteristics copy = (UnitCharacteristics)this.MemberwiseClone();
        copy.Damages = this.Damages.Copy();
        copy.Resists = this.Resists.Copy();

        return copy;
    }
}