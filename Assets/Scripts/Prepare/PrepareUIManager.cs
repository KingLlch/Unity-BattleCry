using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    public GameObject TopView;

    public Transform UnitParent;
    public TMP_InputField NameArmyInputField;
    public TextMeshProUGUI NameArmy;

    public TextMeshProUGUI ArmyPointsRemaning;
    public TextMeshProUGUI GoldText;

    public List<RowUI> Rows;
    public GameObject UnitPrefab;

    public UnitUI DruggableUnit;
    public bool IsDrug;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void AddUnitToArmyUI(UnitUI unitUI, CellUI cell)
    {
        unitUI.Value.text = unitUI.Unit.Value.ToString();

        int rowIndex = cell.transform.parent.parent.GetComponent<RowUI>().IndexRow;
        int columnIndex = cell.transform.parent.GetComponent<ColumnUI>().IndexColumn;
        int unitIndex = cell.transform.GetComponent<CellUI>().IndexCell;

        UnitUI newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity, Rows[rowIndex].Columns[columnIndex].Cells[unitIndex].transform).GetComponent<UnitUI>();

        newUnit.Unit = unitUI.Unit;
        newUnit.UnitMainImage.sprite = unitUI.Unit.MainSprite;
        newUnit.MainUnitLink = unitUI;

        UnitInArmyUI(newUnit);

        cell.unit = newUnit;

        Centralize(newUnit.GetComponent<RectTransform>());
        newUnit.IsInArmy = true;
        newUnit.GetComponent<CanvasGroup>().blocksRaycasts = true;

        ChangeArmyPoints();
    }

    public void LoadUIArmy(Army army)
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

                    UnitUI newUnit = Instantiate(UnitPrefab, Vector3.zero, Quaternion.identity, Rows[rowIndex].Columns[columnIndex].Cells[unitIndex].transform).GetComponent<UnitUI>();

                    newUnit.Unit = unit;
                    newUnit.UnitMainImage.sprite = unit.MainSprite;
                    //newUnit.MainUnitLink = unit;

                    UnitInArmyUI(newUnit);

                    Rows[rowIndex].Columns[columnIndex].Cells[unitIndex].unit = newUnit;

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

    public void UnitInArmyUI(UnitUI unit)
    {
        unit.Value.gameObject.SetActive(false);
        unit.UnitChosenImage.gameObject.SetActive(false);

        unit.ActiveUI();
    }

    public void CreateNewUnit()
    {
        CreateUnit.Instance.Enable();
        CreateUnit.Instance.IsEditUnit = false;
    }

    public void EditUnit()
    {
        if (PrepareManager.Instance.ChosenUnit == null)
        {
            return;
        }

        CreateUnit.Instance.Enable();
        CreateUnit.Instance.EditUnit(PrepareManager.Instance.ChosenUnit);
        CreateUnit.Instance.IsEditUnit = true;
    }

    public void DeleteUnit()
    {
        if (PrepareManager.Instance.ChosenUnit == null)
            return;

        CreateUnit.Instance.DeleteUnit(PrepareManager.Instance.ChosenUnit);
    }

    public void ChangeNameArmy()
    {
        NameArmy.text = NameArmyInputField.text;
        PrepareManager.Instance.Army.Name = NameArmyInputField.text;
    }

    public void ResetArmy()
    {
        foreach (RowUI row in Rows)
        {
            foreach (ColumnUI column in row.Columns)
            {
                foreach (CellUI cell in column.Cells)
                {
                    if (cell.unit != null)
                    {
                        PrepareManager.Instance.RemoveUnitFromArmy(cell.unit, cell);
                    }
                }
            }
        }

        ArmyPointsRemaning.text = (1000 - PrepareManager.Instance.Army.Points).ToString();
    }

    public void UnitParentChangeSize()
    {
        int height = UnitParent.childCount * 150 + (UnitParent.childCount - 1) * 30 + 70;
        if (height < 1920)
            height = 1920;

        UnitParent.GetComponent<RectTransform>().sizeDelta = new Vector2(height, UnitParent.GetComponent<RectTransform>().sizeDelta.y);
    }

    private void Centralize(RectTransform rectTransform)
    {
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.localPosition = Vector3.zero;
    }
}
