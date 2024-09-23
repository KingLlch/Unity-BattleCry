using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    public Army Army;

    public Unit Unit;
    public Coroutine Coroutine;

    private void Awake()
    {
        Unit = gameObject.GetComponentInParent<UnitUI>().Unit;
    }

    public void StartAttack()
    {
        Coroutine = StartCoroutine(AttackCoroutine());
    }

    public IEnumerator AttackCoroutine()
    {
        //BattleManager.Instance.Attack(Unit);
        yield return new WaitForSeconds(Unit.AttackTime);
    }
}
