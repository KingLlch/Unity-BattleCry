using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PrepareUIManager : MonoBehaviour
{
    private static PrepareUIManager _instance;

    public static PrepareUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PrepareUIManager>();
            }

            return _instance;
        }
    }

    public GameObject CreateUnitPanel;
    public GameObject TopView;

    public Transform UnitParent;
    public TMP_InputField NameArmyInputField;
    public TextMeshProUGUI NameArmy;

    public TextMeshProUGUI ArmyPointsRemaning;
    public TextMeshProUGUI GoldText;

    public List<GameObject> Rows;

    public bool IsDrug;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void AddUnitToArmyUI(Unit unit, CellUI cell)
    {
        int rowIndex = cell.transform.parent.parent.GetComponent<RowUI>().IndexRow;
        int columnIndex = cell.transform.parent.GetComponent<ColumnUI>().IndexColumn;
        int unitIndex = cell.transform.GetComponent<CellUI>().IndexCell;

        Unit newUnit = Instantiate(unit, Vector3.zero, Quaternion.identity, Rows[rowIndex].GetComponentInChildren<RowUI>().Columns[columnIndex].GetComponent<ColumnUI>().Cells[unitIndex].transform);

        newUnit.unitCharacteristics = unit.unitCharacteristics;
        newUnit.UnitMainImage.sprite = unit.UnitMainImage.sprite;
        newUnit.MainUnitLink = unit;

        UnitInArmyUI(newUnit);

        cell.unit = newUnit;

        Centralize(newUnit.GetComponent<RectTransform>());
        newUnit.IsInArmy = true;
        newUnit.GetComponent<CanvasGroup>().blocksRaycasts = true;

        ChangeArmyPoints();
    }

    public void LoadUIArmy(Army army)
    {
        foreach (Row row in army.Rows)
        {
            foreach (Column column in row.Columns)
            {
                foreach (Unit unit in column.Units)
                {
                    Unit newUnit = Instantiate(unit, Vector3.zero, Quaternion.identity, Rows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].transform);

                    newUnit.unitCharacteristics = unit.unitCharacteristics;
                    newUnit.UnitMainImage.sprite = unit.UnitMainImage.sprite;
                    newUnit.MainUnitLink = unit;

                    UnitInArmyUI(newUnit);

                    Rows[army.Rows.IndexOf(row)].GetComponentInChildren<RowUI>().Columns[row.Columns.IndexOf(column)].GetComponent<ColumnUI>().Cells[column.Units.IndexOf(unit)].GetComponent<CellUI>().unit = newUnit;

                    Centralize(newUnit.GetComponent<RectTransform>());
                    newUnit.IsInArmy = true;
                }
            }
        }

        ChangeArmyPoints();
    }

    public void ChangeArmyPoints()
    {
        ArmyPointsRemaning.text = (1000 - PrepareManager.Instance.Army.Points).ToString();
    }

    public void ChangeGold()
    {
        GoldText.text = PrepareManager.Instance.Gold.ToString();
    }

    public void UnitInArmyUI(Unit unit)
    {
        unit.Value.gameObject.SetActive(false);
        unit.UnitImageRare.gameObject.SetActive(false);
    }

    public void CreateNewUnit()
    {
        CreateUnitPanel.SetActive(true);
        CreateUnit.Instance.ChangeValueItems();
        CreateUnit.Instance.IsEditUnit = false;
    }

    public void EditUnit()
    {
        if (PrepareManager.Instance.ChosenUnit == null)
        {
            return;
        }

        CreateUnitPanel.SetActive(true);
        CreateUnit.Instance.ChangeValueItems();
        CreateUnit.Instance.EditUnit(PrepareManager.Instance.ChosenUnit);
        CreateUnit.Instance.IsEditUnit = true;
    }

    public void DeleteUnit()
    {
        if (PrepareManager.Instance.ChosenUnit == null)
            return;

        CreateUnit.Instance.DeleteUnit(PrepareManager.Instance.ChosenUnit);
    }

    public void EnableChangeNameArmy()
    {
        NameArmyInputField.enabled = true;
    }

    public void ChangeNameArmy(string name)
    {
        NameArmy.text = name;
        PrepareManager.Instance.Army.Name = name;
        NameArmyInputField.enabled = false;
    }

    public void ResetArmy()
    {
        foreach (GameObject row in Rows)
        {
            foreach (GameObject column in row.GetComponentInChildren<RowUI>().Columns)
            {
                foreach (GameObject cell in column.GetComponent<ColumnUI>().Cells)
                {
                    if (cell.GetComponent<CellUI>().unit != null)
                    {
                        PrepareManager.Instance.RemoveUnitFromArmy(cell.GetComponent<CellUI>().unit, cell.GetComponent<CellUI>());

                        Destroy(cell.GetComponentInChildren<Unit>().gameObject);
                    }
                }
            }
        }

        ArmyPointsRemaning.text = (1000 - PrepareManager.Instance.Army.Points).ToString();
    }

    private void Centralize(RectTransform rectTransform)
    {
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.localPosition = Vector3.zero;
    }
}
