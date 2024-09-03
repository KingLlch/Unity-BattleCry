using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitMove : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool IsDraggable;

    private Camera _mainCamera;
    private Vector3 _offset;

    private Transform CurrentParentTransform;
    private int StartSiblingIndex;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData pointer)
    {
        _offset = transform.position - _mainCamera.ScreenToWorldPoint(new Vector3(pointer.position.x, pointer.position.y, 0));
        if (!IsDraggable) return;

        CurrentParentTransform = transform.parent;
        StartSiblingIndex = transform.GetSiblingIndex();
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData pointer)
    {
        if (!IsDraggable) return;

        transform.position = (_mainCamera.ScreenToWorldPoint(new Vector3(pointer.position.x, pointer.position.y, 0)) + _offset);
    }

    public void OnEndDrag(PointerEventData pointer)
    {
        if (!IsDraggable) return;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (!pointer.pointerCurrentRaycast.gameObject.GetComponent<Cell>())
        {
            transform.SetParent(CurrentParentTransform);
            transform.SetSiblingIndex(StartSiblingIndex);
        }
    }
}
