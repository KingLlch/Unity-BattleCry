using BayatGames.SaveGameFree;
using UnityEngine;
using static UnityEditor.Progress;

public class SaveAndLoad : MonoBehaviour
{
    private static SaveAndLoad _instance;

    public static SaveAndLoad Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveAndLoad>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void SaveAll()
    {
        SaveProgress();
        SaveUnits();
        SaveArmy(PrepareManager.Instance.Army);
        SaveGold(PrepareManager.Instance.Gold);
    }

    public void LoadAll()
    {
        LoadProgress();
        LoadUnits();
        LoadArmy();
        LoadGold();
    }

    private static void SaveUnits()
    {
        int unitCount = 0;
        foreach (Unit unit in PrepareManager.Instance.Units)
        {
            SaveGame.Save<Unit>("Unit" + unitCount, unit);
            unitCount++;
        }

        SaveGame.Save<int>("UnitCount", unitCount);
    }

    public void LoadUnits()
    {
        int unitCount = SaveGame.Load<int>("UnitCount", 0);

        for (int i = 0; i < unitCount; i++)
        {
            Unit loadedUnit = SaveGame.Load<Unit>("Unit" + i);
            PrepareManager.Instance.Units.Add(loadedUnit);
        }
    }

    public void SaveArmy(Army army)
    {
        SaveGame.Save<Army>("Army1", army);
    }

    public void LoadArmy()
    {
        PrepareManager.Instance.Army = SaveGame.Load<Army>("Army1", new Army());
    }

    public void SaveGold(int gold)
    {
        SaveGame.Save<int>("Gold", gold);
    }

    public void LoadGold()
    {
        PrepareManager.Instance.Gold = SaveGame.Load<int>("Gold", 10000);
    }

    public void SaveProgress()
    {
        int itemCount = 0;
        foreach (Item item in ItemsList.AllItems)
        {
            SaveGame.Save<Item>("Item" + itemCount, item);
            itemCount++;
        }

        SaveGame.Save<bool>("IsAddItemsInGame", ItemsList.IsAddItemsInGame);
        SaveGame.Save<int>("ItemCount", itemCount);

        //saveCampaign
    }

    public void LoadProgress()
    {
        int itemCount = SaveGame.Load<int>("ItemCount", 0);

        for (int i = 0; i < itemCount; i++)
        {
            Item loadedItem = SaveGame.Load<Item>("Item" + i);
            ItemsList.AllItems.Add(loadedItem);
        }

        ItemsList.IsAddItemsInGame = SaveGame.Load<bool>("IsAddItemsInGame", false);

        //loadCampaign
    }
}
