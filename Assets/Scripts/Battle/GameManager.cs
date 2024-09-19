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
            foreach (Row row in army.Rows)
            {
                foreach (Column column in row.Columns)
                {
                    foreach (Unit unit in column.Units)
                    {
                        if (unit == null)
                            continue;

                        Unit newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity, PlayerArmyRows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].transform).GetComponent<Unit>();

                        newUnit.GetComponent<UnitMove>().IsDraggable = false;
                        LoadUnit(newUnit, unit);

                        PlayerArmyRows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].GetComponent<CellUI>().unit = newUnit;

                        Centralize(newUnit.GetComponent<RectTransform>());
                        newUnit.IsInArmy = true;
                    }
                }
            }

        else
            foreach (Row row in army.Rows)
            {
                foreach (Column column in row.Columns)
                {
                    foreach (Unit unit in column.Units)
                    {
                        if (unit == null)
                            continue;

                        Unit newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity, EnemyArmyRows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].transform).GetComponent<Unit>();

                        newUnit.GetComponent<UnitMove>().IsDraggable = false;
                        LoadUnit(newUnit, unit);

                        EnemyArmyRows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].GetComponent<CellUI>().unit = newUnit;

                        Centralize(newUnit.GetComponent<RectTransform>());
                        newUnit.IsInArmy = true;
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
        newUnit.UnitImageRare.gameObject.SetActive(false);

        ShowUnit(newUnit, unit);
    }

    private void ShowUnit(Unit newUnit, Unit unit)
    {
        if (newUnit.unitCharacteristics.Race != null)
        {
            newUnit.UnitMainImage.gameObject.SetActive(true);
            newUnit.UnitMainImage.sprite = unit.UnitMainImage.sprite;
            newUnit.UnitRaceImage.gameObject.SetActive(true);
            newUnit.UnitRaceImage.sprite = unit.UnitRaceImage.sprite;
        }
        if (newUnit.unitCharacteristics.Weapon != null)
        {
            newUnit.UnitWeaponImage.gameObject.SetActive(true);
            newUnit.UnitWeaponImage.sprite = unit.UnitWeaponImage.sprite;

        }
        if (newUnit.unitCharacteristics.Armor != null)
        {
            newUnit.UnitArmorImage.gameObject.SetActive(true);
            newUnit.UnitArmorImage.sprite = unit.UnitArmorImage.sprite;

        }
        if (newUnit.unitCharacteristics.Shield != null)
        {
            newUnit.UnitShieldImage.gameObject.SetActive(true);
            newUnit.UnitShieldImage.sprite = unit.UnitShieldImage.sprite;

        }
        if (newUnit.unitCharacteristics.Special != null)
        {
            newUnit.UnitSpecialImage.gameObject.SetActive(true);
            newUnit.UnitSpecialImage.sprite = unit.UnitSpecialImage.sprite;

        }
    }

    private void Centralize(RectTransform rectTransform)
    {
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.localPosition = Vector3.zero;
    }
}
