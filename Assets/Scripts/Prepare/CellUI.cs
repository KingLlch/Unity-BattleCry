using UnityEngine;
using UnityEngine.EventSystems;

public class CellUI : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public int IndexCell;
    public UnitUI unit;

    public void OnDrop(PointerEventData pointer)
    {
        if (pointer.pointerDrag == null && !pointer.pointerDrag.GetComponent<UnitUI>())
            return;

        AddUnitInCell(pointer.pointerDrag.GetComponent<UnitUI>());
    }

    public void OnPointerClick(PointerEventData pointer)
    {
        if (FindAnyObjectByType<PrepareUIManager>() == null)
            return;

        if (PrepareUIManager.Instance.DruggableUnit == null)
            return;

        AddUnitInCell(PrepareUIManager.Instance.DruggableUnit);
    }

    private void AddUnitInCell(UnitUI addUnit)
    {
        if ((addUnit.Unit.Points < (1000 - PrepareManager.Instance.Army.Points)) && (addUnit.Unit.Value > 0 || addUnit.IsInArmy == true) && (unit == null || unit.Unit.Name != addUnit.Unit.Name))
        {
            if (unit != null)
            {
                PrepareManager.Instance.RemoveUnitFromArmy(addUnit, this);
            }

            PrepareManager.Instance.AddUnitToArmy(addUnit.Unit, this);
            PrepareUIManager.Instance.AddUnitToArmyUI(addUnit, this);
        }
    }
}
