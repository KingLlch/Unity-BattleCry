using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;

    private void Start()
    {

        foreach (Item race in ItemsList.AllRace)
        {
            ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero, Quaternion.identity, CreateUnit.Instance.RacesGrid).GetComponent<ItemInfo>();
            newItem.ThisItem = race;
            newItem.Value.text = "x" + race.Value.ToString();
            newItem.Image.sprite = race.Base.Sprite;
            newItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        foreach (Item item in ItemsList.AllItems)
        {
            ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero, Quaternion.identity, CreateUnit.Instance.ItemsGrid).GetComponent<ItemInfo>();
            newItem.ThisItem = item;
            newItem.Value.text = "x" + item.Value.ToString();
            newItem.Image.sprite = item.Base.Sprite;
            newItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }
}
