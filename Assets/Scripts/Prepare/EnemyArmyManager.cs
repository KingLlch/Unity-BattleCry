using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;

public static class AllEnemyArmy
{
    public static List<Army> EnemyArmy = new List<Army>();

    public static List<Unit> AllEnemyUnits = new List<Unit>();
}

public class EnemyArmyManager : MonoBehaviour
{
    public static List<EnemyUnit> AllEnemyUnits = new List<EnemyUnit>();

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
            CreateRow(CreateColumn(FindUnit("Goblin"), FindUnit("Goblin"), FindUnit("Goblin"), FindUnit("Goblin"), FindUnit("Goblin"), FindUnit("Goblin")), CreateColumn(FindUnit("Goblin"), FindUnit("Goblin"), FindUnit("Goblin"), FindUnit("Goblin"), FindUnit("Goblin"), FindUnit("Goblin"))),
            CreateRow(),
            CreateRow(),
            CreateRow(),
            CreateRow()
            ));
    }

    public Unit FindUnit(string name)
    {
        return (AllEnemyArmy.AllEnemyUnits.Find(i => i.Name == name));
    }

    public Column CreateColumn(Unit unit1, Unit unit2, Unit unit3, Unit unit4, Unit unit5, Unit unit6)
    {
        Column newColumn = new Column();

        newColumn.Units[0] = unit1;
        newColumn.Units[1] = unit2;
        newColumn.Units[2] = unit3;
        newColumn.Units[3] = unit4;
        newColumn.Units[4] = unit5;
        newColumn.Units[5] = unit6;

        return newColumn;
    }

    public Row CreateRow(Column column1 = null, Column column2 = null, Column column3 = null)
    {
        Row newRow = new Row();

        if (column1 != null)
            newRow.Columns[0] = column1;
        else
            newRow.Columns[0] = new Column();

        if (column2 != null)
            newRow.Columns[1] = column2;
        else
            newRow.Columns[1] = new Column();

        if (column3 != null)
            newRow.Columns[2] = column3;
        else
            newRow.Columns[2] = new Column();

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

        newUnit.Name = unit.Name;

        newUnit.Race = unit.Race;
        newUnit.RaceName = unit.Race.Base.Name;
        newUnit.MainSprite = unit.Race.Base.MainUnitSprite;
        newUnit.RaceSprite = unit.Race.Base.ItemSprite;

        ChangeDamagesResists(newUnit, unit.Race);

        if (unit.Weapon != null)
        {
            newUnit.Weapon = unit.Weapon;
            newUnit.WeaponName = unit.Weapon.Base.Name;
            newUnit.WeaponSprite = unit.Weapon.Base.ItemSprite;

            ChangeDamagesResists(newUnit, unit.Weapon);
        }

        if (unit.Armor != null)
        {
            newUnit.Armor = unit.Armor;
            newUnit.ArmorName = unit.Armor.Base.Name;
            newUnit.ArmorSprite = unit.Armor.Base.ItemSprite;

            ChangeDamagesResists(newUnit, unit.Armor);
        }

        if (unit.Shield != null)
        {
            newUnit.Shield = unit.Shield;
            newUnit.ShieldName = unit.Shield.Base.Name;
            newUnit.ShieldSprite = unit.Shield.Base.ItemSprite;

            ChangeDamagesResists(newUnit, unit.Shield);
        }

        if (unit.Special != null)
        {
            newUnit.Special = unit.Special;
            newUnit.SpecialName = unit.Special.Base.Name;
            newUnit.SpecialSprite = unit.Special.Base.ItemSprite;

            ChangeDamagesResists(newUnit, unit.Special);
        }

        AllEnemyArmy.AllEnemyUnits.Add(newUnit);
    }

    public void ChangeDamagesResists(Unit newUnitCharacteristics, Item item)
    {
        newUnitCharacteristics.Points += item.Base.Points;
        newUnitCharacteristics.Health += item.Base.Health;
        newUnitCharacteristics.MaxHealth += item.Base.Health;

        Damages damages = newUnitCharacteristics.Damages;
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

        Resists resists = newUnitCharacteristics.Resists;
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
            newUnitCharacteristics.AttackRange = item.Weapon.AttackRange;
            newUnitCharacteristics.AttackTime = item.Weapon.AttackTime;
            newUnitCharacteristics.IsMeleeAttack = item.Weapon.IsMeleeAttack;
        }
    }

    public void AddUnits()
    {
        AllEnemyUnits.Add(new EnemyUnit("Goblin", ItemsList.AllRace.Find(i => i.Base.Name == "Goblin")));
        AllEnemyUnits.Add(new EnemyUnit("Skaven Slave", ItemsList.AllRace.Find(i => i.Base.Name == "Skaven")));
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

    public EnemyUnit(string name, Item race, Item weapon = null, Item armor = null, Item shield = null, Item special = null)
    {
        Name = name;
        Race = race;

        if (weapon != null)
            Weapon = weapon;
        if (armor != null)
            Armor = armor;
        if (shield != null)
            Shield = shield;
        if (special != null)
            Special = special;
    }
}
