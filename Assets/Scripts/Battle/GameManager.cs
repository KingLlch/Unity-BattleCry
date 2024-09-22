using System.Collections.Generic;
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
    public List<GameObject> PlayerArmyRows;

    public Army EnemyArmy;
    public List<GameObject> EnemyArmyRows;

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

                        Unit newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity,PlayerArmyRows[rowIndex].GetComponentInChildren<RowUI>().Columns[columnIndex].GetComponent<ColumnUI>().Cells[unitIndex].transform).GetComponent<Unit>();

                        newUnit.GetComponent<UnitMove>().IsDraggable = false;
                        LoadUnit(newUnit, unit);

                        PlayerArmyRows[rowIndex].GetComponentInChildren<RowUI>().Columns[columnIndex].GetComponent<ColumnUI>().Cells[unitIndex].GetComponent<CellUI>().unit = newUnit;

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

                        Unit newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity,EnemyArmyRows[rowIndex].GetComponentInChildren<RowUI>().Columns[columnIndex].GetComponent<ColumnUI>().Cells[unitIndex].transform).GetComponent<Unit>();

                        newUnit.GetComponent<UnitMove>().IsDraggable = false;
                        LoadUnit(newUnit, unit);

                        EnemyArmyRows[rowIndex].GetComponentInChildren<RowUI>().Columns[columnIndex].GetComponent<ColumnUI>().Cells[unitIndex].GetComponent<CellUI>().unit = newUnit;

                        Centralize(newUnit.GetComponent<RectTransform>());
                        newUnit.IsInArmy = true;
                    }
                }
            }
        }
    }

    private void LoadUnit(Unit newUnit, Unit unit)
    {
        newUnit.unitCharacteristics = unit.unitCharacteristics;
        newUnit.UnitMainImage.sprite = unit.UnitMainImage.sprite;
        newUnit.MainUnitLink = unit;
        newUnit.Value.gameObject.SetActive(false);
        newUnit.UnitChosenImage.gameObject.SetActive(false);

        newUnit.ActiveUI();
    }

    //private void ShowUnit(Unit newUnit, Unit unit)
    //{
    //    if (newUnit.unitCharacteristics.Race != null)
    //    {
    //        newUnit.UnitMainImage.gameObject.SetActive(true);
    //        newUnit.UnitMainImage.sprite = unit.UnitMainImage.sprite;
    //        newUnit.UnitRaceImage.gameObject.SetActive(true);
    //        newUnit.UnitRaceImage.sprite = unit.UnitRaceImage.sprite;
    //    }
    //    if (newUnit.unitCharacteristics.Weapon != null)
    //    {
    //        newUnit.UnitWeaponImage.gameObject.SetActive(true);
    //        newUnit.UnitWeaponImage.sprite = unit.UnitWeaponImage.sprite;

    //    }
    //    if (newUnit.unitCharacteristics.Armor != null)
    //    {
    //        newUnit.UnitArmorImage.gameObject.SetActive(true);
    //        newUnit.UnitArmorImage.sprite = unit.UnitArmorImage.sprite;

    //    }
    //    if (newUnit.unitCharacteristics.Shield != null)
    //    {
    //        newUnit.UnitShieldImage.gameObject.SetActive(true);
    //        newUnit.UnitShieldImage.sprite = unit.UnitShieldImage.sprite;

    //    }
    //    if (newUnit.unitCharacteristics.Special != null)
    //    {
    //        newUnit.UnitSpecialImage.gameObject.SetActive(true);
    //        newUnit.UnitSpecialImage.sprite = unit.UnitSpecialImage.sprite;

    //    }
    //}

    private void Centralize(RectTransform rectTransform)
    {
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.localPosition = Vector3.zero;
    }
}
