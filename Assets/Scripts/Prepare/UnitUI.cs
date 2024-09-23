using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public bool IsInArmy = false;
    public UnitUI MainUnitLink;

    public Unit Unit = new();

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
        UnitMainImage.gameObject.SetActive(true);
        UnitMainImage.sprite = Unit.MainSprite;
        UnitRaceImage.gameObject.SetActive(true);
        UnitRaceImage.sprite = Unit.RaceSprite;

        if (Unit.Weapon != null)
        {
            UnitWeaponImage.gameObject.SetActive(true);
            UnitWeaponImage.sprite = Unit.WeaponSprite;
        }
        else
            UnitWeaponImage.gameObject.SetActive(false);

        if (Unit.Armor != null)
        {
            UnitArmorImage.gameObject.SetActive(true);
            UnitArmorImage.sprite = Unit.ArmorSprite;
        }
        else
            UnitArmorImage.gameObject.SetActive(false);

        if (Unit.Shield != null)
        {
            UnitShieldImage.gameObject.SetActive(true);
            UnitShieldImage.sprite = Unit.ShieldSprite;
        }
        else
            UnitShieldImage.gameObject.SetActive(false);

        if (Unit.Special != null)
        {
            UnitSpecialImage.gameObject.SetActive(true);
            UnitSpecialImage.sprite = Unit.SpecialSprite;
        }
        else
            UnitSpecialImage.gameObject.SetActive(false);
    }

    public UnitUI Copy()
    {
        UnitUI copy = (UnitUI)MemberwiseClone();

        copy.IsInArmy = IsInArmy;
        copy.Unit = Unit.Copy();

        return copy;
    }
}

public class Unit
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

    public BattleUnit BattleUnit;

    public Unit Copy()
    {
        Unit copy = (Unit)MemberwiseClone();

        if (Race != null)
        {
            copy.Race = Race.Copy();
            copy.MainSprite = MainSprite;
            copy.RaceSprite = RaceSprite;
        }

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

        if(copy != null)
        {
            copy.Damages = Damages.Copy();
            copy.Resists = Resists.Copy();
        }

        return copy;
    }
}