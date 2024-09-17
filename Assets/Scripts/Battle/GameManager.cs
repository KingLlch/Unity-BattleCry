using System.Collections;
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

                        Unit newUnit = Instantiate(unit, Vector3.zero, Quaternion.identity, PlayerArmyRows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].transform);

                        newUnit.unitCharacteristics = unit.unitCharacteristics;
                        newUnit.UnitMainImage.sprite = unit.UnitMainImage.sprite;
                        newUnit.MainUnitLink = unit;
                        newUnit.Value.gameObject.SetActive(false);
                        newUnit.UnitImageRare.gameObject.SetActive(false);

                        PlayerArmyRows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].GetComponent<CellUI>().unit = newUnit;

                        //Centralize(newUnit.GetComponent<RectTransform>());
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

                        Unit newUnit = Instantiate(unit, Vector3.zero, Quaternion.identity, EnemyArmyRows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].transform);

                        newUnit.unitCharacteristics = unit.unitCharacteristics;
                        newUnit.UnitMainImage.sprite = unit.UnitMainImage.sprite;
                        newUnit.MainUnitLink = unit;
                        newUnit.Value.gameObject.SetActive(false);
                        newUnit.UnitImageRare.gameObject.SetActive(false);

                        EnemyArmyRows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].GetComponent<CellUI>().unit = newUnit;

                        //Centralize(newUnit.GetComponent<RectTransform>());
                        newUnit.IsInArmy = true;
                    }
                }
            }
    }
}
