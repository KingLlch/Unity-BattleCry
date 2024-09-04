using System.Collections;
using System.Collections.Generic;
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

    public GameObject CreateUnitPanel;
    public GameObject TopView;

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

        Unit newUnit = Instantiate(unit,Vector3.zero,Quaternion.identity, Rows[rowIndex].GetComponentInChildren<RowUI>().Columns[columnIndex].GetComponent<ColumnUI>().Cells[unitIndex].transform);

        cell.unit = newUnit;
        unit.cell = cell;

        Centralize(newUnit.GetComponent<RectTransform>());
        newUnit.GetComponent<UnitMove>().IsInArmy = true;
        newUnit.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void CreatenewUnit()
    {
        CreateUnitPanel.SetActive(true);
    }

    public void EditUnit()
    {
        CreateUnitPanel.SetActive(true);
        CreateUnit.Instance.LoadUnit();
    }

    public void DeleteUnit()
    {
        PrepareManager.Instance.DeleteUnit();
    }

    public void VisualRenameArmy()
    {

    }

    public void VisualResetArmy()
    {

    }

    private void Centralize(RectTransform rectTransform)
    {
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.localPosition = Vector3.zero;
    }
}
