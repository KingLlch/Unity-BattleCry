using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IPointerClickHandler
{
    public Item ThisItem;
    public bool IsInUnit;

    public TextMeshProUGUI Value;
    public Image Image;
    public Image ImageEdge;

    public bool Hide;
    public GameObject ImageHide;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public ItemInfo Copy()
    {
        ItemInfo copy = (ItemInfo)this.MemberwiseClone(); ;
        copy.ThisItem = ThisItem.Copy();
        return copy;
    }

    public void OnPointerEnter(PointerEventData pointer)
    {
        if(!Hide)
            Description.Instance.ShowDescriptionItem(ThisItem, _mainCamera.ScreenToWorldPoint(new Vector3(pointer.position.x, pointer.position.y, 0)));
    }

    public void OnPointerExit(PointerEventData pointer)
    {
        if (!Hide)
            Description.Instance.HideDescription();
    }

    public void OnPointerMove(PointerEventData pointer)
    {
        if (!Hide)
            Description.Instance.ChangePositionDescription(pointer.position);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsInUnit)
            CreateUnit.Instance.AddItem(this);
        else
            CreateUnit.Instance.RemoveItem(this);
    }
}
