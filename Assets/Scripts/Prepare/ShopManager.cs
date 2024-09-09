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

    public void BuyBooster(BusterItems items,int cost)
    {
        if (PrepareManager.Instance.Gold > cost)
        {
            PrepareManager.Instance.Gold -= cost;
            PrepareUIManager.Instance.ChangeGold();

            RandomItems(items);
        }

        else
        {
            return;
        }
    }

    public void RandomItems(BusterItems items)
    {
        for (int i = 0; i < items.CommonItemCount; i+=10)
        {        
            ItemsList.AllCommonItem[Random.Range(0, ItemsList.AllCommonItem.Count)].Base.Value += 10;
            AddItem(ItemsList.AllCommonItem[Random.Range(0, ItemsList.AllCommonItem.Count)], 10);
        }

        for (int i = 0; i < items.UncommonItemCount; i+=5)
        {
            ItemsList.AllUncommonItem[Random.Range(0, ItemsList.AllUncommonItem.Count)].Base.Value+= 5;
            AddItem(ItemsList.AllUncommonItem[Random.Range(0, ItemsList.AllUncommonItem.Count)], 5);
        }

        for (int i = 0; i < items.RareItemCount; i++)
        {
            ItemsList.AllRareItem[Random.Range(0, ItemsList.AllRareItem.Count)].Base.Value+= 1;
            AddItem(ItemsList.AllRareItem[Random.Range(0, ItemsList.AllRareItem.Count)], 1);
        }

        for (int i = 0; i < items.EpicItemCount; i++)
        {
            ItemsList.AllEpicItem[Random.Range(0, ItemsList.AllEpicItem.Count)].Base.Value+= 1;
            AddItem(ItemsList.AllEpicItem[Random.Range(0, ItemsList.AllEpicItem.Count)], 1);
        }

        for (int i = 0; i < items.LegendaryItemCount; i++)
        {
            ItemsList.AllLegendaryItem[Random.Range(0, ItemsList.AllLegendaryItem.Count)].Base.Value+= 1;
            AddItem(ItemsList.AllLegendaryItem[Random.Range(0, ItemsList.AllLegendaryItem.Count)], 1);
        }

        for (int i = 0; i < items.MythicalItemCount; i++)
        {
            ItemsList.AllMythicalItem[Random.Range(0, ItemsList.AllMythicalItem.Count)].Base.Value+= 1;
            AddItem(ItemsList.AllMythicalItem[Random.Range(0, ItemsList.AllMythicalItem.Count)], 1);
        }

    }

    public void AddItem(Item item, int value)
    {
        AddItemsPanel.gameObject.SetActive(true);

        ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero,Quaternion.identity, AddItemsPanel.ItemsParent).GetComponent<ItemInfo>();
        newItem.ThisItem = item;
        newItem.Image.sprite = item.Base.Sprite;
        newItem.Value.text = (value).ToString();
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
