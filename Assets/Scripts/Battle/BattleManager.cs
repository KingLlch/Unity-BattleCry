using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
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

        army.Rows[unit.BattleUnit.RowIndex].Columns[unit.BattleUnit.ColumnIndex].Units[unit.BattleUnit.CellIndex] = null;
        army.CountUnitInArmy--;
        army.Rows[unit.BattleUnit.RowIndex].CountUnitInRow--;
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
