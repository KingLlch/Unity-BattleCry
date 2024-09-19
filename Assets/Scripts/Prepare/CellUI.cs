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
        Unit dropUnit = addUnit;

        if ((dropUnit.unitCharacteristics.Points < (1000 - PrepareManager.Instance.Army.Points)) && (dropUnit.unitCharacteristics.Value > 0 || dropUnit.IsInArmy == true) && (addUnit == null || unit.unitCharacteristics.Name != dropUnit.unitCharacteristics.Name))
        {
            if (addUnit != null)
            {
                PrepareManager.Instance.RemoveUnitFromArmy(addUnit, this);
            }

            PrepareManager.Instance.AddUnitToArmy(addUnit, this);
            PrepareUIManager.Instance.AddUnitToArmyUI(addUnit, this);
        }
    }
}
