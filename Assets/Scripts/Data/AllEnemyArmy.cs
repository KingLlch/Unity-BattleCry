using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;

public static class AllEnemyArmy
{
    public static List<Army> EnemyArmy;

    public static List<Unit> AllEnemyUnits;
}

public class EnemyArmyManager : MonoBehaviour
{
    public static List<EnemyUnit> AllEnemyUnits;

    private void Start()
    {
        AddUnits();

        foreach (EnemyUnit unit in AllEnemyUnits)
        {
            ChangeTypeUnit(unit);
        }

        AddEnemyArmy();
    }

    public void AddEnemyArmy()
    {
        AllEnemyArmy.EnemyArmy.Add(CreateEnemyArmy("GoblinArmy", 
            CreateRow(CreateColumn(FindUnit(""), FindUnit(""), FindUnit(""), FindUnit(""), FindUnit(""), FindUnit("")), CreateColumn(FindUnit(""), FindUnit(""), FindUnit(""), FindUnit(""), FindUnit(""), FindUnit(""))), 
            CreateRow(), 
            CreateRow(), 
            CreateRow(), 
            CreateRow()
            ));
    }

    public Unit FindUnit(string name)
    {
        return (AllEnemyArmy.AllEnemyUnits.Find(i => i.unitCharacteristics.Name == name));
    }

    public Column CreateColumn(Unit unit1, Unit unit2, Unit unit3, Unit unit4, Unit unit5, Unit unit6)
    {
        Column newColumn = new Column();

        newColumn.Units.Add(unit1);
        newColumn.Units.Add(unit2);
        newColumn.Units.Add(unit3);
        newColumn.Units.Add(unit4);
        newColumn.Units.Add(unit5);
        newColumn.Units.Add(unit6);

        return newColumn;
    }

    public Row CreateRow(Column column1 = null, Column column2 = null, Column column3 = null)
    {
        Row newRow = new Row();

        newRow.Columns.Add(column1);
        newRow.Columns.Add(column2);
        newRow.Columns.Add(column3);

        return newRow;
    }

    public Army CreateEnemyArmy(string name, Row row1, Row row2, Row row3, Row row4, Row row5)
    {
        Army newArmy = new Army();

        newArmy.Name = name;

        List<Row> rows = new List<Row>
        {
            row1,
            row2,
            row3,
            row4,
            row5
        };

        newArmy.Rows = rows;


        return newArmy;
    }

    public void ChangeTypeUnit(EnemyUnit unit)
    {
        Unit newUnit = new Unit();

        newUnit.unitCharacteristics.Name = unit.Name;

        if (unit.Race != null)
        {
            newUnit.unitCharacteristics.RaceName = unit.Race.Base.Name;
            newUnit.UnitMainImage.sprite = unit.Race.Base.MainUnitSprite;
            newUnit.UnitRaceImage.sprite = unit.Race.Base.ItemSprite;

            ChangeDamagesResists(newUnit, unit.Race);
        }

        if(unit.Weapon != null)
        {
            newUnit.unitCharacteristics.WeaponName = unit.Weapon.Base.Name;
            newUnit.UnitWeaponImage.sprite = unit.Weapon.Base.ItemSprite;

            ChangeDamagesResists(newUnit, unit.Weapon);
        }

        if (unit.Armor != null)
        {
            newUnit.unitCharacteristics.ArmorName = unit.Armor.Base.Name;
            newUnit.UnitArmorImage.sprite = unit.Armor.Base.ItemSprite;

            ChangeDamagesResists(newUnit, unit.Armor);
        }

        if (unit.Shield != null)
        {
            newUnit.unitCharacteristics.ShieldName = unit.Shield.Base.Name;
            newUnit.UnitShieldImage.sprite = unit.Shield.Base.ItemSprite;

            ChangeDamagesResists(newUnit, unit.Shield);
        }

        if (unit.Special != null)
        {
            newUnit.unitCharacteristics.SpecialName = unit.Special.Base.Name;
            newUnit.UnitSpecialImage.sprite = unit.Special.Base.ItemSprite;

            ChangeDamagesResists(newUnit, unit.Special);
        }


        AllEnemyArmy.AllEnemyUnits.Add(newUnit);
    }

    public void ChangeDamagesResists(Unit unit, Item item)
    {
        unit.unitCharacteristics.Points += item.Base.Points;
        unit.unitCharacteristics.Health += item.Base.Health;
        unit.unitCharacteristics.MaxHealth += item.Base.Health;

        Damages damages = unit.unitCharacteristics.Damages;
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

        Resists resists = unit.unitCharacteristics.Resists;
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
            unit.unitCharacteristics.AttackRange = item.Weapon.AttackRange;
            unit.unitCharacteristics.AttackTime = item.Weapon.AttackTime;
            unit.unitCharacteristics.IsMeleeAttack = item.Weapon.IsMeleeAttack;
        }
    }

    public void AddUnits()
    {
        AllEnemyUnits.Add(new EnemyUnit("Skaven Slave", ItemsList.AllRace.Find(i => i.Base.Name == "Skaven"), ItemsList.AllRace.Find(i => i.Base.Name == "Wooden Spear"), null, null, null));
    }
}

public class EnemyUnit
{
    public string Name;

    public Item Race;
    public Item Weapon;
    public Item Armor;
    public Item Shield;
    public Item Special;

    public EnemyUnit(string name, Item race, Item weapon, Item armor, Item shield, Item special)
    {
        Name = name;
        Race = race;
        Weapon = weapon;
        Armor = armor;
        Shield = shield;
        Special = special;
    }
}
