using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public int IndexCell;
    public Unit unit;

    public void OnDrop(PointerEventData pointer)
    {
        if (pointer.pointerDrag == null) return;

        if(unit != pointer.pointerDrag.GetComponent<Unit>())
        {
            PrepareManager.Instance.AddUnitToArmy(pointer.pointerDrag.GetComponent<Unit>(), this);
            PrepareUIManager.Instance.AddUnitToArmyUI(pointer.pointerDrag.GetComponent<Unit>(), this);
        }
    }

    public void OnPointerEnter(PointerEventData pointer)
    {

    }

    public void OnPointerExit(PointerEventData pointer)
    {

    }
}
