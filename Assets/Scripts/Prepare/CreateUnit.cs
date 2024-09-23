using System;
using System.Reflection;
using TMPro;
using UnityEngine;

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

    public GameObject createUnitGameObject;

    public ItemInfo Race;
    public ItemInfo Weapon;
    public ItemInfo Armor;
    public ItemInfo Shield;
    public ItemInfo Special;

    private ItemInfo RaceLink;
    private ItemInfo WeaponLink;
    private ItemInfo ArmorLink;
    private ItemInfo ShieldLink;
    private ItemInfo SpecialLink;

    public UnitUI createUnit;
    public UnitUI loadUnit;

    public TextMeshProUGUI Value;

    public TextMeshProUGUI NamePlaceholder;
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

    public bool IsEditUnit;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        ClearUI();
    }

    public void Enable()
    {
        createUnitGameObject.SetActive(true);

        SetName();
        ChangeValueItems();
    }

    public void SetName()
    {
        createUnit.Unit.Name = "Unit " + PrepareManager.Instance.Army.UnitNameNumber;
        NamePlaceholder.text = createUnit.Unit.Name + "...";
    }

    public void ChangeName(string name)
    {
        Name.text = name;
        createUnit.Unit.Name = name;
    }

    public void AddItem(ItemInfo itemInfo)
    {
        createUnit.Unit.Value = 1;
        ChangeItemValueUI();

        if (itemInfo.ThisItem.Base.Type == ItemType.Race && itemInfo.ThisItem.Value.ItemValue > 0 && (Race.ThisItem == null || Race.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Race.ThisItem != null)
            {
                ChangeStats(Race.ThisItem, false);
            }

            Race.ThisItem = itemInfo.ThisItem.Copy();
            RaceLink = itemInfo;
            Race.Image.sprite = itemInfo.ThisItem.Base.ItemUISprite;

            createUnit.Unit.MainSprite = itemInfo.ThisItem.Base.MainUnitSprite;
            createUnit.Unit.RaceSprite = itemInfo.ThisItem.Base.ItemSprite;

            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }

        else if (itemInfo.ThisItem.Base.Type == ItemType.Weapon && itemInfo.ThisItem.Value.ItemValue > 0 && (Weapon.ThisItem == null || Weapon.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Weapon.ThisItem != null)
            {
                ChangeStats(Weapon.ThisItem, false);
            }

            Weapon.ThisItem = itemInfo.ThisItem.Copy();
            WeaponLink = itemInfo;
            Weapon.Image.sprite = itemInfo.ThisItem.Base.ItemUISprite;
            createUnit.Unit.WeaponSprite = itemInfo.ThisItem.Base.ItemSprite;
            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }

        else if (itemInfo.ThisItem.Base.Type == ItemType.Armor && itemInfo.ThisItem.Value.ItemValue > 0 && (Armor.ThisItem == null || Armor.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Armor.ThisItem != null)
            {
                ChangeStats(Armor.ThisItem, false);
            }

            Armor.ThisItem = itemInfo.ThisItem.Copy();
            ArmorLink = itemInfo;
            Armor.Image.sprite = itemInfo.ThisItem.Base.ItemUISprite;
            createUnit.Unit.ArmorSprite = itemInfo.ThisItem.Base.ItemSprite;
            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }

        else if (itemInfo.ThisItem.Base.Type == ItemType.Shield && itemInfo.ThisItem.Value.ItemValue > 0 && (Shield.ThisItem == null || Shield.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Shield.ThisItem != null)
            {
                ChangeStats(Shield.ThisItem, false);
            }

            Shield.ThisItem = itemInfo.ThisItem.Copy();
            ShieldLink = itemInfo;
            Shield.Image.sprite = itemInfo.ThisItem.Base.ItemUISprite;
            createUnit.Unit.ShieldSprite = itemInfo.ThisItem.Base.ItemSprite;
            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }

        else if (itemInfo.ThisItem.Base.Type == ItemType.Special && itemInfo.ThisItem.Value.ItemValue > 0 && (Special.ThisItem == null || Special.ThisItem.Base.Name != itemInfo.ThisItem.Base.Name))
        {
            if (Special.ThisItem != null)
            {
                ChangeStats(Special.ThisItem, false);
            }

            Special.ThisItem = itemInfo.ThisItem.Copy();
            SpecialLink = itemInfo;
            Special.Image.sprite = itemInfo.ThisItem.Base.ItemUISprite;
            createUnit.Unit.SpecialSprite = itemInfo.ThisItem.Base.ItemSprite;
            ChangeStats(itemInfo.ThisItem, true);
            ChangeUI(createUnit);
        }
    }

    private void ChangeItemValueUI()
    {
        Race.Value.text = createUnit.Unit.Value.ToString();
        Weapon.Value.text = createUnit.Unit.Value.ToString();
        Armor.Value.text = createUnit.Unit.Value.ToString();
        Shield.Value.text = createUnit.Unit.Value.ToString();
        Special.Value.text = createUnit.Unit.Value.ToString();
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
            createUnit.Unit.Points += item.Base.Points;
            createUnit.Unit.Health += item.Base.Health;
            createUnit.Unit.MaxHealth += item.Base.Health;

            Damages damages = createUnit.Unit.Damages;
            Type damageType = damages.GetType();
            FieldInfo[] damageFields = damageType.GetFields();

            Damages damagesItem = item.Damages;
            Type damageTypeItem = damagesItem.GetType();
            FieldInfo[] damageFieldsItem = damageTypeItem.GetFields();

            for (int i = 0; i < damageFieldsItem.Length; i++)
            {
                int currentDamageValue = (int)damageFields[i].GetValue(damages);
                int itemDamageValue = (int)damageFieldsItem[i].GetValue(damagesItem);

                int resultValue = currentDamageValue + itemDamageValue;

                damageFields[i].SetValueDirect(__makeref(damages), resultValue);
            }

            Resists resists = createUnit.Unit.Resists;
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

            if (item.Weapon.IsWeapon)
            {
                createUnit.Unit.AttackTime = item.Weapon.AttackTime;
                createUnit.Unit.AttackRange = item.Weapon.AttackRange;
                createUnit.Unit.IsMeleeAttack = item.Weapon.IsMeleeAttack;
            }
        }

        else
        {
            createUnit.Unit.Points -= item.Base.Points;
            createUnit.Unit.Health -= item.Base.Health;
            createUnit.Unit.MaxHealth -= item.Base.Health;

            Damages damages = createUnit.Unit.Damages;
            Type damageType = damages.GetType();
            FieldInfo[] damageFields = damageType.GetFields();

            Damages damagesItem = item.Damages;
            Type damageTypeItem = damagesItem.GetType();
            FieldInfo[] damageFieldsItem = damageTypeItem.GetFields();

            for (int i = 0; i < damageFieldsItem.Length; i++)
            {
                int currentDamageValue = (int)damageFields[i].GetValue(damages);
                int itemDamageValue = (int)damageFieldsItem[i].GetValue(damagesItem);

                int resultValue = currentDamageValue - itemDamageValue;

                damageFields[i].SetValueDirect(__makeref(damages), resultValue);
            }

            Resists resists = createUnit.Unit.Resists;
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

            if (item.Weapon.IsWeapon)
            {
                createUnit.Unit.AttackTime = 1;
                createUnit.Unit.AttackRange = 1;
                createUnit.Unit.IsMeleeAttack = true;
            }
        }
    }

    public void ChangeUI(UnitUI unit)
    {
        unit.ActiveUI();

        Value.text = unit.Unit.Value.ToString();
        Points.text = unit.Unit.Points.ToString();
        Health.text = unit.Unit.Health + " / " + unit.Unit.MaxHealth;

        Damages damages = unit.Unit.Damages;
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

        Resists resists = unit.Unit.Resists;
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

        AttackInterval.text = unit.Unit.AttackTime.ToString();
        AttackRange.text = unit.Unit.AttackRange.ToString();
    }

    public void AllItems()
    {
        int count = 0;

        foreach (Transform item in ItemsGrid.transform)
        {
            item.gameObject.SetActive(true);
            count++;
        }

        ChangeSize(count);
    }

    public void WeaponItems()
    {
        int count = 0;

        foreach (Transform item in ItemsGrid.transform)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Weapon)
            {
                item.gameObject.SetActive(true);
                count++;
            }
            else
                item.gameObject.SetActive(false);
        }

        ChangeSize(count);
    }

    public void ArmorItems()
    {
        int count = 0;

        foreach (Transform item in ItemsGrid.transform)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Armor)
            {
                item.gameObject.SetActive(true);
                count++;
            }
            else
                item.gameObject.SetActive(false);
        }

        ChangeSize(count);
    }

    public void ShieldItems()
    {
        int count = 0;

        foreach (Transform item in ItemsGrid.transform)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Shield)
            {
                item.gameObject.SetActive(true);
                count++;
            }
            else
                item.gameObject.SetActive(false);
        }

        ChangeSize(count);
    }

    public void SpecialItems()
    {
        int count = 0;

        foreach (Transform item in ItemsGrid.transform)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Special)
            {
                item.gameObject.SetActive(true);
                count++;
            }
            else
                item.gameObject.SetActive(false);
        }

        ChangeSize(count);
    }

    private void ChangeSize(int count)
    {
        int height = Mathf.CeilToInt((float)count / 5) * 100 + (Mathf.CeilToInt((float)count / 5) - 1) * 30 + 30;
        ItemsGrid.GetComponent<RectTransform>().sizeDelta = new Vector2(ItemsGrid.GetComponent<RectTransform>().sizeDelta.x, height);
    }

    public void AddValue()
    {
        if ((Race.ThisItem == null || Race.ThisItem.Value.ItemValue > createUnit.Unit.Value) &&
            (Weapon.ThisItem == null || Weapon.ThisItem.Value.ItemValue > createUnit.Unit.Value) &&
            (Armor.ThisItem == null || Armor.ThisItem.Value.ItemValue > createUnit.Unit.Value) &&
            (Shield.ThisItem == null || Shield.ThisItem.Value.ItemValue > createUnit.Unit.Value) &&
            (Special.ThisItem == null || Special.ThisItem.Value.ItemValue > createUnit.Unit.Value))
        {
            createUnit.Unit.Value++;
            Value.text = createUnit.Unit.Value.ToString();
            ChangeItemValueUI();
        }
    }

    public void RemoveValue()
    {
        if (createUnit.Unit.Value > 1)
        {
            createUnit.Unit.Value--;
            Value.text = createUnit.Unit.Value.ToString();
            ChangeItemValueUI();
        }
    }

    public void CreateNewUnit()
    {
        if (Race.ThisItem != null)
        {
            createUnit.Unit.Race = Race.ThisItem.Copy();
            createUnit.Unit.RaceName = Race.ThisItem.Base.Name;
            RaceLink.ThisItem.Value.ItemValue -= createUnit.Unit.Value;
            RaceLink.Value.text = RaceLink.ThisItem.Value.ItemValue.ToString();
        }
        else
            return;

        if (Weapon.ThisItem != null)
        {
            createUnit.Unit.Weapon = Weapon.ThisItem.Copy();
            createUnit.Unit.WeaponName = Weapon.ThisItem.Base.Name;
            WeaponLink.ThisItem.Value.ItemValue -= createUnit.Unit.Value;
            WeaponLink.Value.text = WeaponLink.ThisItem.Value.ItemValue.ToString();
        }
        if (Armor.ThisItem != null)
        {
            createUnit.Unit.Armor = Armor.ThisItem.Copy();
            createUnit.Unit.ArmorName = Armor.ThisItem.Base.Name;
            ArmorLink.ThisItem.Value.ItemValue -= createUnit.Unit.Value;
            ArmorLink.Value.text = ArmorLink.ThisItem.Value.ItemValue.ToString();
        }
        if (Shield.ThisItem != null)
        {
            createUnit.Unit.Shield = Shield.ThisItem.Copy();
            createUnit.Unit.ShieldName = Shield.ThisItem.Base.Name;
            ShieldLink.ThisItem.Value.ItemValue -= createUnit.Unit.Value;
            ShieldLink.Value.text = ShieldLink.ThisItem.Value.ItemValue.ToString();
        }
        if (Special.ThisItem != null)
        {
            createUnit.Unit.Special = Special.ThisItem.Copy();
            createUnit.Unit.SpecialName = Special.ThisItem.Base.Name;
            SpecialLink.ThisItem.Value.ItemValue -= createUnit.Unit.Value;
            SpecialLink.Value.text = SpecialLink.ThisItem.Value.ItemValue.ToString();
        }

        if (!IsEditUnit)
        {
            UnitUI newUnit = Instantiate(UnitPrefab, Vector2.zero, Quaternion.identity, PrepareUIManager.Instance.UnitParent).GetComponent<UnitUI>();
            newUnit.Unit = createUnit.Unit.Copy();
            newUnit.Value.text = "x" + createUnit.Unit.Value;

            PrepareManager.Instance.Army.UnitNameNumber++;

            if (Race.ThisItem != null)
            {
                newUnit.Unit.RaceLink = RaceLink;
                //newUnit.UnitMainImage.gameObject.SetActive(true);
                //newUnit.UnitMainImage.sprite = createUnit.UnitMainImage.sprite;
                //newUnit.UnitRaceImage.gameObject.SetActive(true);
                //newUnit.UnitRaceImage.sprite = createUnit.UnitRaceImage.sprite;
            }
            if (Weapon.ThisItem != null)
            {
                newUnit.Unit.WeaponLink = WeaponLink;
                //newUnit.UnitWeaponImage.gameObject.SetActive(true);
                //newUnit.UnitWeaponImage.sprite = createUnit.UnitWeaponImage.sprite;
            }
            if (Armor.ThisItem != null)
            {
                newUnit.Unit.ArmorLink = ArmorLink;
                //newUnit.UnitArmorImage.gameObject.SetActive(true);
                //newUnit.UnitArmorImage.sprite = createUnit.UnitArmorImage.sprite;
            }
            if (Shield.ThisItem != null)
            {
                newUnit.Unit.ShieldLink = ShieldLink;
                //newUnit.UnitShieldImage.gameObject.SetActive(true);
                //newUnit.UnitShieldImage.sprite = createUnit.UnitShieldImage.sprite;

            }
            if (Special.ThisItem != null)
            {
                newUnit.Unit.SpecialLink = SpecialLink;
                //newUnit.UnitSpecialImage.gameObject.SetActive(true);
               // newUnit.UnitSpecialImage.sprite = createUnit.UnitSpecialImage.sprite;

            }

            newUnit.ActiveUI();
            PrepareManager.Instance.Units.Add(newUnit);

            newUnit.GetComponent<RectTransform>().localPosition = Vector3.zero;
            newUnit.transform.SetAsFirstSibling();

            PrepareUIManager.Instance.UnitParentChangeSize();
        }

        else
        {
            PrepareManager.Instance.ChosenUnit.Unit = createUnit.Unit.Copy();
            PrepareManager.Instance.ChosenUnit.UnitMainImage.sprite = createUnit.UnitMainImage.sprite;
            PrepareManager.Instance.ChosenUnit.Value.text = "x" + createUnit.Unit.Value;

            if (Race.ThisItem != null)
                PrepareManager.Instance.ChosenUnit.Unit.RaceLink = RaceLink;
            if (Weapon.ThisItem != null)
                PrepareManager.Instance.ChosenUnit.Unit.WeaponLink = WeaponLink;
            if (Armor.ThisItem != null)
                PrepareManager.Instance.ChosenUnit.Unit.ArmorLink = ArmorLink;
            if (Shield.ThisItem != null)
                PrepareManager.Instance.ChosenUnit.Unit.ShieldLink = ShieldLink;
            if (Special.ThisItem != null)
                PrepareManager.Instance.ChosenUnit.Unit.SpecialLink = SpecialLink;

            //            PrepareManager.Instance.Units.
        }

        CloseCreateUnitPanel(false);
    }

    public void CreateLoadUnit(UnitUI loadedUnit)
    {
        UnitUI newUnit = Instantiate(UnitPrefab, Vector2.zero, Quaternion.identity, PrepareUIManager.Instance.UnitParent).GetComponent<UnitUI>();
        newUnit.Unit = loadedUnit.Unit.Copy();
        newUnit.UnitMainImage.sprite = loadedUnit.UnitMainImage.sprite;
        newUnit.Value.text = "x" + loadedUnit.Unit.Value;

        newUnit.Unit.RaceLink = loadedUnit.Unit.RaceLink;
        newUnit.Unit.WeaponLink = loadedUnit.Unit.WeaponLink;
        newUnit.Unit.ArmorLink = loadedUnit.Unit.ArmorLink;
        newUnit.Unit.ShieldLink = loadedUnit.Unit.ShieldLink;
        newUnit.Unit.SpecialLink = loadedUnit.Unit.SpecialLink;

        PrepareManager.Instance.Units.Add(newUnit);
        newUnit.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

    public void CloseCreateUnitPanel(bool isButton = true)
    {
        if (IsEditUnit && isButton)
        {
            if (RaceLink != null)
            {
                RaceLink.ThisItem.Value.ItemValue -= loadUnit.Unit.Value;
                RaceLink.Value.text = RaceLink.ThisItem.Value.ItemValue.ToString();
            }
            if (WeaponLink != null)
            {
                WeaponLink.ThisItem.Value.ItemValue -= loadUnit.Unit.Value;
                WeaponLink.Value.text = WeaponLink.ThisItem.Value.ItemValue.ToString();
            }
            if (ArmorLink != null)
            {
                ArmorLink.ThisItem.Value.ItemValue -= loadUnit.Unit.Value;
                ArmorLink.Value.text = ArmorLink.ThisItem.Value.ItemValue.ToString();
            }
            if (ShieldLink != null)
            {
                ShieldLink.ThisItem.Value.ItemValue -= loadUnit.Unit.Value;
                ShieldLink.Value.text = ShieldLink.ThisItem.Value.ItemValue.ToString();
            }
            if (SpecialLink != null)
            {
                SpecialLink.ThisItem.Value.ItemValue -= loadUnit.Unit.Value;
                SpecialLink.Value.text = SpecialLink.ThisItem.Value.ItemValue.ToString();
            }
        }

        ClearCreateUnit();
        createUnitGameObject.SetActive(false);
    }

    public void ClearCreateUnit()
    {
        createUnit.Unit = new Unit();
        Race.ThisItem = Weapon.ThisItem = Armor.ThisItem = Shield.ThisItem = Special.ThisItem = null;
        Race.Image.sprite = Weapon.Image.sprite = Armor.Image.sprite = Shield.Image.sprite = Special.Image.sprite = null;
        RaceLink = WeaponLink = ArmorLink = ShieldLink = SpecialLink = null;
        ClearUI();
    }

    private void ClearUI()
    {
        Value.text = "1";
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

    public void EditUnit(UnitUI unit)
    {
        loadUnit = unit;
        createUnit.Unit = loadUnit.Unit.Copy();
        ChangeUI(loadUnit);

        Race.ThisItem = loadUnit.Unit.Race;
        Weapon.ThisItem = loadUnit.Unit.Weapon;
        Armor.ThisItem = loadUnit.Unit.Armor;
        Shield.ThisItem = loadUnit.Unit.Shield;
        Special.ThisItem = loadUnit.Unit.Special;

        if (loadUnit.Unit.Race != null)
            Race.Image.sprite = loadUnit.Unit.Race.Base.ItemUISprite;
        if (loadUnit.Unit.Weapon != null)
            Weapon.Image.sprite = loadUnit.Unit.Weapon.Base.ItemUISprite;
        if (loadUnit.Unit.Armor != null)
            Armor.Image.sprite = loadUnit.Unit.Armor.Base.ItemUISprite;
        if (loadUnit.Unit.Shield != null)
            Shield.Image.sprite = loadUnit.Unit.Shield.Base.ItemUISprite;
        if (loadUnit.Unit.Special != null)
            Special.Image.sprite = loadUnit.Unit.Special.Base.ItemUISprite;

        RaceLink = loadUnit.Unit.RaceLink;
        WeaponLink = loadUnit.Unit.WeaponLink;
        ArmorLink = loadUnit.Unit.ArmorLink;
        ShieldLink = loadUnit.Unit.ShieldLink;
        SpecialLink = loadUnit.Unit.SpecialLink;

        Race.Value.text = loadUnit.Unit.Value.ToString();
        Weapon.Value.text = loadUnit.Unit.Value.ToString();
        Armor.Value.text = loadUnit.Unit.Value.ToString();
        Shield.Value.text = loadUnit.Unit.Value.ToString();
        Special.Value.text = loadUnit.Unit.Value.ToString();


        if (RaceLink != null)
        {
            RaceLink.ThisItem.Value.ItemValue += loadUnit.Unit.Value;
            RaceLink.Value.text = RaceLink.ThisItem.Value.ItemValue.ToString();
        }

        if (WeaponLink != null)
        {
            WeaponLink.ThisItem.Value.ItemValue += loadUnit.Unit.Value;
            WeaponLink.Value.text = WeaponLink.ThisItem.Value.ItemValue.ToString();
        }
        if (ArmorLink != null)
        {
            ArmorLink.ThisItem.Value.ItemValue += loadUnit.Unit.Value;
            ArmorLink.Value.text = ArmorLink.ThisItem.Value.ItemValue.ToString();
        }
        if (ShieldLink != null)
        {
            ShieldLink.ThisItem.Value.ItemValue += loadUnit.Unit.Value;
            ShieldLink.Value.text = ShieldLink.ThisItem.Value.ItemValue.ToString();
        }
        if (SpecialLink != null)
        {
            SpecialLink.ThisItem.Value.ItemValue += loadUnit.Unit.Value;
            SpecialLink.Value.text = SpecialLink.ThisItem.Value.ItemValue.ToString();
        }
    }

    public void DeleteUnit(UnitUI deleteUnit)
    {
        RaceLink = deleteUnit.Unit.RaceLink;
        WeaponLink = deleteUnit.Unit.WeaponLink;
        ArmorLink = deleteUnit.Unit.ArmorLink;
        ShieldLink = deleteUnit.Unit.ShieldLink;
        SpecialLink = deleteUnit.Unit.SpecialLink;

        if (RaceLink != null)
        {
            RaceLink.ThisItem.Value.ItemValue += deleteUnit.Unit.Value;
            RaceLink.Value.text = RaceLink.ThisItem.Value.ItemValue.ToString();
        }
        if (WeaponLink != null)
        {
            WeaponLink.ThisItem.Value.ItemValue += deleteUnit.Unit.Value;
            WeaponLink.Value.text = WeaponLink.ThisItem.Value.ItemValue.ToString();
        }
        if (ArmorLink != null)
        {
            ArmorLink.ThisItem.Value.ItemValue += deleteUnit.Unit.Value;
            ArmorLink.Value.text = ArmorLink.ThisItem.Value.ItemValue.ToString();
        }
        if (ShieldLink != null)
        {
            ShieldLink.ThisItem.Value.ItemValue += deleteUnit.Unit.Value;
            ShieldLink.Value.text = ShieldLink.ThisItem.Value.ItemValue.ToString();
        }
        if (SpecialLink != null)
        {
            SpecialLink.ThisItem.Value.ItemValue += deleteUnit.Unit.Value;
            SpecialLink.Value.text = SpecialLink.ThisItem.Value.ItemValue.ToString();
        }

        PrepareManager.Instance.Units.Remove(PrepareManager.Instance.ChosenUnit);
        Destroy(PrepareManager.Instance.ChosenUnit.gameObject);
    }

    public void ChangeValueItems()
    {
        foreach (Transform child in RacesGrid)
        {
            ItemInfo clildInfo = child.GetComponent<ItemInfo>();
            clildInfo.Value.text = clildInfo.ThisItem.Value.ItemValue.ToString();

            if (clildInfo.ThisItem.Value.ItemValue > 0)
            {
                clildInfo.Hide = false;
                clildInfo.ImageHide.SetActive(false);
            }
        }

        foreach (Transform child in ItemsGrid)
        {
            ItemInfo clildInfo = child.GetComponent<ItemInfo>();
            clildInfo.Value.text = clildInfo.ThisItem.Value.ItemValue.ToString();

            if (clildInfo.ThisItem.Value.ItemValue > 0)
            {
                clildInfo.Hide = false;
                clildInfo.ImageHide.SetActive(false);
            }
        }
    }
}
