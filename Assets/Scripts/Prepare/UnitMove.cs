using UnityEngine;
using UnityEngine.EventSystems;

public class UnitMove : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IPointerClickHandler
{
    public bool IsDraggable = true;
    public Unit ThisUnit;

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
        transform.SetParent(PrepareUIManager.Instance.TopView.transform);
        PrepareUIManager.Instance.IsDrug = true;
    }

    public void OnDrag(PointerEventData pointer)
    {
        if (!IsDraggable) return;

        transform.position = (_mainCamera.ScreenToWorldPoint(new Vector3(pointer.position.x + 100, pointer.position.y, 0)) + _offset);
    }

    public void OnEndDrag(PointerEventData pointer)
    {
        if (!IsDraggable) return;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (!ThisUnit.IsInArmy)
        {
            transform.SetParent(CurrentParentTransform);
            transform.SetSiblingIndex(StartSiblingIndex);
        }

        else
        {
            PrepareManager.Instance.RemoveUnitFromArmy(ThisUnit, CurrentParentTransform.GetComponent<CellUI>());
            PrepareUIManager.Instance.ChangeArmyPoints();
            CurrentParentTransform.GetComponent<CellUI>().unit = null;
            Destroy(gameObject);
        }

        PrepareUIManager.Instance.IsDrug = false;
    }

    public void OnPointerEnter(PointerEventData pointer)
    {
        Description.Instance.ShowDescriptionUnit(transform.GetComponent<Unit>(), _mainCamera.ScreenToWorldPoint(new Vector3(pointer.position.x, pointer.position.y, 0)));
    }

    public void OnPointerExit(PointerEventData pointer)
    {
        Description.Instance.HideDescription();
    }

    public void OnPointerMove(PointerEventData pointer)
    {
        Description.Instance.ChangePositionDescription(pointer.position);
    }

    public void OnPointerClick(PointerEventData pointer)
    {
        if (PrepareManager.Instance.ChosenUnit == ThisUnit)
        {
            PrepareManager.Instance.ChoseUnit(null);
        }
        else
            PrepareManager.Instance.ChoseUnit(ThisUnit);
    }
}
