using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public ItemInfo Race;

    public ItemInfo Weapon;
    public ItemInfo Armor;
    public ItemInfo Shield;
    public ItemInfo Special;

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
    }

    public void ChangeName(string name)
    {
        Name.text = name;
    }

    public void AddItem(ItemInfo itemInfo)
    {
        createUnit.unitCharacteristics.Value = 1;
        ChangeItemValueUI();

        if (itemInfo.ThisItem.Base.Type == ItemType.Race && itemInfo.ThisItem.Value > 0 && (Race.ThisItem == null || Race.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Race.ThisItem != null)
            {
                ChangeStats(Race.ThisItem, false);
            }

            Race.Image.sprite = itemInfo.ThisItem.Base.Sprite;
            Race = itemInfo;
            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }

        else if (itemInfo.ThisItem.Base.Type == ItemType.Weapon && itemInfo.ThisItem.Value > 0 && (Weapon.ThisItem == null || Weapon.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Weapon.ThisItem != null)
            {
                ChangeStats(Weapon.ThisItem, false);
            }

            Weapon.Image.sprite = itemInfo.ThisItem.Base.Sprite;
            Weapon = itemInfo;
            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }

        else if (itemInfo.ThisItem.Base.Type == ItemType.Armor && itemInfo.ThisItem.Value > 0 && (Armor.ThisItem == null || Armor.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Armor.ThisItem != null)
            {
                ChangeStats(Armor.ThisItem, false);
            }

            Armor.Image.sprite = itemInfo.ThisItem.Base.Sprite;
            Armor = itemInfo;
            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }

        else if (itemInfo.ThisItem.Base.Type == ItemType.Shield && itemInfo.ThisItem.Value > 0 && (Shield.ThisItem == null || Shield.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Shield.ThisItem != null)
            {
                ChangeStats(Shield.ThisItem, false);
            }

            Shield.Image.sprite = itemInfo.ThisItem.Base.Sprite;
            Shield = itemInfo;
            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }

        else if (itemInfo.ThisItem.Base.Type == ItemType.Special && itemInfo.ThisItem.Value > 0 && (Special.ThisItem == null || Special.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Special.ThisItem != null)
            {
                ChangeStats(Special.ThisItem, false);
            }

            Special.Image.sprite = itemInfo.ThisItem.Base.Sprite;
            Special = itemInfo;
            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }
    }

    private void ChangeItemValueUI()
    {
        Race.Value.text = createUnit.unitCharacteristics.Value.ToString();
        Weapon.Value.text = createUnit.unitCharacteristics.Value.ToString();
        Armor.Value.text = createUnit.unitCharacteristics.Value.ToString();
        Shield.Value.text = createUnit.unitCharacteristics.Value.ToString();
        Special.Value.text = createUnit.unitCharacteristics.Value.ToString();
    }

    public void RemoveItem(ItemInfo itemInfo)
    {
        if (Race.ThisItem != null && itemInfo.ThisItem.Base.Type == ItemType.Race)
        {
            ChangeStats(Race.ThisItem, false);
            Race.ThisItem = null;
            Race.Image.sprite = null;
        }

        if (Weapon.ThisItem != null && itemInfo.ThisItem.Base.Type == ItemType.Weapon)
        {
            ChangeStats(Weapon.ThisItem, false);
            Weapon.ThisItem = null;
            Weapon.Image.sprite = null;
        }

        if (Armor.ThisItem != null && itemInfo.ThisItem.Base.Type == ItemType.Armor)
        {
            ChangeStats(Armor.ThisItem, false);
            Armor.ThisItem = null;
            Armor.Image.sprite = null;
        }

        if (Shield.ThisItem != null && itemInfo.ThisItem.Base.Type == ItemType.Shield)
        {
            ChangeStats(Shield.ThisItem, false);
            Shield.ThisItem = null;
            Shield.Image.sprite = null;
        }
        if (Special.ThisItem != null && itemInfo.ThisItem.Base.Type == ItemType.Special)
        {
            ChangeStats(Special.ThisItem, false);
            Special.ThisItem = null;
            Special.Image.sprite = null;
        }

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
        Value.text = unit.unitCharacteristics.Value.ToString();
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
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Weapon)
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
        if ((Race.ThisItem == null || Race.ThisItem.Value > createUnit.unitCharacteristics.Value) &&
            (Weapon.ThisItem == null || Weapon.ThisItem.Value > createUnit.unitCharacteristics.Value) &&
            (Armor.ThisItem == null || Armor.ThisItem.Value > createUnit.unitCharacteristics.Value) &&
            (Shield.ThisItem == null || Shield.ThisItem.Value > createUnit.unitCharacteristics.Value) &&
            (Special.ThisItem == null || Special.ThisItem.Value > createUnit.unitCharacteristics.Value))
        {
            createUnit.unitCharacteristics.Value++;
            Value.text = createUnit.unitCharacteristics.Value.ToString();
            ChangeItemValueUI();
        }
    }

    public void RemoveValue()
    {
        if (createUnit.unitCharacteristics.Value > 1)
        {
            createUnit.unitCharacteristics.Value--;
            Value.text = createUnit.unitCharacteristics.Value.ToString();
        }
    }

    public void CreateNewUnit()
    {
        if (Race.ThisItem != null)
        {
            Race.ThisItem.Value -= createUnit.unitCharacteristics.Value;
            Race.Value.text = Race.ThisItem.Value.ToString();
        }
        else
            return;

        if (Weapon.ThisItem != null)
        {
            Weapon.ThisItem.Value -= createUnit.unitCharacteristics.Value;
            Weapon.Value.text = Weapon.ThisItem.Value.ToString();
        }
        if (Armor.ThisItem != null)
        {
            Armor.ThisItem.Value -= createUnit.unitCharacteristics.Value;
            Armor.Value.text = Armor.ThisItem.Value.ToString();
        }
        if (Shield.ThisItem != null)
        {
            Shield.ThisItem.Value -= createUnit.unitCharacteristics.Value;
            Shield.Value.text = Shield.ThisItem.Value.ToString();
        }
        if (Special.ThisItem != null)
        {
            Special.ThisItem.Value -= createUnit.unitCharacteristics.Value;
            Special.Value.text = Special.ThisItem.Value.ToString();
        }

        Unit newUnit = Instantiate(UnitPrefab, Vector2.zero, Quaternion.identity, PrepareUIManager.Instance.UnitParent).GetComponent<Unit>();
        newUnit.unitCharacteristics = createUnit.unitCharacteristics.Copy();
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
        createUnit.unitCharacteristics = new UnitCharacteristics();
        ClearUI();
    }

    private void ClearUI()
    {
        Race.ThisItem = Weapon.ThisItem = Armor.ThisItem = Shield.ThisItem = Special.ThisItem = null;
        Race.Image.sprite = Weapon.Image.sprite = Armor.Image.sprite = Shield.Image.sprite = Special.Image.sprite = null;

        Health.text = "0/0";
        Points.text = "0";
        AttackInterval.text = "0.0s";
        AttackRange.text = null;

        for (int i = 0; i < Damages.Length; i++)
        {
            Damages[i].gameObject.SetActive(false);
            DamagesGameObjects[i].SetActive(false);
            Resists[i].gameObject.SetActive(false);
            ResistsGameObjects[i].SetActive(false);
        }
    }

    public void LoadUnit(Unit loadUnit)
    {
        createUnit = loadUnit;

        Race.ThisItem = Weapon.ThisItem = Armor.ThisItem = Shield.ThisItem = Special.ThisItem = loadUnit.unitCharacteristics.Race;
    }

    public void DeleteUnit(Unit deleteUnit)
    {
        Race.ThisItem.Value += Weapon.ThisItem.Value += Armor.ThisItem.Value += Shield.ThisItem.Value += Special.ThisItem.Value += deleteUnit.unitCharacteristics.Value;
    }
}
