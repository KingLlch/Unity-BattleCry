using UnityEngine;

public class CreateUnit : MonoBehaviour
{

    private static CreateUnit _instance;

    public static CreateUnit Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CreateUnit>();
            }

            return _instance;
        }
    }

    public Item Race;

    public Item Weapon;
    public Item Armor;
    public Item Shield;
    public Item Special;

    public Unit createUnit;

    public GameObject RacesGrid;
    public GameObject ItemsGrid;

    public GameObject UnitsGrid;

    public GameObject ItemPrefab;
    public GameObject UnitPrefab;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        foreach (Item race in ItemsList.AllRace)
        {
            ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero,Quaternion.identity, RacesGrid.transform).GetComponent<ItemInfo>();
            newItem.ThisItem = race;
        }

        foreach (Item item in ItemsList.AllItems)
        {
            ItemInfo newItem = Instantiate(ItemPrefab, Vector2.zero, Quaternion.identity, RacesGrid.transform).GetComponent<ItemInfo>();
            newItem.ThisItem = item;
        }
    }

    public void CreateNewUnit()
    {
        Unit newUnit = Instantiate(UnitPrefab, Vector2.zero, Quaternion.identity, UnitsGrid.transform).GetComponent<Unit>();
        newUnit = createUnit;
        CloseCreateUnitPanel();
    }

    public void CloseCreateUnitPanel()
    {
        ClearCreateUnit();
        gameObject.SetActive(false);
    }

    public void ClearCreateUnit()
    {
        Race = new Item();

        Weapon = new Item();
        Armor = new Item();
        Shield = new Item();
        Special = new Item();

        createUnit = new Unit();
    }

    public void LoadUnit(Unit loadUnit)
    {
        createUnit = loadUnit;

        Race = loadUnit.unitCharacteristics.Race;

        Weapon = loadUnit.unitCharacteristics.Weapon;
        Armor = loadUnit.unitCharacteristics.Armor;
        Shield = loadUnit.unitCharacteristics.Shield;
        Special = loadUnit.unitCharacteristics.Special;
    }
}
