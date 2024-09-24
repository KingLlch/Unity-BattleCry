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

    public void Attack(Unit startUnit, Unit targetUnit)
    {
        targetUnit.Health -= TakeDamage(startUnit, targetUnit);

        if(targetUnit.Health <= 0)
        {
            DeadUnit(targetUnit);
        }

    }

    public void DeadUnit(Unit unit)
    {
        int hz = 0;

        unit.BattleUnit.Army.Rows[hz].Columns[hz].Units[hz] = null;

        if (unit.BattleUnit.Army == GameManager.Instance.PlayerArmy)
            Destroy(BattleField.Instance.RowsUI[hz].Columns[hz].Cells[hz].unit.gameObject);
        else if (unit.BattleUnit.Army == GameManager.Instance.EnemyArmy)
            Destroy(BattleField.Instance.RowsUI[hz].Columns[hz].Cells[hz].unit.gameObject);
    }

    public int TakeDamage(Unit startUnit, Unit targetUnit)
    {
        int damage = 0;

        damage += Mathf.Max(startUnit.Damages.PierceDamage - targetUnit.Resists.PierceResist, 0);
        damage += Mathf.Max(startUnit.Damages.SlashDamage - targetUnit.Resists.SlashResist, 0);
        damage += Mathf.Max(startUnit.Damages.BluntDamage - targetUnit.Resists.BluntResist, 0);
        damage += Mathf.Max(startUnit.Damages.FireDamage - targetUnit.Resists.FireResist, 0);
        damage += Mathf.Max(startUnit.Damages.IceDamage - targetUnit.Resists.IceResist, 0);
        damage += Mathf.Max(startUnit.Damages.EarthDamage - targetUnit.Resists.EarthResist, 0);
        damage += Mathf.Max(startUnit.Damages.PoisonDamage - targetUnit.Resists.PoisonResist, 0);
        damage += Mathf.Max(startUnit.Damages.WaterDamage - targetUnit.Resists.WaterResist, 0);
        damage += Mathf.Max(startUnit.Damages.LightDamage - targetUnit.Resists.LightResist, 0);
        damage += Mathf.Max(startUnit.Damages.DarknessDamage - targetUnit.Resists.DarknessResist, 0);

        damage = Mathf.Max(1, damage);
        return damage;
    }
}
