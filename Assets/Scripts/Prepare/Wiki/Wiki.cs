using UnityEngine;

public class Wiki : MonoBehaviour
{
    public Transform AllItemsParent;

    public void AllItems()
    {
        int count = 0;

        foreach (Transform item in AllItemsParent)
        {
            item.gameObject.SetActive(true);
            count++;
        }

        ChangeSize(count);
    }

    public void RaceItems()
    {
        int count = 0;

        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Race)
            {
                item.gameObject.SetActive(true);
                count++;
            }
            else
                item.gameObject.SetActive(false);
        }

        ChangeSize(count);
    }

    public void WeaponItems()
    {
        int count = 0;

        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Weapon)
            {
                item.gameObject.SetActive(true);
                count++;
            }
            else
                item.gameObject.SetActive(false);
        }

        ChangeSize(count);
    }

    public void ArmorItems()
    {
        int count = 0;

        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Armor)
            {
                item.gameObject.SetActive(true);
                count++;
            }
            else
                item.gameObject.SetActive(false);
        }

        ChangeSize(count);
    }

    public void ShieldItems()
    {
        int count = 0;

        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Shield)
            {
                item.gameObject.SetActive(true);
                count++;
            }
            else
                item.gameObject.SetActive(false);
        }

        ChangeSize(count);
    }

    public void SpecialItems()
    {
        int count = 0;

        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Special)
            {
                item.gameObject.SetActive(true);
                count++;
            }
            else
                item.gameObject.SetActive(false);
        }

        ChangeSize(count);
    }

    public void ChangeSize(int count)
    {
        int height = Mathf.CeilToInt((float)count / 12) * 100 + (Mathf.CeilToInt((float)count / 12) - 1) * 30 + 30;
        AllItemsParent.GetComponent<RectTransform>().sizeDelta = new Vector2(AllItemsParent.GetComponent<RectTransform>().sizeDelta.x, height);
    }
}
