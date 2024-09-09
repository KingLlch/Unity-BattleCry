using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;

    private void Start()
    {
        foreach (Item race in ItemsList.AllRace)
        {
            Debug.Log(CreateUnit.Instance.RacesGrid);
            ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero, Quaternion.identity, CreateUnit.Instance.RacesGrid).GetComponent<ItemInfo>();
            newItem.ThisItem = race.Copy();
            newItem.Value.text = "x" + newItem.ThisItem.Base.Value.ToString();
            newItem.Image.sprite = newItem.ThisItem.Base.Sprite;
            newItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        foreach (Item item in ItemsList.AllEquipmentItems)
        {
            ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero, Quaternion.identity, CreateUnit.Instance.ItemsGrid).GetComponent<ItemInfo>();
            newItem.ThisItem = item.Copy();
            newItem.Value.text = "x" + newItem.ThisItem.Base.Value.ToString();
            newItem.Image.sprite = newItem.ThisItem.Base.Sprite;
            newItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }
}
