using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class BattleManager : MonoBehaviour
{
    private static BattleManager _instance;

    public static BattleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BattleManager>();
            }

            return _instance;
        }
    }

    public bool IsFight;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void StartBattle()
    {
        StartCoroutine(Battle());
    }

    public IEnumerator Battle()
    {
        while (true)
        {
            if (!IsFight)
            {
                RowMove(BattleField.Instance.FirstPlayerRow[0]);
                RowMove(BattleField.Instance.FirstEnemyRow[0]);
            }

            if (BattleField.Instance.IsRowNear())
            {
                IsFight = true;


            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void RowMove(Row row) 
    {
        for (int i = 0; i < row.Columns.Count; i++)
        {
            ColumnMove(row.Columns[i]);
        }
    }

    public void ColumnMove(Column column)
    {
        for (int i = 0; i < column.Units.Count; i++)
        {
            UnitMove(column.Units[i]);
        }
    }

    public void UnitMove(Unit unit)
    {
        int rowIndex = unit.BattleUnit.RowIndex;
        int columnIndex = unit.BattleUnit.ColumnIndex;
        int cellIndex = unit.BattleUnit.CellIndex;

        int nextColumnIndex = 2 - columnIndex;
        int nextRowIndex = 0;

        BattleField.Instance.Rows[rowIndex].Columns[columnIndex].Units[cellIndex] = null;

        if (unit.BattleUnit.IsPlayerUnit)
        {
            if (columnIndex == 0)
                nextRowIndex = rowIndex + 1;
            else
                nextRowIndex = rowIndex;

            BattleField.Instance.Rows[nextRowIndex].Columns[nextColumnIndex].Units[cellIndex] = unit;
            MoveUnitUI(unit.BattleUnit.UnitUI, BattleField.Instance.RowsUI[nextRowIndex].Columns[nextColumnIndex].Cells[cellIndex]);
        }
        else
        {
            if (columnIndex == 2)
                nextRowIndex = rowIndex - 1;
            else
                nextRowIndex = rowIndex;

            BattleField.Instance.Rows[nextRowIndex].Columns[nextColumnIndex].Units[cellIndex] = unit;
            MoveUnitUI(unit.BattleUnit.UnitUI, BattleField.Instance.RowsUI[nextRowIndex].Columns[nextColumnIndex].Cells[cellIndex]);
        }
    }

    public void MoveUnitUI(UnitUI unitUI, CellUI cell)
    {
        unitUI.transform.SetParent(cell.transform);
    }

    public void RowFight(Row row)
    {
        for (int i = 0; i < row.Columns.Count; i++)
        {
            ColumnFight(row.Columns[i]);
        }
    }

    public void ColumnFight(Column column)
    {
        for (int i = 0; i < column.Units.Count; i++)
        {
            UnitFight(column.Units[i]);
        }
    }

    public void UnitFight(Unit unit)
    {
        //Attack(unit, );
        UnitFightUI();
    }

    public void UnitFightUI()
    {

    }

    public void Attack(Unit attacker, Unit defender)
    {
        if (defender == null)
        {
            return;
        }

        int damage = CalculateDamage(attacker, defender);
        defender.Health -= damage;

        if (defender.Health <= 0)
        {
            KillUnit(defender);
        }
    }

    public int CalculateDamage(Unit attacker, Unit defender)
    {
        int damage = 0;

        damage += Mathf.Max(attacker.Damages.PierceDamage - defender.Resists.PierceResist, 0);
        damage += Mathf.Max(attacker.Damages.SlashDamage - defender.Resists.SlashResist, 0);
        damage += Mathf.Max(attacker.Damages.BluntDamage - defender.Resists.BluntResist, 0);
        damage += Mathf.Max(attacker.Damages.FireDamage - defender.Resists.FireResist, 0);
        damage += Mathf.Max(attacker.Damages.IceDamage - defender.Resists.IceResist, 0);
        damage += Mathf.Max(attacker.Damages.EarthDamage - defender.Resists.EarthResist, 0);
        damage += Mathf.Max(attacker.Damages.PoisonDamage - defender.Resists.PoisonResist, 0);
        damage += Mathf.Max(attacker.Damages.WaterDamage - defender.Resists.WaterResist, 0);
        damage += Mathf.Max(attacker.Damages.LightDamage - defender.Resists.LightResist, 0);
        damage += Mathf.Max(attacker.Damages.DarknessDamage - defender.Resists.DarknessResist, 0);

        return Mathf.Max(1, damage);
    }

    public void KillUnit(Unit unit)
    {
        if (unit == null || unit.BattleUnit == null)
            return;

        Army army = new Army();

        if (unit.BattleUnit.IsPlayerUnit == true)
        {
            army = GameManager.Instance.PlayerArmy;
        }
        else
        {
            army = GameManager.Instance.EnemyArmy;
        }

        BattleField.Instance.Rows[unit.BattleUnit.RowIndex].Columns[unit.BattleUnit.ColumnIndex].Units[unit.BattleUnit.CellIndex] = null;
        army.CountUnitInArmy--;
        army.Rows[unit.BattleUnit.RowIndex].CountUnitInRow--;

        if (army.Rows[unit.BattleUnit.RowIndex].CountUnitInRow <= 0)
        {
            if(army == GameManager.Instance.PlayerArmy)
                BattleField.Instance.FirstPlayerRow.Remove(army.Rows[unit.BattleUnit.RowIndex]);
            else
                BattleField.Instance.FirstEnemyRow.Remove(army.Rows[unit.BattleUnit.RowIndex]);
        }

        Destroy(BattleField.Instance.RowsUI[unit.BattleUnit.RowIndex].Columns[unit.BattleUnit.ColumnIndex].Cells[unit.BattleUnit.CellIndex].unit.gameObject);

        if (army.CountUnitInArmy <= 0)
        {
            if (army == GameManager.Instance.PlayerArmy)
                GameManager.Instance.Lose();
            else
                GameManager.Instance.Win();
        }
    }
}
