using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public bool IsInArmy = false;
    public Unit MainUnitLink;

    public UnitCharacteristics unitCharacteristics = new();

    public TextMeshProUGUI Value;
    public Image UnitChosenImage;

    public Image UnitMainImage;
    public Image UnitRaceImage;
    public Image UnitWeaponImage;
    public Image UnitArmorImage;
    public Image UnitShieldImage;
    public Image UnitSpecialImage;

    public void ActiveUI()
    {
        UnitMainImage.sprite = unitCharacteristics.MainSprite;
        UnitRaceImage.sprite = unitCharacteristics.RaceSprite;

        if (unitCharacteristics.Weapon != null)
        {
            UnitWeaponImage.gameObject.SetActive(true);
            UnitWeaponImage.sprite = unitCharacteristics.WeaponSprite;
        }
        else
            UnitWeaponImage.gameObject.SetActive(false);

        if (unitCharacteristics.Armor != null)
        {
            UnitArmorImage.gameObject.SetActive(true);
            UnitArmorImage.sprite = unitCharacteristics.ArmorSprite;
        }
        else
            UnitArmorImage.gameObject.SetActive(false);

        if (unitCharacteristics.Shield != null)
        {
            UnitShieldImage.gameObject.SetActive(true);
            UnitShieldImage.sprite = unitCharacteristics.ShieldSprite;
        }
        else
            UnitShieldImage.gameObject.SetActive(false);

        if (unitCharacteristics.Special != null)
        {
            UnitSpecialImage.gameObject.SetActive(true);
            UnitSpecialImage.sprite = unitCharacteristics.SpecialSprite;
        }
        else
            UnitSpecialImage.gameObject.SetActive(false);
    }

    public Unit Copy()
    {
        Unit copy = (Unit)MemberwiseClone();

        copy.IsInArmy = IsInArmy;
        copy.unitCharacteristics = unitCharacteristics.Copy();


        //copy.UnitMainImage = UnitMainImage;
        //copy.UnitRaceImage = UnitRaceImage; 
        //copy.UnitWeaponImage = UnitWeaponImage; 
        //copy.UnitArmorImage = UnitArmorImage; 
        //copy.UnitShieldImage = UnitShieldImage; 
        //copy.UnitSpecialImage = UnitSpecialImage;

        return copy;
    }
}

public class UnitCharacteristics
{
    public int Value = 1;

    public string Name = "Unit 1";
    public int Points;

    public string RaceName = " ";
    public string WeaponName = " ";
    public string ArmorName = " ";
    public string ShieldName = " ";
    public string SpecialName = "  ";

    public Sprite MainSprite;
    public Sprite RaceSprite;
    public Sprite WeaponSprite;
    public Sprite ArmorSprite;
    public Sprite ShieldSprite;
    public Sprite SpecialSprite;

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

        copy.Race = Race.Copy();
        copy.MainSprite = MainSprite;
        copy.RaceSprite = RaceSprite;


        if (Weapon != null)
        {
            copy.Weapon = Weapon.Copy();
            copy.WeaponSprite = WeaponSprite;
        }
        if (Armor != null)
        {
            copy.Armor = Armor.Copy();
            copy.ArmorSprite = ArmorSprite;
        }
        if (Shield != null)
        {
            copy.Shield = Shield.Copy();
            copy.ShieldSprite = ShieldSprite;
        }
        if (Special != null)
        {
            copy.Special = Special.Copy();
            copy.SpecialSprite = SpecialSprite;
        }

        copy.Damages = Damages.Copy();
        copy.Resists = Resists.Copy();

        return copy;
    }
}