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

    public Item Race;

    public Item Weapon;
    public Item Armor;
    public Item Shield;
    public Item Special;

    public Unit createUnit;

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

    public void AddItem()
    {
        ChangeUI(createUnit);
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

    public void CreateNewUnit()
    {
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
        Race = new Item();

        Weapon = new Item();
        Armor = new Item();
        Shield = new Item();
        Special = new Item();

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
}
