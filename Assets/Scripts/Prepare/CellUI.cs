using UnityEngine;
using UnityEngine.EventSystems;

public class CellUI : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public int IndexCell;
    public Unit unit;

    public void OnDrop(PointerEventData pointer)
    {
        if (pointer.pointerDrag == null && !pointer.pointerDrag.GetComponent<Unit>())
            return;

        AddUnitInCell(pointer.pointerDrag.GetComponent<Unit>());
    }

    public void OnPointerClick(PointerEventData pointer)
    {
        if (PrepareUIManager.Instance.DruggableUnit == null)
            return;

        AddUnitInCell(PrepareUIManager.Instance.DruggableUnit);
    }

    private void AddUnitInCell(Unit addUnit)
    {
        if ((addUnit.unitCharacteristics.Points < (1000 - PrepareManager.Instance.Army.Points)) && (addUnit.unitCharacteristics.Value > 0 || addUnit.IsInArmy == true) && (unit == null || unit.unitCharacteristics.Name != addUnit.unitCharacteristics.Name))
        {
            if (unit != null)
            {
                PrepareManager.Instance.RemoveUnitFromArmy(addUnit, this);
            }

            PrepareManager.Instance.AddUnitToArmy(addUnit, this);
            PrepareUIManager.Instance.AddUnitToArmyUI(addUnit, this);
        }
    }
}
