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

    public List<UnitUI> Units;

    public UnitUI ChosenUnit = new UnitUI();

    public int Gold;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        SaveAndLoad.Instance.ClearAll();
        //SaveAndLoad.Instance.SaveGold(999999);
        SaveAndLoad.Instance.LoadAll();
        PrepareUIManager.Instance.ChangeGold();
    }

    private void Start()
    {
        if (BattleInfo.Instance.IsWin)
        {
            CampaignManager.Instance.ChangeProgress(BattleInfo.Instance.CampaignNumber, BattleInfo.Instance.MissionNumber);
        }
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

    public void RemoveUnitFromArmy(UnitUI unit, CellUI cell)
    {
        Army.RemoveUnit(unit.Unit, cell);
        unit.MainUnitLink.Value.text = unit.Unit.Value.ToString();

        Destroy(unit.gameObject);
    }

    public void ChoseUnit(UnitUI chosenUnit)
    {
        if (ChosenUnit != null)
        {
            ChosenUnit.UnitChosenImage.color = Color.white;
        }

        if (chosenUnit != null)
        {
            ChosenUnit = chosenUnit;
            ChosenUnit.UnitChosenImage.color = Color.red;
        }
        else
        {
            ChosenUnit = null;
        }
    }
}
