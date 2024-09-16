using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private static ShopManager _instance;

    public static ShopManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ShopManager>();
            }

            return _instance;
        }
    }

    public AddItemPanel AddItemsPanel;

    public GameObject ItemPrefab;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void BuyBooster(BusterItems items, int cost)
    {
        if (PrepareManager.Instance.Gold >= cost)
        {
            PrepareManager.Instance.Gold -= cost;
            PrepareUIManager.Instance.ChangeGold();

            RandomItems(items);

            SaveAndLoad.Instance.SaveGold(PrepareManager.Instance.Gold);
        }

        else
        {
            return;
        }
    }

    public void RandomItems(BusterItems items)
    {
        for (int i = 0; i < items.CommonItemCount; i += 10)
        {
            ItemsList.AllCommonItem[Random.Range(0, ItemsList.AllCommonItem.Count)].Value.ItemValue += 10;
            AddItem(ItemsList.AllCommonItem[Random.Range(0, ItemsList.AllCommonItem.Count)], 10);
        }

        for (int i = 0; i < items.UncommonItemCount; i += 5)
        {
            ItemsList.AllUncommonItem[Random.Range(0, ItemsList.AllUncommonItem.Count)].Value.ItemValue += 5;
            AddItem(ItemsList.AllUncommonItem[Random.Range(0, ItemsList.AllUncommonItem.Count)], 5);
        }

        for (int i = 0; i < items.RareItemCount; i++)
        {
            ItemsList.AllRareItem[Random.Range(0, ItemsList.AllRareItem.Count)].Value.ItemValue += 1;
            AddItem(ItemsList.AllRareItem[Random.Range(0, ItemsList.AllRareItem.Count)], 1);
        }

        for (int i = 0; i < items.EpicItemCount; i++)
        {
            ItemsList.AllEpicItem[Random.Range(0, ItemsList.AllEpicItem.Count)].Value.ItemValue += 1;
            AddItem(ItemsList.AllEpicItem[Random.Range(0, ItemsList.AllEpicItem.Count)], 1);
        }

        for (int i = 0; i < items.LegendaryItemCount; i++)
        {
            ItemsList.AllLegendaryItem[Random.Range(0, ItemsList.AllLegendaryItem.Count)].Value.ItemValue += 1;
            AddItem(ItemsList.AllLegendaryItem[Random.Range(0, ItemsList.AllLegendaryItem.Count)], 1);
        }

        for (int i = 0; i < items.MythicalItemCount; i++)
        {
            ItemsList.AllMythicalItem[Random.Range(0, ItemsList.AllMythicalItem.Count)].Value.ItemValue += 1;
            AddItem(ItemsList.AllMythicalItem[Random.Range(0, ItemsList.AllMythicalItem.Count)], 1);
        }

    }

    public void AddItem(Item item, int value)
    {
        AddItemsPanel.gameObject.SetActive(true);

        ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero, Quaternion.identity, AddItemsPanel.ItemsParent).GetComponent<ItemInfo>();
        newItem.ThisItem = item;
        newItem.Image.sprite = item.Base.ItemUISprite;
        newItem.ImageEdge.sprite = Resources.Load<Sprite>("Sprites/Rare/" + item.Base.Rare);
        newItem.Value.text = (value).ToString();

        int height = Mathf.CeilToInt((float)AddItemsPanel.ItemsParent.childCount / 6) * 100 + (Mathf.CeilToInt((float)AddItemsPanel.ItemsParent.childCount / 6) - 1) * 15 + 30;
        AddItemsPanel.ItemsParent.GetComponent<RectTransform>().sizeDelta = new Vector2(AddItemsPanel.ItemsParent.GetComponent<RectTransform>().sizeDelta.x, height);

        Centralize(newItem.GetComponent<RectTransform>());
    }

    public void CloseAddItemPanel()
    {
        AddItemsPanel.gameObject.SetActive(false);
        DestroyAllChildren(AddItemsPanel.ItemsParent.gameObject);
    }

    private void DestroyAllChildren(GameObject parent)
    {
        for (int i = parent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.transform.GetChild(i).gameObject);
        }
    }

    private void Centralize(RectTransform rectTransform)
    {
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.localPosition = Vector3.zero;
    }
}

public class BusterItems
{
    public int CommonItemCount;
    public int UncommonItemCount;
    public int RareItemCount;
    public int EpicItemCount;
    public int LegendaryItemCount;
    public int MythicalItemCount;
}
