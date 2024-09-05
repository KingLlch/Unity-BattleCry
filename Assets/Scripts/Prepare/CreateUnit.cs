using System;
using System.Diagnostics;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

public class CreateUnit : MonoBehaviour
{

    private static CreateUnit _instance;

    public static CreateUnit Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CreateUnit>();
            }

            return _instance;
        }
    }

    public Item Race;

    public Item Weapon;
    public Item Armor;
    public Item Shield;
    public Item Special;

    public Image RaceImage;
    public Image WeaponImage;
    public Image ArmorImage;
    public Image ShieldImage;
    public Image SpecialImage;

    public Unit createUnit;

    public TextMeshProUGUI Value;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Points;

    public TextMeshProUGUI Health;

    public TextMeshProUGUI AttackRange;
    public TextMeshProUGUI AttackInterval;

    public GameObject[] DamagesGameObjects;
    public TextMeshProUGUI[] Damages;

    public GameObject[] ResistsGameObjects;
    public TextMeshProUGUI[] Resists;

    public Transform RacesGrid;
    public Transform ItemsGrid;

    public GameObject UnitPrefab;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        createUnit = new Unit();
    }

    public void ChangeName(string name)
    {
        Name.text = name;
    }

    public void AddItem(Item item)
    {
        if (item.Base.Type == ItemType.Race && item.Value > 0 && (Race == null || Race.Base.Name != item.Base.Name))
        {
            if (Race != null)
            {
                ChangeStats(Race, false);
                //Race.Value++;
            }

            RaceImage.sprite = item.Base.Sprite;
            Race = item;
            //item.Value--;
        }

        else if (item.Base.Type == ItemType.Weapon && item.Value > 0 && (Weapon == null || Weapon.Base.Name != item.Base.Name))
        {
            if (Weapon != null)
            {
                ChangeStats(Weapon, false);
                //Weapon.Value++;
            }

            WeaponImage.sprite = item.Base.Sprite;
            Weapon = item;
            //item.Value--;
        }

        else if (item.Base.Type == ItemType.Armor && item.Value > 0 && (Armor == null || Armor.Base.Name != item.Base.Name))
        {
            if (Armor != null)
            {
                ChangeStats(Armor, false);
                //Armor.Value++;
            }

            ArmorImage.sprite = item.Base.Sprite;
            Armor = item;
            //item.Value--;
        }

        else if (item.Base.Type == ItemType.Shield && item.Value > 0 && (Shield == null || Shield.Base.Name != item.Base.Name))
        {
            if (Shield != null)
            {
                ChangeStats(Shield, false);
                //Shield.Value++;
            }

            ShieldImage.sprite = item.Base.Sprite;
            Shield = item;
            //item.Value--;
        }

        else if (item.Base.Type == ItemType.Special && item.Value > 0 && (Special == null || Special.Base.Name != item.Base.Name))
        {
            if (Special != null)
            {
                ChangeStats(Special, false);
                //Special.Value++;
            }

            SpecialImage.sprite = item.Base.Sprite;
            Special = item;
            //item.Value--;
        }

        ChangeStats(item, true);
        ChangeUI(createUnit);
    }

    public void ChangeStats(Item item, bool isAdd)
    {
        if (isAdd)
        {

            createUnit.unitCharacteristics.Points += item.Base.Points;
            createUnit.unitCharacteristics.Health += item.Base.Health;
            createUnit.unitCharacteristics.MaxHealth += item.Base.Health;

            Damages damages = createUnit.unitCharacteristics.Damages;
            Type damageType = damages.GetType();
            FieldInfo[] damageFields = damageType.GetFields();

            Damages damagesItem = item.Damages;
            Type damageTypeItem = damagesItem.GetType();
            FieldInfo[] damageFieldsItem = damageTypeItem.GetFields();

            for (int i = 0; i < Damages.Length; i++)
            {
                int currentDamageValue = (int)damageFields[i].GetValue(damages);
                int itemDamageValue = (int)damageFieldsItem[i].GetValue(damagesItem);

                int resultValue = currentDamageValue + itemDamageValue;

                damageFields[i].SetValueDirect(__makeref(damages), resultValue);
            }

            Resists resists = createUnit.unitCharacteristics.Resists;
            Type resistType = resists.GetType();
            FieldInfo[] resistFields = resistType.GetFields();

            Resists resistsItem = item.Resists;
            Type resistTypeItem = resistsItem.GetType();
            FieldInfo[] resistFieldsItem = resistTypeItem.GetFields();

            for (int i = 0; i < resistFields.Length; i++)
            {
                int currentResistValue = (int)resistFields[i].GetValue(resists);
                int itemResistValue = (int)resistFieldsItem[i].GetValue(resistsItem);

                int resultValue = currentResistValue + itemResistValue;

                resistFields[i].SetValueDirect(__makeref(resists), resultValue);
            }

            createUnit.unitCharacteristics.AttackTime = item.Weapon.AttackTime;
            createUnit.unitCharacteristics.AttackRange = item.Weapon.AttackRange;
        }

        else
        {
            createUnit.unitCharacteristics.Points -= item.Base.Points;
            createUnit.unitCharacteristics.Health -= item.Base.Health;
            createUnit.unitCharacteristics.MaxHealth -= item.Base.Health;

            Damages damages = createUnit.unitCharacteristics.Damages;
            Type damageType = damages.GetType();
            FieldInfo[] damageFields = damageType.GetFields();

            Damages damagesItem = item.Damages;
            Type damageTypeItem = damagesItem.GetType();
            FieldInfo[] damageFieldsItem = damageTypeItem.GetFields();

            for (int i = 0; i < Damages.Length; i++)
            {
                int currentDamageValue = (int)damageFields[i].GetValue(damages);
                int itemDamageValue = (int)damageFieldsItem[i].GetValue(damagesItem);

                int resultValue = currentDamageValue - itemDamageValue;

                damageFields[i].SetValueDirect(__makeref(damages), resultValue);
            }

            Resists resists = createUnit.unitCharacteristics.Resists;
            Type resistType = resists.GetType();
            FieldInfo[] resistFields = resistType.GetFields();

            Resists resistsItem = item.Resists;
            Type resistTypeItem = resistsItem.GetType();
            FieldInfo[] resistFieldsItem = resistTypeItem.GetFields();

            for (int i = 0; i < resistFields.Length; i++)
            {
                int currentResistValue = (int)resistFields[i].GetValue(resists);
                int itemResistValue = (int)resistFieldsItem[i].GetValue(resistsItem);

                int resultValue = currentResistValue - itemResistValue;

                resistFields[i].SetValueDirect(__makeref(resists), resultValue);
            }

            createUnit.unitCharacteristics.AttackTime = item.Weapon.AttackTime;
            createUnit.unitCharacteristics.AttackRange = item.Weapon.AttackRange;
        }
    }

    public void ChangeUI(Unit unit)
    {
        Points.text = unit.unitCharacteristics.Points.ToString();
        Health.text = unit.unitCharacteristics.Health + " / " + unit.unitCharacteristics.MaxHealth;

        Damages damages = unit.unitCharacteristics.Damages;
        Type damageType = damages.GetType();
        FieldInfo[] damagefields = damageType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if ((int)damagefields[i].GetValue(damages) != 0)
            {
                DamagesGameObjects[i].SetActive(true);
                Damages[i].gameObject.SetActive(true);
                Damages[i].text = ((int)damagefields[i].GetValue(damages)).ToString();
            }
            else
            {
                Damages[i].gameObject.SetActive(false);
                DamagesGameObjects[i].SetActive(false);
            }
        }

        Resists resists = unit.unitCharacteristics.Resists;
        Type resistType = resists.GetType();
        FieldInfo[] resistfields = resistType.GetFields();

        for (int i = 0; i < Damages.Length; i++)
        {
            if ((int)resistfields[i].GetValue(resists) != 0)
            {
                ResistsGameObjects[i].SetActive(true);
                Resists[i].gameObject.SetActive(true);
                Resists[i].text = ((int)resistfields[i].GetValue(resists)).ToString();
            }
            else
            {
                Resists[i].gameObject.SetActive(false);
                ResistsGameObjects[i].SetActive(false);
            }
        }

        AttackInterval.text = unit.unitCharacteristics.AttackTime.ToString();
        AttackRange.text = unit.unitCharacteristics.AttackRange.ToString();
    }

    public void ClearRace()
    {
        if (Race != null)
        {
            ChangeStats(Race, false);
            Race = null;
        }
    }

    public void ClearWeapon()
    {
        if (Weapon != null)
        {
            ChangeStats(Weapon, false);
            Weapon = null;
        }
    }

    public void ClearArmor()
    {
        if (Armor != null)
        {
            ChangeStats(Armor, false);
            Armor = null;
        }
    }

    public void ClearShield()
    {
        if (Shield != null)
        {
            ChangeStats(Shield, false);
            Shield = null;
        }
    }

    public void ClearSpecial()
    {
        if (Special != null)
        {
            ChangeStats(Special, false);
            Special = null;
        }
    }

    public void AllItems()
    {
        foreach (Transform item in ItemsGrid.transform)
        {
            item.gameObject.SetActive(true);
        }  
    }

    public void WeaponItems()
    {
        foreach (Transform item in ItemsGrid.transform)
        {
            if(item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Weapon)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }

    public void ArmorItems()
    {
        foreach (Transform item in ItemsGrid.transform)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Armor)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }

    public void ShieldItems()
    {
        foreach (Transform item in ItemsGrid.transform)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Shield)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }

    public void SpecialItems()
    {
        foreach (Transform item in ItemsGrid.transform)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Special)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }

    public void AddValue()
    {
        if ((Race == null || Race.Value > createUnit.unitCharacteristics.Value) && 
            (Weapon == null || Weapon.Value > createUnit.unitCharacteristics.Value) && 
            (Armor == null || Armor.Value > createUnit.unitCharacteristics.Value) && 
            (Shield == null || Shield.Value > createUnit.unitCharacteristics.Value) && 
            (Special == null || Special.Value > createUnit.unitCharacteristics.Value))
        {
            createUnit.unitCharacteristics.Value++;
            Value.text = createUnit.unitCharacteristics.Value.ToString();
        }
    }

    public void RemoveValue()
    {
        if(createUnit.unitCharacteristics.Value > 1)
        {
            createUnit.unitCharacteristics.Value--;
            Value.text = createUnit.unitCharacteristics.Value.ToString();
        }
    }

    public void CreateNewUnit()
    {
        Race.Value -= createUnit.unitCharacteristics.Value;
        Weapon.Value -= createUnit.unitCharacteristics.Value;
        Armor.Value -= createUnit.unitCharacteristics.Value;
        Shield.Value -= createUnit.unitCharacteristics.Value;
        Special.Value -= createUnit.unitCharacteristics.Value;

        Unit newUnit = Instantiate(UnitPrefab, Vector2.zero, Quaternion.identity, PrepareUIManager.Instance.UnitParent).GetComponent<Unit>();
        newUnit = createUnit;
        newUnit.UnitImage.sprite = createUnit.UnitImage.sprite;
        newUnit.GetComponent<RectTransform>().localPosition = Vector3.zero;
        CloseCreateUnitPanel();
    }

    public void CloseCreateUnitPanel()
    {
        ClearCreateUnit();
        gameObject.SetActive(false);
    }

    public void ClearCreateUnit()
    {
        Race = null;

        Weapon = null;
        Armor = null;
        Shield = null;
        Special = null;

        createUnit = new Unit();
    }

    public void LoadUnit(Unit loadUnit)
    {
        createUnit = loadUnit;

        Race = loadUnit.unitCharacteristics.Race;

        Weapon = loadUnit.unitCharacteristics.Weapon;
        Armor = loadUnit.unitCharacteristics.Armor;
        Shield = loadUnit.unitCharacteristics.Shield;
        Special = loadUnit.unitCharacteristics.Special;
    }

    public void DeleteUnit(Unit deleteUnit)
    {
        Race.Value += deleteUnit.unitCharacteristics.Value;
        Weapon.Value += deleteUnit.unitCharacteristics.Value;
        Armor.Value += deleteUnit.unitCharacteristics.Value;
        Shield.Value += deleteUnit.unitCharacteristics.Value;
        Special.Value += deleteUnit.unitCharacteristics.Value;
    }
}
