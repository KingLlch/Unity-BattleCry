using UnityEngine;
using UnityEngine.EventSystems;

public class CellUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public int IndexCell;
    public Unit unit;

    public void OnDrop(PointerEventData pointer)
    {
        if (pointer.pointerDrag == null) return;

        Unit dropUnit = pointer.pointerDrag.GetComponent<Unit>();

        if ((dropUnit.unitCharacteristics.Points < (1000 - PrepareManager.Instance.Army.Points)) && (dropUnit.unitCharacteristics.Value > 0) && (unit == null || unit.unitCharacteristics.Name != dropUnit.unitCharacteristics.Name))
        {
            PrepareManager.Instance.AddUnitToArmy(pointer.pointerDrag.GetComponent<Unit>(), this);
            PrepareUIManager.Instance.AddUnitToArmyUI(pointer.pointerDrag.GetComponent<Unit>(), this);
        }

        else
        {

        }
    }

    public void OnPointerEnter(PointerEventData pointer)
    {

    }

    public void OnPointerExit(PointerEventData pointer)
    {

    }
}
