using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrepareManager : MonoBehaviour
{
    private static PrepareManager _instance;

    public static PrepareManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PrepareManager>();
            }

            return _instance;
        }
    }

    public Army Army = new Army();

    public List<Unit> Units;

    public Unit ChosenUnit = new Unit();

    public int Gold;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        //SaveAndLoad.Instance.SaveGold(999999);
        SaveAndLoad.Instance.LoadAll();
        PrepareUIManager.Instance.ChangeGold();
    }

    public void SaveArmy()
    {
        SaveAndLoad.Instance.SaveArmy(Army);
    }

    public void ResetArmy()
    {
        PrepareUIManager.Instance.ResetArmy();
    }

    public void AddUnitToArmy(Unit unit, CellUI cell)
    {
        Army.AddUnit(unit, cell);
    }

    public void RemoveUnitFromArmy(Unit unit, CellUI cell)
    {
        Army.RemoveUnit(unit, cell);
    }

    public void ChoseUnit(Unit chosenUnit)
    {
        if(ChosenUnit != null)
        {
            ChosenUnit.UnitImageEdge.color = Color.white;
        }

        if (chosenUnit != null)
        {
            ChosenUnit = chosenUnit;
            ChosenUnit.UnitImageEdge.color = Color.red;
        }
        else
        {
            ChosenUnit = null;
        }
    }
}
