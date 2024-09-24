using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class BattleField : MonoBehaviour
{
    private static BattleField _instance;

    public static BattleField Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BattleField>();
            }

            return _instance;
        }
    }

    public List<Row> Rows = new List<Row>(12);
    public List<RowUI> RowsUI = new List<RowUI>(12);

    public GameObject UnitPrefab;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        InitializeRows();
    }

    public void InitializeRows()
    {
        for (int i = 0; i < 12; i++)
        {
            Rows.Add(new Row());
        }
    }

    public void LoadArmy(Army army, bool isPlayer)
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

                        Rows[rowIndex].Columns[columnIndex].Units[unitIndex] = unit;
                        UnitUI newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity, RowsUI[rowIndex].Columns[columnIndex].Cells[unitIndex].transform).GetComponent<UnitUI>();

                        newUnit.Unit.BattleUnit = newUnit.AddComponent<BattleUnit>();
                        newUnit.Unit.BattleUnit.Army = army;
                        newUnit.Unit.BattleUnit.Unit = newUnit.Unit;
                        newUnit.GetComponent<UnitMove>().IsDraggable = false;
                        LoadUnit(newUnit, unit);

                        RowsUI[rowIndex].Columns[columnIndex].Cells[unitIndex].unit = newUnit;

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

                        int reversedColumnIndex = 2 - columnIndex;

                        Rows[rowIndex + 7].Columns[reversedColumnIndex].Units[unitIndex] = unit;
                        UnitUI newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity, RowsUI[rowIndex + 7].Columns[reversedColumnIndex].Cells[unitIndex].transform).GetComponent<UnitUI>();

                        newUnit.Unit.BattleUnit = newUnit.AddComponent<BattleUnit>();
                        newUnit.Unit.BattleUnit.Army = army;
                        newUnit.Unit.BattleUnit.Unit = newUnit.Unit;
                        newUnit.UnitMainImage.transform.parent.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                        newUnit.GetComponent<UnitMove>().IsDraggable = false;
                        LoadUnit(newUnit, unit);

                        RowsUI[rowIndex + 7].Columns[reversedColumnIndex].Cells[unitIndex].unit = newUnit;

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
