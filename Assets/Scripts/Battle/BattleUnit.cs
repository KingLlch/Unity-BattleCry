using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    public UnitUI UnitUI;
    public Unit Unit;
    public Coroutine Coroutine;

    public int RowIndex;
    public int ColumnIndex;
    public int CellIndex;

    public bool IsPlayerUnit;

    private void Awake()
    {
        Unit = gameObject.GetComponentInParent<UnitUI>().Unit;
    }

    public void StartAttack(Unit targetUnit)
    {
        Coroutine = StartCoroutine(AttackCoroutine(targetUnit));
    }

    public IEnumerator AttackCoroutine(Unit targetUnit)
    {
        BattleManager.Instance.Attack(Unit, targetUnit);
        yield return new WaitForSeconds(Unit.AttackTime);
    }
}
