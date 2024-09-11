using UnityEngine;

public class Wiki : MonoBehaviour
{
    public Transform AllItemsParent;

    public void AllItems()
    {
        foreach (Transform item in AllItemsParent)
        {
            item.gameObject.SetActive(true);
        }
    }

    public void RaceItems()
    {
        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Race)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }

    public void WeaponItems()
    {
        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Weapon)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }

    public void ArmorItems()
    {
        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Armor)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }

    public void ShieldItems()
    {
        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Shield)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }

    public void SpecialItems()
    {
        foreach (Transform item in AllItemsParent)
        {
            if (item.GetComponent<ItemInfo>().ThisItem.Base.Type == ItemType.Special)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }
}
