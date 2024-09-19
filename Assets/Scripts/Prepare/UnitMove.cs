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

    private bool IsShiftPressed;
    private bool IsDragging;
    private PointerEventData currentPointer;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (IsShiftPressed && IsDragging)
        {
            OnDrag(currentPointer);

            if (!Input.GetKey(KeyCode.LeftShift))
            {
                IsShiftPressed = false;

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                transform.SetParent(CurrentParentTransform);
                transform.SetSiblingIndex(StartSiblingIndex);
            }
        }
    }

    public void OnBeginDrag(PointerEventData pointer)
    {
        _offset = transform.position - _mainCamera.ScreenToWorldPoint(new Vector3(pointer.position.x, pointer.position.y, 0));
        if (!IsDraggable) return;

        CurrentParentTransform = transform.parent;
        StartSiblingIndex = transform.GetSiblingIndex();
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(PrepareUIManager.Instance.TopView.transform);
        IsDragging = true;
        PrepareUIManager.Instance.IsDrug = IsDragging;

    }

    public void OnDrag(PointerEventData pointer)
    {
        if (!IsDraggable) return;

        transform.position = (_mainCamera.ScreenToWorldPoint(new Vector3(pointer.position.x + 100, pointer.position.y, 0)) + _offset);

        currentPointer = pointer;

    }

    public void OnEndDrag(PointerEventData pointer)
    {
        if (!IsDraggable) return;

        if (!ThisUnit.IsInArmy && Input.GetKey(KeyCode.LeftShift))
        {
            IsShiftPressed = true;
            PrepareUIManager.Instance.DruggableUnit = pointer.pointerDrag.GetComponent<Unit>();
        }

        else
        {
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
            }

            IsDragging = false;
            PrepareUIManager.Instance.IsDrug = IsDragging;
        }

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
