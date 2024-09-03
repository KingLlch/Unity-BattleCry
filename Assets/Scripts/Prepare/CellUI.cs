using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public int IndexCell;

    public void OnDrop(PointerEventData pointer)
    {
        if (pointer.pointerDrag == null) return;

        PrepareManager.Instance.AddUnitToArmy(pointer.pointerDrag.GetComponent<Unit>(), this);
    }

    public void OnPointerEnter(PointerEventData pointer)
    {

    }

    public void OnPointerExit(PointerEventData pointer)
    {

    }
}
