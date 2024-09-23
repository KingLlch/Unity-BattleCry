using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public Army PlayerArmy;
    public List<RowUI> PlayerArmyRows;

    public Army EnemyArmy;
    public List<RowUI> EnemyArmyRows;

    public GameObject UnitPrefab;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }


    private void Start()
    {
        PlayerArmy = BattleInfo.Instance.PlayerArmy;
        EnemyArmy = BattleInfo.Instance.EnemyArmy;

        LoadArmy(PlayerArmy, true);
        LoadArmy(EnemyArmy, false);


    }

    private void LoadArmy(Army army, bool isPlayer)
    {
        if (isPlayer)
        {
            for (int rowIndex = 0; rowIndex < army.Rows.Count; rowIndex++)
            {
                Row row = army.Rows[rowIndex];

                for (int columnIndex = 0; columnIndex < row.Columns.Count; columnIndex++)
                {
                    Column column = row.Columns[columnIndex];

                    for (int unitIndex = 0; unitIndex < column.Units.Count; unitIndex++)
                    {
                        Unit unit = column.Units[unitIndex];

                        if (unit == null)
                            continue;

                        UnitUI newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity,PlayerArmyRows[rowIndex].Columns[columnIndex].Cells[unitIndex].transform).GetComponent<UnitUI>();

                        newUnit.Unit.BattleUnit = newUnit.AddComponent<BattleUnit>();
                        newUnit.Unit.BattleUnit.Army = army;
                        newUnit.Unit.BattleUnit.Unit = newUnit.Unit;
                        newUnit.GetComponent<UnitMove>().IsDraggable = false;
                        LoadUnit(newUnit, unit);

                        PlayerArmyRows[rowIndex].Columns[columnIndex].Cells[unitIndex].unit = newUnit;

                        Centralize(newUnit.GetComponent<RectTransform>());
                        newUnit.IsInArmy = true;
                    }
                }
            }
        }
        else
        {
            for (int rowIndex = 0; rowIndex < army.Rows.Count; rowIndex++)
            {
                Row row = army.Rows[rowIndex];

                for (int columnIndex = 0; columnIndex < row.Columns.Count; columnIndex++)
                {
                    Column column = row.Columns[columnIndex];

                    for (int unitIndex = 0; unitIndex < column.Units.Count; unitIndex++)
                    {
                        Unit unit = column.Units[unitIndex];

                        if (unit == null)
                            continue;

                        UnitUI newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity,EnemyArmyRows[rowIndex].Columns[columnIndex].Cells[unitIndex].transform).GetComponent<UnitUI>();

                        newUnit.Unit.BattleUnit = newUnit.AddComponent<BattleUnit>();
                        newUnit.Unit.BattleUnit.Army = army;
                        newUnit.Unit.BattleUnit.Unit = newUnit.Unit;
                        newUnit.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,180,0));
                        newUnit.GetComponent<UnitMove>().IsDraggable = false;
                        LoadUnit(newUnit, unit);

                        EnemyArmyRows[rowIndex].Columns[columnIndex].Cells[unitIndex].unit = newUnit;

                        Centralize(newUnit.GetComponent<RectTransform>());
                        newUnit.IsInArmy = true;
                    }
                }
            }
        }
    }

    private void LoadUnit(UnitUI newUnit, Unit unit)
    {
        newUnit.Unit = unit;
        newUnit.UnitMainImage.sprite = unit.MainSprite;
        newUnit.MainUnitLink = newUnit;
        newUnit.Value.gameObject.SetActive(false);
        newUnit.UnitChosenImage.gameObject.SetActive(false);

        newUnit.ActiveUI();
    }

    private void Centralize(RectTransform rectTransform)
    {
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.localPosition = Vector3.zero;
    }
}
