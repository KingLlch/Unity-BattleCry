using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    public Transform AllItemsParent;
    public GameObject ItemPrefab;

    private void Start()
    {
        SpawnInAllItems();
        SpawnInCreateUnit();
    }

    private void SpawnInCreateUnit()
    {
        foreach (Item race in ItemsList.AllRace)
        {
            ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero, Quaternion.identity, CreateUnit.Instance.RacesGrid).GetComponent<ItemInfo>();
            newItem.ThisItem = race.Copy();
            newItem.ThisItem.Value = race.Value;
            newItem.Value.text = "x" + newItem.ThisItem.Value.ItemValue.ToString();
            newItem.Image.sprite = newItem.ThisItem.Base.Sprite;

            if (race.Value.ItemValue == 0)
            {
                newItem.ImageHide.SetActive(true);
                newItem.Hide = true;
            }

            newItem.ImageEdge.sprite = Resources.Load<Sprite>("Sprites/Rare/" + race.Base.Rare);
            newItem.GetComponent<RectTransform>().localPosition = Vector3.zero;

        }

        foreach (Item item in ItemsList.AllEquipmentItems)
        {
            ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero, Quaternion.identity, CreateUnit.Instance.ItemsGrid).GetComponent<ItemInfo>();
            newItem.ThisItem = item.Copy();
            newItem.ThisItem.Value = item.Value;
            newItem.Value.text = "x" + newItem.ThisItem.Value.ItemValue.ToString();
            newItem.Image.sprite = newItem.ThisItem.Base.Sprite;

            if (item.Value.ItemValue == 0)
            {
                newItem.ImageHide.SetActive(true);
                newItem.Hide = true;
            }

            newItem.ImageEdge.sprite = Resources.Load<Sprite>("Sprites/Rare/" + item.Base.Rare);
            newItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }

    private void SpawnInAllItems()
    {
        foreach (Item item in ItemsList.AllItems)
        {
            ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero, Quaternion.identity, AllItemsParent).GetComponent<ItemInfo>();
            newItem.ThisItem = item.Copy();
            newItem.ThisItem.Value = item.Value;
            newItem.Image.sprite = newItem.ThisItem.Base.Sprite;
            newItem.ImageEdge.sprite = Resources.Load<Sprite>("Sprites/Rare/" + item.Base.Rare);
            newItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }
}
